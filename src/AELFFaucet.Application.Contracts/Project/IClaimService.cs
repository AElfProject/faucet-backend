using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AELFFaucet.Project;

public interface IClaimService: IApplicationService
{
    Task<MessageResult> ClaimTokenAsync(string walletAddress);
    Task<MessageResult> ClaimSeedAsync(string walletAddress);
    Task<MessageResult> ClaimNFTSeedAsync(string walletAddress);
}