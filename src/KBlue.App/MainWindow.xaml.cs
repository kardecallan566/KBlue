using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using KBlue.App.Views;
namespace KBlue.App;
public sealed partial class MainWindow : Window
{
 public MainWindow() { InitializeComponent(); Title="Kardec Connect"; Navigation.SelectedItem=Navigation.MenuItems[0]; ContentFrame.Navigate(typeof(DashboardPage)); }
 private void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
 {
  if(args.IsSettingsSelected || args.SelectedItem is not NavigationViewItem item) return;
  var page=item.Tag?.ToString() switch { "home"=>typeof(DashboardPage), "discovery"=>typeof(DiscoveryPage), "devices"=>typeof(DevicesPage), _=>typeof(PlaceholderPage) };
  ContentFrame.Navigate(page);
 }
}
