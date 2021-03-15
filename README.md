# Analisador De Bytes

## Pré-requisitos:
[Git](https://git-scm.com/)

[Dotnet 5 sdk (SDK 5.0.201)](https://dotnet.microsoft.com/download/dotnet/5.0)


## Como usar:
```
git clone https://github.com/eduardonaguiarviavarejo/AnalisadorDeBytes.git
```
```
cd AnalisadorDeBytes
```
```
dotnet build
```
```
dotnet run --project .\AnalisadorDeBytes\ --f 0 --c "c:\dev" --b 1000000
```

## Parâmetros: 

#### --c | --caminho:
***[Requerido]*** Caminho de destino do arquivo. Ex.: c:\.

#### --b | --buffer:
Tamanho do buffer em bytes. (Caso não digitado o valor padrão é 1000000).

#### --f | --formato:
Formato da impressão em tela: 
-  0: Tabela
-  1: Json
     
## Testes
#### Executando testes unitários:
```
dotnet run test
```



