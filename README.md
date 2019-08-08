# KartRace

Código desenvolvido utilizando VSCode.

Para compilar instalar as bibliotecas .net e executar os comandos ".net restore" e ".net run"

O Arquivo main é o Race.cs que está na raiz da pasta Gympass contida nesse repositório, dentro da pasta "data" está o log.txt que contém os dados da corrida.

a pasta "src" contém os modelos Pilot.cs e Lap.cs que armazenam:

Pilot.cs
- ID
- Nome
- voltas
Além de calcular a melhor volta, tempo e velocidade média

Lap.cs
- ID
- Hora
- Tempo da volta
- Velocidade média da volta

A pasta Utils contida dentro da src contem o script que lê o Log e converte em dados de piloto e volta.
