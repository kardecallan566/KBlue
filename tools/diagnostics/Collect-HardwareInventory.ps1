[CmdletBinding()]
param(
    [string]$OutputPath = (Join-Path (Get-Location) "kblue-hardware-report.json")
)

$ErrorActionPreference = "Continue"

function Get-DeviceRows {
    param([string]$ClassName)

    try {
        Get-PnpDevice -Class $ClassName -PresentOnly |
            Select-Object FriendlyName, Manufacturer, Class, Status, InstanceId
    }
    catch {
        @()
    }
}

$netAdapters = @()
try {
    $netAdapters = @(Get-NetAdapter -IncludeHidden | ForEach-Object {
        [pscustomobject]@{
            Name = $_.Name
            InterfaceDescription = $_.InterfaceDescription
            InterfaceGuid = [string]$_.InterfaceGuid
            Status = [string]$_.Status
            MediaType = [string]$_.MediaType
            PhysicalMediaType = [string]$_.PhysicalMediaType
            LinkSpeed = [string]$_.LinkSpeed
            MacAddress = $_.MacAddress
            HardwareInterface = $_.HardwareInterface
        }
    })
} catch {}

$wifiAdapters = @($netAdapters | Where-Object {
    $_.InterfaceDescription -match 'Wi-?Fi|Wireless|802\.11|WLAN'
})

$bluetoothDevices = @(Get-DeviceRows -ClassName "Bluetooth")
$networkPnpDevices = @(Get-DeviceRows -ClassName "Net")

$wlanDriverOutput = ""
try {
    $wlanDriverOutput = (& netsh wlan show drivers 2>&1 | Out-String).Trim()
} catch {
    $wlanDriverOutput = "Unable to query WLAN driver details: $($_.Exception.Message)"
}

$report = [ordered]@{
    GeneratedAtUtc = [DateTime]::UtcNow.ToString("o")
    Computer = [ordered]@{
        OS = (Get-CimInstance Win32_OperatingSystem | Select-Object -ExpandProperty Caption -ErrorAction SilentlyContinue)
        OSVersion = [Environment]::OSVersion.VersionString
        Architecture = [Runtime.InteropServices.RuntimeInformation]::OSArchitecture.ToString()
    }
    NetworkAdapters = $netAdapters
    LikelyWifiAdapters = $wifiAdapters
    NetworkPnPDevices = $networkPnpDevices
    BluetoothPnPDevices = $bluetoothDevices
    WlanDriverDiagnostic = $wlanDriverOutput
    Interpretation = [ordered]@{
        BluetoothRadioPresent = if ($bluetoothDevices.Count -gt 0) { "Detected by Windows PnP" } else { "Not detected in Bluetooth device class; verify Device Manager and OEM drivers" }
        WifiDirectSupport = "Unknown: requires adapter/driver capability validation; raw WLAN driver output is included"
        BluetoothOverWifi = "Not established by this inventory; Wi-Fi and Bluetooth are distinct radio/protocol interfaces"
    }
}

$directory = Split-Path -Parent $OutputPath
if ($directory -and -not (Test-Path $directory)) {
    New-Item -ItemType Directory -Path $directory -Force | Out-Null
}
$report | ConvertTo-Json -Depth 8 | Set-Content -Path $OutputPath -Encoding utf8
Write-Host "KBlue hardware report saved to: $OutputPath"
Write-Host "Wi-Fi-like adapters: $($wifiAdapters.Count)"
Write-Host "Bluetooth PnP devices: $($bluetoothDevices.Count)"
Write-Host "This diagnostic is read-only; it does not change radio, driver, or network settings."
