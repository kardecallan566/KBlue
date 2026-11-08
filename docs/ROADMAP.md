# Roadmap

| CP | Entrega | Critério de aceite |
|---|---|---|
| CP00 | Solução, shell WinUI, Core/Discovery e testes | Restore, build e testes em Windows |
| CP01 | Inventário real de hardware | Modelo, fabricante, driver, estado e capacidades Wi-Fi/Bluetooth; sem alterar configurações |
| CP02 | Bluetooth Classic/BLE | Descoberta e serviços Bluetooth somente quando houver rádio compatível |
| CP03 | Wi-Fi Direct e descoberta Wi-Fi | Verificar suporte P2P, descobrir peers e estabelecer sessão autorizada sem roteador quando possível |
| CP04 | Descoberta unificada | Correlacionar resultados sem confundir Bluetooth, Wi-Fi Direct e LAN |
| CP05 | Gerenciador de conexões | Selecionar transporte compatível, pareamento e sessões com consentimento |
| CP06 | Transferência segura | Envio/recebimento, validação e progresso sobre transporte suportado |
| CP07 | Controle remoto | Teclado/mouse virtual em sessão autenticada e com agente compatível |
| CP08 | Release | Testes integrados, instalador e documentação |

## Objetivo central: conectividade próxima sem exigir Bluetooth integrado

O KBlue deve investigar primeiro o que a placa Wi-Fi instalada consegue fazer para comunicação direta com dispositivos próximos. Wi-Fi Direct/P2P pode criar uma conexão sem roteador, mas depende de suporte do adaptador, driver, Windows e dispositivo remoto.

Uma placa Wi-Fi comum não pode ser convertida em rádio Bluetooth por software. Se não houver rádio Bluetooth enumerado, o KBlue deve oferecer os caminhos Wi-Fi compatíveis e informar com clareza que periféricos Bluetooth genéricos não poderão ser acessados como Bluetooth apenas pela antena Wi-Fi.

Cada checkpoint termina com testes, documentação e commit.
