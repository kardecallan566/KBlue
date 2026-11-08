using Xunit;
using KBlue.Core.Models;
namespace KBlue.Tests;
public sealed class DeviceModelTests
{
 [Fact] public void NewDeviceDefaultsToDiscoveredAndNoServices()
 {
  var d=new DiscoveredDevice { Id="ble:test", Name="Sensor", Protocol=DeviceProtocol.BluetoothLe };
  Assert.Equal(DeviceStatus.Discovered,d.Status); Assert.Empty(d.Services); Assert.False(d.IsConnectable);
 }
 [Fact] public void WirelessProtocolsRemainDistinct()
 {
  Assert.NotEqual(DeviceProtocol.BluetoothClassic,DeviceProtocol.BluetoothLe);
  Assert.NotEqual(DeviceProtocol.Wifi,DeviceProtocol.WifiDirect);
 }
}
