using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AELFFaucet.Project;

public interface IClaimService: IApplicationService
{
    Task<MessageResult> ClaimTokenAsync(string walletAddress, string recaptchaToken, string platform);
    Task<MessageResult> ClaimSeedAsync(string walletAddress, string recaptchaToken, string platform);
    Task<MessageResult> ClaimNFTSeedAsync(string walletAddress, string recaptchaToken, string platform);
}