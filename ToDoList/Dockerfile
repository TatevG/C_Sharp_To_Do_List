FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ToDoList/ToDoList.csproj", "ToDoList/"]
RUN dotnet restore "ToDoList/ToDoList.csproj"
COPY . .
WORKDIR "/src/ToDoList"
RUN dotnet build "ToDoList.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ToDoList.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ToDoList.dll"]