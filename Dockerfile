# Utiliza una imagen base de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos y compila la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Utiliza una imagen base de .NET runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto 8003
EXPOSE 8003

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "MultiplicationApi.dll"]
