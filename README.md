# full
some desc over here

```sh
dotnet new sln -n main
dotnet new webapi -n Services/Catalog/Catalog.API
dotnet sln main.sln add Services/Catalog/Catalog.API

CMD + P
Add docker file to workspace...

docker-compose down
docker-compose build
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

```

`docker-compose`
```yml
# Please refer https://aka.ms/HTTPSinContainer on how to setup an https developer certificate for your ASP .NET Core service.

version: '3.4'

services:
  catalogdb:
    image: mongo

  catalogapi:
    image: catalogapi
    build:
      context: .
      dockerfile: Services/Catalog/Catalog.API/Dockerfile

volumes: 
  mongo_data:
```
`docker-compose.override`
```yml
# Please refer https://aka.ms/HTTPSinContainer on how to setup an https developer certificate for your ASP .NET Core service.

version: '3.4'

services:
  catalogdb:
    container_name: catalogdb
    restart: always
    ports: 
      - "27017:27017"
    volumes:
      - mongo_data:/data/db
      
  catalogapi:
    image: catalogapi
    build:
      context: .
      dockerfile: Services/Catalog/Catalog.API/Dockerfile
    ports:
      - "8000:80"
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - "MongoDbSettings:ConnectionString=mongodb://catalogdb:27017"
    depends_on: 
      - catalogdb
    volumes:
      - ~/.vsdbg:/remote_debugger:rw
```