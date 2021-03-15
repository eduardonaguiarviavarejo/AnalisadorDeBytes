# Analisador De Bytes

## Pré-requisitos:
[Git](https://git-scm.com/)

[Dotnet 5 sdk (SDK 5.0.201)](https://dotnet.microsoft.com/download/dotnet/5.0)

## Construçao

Para o desenho do sofware fora escolhidos os padroes Command (para o roteiro de execução das etapas em cadeia), Strategy (para estratégias de fallback) e Singleton (evitando memory leak na criação de objetos).

## Frameworks utilizados:
[Puppeteer-sharp](https://github.com/hardkoded/puppeteer-sharp): Crawler utilizado para buscar conteúdo nos sites relacionados. 

[ConsoleTableExt](https://github.com/minhhungit/ConsoleTableExt/): Exibição de relatório em formato tabela.

[Commandline](https://github.com/commandlineparser/commandline): Commandline de execuçao do projeto.


## Como utilizar:

### No PowerShell digite:
```
git clone https://github.com/eduardonaguiarviavarejo/AnalisadorDeBytes.git
```
```
cd AnalisadorDeBytes\AnalisadorDeBytes
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

-  1: Criar pasta "c:\data"
-  2: Executar comando:
```
dotnet test
```



