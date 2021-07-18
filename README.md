# Filmes Ioasys

# Indice

- [Como baixar o projeto](#-como-baixar-o-projeto)
- [Rodando migrations para criação das tabelas do banco de dados](#migrations)
- [Configurar Conexão com o banco de dados](#conexão-com-banco-de-dados)

## 🗂 Como baixar o projeto

```bash

    # Clonar o repositório
    $ git clone https://github.com/LeonardoGabrielSanches

    # Entrar no diretório
    $ cd filmes-ioasys
```

 - Abra o projeto em seu local de preferencia.

---

## Migrations

### Antes de rodar as migrations
 - Ir até o arquivo "DataContext.cs".
 - Descomentar o método "OnConfiguring".
 - Dentro do método "UseSqlServer", inserir a string de conexão para o banco SQL.
 
 ### Rodando as migrations
 - Para rodar as migrations basta abrir um CMD na pasta do projeto "MoviesIoasys.Infra.Data.Sql" e rodar o seguinte comando.
 
 ```bash
    # Criar as tabelas
    $ dotnet ef database update
 ```
 
 ### Após rodar as migrations
 - Ir até o arquivo "DataContext.cs" e comentar novamente o método "OnConfiguring". (Não é necessário realizar esse passo caso não queira)

---
 
 ## Conexão com banco de dados
 - Configurar a string de conexão no arquivo "appsettings.json", campo "Database".


Desenvolvido por Leonardo Gabriel Sanches
