# Desafio Fullstack: A Forja dos Anéis de Poder 💍

## Contexto

O desafio consiste em criar um sistema para gerenciar os anéis de poder, com um backend em **.NET Core** e um frontend em **Razor Pages**. O sistema permite criar, ler, atualizar e deletar anéis de poder, com regras específicas para a quantidade de anéis permitidos por portador (Elfos, Anões, Homens e Sauron).

> "One Ring to rule them all, One Ring to find them, One Ring to bring them all, and in the darkness bind them."  
> — **J.R.R. Tolkien**

---

## Funcionalidades

### Backend

- **Criar um Anel**: Registro de um novo anel com as propriedades:

  - **Nome**: Nome do anel.
  - **Poder**: Descrição do poder do anel.
  - **Portador**: Nome do portador atual.
  - **Forjado por**: Quem forjou o anel.
  - **Imagem**: URL de uma imagem representando o anel.

- **Validações**:

  - Máximo de **3 anéis** para **Elfos**.
  - Máximo de **7 anéis** para **Anões**.
  - Máximo de **9 anéis** para **Homens**.
  - Apenas **1 anel** para **Sauron**.

- **Listar Anéis**: Retorna todos os anéis cadastrados.

- **Atualizar Anel**: Modificação das propriedades de um anel existente.

- **Deletar Anel**: Exclusão de um anel pelo seu identificador.

### Frontend

- **Tela de Criação/Atualização**: Formulário para criar e atualizar anéis com os seguintes campos:

  - **Nome**, **Poder**, **Portador**, **Forjado por**, **Imagem**.

- **Tela de Visualização**: Exibe todos os anéis em um **carrossel/grid**, com a possibilidade de **editar** ou **excluir** os anéis diretamente da tela.

---

## Tecnologias Utilizadas

### Backend

- **.NET Core 6+**
- **Entity Framework** para o acesso ao banco de dados.
- **SQL Server** ou **MongoDB** (configurável).

### Frontend

- **Razor Pages** para a construção das interfaces.
- **Bootstrap** (ou outra biblioteca CSS) para estilização responsiva.

---

## Como Rodar o Projeto

### Backend

1. Clone o repositório.
2. Abra o projeto em um editor de código (ex: **Visual Studio**).
3. Configure o banco de dados (SQL Server ou MongoDB).
4. Execute as migrações para criar o banco de dados.
5. Rode o backend utilizando o comando:

   ```bash
   dotnet run
   Frontend

    Clone o repositório.

    Abra o projeto Razor Pages.

    Configure as rotas para consumir a API do backend.

    Rode o frontend com o comando:

    dotnet run
   ```

Observações

    Problema na Edição dos Nomes no Frontend: A parte de editar os nomes no frontend ficou sem solução no momento. Não foi possível implementar a funcionalidade completa de edição dos campos de nome diretamente na interface do usuário.

Critérios de Avaliação

    Código limpo e bem estruturado.
    Funcionalidades completas (CRUD).
    Validação das regras de negócio.
    Interface intuitiva e responsiva.

Licença

Este projeto está sob a licença MIT.
