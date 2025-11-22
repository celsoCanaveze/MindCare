# MindCare

1. Introdução

O projeto MindCareWeb representa a camada backend do sistema MindCare desenvolvida em ASP.NET Core 8.0, integrando mecanismos de autenticação, rotas de comunicação com banco de dados e suporte às funcionalidades utilizadas pela aplicação e pela camada de Inteligência Artificial.

Este módulo constitui o núcleo operacional do sistema, responsável por gerenciar usuários, tarefas, humores, auditorias e conexões com o banco de dados.

2. Objetivo

O presente repositório tem por objetivo:

Documentar a API desenvolvida em .NET;

Descrever sua estrutura interna;

Detalhar o processo de execução e configuração;

Apresentar arquitetura organizacional do código.

3. Fundamentação Técnica

A API foi construída seguindo princípios modernos de desenvolvimento:

ASP.NET Core MVC e Web API,

Entity Framework Core (caso aplicável),

Organização em camadas (Controllers, Models, Config, Security etc.),

Compatível com banco de dados Oracle (placeholders presentes nos appsettings),

Integração futura com módulo Python (MindCareIA).

4. Estrutura do Repositório
MindCare/

│── MindCare.sln

│── MindCareWeb/

│     ├── appsettings.json 

│     ├── appsettings.Development.json

│     ├── Controllers/      

│     ├── Models/   

│     ├── Security/  

│     ├── Services/   

│     ├── Program.cs               


6. Procedimentos de Execução
   
5.1. Requisitos

Visual Studio 2022

.NET SDK 8.0

Banco Oracle (opcional para testes iniciais)

5.2. Execução

Abrir o arquivo MindCare.sln no Visual Studio.

Selecionar MindCareWeb como projeto inicial.

Executar via IIS Express ou Kestrel.

A API iniciará nas portas padrão:

https://localhost:5001

http://localhost:5000

5.3. Endpoints

A API inclui endpoints para:

Usuários

Tarefas

Competências

Humor (Histórico)

Autenticação JWT

Auditoria

Os endpoints estão documentados via Swagger.

6. Considerações Finais

O módulo MindCareWeb representa a espinha dorsal do sistema MindCare, garantindo estrutura, controle, segurança e integração com demais módulos. Ele fornece as funcionalidades essenciais para o funcionamento do ecossistema, servindo como gateway para o aplicativo, banco de dados e módulos de inteligência artificial.
