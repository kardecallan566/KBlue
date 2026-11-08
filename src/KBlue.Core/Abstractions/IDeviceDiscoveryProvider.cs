using KBlue.Core.Models;
namespace KBlue.Core.Abstractions;

public interface IDeviceDiscoveryProvider
{
    string ProviderId { get; }
    DeviceProtocol Protocol { get; }
    Task<IReadOnlyCollection<DiscoveredDevice>> DiscoverAsync(CancellationToken cancellationToken = default);
}
