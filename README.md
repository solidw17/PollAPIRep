# PollAPIRep

Este projeto foi criado usando Visual Studio Community 2019, baixado pelo link a seguir: https://visualstudio.microsoft.com/pt-br/downloads/  
Dever�o ser instalados pelo Visual Studio Installer as seguintes cargas de trabalho:  
	- ASP.NET e desenvolvimento Web  
	- Desenvolvimento para desktop com .NET  
	- Desenvolvimento com a Plataforma Universal do Windows  
	- Processamento e armazenamento de dados  
	- Desenvolvimento multiplataforma com .NET Core  
� necess�rio baixar e instalar o SDK do .Net Core 3.1 para constru��o de aplicativos, pelo link: https://dotnet.microsoft.com/download  
Tamb�m � usado o SQL Server na vers�o gratuita Developer, dispon�vel no link: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads  
Basta iniciar a depura��o e os testes poder�o ser executados.  
OBSERVA��O: A verifica��o de certificado SSL deve estar desativada no teste automatizado.  

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
	Registra um voto para uma op��o.  
	Exemplo de formato:  
```json
{  
	"option_id":1  
}
```

Get /poll/:id/stats
	Retorna as estat�sticas da enquete.  