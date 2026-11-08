using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
namespace KBlue.App.Views;
public sealed partial class DiscoveryPage : Page
{
 public DiscoveryPage() => InitializeComponent();
 private async void ScanButton_Click(object sender, RoutedEventArgs e)
 {
  ScanButton.IsEnabled=false; ScanProgress.IsActive=true; StatusText.Text="Preparando provedores…";
  try { await Task.Delay(250); StatusText.Text="CP00: interface pronta; provedores de hardware entram nos próximos checkpoints."; }
  finally { ScanProgress.IsActive=false; ScanButton.IsEnabled=true; }
 }
}
