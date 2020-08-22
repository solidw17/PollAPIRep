# PollAPIRep

Este projeto foi criado usando Visual Studio Community 2019, baixado pelo link a seguir: https://visualstudio.microsoft.com/pt-br/downloads/  
Deverão ser instalados pelo Visual Studio Installer as seguintes cargas de trabalho:  
	- ASP.NET e desenvolvimento Web  
	- Desenvolvimento para desktop com .NET  
	- Desenvolvimento com a Plataforma Universal do Windows  
	- Processamento e armazenamento de dados  
	- Desenvolvimento multiplataforma com .NET Core  
É necessário baixar e instalar o SDK do .Net Core 3.1 para construção de aplicativos, pelo link: https://dotnet.microsoft.com/download  
Também é usado o SQL Server na versão gratuita Developer, disponível no link: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads  
Basta iniciar a depuração e os testes poderão ser executados.  
O endereço para teste é https://localhost:44343/  
OBSERVAÇÃO: A verificação de certificado SSL deve estar desativada no teste automatizado.  

Exemplos:  

Get /poll/:id  
	Retorna os dados de uma enquete.  

Post /poll
	Cria uma nova enquete.  
	Exemplo de formato:  
```json
{  
	"poll_description":"This is the question",  
	"options":[  
		{"description":"First Option"},  
		{"description":"Second Option"},  
		{"description":"Third Option"}  
	]  
} 
``` 
Retorna o id gerado da enquete inserida no banco de dados.  

Post /poll/:id/vote  
	Registra um voto para uma opção.  
	Exemplo de formato:  
```json
{  
	"option_id":1  
}
```

Get /poll/:id/stats
	Retorna as estatísticas da enquete.  