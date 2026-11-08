namespace KBlue.Core.Models;

public enum DeviceProtocol { Unknown, BluetoothClassic, BluetoothLe, Wifi, WifiDirect, Mdns, Ssdp, Tcp, Udp }
public enum DeviceStatus { Discovered, Paired, Connected, Unavailable, RequiresAuthorization }

public sealed record DiscoveredDevice
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required DeviceProtocol Protocol { get; init; }
    public string? Address { get; init; }
    public int? SignalStrength { get; init; }
    public DeviceStatus Status { get; init; } = DeviceStatus.Discovered;
    public IReadOnlyList<string> Services { get; init; } = [];
    public DateTimeOffset FirstSeenAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastSeenAt { get; init; } = DateTimeOffset.UtcNow;
    public bool IsConnectable { get; init; }
}
