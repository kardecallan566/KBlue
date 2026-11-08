using KBlue.Core.Abstractions;
using KBlue.Core.Models;
namespace KBlue.Discovery;

public sealed class DiscoveryEngine(IEnumerable<IDeviceDiscoveryProvider> providers)
{
    private readonly IReadOnlyList<IDeviceDiscoveryProvider> _providers = providers.ToArray();

    public async Task<IReadOnlyList<DiscoveredDevice>> DiscoverAsync(CancellationToken cancellationToken = default)
    {
        var results = new List<DiscoveredDevice>();
        foreach (var provider in _providers)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try { results.AddRange(await provider.DiscoverAsync(cancellationToken)); }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { throw; }
            catch { /* Isola falhas por protocolo para não interromper os demais provedores. */ }
        }
        return results.GroupBy(d => $"{d.Protocol}:{d.Id}", StringComparer.OrdinalIgnoreCase)
            .Select(g => g.OrderByDescending(d => d.LastSeenAt).First()).OrderBy(d => d.Name).ToArray();
    }
}
