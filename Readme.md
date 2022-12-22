# ActorModel.Orleans

This is an example of an bidding app using [Microsoft Orleans 7](https://learn.microsoft.com/en-us/dotnet/orleans/) with persistence using [PostgreSQL](https://www.postgresql.org/).

## How to run

1. Start an instance of PostgreSQL using the [docker-compose.yml](docker-compose.yml)

   `docker compose up`
2. Create the neccessary tables for Orleans, using the [Postgres-setup.sql](Postgres-setup.sql) script.

   (this script is a combination of 2 scripts provided by MS Orleans, see in github: [script1](https://github.com/dotnet/orleans/blob/eda972a0de495e793e33ef07030b9e5a9397c9dc/src/AdoNet/Shared/PostgreSQL-Main.sql) and [script2](https://github.com/dotnet/orleans/blob/eda972a0de495e793e33ef07030b9e5a9397c9dc/src/AdoNet/Orleans.Persistence.AdoNet/PostgreSQL-Persistence.sql))
3. Run the server app.
4. Run the client Api.
5. perform different calls with some bids.
6. double check that the state is saved and updated in `orleansstorage` table.