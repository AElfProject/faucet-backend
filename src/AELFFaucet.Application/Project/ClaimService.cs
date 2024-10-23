using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace AELFFaucet.Project;

public class ClaimService : AELFFaucetAppService, IClaimService
{
    private readonly ISendTokenInfoRepository _sendTokenInfoRepository;
    private readonly ITokenSendContractService _otherTokenSendContractService;
    private readonly ITokenSendContractService _nftSeedTokenSendContractService;
    private readonly ApiConfigOptions _apiConfig;
    public ClaimService(ISendTokenInfoRepository sendTokenInfoRepository,
                        OtherTokenSendContractService otherTokenSendContractService,
                        NftSeedTokenSendContractService nftSeedTokenSendContractService,
                         IOptions<ApiConfigOptions> apiConfig)
    {
        _sendTokenInfoRepository = sendTokenInfoRepository;
        _otherTokenSendContractService = otherTokenSendContractService;
        _nftSeedTokenSendContractService = nftSeedTokenSendContractService;
        _apiConfig = apiConfig.Value;
    }

    // Method to retrieve the reCAPTCHA secret key based on the platform
    private string GetRecaptchaSecretKey(string platform)
    {
        return platform switch
        {
            "FaucetUI" => _apiConfig.FaucetUI,
            "PlaygroundStaging" => _apiConfig.PlaygroundStaging,
            "PlaygroundProduction" => _apiConfig.PlaygroundProduction,
            "AelfStudio" => _apiConfig.AelfStudio,
            _ => null
        };
    }

    private async Task<bool> VerifyRecaptchaAsync(string recaptchaToken, string secretKey)
    {
        var url = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaToken}";

