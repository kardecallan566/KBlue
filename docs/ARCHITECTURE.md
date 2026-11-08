# Arquitetura

- **Core**: modelos e contratos independentes de plataforma.
- **Discovery**: coordena provedores isolados por protocolo; falha de um não derruba os demais.
- **App**: shell WinUI 3 e interface Windows.
- **Protocols** (futuro): Bluetooth, GATT, mDNS, SSDP e Wi-Fi Direct.
- **Connections / Transfer / Control / Security / Storage** (futuros): sessões, transporte, autorização, persistência e políticas.

A interface não acessará APIs de hardware diretamente. Cada provedor informará protocolo e metadados observados. Capacidades desconhecidas permanecem desconhecidas, sem inferência.
