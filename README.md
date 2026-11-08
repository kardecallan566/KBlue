# Kardec Connect (KBlue)

Aplicativo desktop Windows para descoberta, análise, conexão, transferência e controle autorizado de dispositivos.

Status: CP00 — fundação inicial. Provedores de hardware serão adicionados nos checkpoints CP01–CP03.

## Requisitos
- Windows 10 19041+ (Windows 11 recomendado)
- .NET 8 SDK
- Visual Studio com workload de desenvolvimento desktop .NET e suporte WinUI 3 / Windows App SDK

## Build e testes
```powershell
dotnet restore .\KBlue.sln
dotnet build .\KBlue.sln -c Debug
dotnet test .\tests\KBlue.Tests\KBlue.Tests.csproj
```

## Segurança
Descobrir não autoriza parear, conectar, transferir ou controlar. Essas ações exigem consentimento explícito e sessões autenticadas. A descoberta de LAN deve ficar limitada a redes autorizadas.

## Roadmap
CP00 fundação; CP01 adaptadores; CP02 Bluetooth; CP03 Wi-Fi/LAN/mDNS/SSDP/Wi-Fi Direct; CP04 analisador; CP05 conexões; CP06 transferência; CP07 controle remoto; CP08 release.

Hardware, driver e permissões limitam o que pode ser descoberto. Encontrar um dispositivo não garante que ele aceite conexões ou controle remoto.
