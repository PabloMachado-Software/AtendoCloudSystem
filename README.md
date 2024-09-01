# aspnet-core

# AtendoCloudSystemAPI

## Descrição do Projeto

O **AtendoCloudSystemAPI** é uma plataforma completa para o gerenciamento de pedidos e entregas em restaurantes. O sistema foi desenvolvido utilizando os princípios de SOLID e a arquitetura DDD (Domain-Driven Design), garantindo uma solução robusta, escalável e fácil de manter. 

O projeto é dividido em duas partes principais:

1. **Backend**: Desenvolvido em .NET 6.0, expõe uma API RESTful para ser consumida pelo frontend.
2. **Frontend**: Desenvolvido em Angular, que interage com a API para fornecer uma interface amigável e responsiva para os usuários.

## Requisitos

- .NET 6.0 SDK
- Node.js (versão 14 ou superior)
- Angular CLI (versão 12 ou superior)
- Git

## Clonando o Repositório

Para obter uma cópia local do projeto, você pode clonar o repositório usando o seguinte comando:

```bash
git clone https://github.com/pablosilvamachado/AtendoCloudSystemAPI.git
```
Configuração do Backend
Após clonar o repositório, navegue até a pasta raiz do projeto e siga as etapas abaixo para configurar o backend.

1. Restaurar os Pacotes NuGet
Navegue até a pasta do projeto backend e restaure as dependências do projeto:

```bash
cd AtendoCloudSystemAPI
dotnet restore
```

2. Configurar o Banco de Dados
Antes de rodar o projeto, configure o banco de dados no arquivo appsettings.json, substituindo as informações de conexão para o seu ambiente local:

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AtendoCloudDB;User Id=seu_usuario;Password=sua_senha;"
}
```

3. Executar Migrações do Entity Framework
Para criar o banco de dados e aplicar as migrações necessárias, execute:

```bash
dotnet ef database update
```

4. Executar o Projeto
Para rodar o backend, execute o seguinte comando:

```bash
dotnet run
```

O backend estará disponível em https://localhost:5001.
=============================================================================================================================================================================================================================================================================

Configuração do Frontend
O frontend do projeto está localizado na pasta frontend dentro do repositório. Siga os passos abaixo para configurar e rodar o frontend.

1. Navegar até a Pasta do Frontend
   
```bash
cd frontend
```

2. Instalar Dependências
Use o comando abaixo para instalar todas as dependências do projeto Angular:

```bash
npm install
```

3. Configurar a URL da API
No arquivo environment.ts, configure a URL da API para apontar para o backend:

```bash
export const environment = {
  production: false,
  apiUrl: 'https://localhost:5001/api'
};
```

4. Rodar o Frontend
Finalmente, para rodar a aplicação Angular, execute:

```bash
ng serve --open
```

A aplicação frontend estará disponível em http://localhost:4200.

Testes Unitários

Backend
Para rodar os testes unitários no backend, execute:

```bash
dotnet test
```

Frontend
Para rodar os testes unitários no frontend, execute:

```bash
ng test
```

Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para enviar um pull request ou abrir uma issue no GitHub.

Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para mais detalhes.

### Instruções

1. **Crie um arquivo `README.md` na raiz do seu repositório** e cole o conteúdo acima.
2. **Substitua** as informações como `seu_usuario` e `sua_senha` pela configuração do banco de dados que você estiver utilizando.
3. **Atualize** qualquer informação específica para o seu projeto que seja diferente do que está descrito.

Este README fornece uma visão clara do projeto e instruções detalhadas para instalação e execução. Se precisar de mais ajustes ou informações adicionais, estou aqui para ajudar!
