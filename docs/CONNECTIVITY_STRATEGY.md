# Estratégia de conectividade por rádio

## Objetivo principal

O objetivo do Kardec Connect é permitir que o PC descubra e se conecte a dispositivos próximos, priorizando comunicação direta e sem depender de um roteador ou de uma rede compartilhada sempre que o hardware e o dispositivo remoto oferecerem suporte.

O projeto deve investigar e aproveitar ao máximo o adaptador Wi-Fi existente, inclusive quando o computador não possui um rádio Bluetooth separado. Não se deve pressupor que instalar software transforme qualquer placa Wi-Fi em um rádio Bluetooth.

## Limite físico importante

Wi-Fi e Bluetooth podem operar na banda de 2,4 GHz, mas usam camadas físicas, modulação, temporização, canais e protocolos diferentes. Uma antena é apenas o elemento de RF; quem gera e interpreta os sinais é o chipset/radio, com firmware e driver. Portanto, uma placa Wi-Fi convencional não passa a transmitir Bluetooth clássico ou BLE apenas por software.

Alguns módulos combinados possuem Wi-Fi e Bluetooth no mesmo componente físico, mas expõem funções/radios separados ao sistema operacional. Outros adaptadores Wi-Fi não possuem Bluetooth. O inventário deve distinguir placa Wi-Fi, rádio Bluetooth enumerado pelo Windows, suporte a Wi-Fi Direct/P2P, descoberta de serviços na LAN e capacidades desconhecidas.

## Caminhos que o KBlue deve implementar/investigar

1. **Wi-Fi Direct:** conexão peer-to-peer sem roteador, quando adaptador, driver e dispositivo remoto suportarem. É a principal rota Wi-Fi direta a investigar para dispositivos próximos.
2. **Wi-Fi LAN e descoberta de serviços:** mDNS/DNS-SD, SSDP e protocolos explícitos de descoberta, restritos a redes autorizadas.
3. **Bluetooth Classic e BLE:** usar as APIs Bluetooth do Windows quando houver um rádio Bluetooth real, interno ou externo.
4. **Transporte alternativo KBlue:** para dois dispositivos que executem software compatível, avaliar um protocolo próprio sobre Wi-Fi Direct ou LAN, com autenticação, consentimento e criptografia. Isso não equivale a conectar-se a um periférico Bluetooth genérico.
5. **Diagnóstico de compatibilidade:** informar quando o adaptador não oferece Wi-Fi Direct, quando não há rádio Bluetooth e quando o dispositivo remoto não anuncia serviço compatível.

## Regras de produto

- Não rotular Wi-Fi Direct, TCP/IP ou descoberta LAN como Bluetooth.
- Não afirmar que um dispositivo Bluetooth genérico pode ser controlado por Wi-Fi.
- Não tentar injetar quadros de rádio, contornar drivers ou ativar modos não suportados.
- Descoberta não implica autorização. Pareamento, conexão, transferência e controle exigem consentimento explícito.
- Exibir protocolo utilizado e motivo de indisponibilidade em cada resultado.

## Investigação de hardware

O CP01 deve registrar fabricante, modelo, driver, estado e capacidades reportadas para cada interface. O CP03 deve testar a disponibilidade real de Wi-Fi Direct e APIs de descoberta. A compatibilidade final depende do modelo exato do adaptador e do dispositivo remoto.

## Referências técnicas

- Microsoft: [Bluetooth no Windows](https://learn.microsoft.com/en-us/windows-hardware/design/component-guidelines/bluetooth)
- Microsoft: [Enumerar dispositivos por rede e protocolos sem fio](https://learn.microsoft.com/en-us/windows/apps/develop/devices-sensors/enumerate-devices-over-a-network)
- Microsoft: [Wi-Fi Direct API](https://learn.microsoft.com/en-us/windows/win32/nativewifi/about-the-wi-fi-direct-api)
- Microsoft: [Bluetooth FAQ e coexistência Wi-Fi/Bluetooth](https://learn.microsoft.com/en-us/windows-hardware/drivers/bluetooth/bluetooth-faq)