        using (var client = new HttpClient())
        {
            var response = await client.PostAsync(url, null);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var captchaResponse = JsonSerializer.Deserialize<CaptchaResponse>(jsonResult);

            return captchaResponse.success;
        }
    }

    public class CaptchaResponse
    {
        public bool success { get; set; }
    }

    [Route("api/claim")]
    public async Task<MessageResult> ClaimTokenAsync(string walletAddress, string recaptchaToken, [FromHeader(Name = "Platform")] string platform)
    {
        var messageResult = new MessageResult();

        if (string.IsNullOrEmpty(walletAddress))
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidAddress);
            messageResult.Message = "Incorrect address format.";
            return messageResult;
        }

        // Verify reCAPTCHA token here based on platform
        var secretKey = GetRecaptchaSecretKey(platform);
        if (string.IsNullOrEmpty(secretKey))
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidPlatform);
            messageResult.Message = "Invalid platform specified.";
            return messageResult;
        }

        // Verify reCAPTCHA token here
        var isCaptchaValid = await VerifyRecaptchaAsync(recaptchaToken, secretKey);

        if (!isCaptchaValid)
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidCaptcha);
            messageResult.Message = "Invalid reCAPTCHA verification.";
            return messageResult;
        }

        // Existing code
        var chainType = ChainType.Mainchain;
        if (walletAddress.Contains("ELF_"))
        {
            if (walletAddress.Split('_')[2] != "AELF")
            {
                chainType = ChainType.Sidechain;
            }

            walletAddress = walletAddress.Split('_')[1];
        }

        // Rest of your existing code...
        var gotTokenBefore = await _sendTokenInfoRepository.GetAsync(walletAddress.ToLower());
        if (gotTokenBefore is { IsSentToken: true })
        {
            messageResult.IsSuccess = false;
            messageResult.Message = $"You have received the test tokens and cannot receive it again";
            messageResult.Code = Convert.ToInt32(CodeStatus.HadReceived);
            return messageResult;
        }

        var checkBalanceMessageResult = await _otherTokenSendContractService.CheckBalanceAsync(chainType);
        if (!checkBalanceMessageResult.IsSuccess)
        {
            return checkBalanceMessageResult;
        }

        var sendTokenMessageResult = await _otherTokenSendContractService.SendTokensAsync(walletAddress, chainType);
        if (!sendTokenMessageResult.IsSuccess)
        {
            return sendTokenMessageResult;
        }

        messageResult.Message = sendTokenMessageResult.Message;

        try
        {
            SendTokenInfo result;
            var sendTokenInfo = await _sendTokenInfoRepository.GetAsync(walletAddress.ToLower());
            if (sendTokenInfo == null)
            {
                sendTokenInfo = new SendTokenInfo
                {
                    WalletAddress = walletAddress,
                };
                sendTokenInfo.SetId(walletAddress);
                result = await _sendTokenInfoRepository.InsertAsync(sendTokenInfo);
            }
            else
            {
                sendTokenInfo.IsSentToken = true;
                result = await _sendTokenInfoRepository.UpdateAsync(sendTokenInfo);
            }

            if (result == null)
            {
                messageResult.IsSuccess = false;
                messageResult.Message = $"System error: Failed to insert send token info.";
                messageResult.Code = Convert.ToInt32(CodeStatus.SystemError);
            }
        }
        catch (Exception ex)
        {
            messageResult.IsSuccess = false;
            messageResult.Message = $"System error: {ex.Message}";
            messageResult.Code = Convert.ToInt32(CodeStatus.SystemError);
        }

        return messageResult;
    }

    [HttpPost("api/claim-seed")]
    public async Task<MessageResult> ClaimNFTSeedAsync(string walletAddress, string recaptchaToken, [FromHeader(Name = "Platform")] string platform)
    {
        var messageResult = new MessageResult();

        // Verify reCAPTCHA token here based on platform
        var secretKey = GetRecaptchaSecretKey(platform);
        if (string.IsNullOrEmpty(secretKey))
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidPlatform);
            messageResult.Message = "Invalid platform specified.";
            return messageResult;
        }
        // Verify reCAPTCHA token here
        var isCaptchaValid = await VerifyRecaptchaAsync(recaptchaToken, secretKey);

        if (!isCaptchaValid)
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidCaptcha);
            messageResult.Message = "Invalid reCAPTCHA verification.";
            return messageResult;
        }

        return await ClaimSeedAsync(walletAddress, _otherTokenSendContractService, tokenInfo => tokenInfo.IsSentSeed, (tokenInfo, isSent) => tokenInfo.IsSentSeed = isSent);
    }

    [HttpPost("api/claim-nft-seed")]
    public async Task<MessageResult> ClaimSeedAsync(string walletAddress, string recaptchaToken, [FromHeader(Name = "Platform")] string platform)
    {
        var messageResult = new MessageResult();

        // Verify reCAPTCHA token here based on platform
        var secretKey = GetRecaptchaSecretKey(platform);
        if (string.IsNullOrEmpty(secretKey))
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidPlatform);
            messageResult.Message = "Invalid platform specified.";
            return messageResult;
        }
        // Verify reCAPTCHA token here
        var isCaptchaValid = await VerifyRecaptchaAsync(recaptchaToken, secretKey);

        if (!isCaptchaValid)
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.InvalidCaptcha);
            messageResult.Message = "Invalid reCAPTCHA verification.";
            return messageResult;
        }

        return await ClaimSeedAsync(walletAddress, _nftSeedTokenSendContractService, tokenInfo => tokenInfo.IsSentNftSeed, (tokenInfo, isSent) => tokenInfo.IsSentNftSeed = isSent);
    }

    private async Task<MessageResult> ClaimSeedAsync(string walletAddress,
                                                     ITokenSendContractService tokenSendContractService,
                                                     Func<SendTokenInfo, bool> isSentCheck,
                                                     Action<SendTokenInfo, bool> setIsSent)
    {
        var messageResult = new MessageResult();

        var balanceSymbols = await tokenSendContractService.GetBalanceSymbols();
        var seedTokenSymbol = balanceSymbols.FirstOrDefault(s => s.Contains("SEED"));
        if (seedTokenSymbol == null)
        {
            messageResult.IsSuccess = false;
            messageResult.Code = Convert.ToInt32(CodeStatus.SystemError);
            messageResult.Message = "Failed to get seed token.";
            return messageResult;
        }

        var gotTokenBefore = await _sendTokenInfoRepository.GetAsync(walletAddress.ToLower());
        if (gotTokenBefore != null && isSentCheck(gotTokenBefore))
        {
            messageResult.IsSuccess = false;
            messageResult.Message = "You have received the seed and cannot receive it again.";
            messageResult.Code = Convert.ToInt32(CodeStatus.HadReceived);
            return messageResult;
        }

        var sendTokenMessageResult = await tokenSendContractService.SendSeedAsync(walletAddress, seedTokenSymbol);
        if (!sendTokenMessageResult.IsSuccess)
        {
            return sendTokenMessageResult;
        }

        try
        {
            SendTokenInfo result;
            var sendTokenInfo = await _sendTokenInfoRepository.GetAsync(walletAddress.ToLower());
            if (sendTokenInfo == null)
            {
                sendTokenInfo = new SendTokenInfo
                {
                    WalletAddress = walletAddress
                };
                setIsSent(sendTokenInfo, true);
                sendTokenInfo.SetId(walletAddress);
                result = await _sendTokenInfoRepository.InsertAsync(sendTokenInfo);
            }
            else
            {
                setIsSent(sendTokenInfo, true);
                result = await _sendTokenInfoRepository.UpdateAsync(sendTokenInfo);
            }

            if (result == null)
            {
                messageResult.IsSuccess = false;
                messageResult.Message = "System error: Failed to insert send token info.";
                messageResult.Code = Convert.ToInt32(CodeStatus.SystemError);
            }
        }
        catch (Exception ex)
        {
            messageResult.IsSuccess = false;
            messageResult.Message = $"System error: {ex.Message}";
            messageResult.Code = Convert.ToInt32(CodeStatus.SystemError);
        }

        messageResult.Message = sendTokenMessageResult.Message;

        return messageResult;
    }

    public Task<MessageResult> ClaimTokenAsync(string walletAddress)
    {
        throw new NotImplementedException();
    }

    public Task<MessageResult> ClaimSeedAsync(string walletAddress)
    {
        throw new NotImplementedException();
    }

    public Task<MessageResult> ClaimNFTSeedAsync(string walletAddress)
    {
        throw new NotImplementedException();
    }
}
