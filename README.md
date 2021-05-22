# full
some desc over here

## Part I
```sh
dotnet new sln -n main
dotnet new webapi -o Services/Catalog/Catalog.API
dotnet sln main.sln add Services/Catalog/Catalog.API

CMD + P
Add docker file to workspace...

docker-compose down
docker-compose build
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
docker-compose exec <container_name> sh

docker system prune
docker inspect discountdb #| grep IPAddress 
```

## Part II
```sh
dotnet new webapi -o Services/Basket/Basket.API
dotnet sln main.sln add Services/Basket/Basket.API

docker run -d -p 6379:6379 --name redis1 redis
```
### Redis commands
* redis-cli
* KEYS *
* get `key`
* HGETALL `key`


## Part IV
```sh
dotnet new grpc -o Services/Discount/Discount.GRPC
dotnet restore
dotnet sln main.sln add Services/Discount/Discount.GRPC
```

### Useful links
* [run grpc on mac os x](https://docs.microsoft.com/aspnet/core/grpc/troubleshoot?view=aspnetcore-3.0&branch=master#unable-to-start-aspnet-core-grpc-app-on-macos)

### Extras
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