
## Dapper Web Api Tutorial
Simple demo to use Dapper with Mysql

### Requirements
- [x] [Docker 19](https://docs.docker.com/engine/install/)
- [x] [Dotnetcore 3.1 SDK](https://dotnet.microsoft.com/download)
- [ ] [Flyway client](https://flywaydb.org/documentation/usage/commandline/)

### Database
Mysql8 used with Docker, the docker compose file  to run  the database is in the folder `backing-services`

### Supported Actions

#### GetAll
```
curl -k --request GET 'https://localhost:5001/api/actors' \
--header 'Content-Type: application/json'



```
#### Post
```
curl -k --request POST 'https://localhost:5001/api/actors' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name":"Jim Carrey"
}'
```
#### GetById
```
curl -k --request GET 'https://localhost:5001/api/actors/1' \
--header 'Content-Type: application/json'
```

####  Delete 
```
curl -k --request DELETE 'https://localhost:5001/api/actors/1' \
--header 'Content-Type: application/json'
```

#### Update
```
curl -k --request PUT 'https://localhost:5001/api/actors/1' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name" : "<<insert updated info>>"
}'
```

### Migrations 
This demo use flyway to migrate, but the file `db/sql/V1_0__init.sql` contains the info and can be used in other tools
Migrations are in folder: `db/sql`
```
flyway -configFiles=db/flyway.conf
```


### Pendings

- [ ] Add testing project
- [ ] Add Dockerfile to build image
- [ ] Add docker-compose to run the application/migrations