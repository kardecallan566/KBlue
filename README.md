# KBlue

KBlue (Kardec Connect) é uma plataforma experimental para pesquisa e desenvolvimento de comunicação sem fio entre dispositivos próximos.

O objetivo central é investigar e aproveitar ao máximo o hardware de rádio disponível, priorizando comunicação direta e explorando camadas de sistema, drivers e firmware quando houver suporte documentado e viabilidade técnica. O projeto não é específico de um fabricante ou computador.

## Princípios

- Separar claramente Bluetooth, Wi-Fi Direct, Wi-Fi/LAN e protocolos próprios KBlue.
- Investigar capacidades reais do chipset, driver e firmware antes de prometer compatibilidade.
- Não assumir que uma placa Wi-Fi convencional possa ser convertida em rádio Bluetooth apenas por software.
- Implementar conexões somente com consentimento e autenticação explícitos.
- Evoluir em checkpoints pequenos, testáveis e documentados.

## Estado do projeto

Consulte [Roadmap](docs/ROADMAP.md), [Estratégia de conectividade](docs/CONNECTIVITY_STRATEGY.md) e [Arquitetura](docs/ARCHITECTURE.md).

### Diagnóstico inicial de hardware (CP01)

No Windows, execute em PowerShell:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\tools\diagnostics\Collect-HardwareInventory.ps1
```

O script gera `kblue-hardware-report.json` e não altera configurações do sistema. Leia [Inventário de hardware](docs/HARDWARE_INVENTORY.md) antes de compartilhar o relatório.

## Desenvolvimento

A solução usa .NET 8 e WinUI 3. A validação de CI usa MSBuild do Visual Studio para compilar o projeto WinUI e .NET CLI para restaurar/testar os projetos.
