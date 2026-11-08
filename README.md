# Kardec Connect (KBlue)

Aplicativo desktop Windows para descobrir, analisar e conectar dispositivos próximos, transferir arquivos e oferecer controle remoto autorizado.

**Objetivo central:** aproveitar ao máximo o adaptador Wi-Fi existente para conexões diretas entre dispositivos próximos, inclusive Wi-Fi Direct quando suportado, sem exigir que a comunicação passe por um roteador. Bluetooth Classic/BLE será usado quando o Windows detectar um rádio Bluetooth compatível.

Wi-Fi e Bluetooth são tecnologias de rádio distintas. O software não consegue transformar uma placa Wi-Fi comum em um rádio Bluetooth; a estratégia técnica está em [docs/CONNECTIVITY_STRATEGY.md](docs/CONNECTIVITY_STRATEGY.md).

## Requisitos
- Windows 10 19041+ (Windows 11 recomendado)
- .NET 8 SDK
- Visual Studio com workload de desenvolvimento desktop .NET e suporte WinUI 3 / Windows App SDK

## Build e testes
Comandos PowerShell: dotnet restore KBlue.sln, dotnet build KBlue.sln -c Debug e dotnet test tests/KBlue.Tests/KBlue.Tests.csproj.

## Segurança
Descobrir não autoriza parear, conectar, transferir ou controlar. Essas ações exigem consentimento explícito e sessões autenticadas. A descoberta de LAN deve ficar limitada a redes autorizadas.

## Roadmap
CP00 fundação; CP01 inventário de hardware; CP02 Bluetooth; CP03 Wi-Fi Direct e descoberta Wi-Fi; CP04 descoberta unificada; CP05 conexões; CP06 transferência; CP07 controle remoto; CP08 release.
