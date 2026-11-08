# CP01 — Inventário de hardware sem fio

## Objetivo

Identificar as interfaces e capacidades que o sistema operacional realmente expõe, sem pressupor fabricante, computador ou chipset. O inventário é a primeira etapa para decidir quais experimentos de baixo nível são tecnicamente viáveis.

## Dados coletados

- Adaptadores de rede, descrição, estado, tipo de mídia e velocidade.
- Dispositivos Plug and Play da classe de rede.
- Dispositivos Plug and Play da classe Bluetooth.
- Diagnóstico bruto de drivers WLAN fornecido por `netsh wlan show drivers`.
- Versão e arquitetura do Windows.

## O que o relatório não conclui sozinho

A presença de uma interface Wi-Fi não prova suporte a Wi-Fi Direct, monitor mode, injeção de quadros ou acesso ao firmware. A ausência de dispositivos na classe Bluetooth também não prova, isoladamente, ausência física de rádio: driver, firmware, BIOS e enumeração PnP podem interferir.

O relatório marca Wi-Fi Direct como desconhecido até que a capacidade seja validada por API/driver. Ele não tenta transformar Wi-Fi em Bluetooth nem modifica configurações.

## Executar

Abra PowerShell e execute a partir da raiz do repositório:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\tools\diagnostics\Collect-HardwareInventory.ps1
```

O arquivo `kblue-hardware-report.json` será criado no diretório atual. Para escolher outro destino:

```powershell
.\tools\diagnostics\Collect-HardwareInventory.ps1 -OutputPath .\artifacts\hardware.json
```

Revise o JSON antes de compartilhá-lo. Ele inclui identificadores PnP e endereço MAC, que podem ser dados identificáveis do dispositivo.

## Próxima etapa técnica

Após identificar fabricante, modelo e driver do chipset Wi-Fi, cruzar essas informações com documentação pública do fabricante e validar as APIs Windows disponíveis. Só então selecionar a rota de implementação: Wi-Fi Direct, Native Wi-Fi, Bluetooth Windows quando houver rádio enumerado, ou pesquisa com hardware de rádio programável.

## Limites de segurança

O script é somente leitura. Não instala drivers, altera registro, muda canais/potência, ativa modos de monitoramento, injeta quadros nem acessa firmware.
