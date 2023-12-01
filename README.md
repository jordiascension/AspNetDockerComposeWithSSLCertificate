
- Docker compose with our own certificate
https://www.yogihosting.com/docker-compose-aspnet-core/
https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-dev-certs

- Create ssl certificate in https folder
	- dotnet dev-certs https -ep \\https\\aspnetapp.pfx -p mypass123
- Execute this command to trust the certificate
	- dotnet dev-certs https --trust or you can also execute
	- dotnet dev-certs https -ep \\https\\aspnetapp.pfx -p mypass123 --trust
 
 - Change the docker-compose.override.yaml to read this certificate
  volumes:
      - ${APPDATA}/Microsoft/UserSecrets:/root/.microsoft/usersecrets:ro
      #- ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro
      - ./https/aspnetapp.pfx:/https/aspnetapp.pfx:ro
      
 - execute docker compose build
 - execute docker compose up
 - now the certificate is in your git repository and if you clone it, it will fork!

 