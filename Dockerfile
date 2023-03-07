FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./QuizApp.Application/QuizApp.Application.csproj", "src/QuizApp.Application/"]
COPY ["./QuizApp.Domain/QuizApp.Domain.csproj", "src/QuizApp.Domain/"]
COPY ["./QuizApp.Infrastructure/QuizApp.Infrastructure.csproj", "src/QuizApp.Infrastructure/"]
COPY ["./QuizApp.Persistence/QuizApp.Persistence.csproj", "src/QuizApp.Persistence/"]
COPY ["./QuizApp.WebAPI/QuizApp.WebAPI.csproj", "src/QuizApp.WebAPI/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/QuizApp.WebAPI/QuizApp.WebAPI.csproj"

COPY . .

# run build over the API project
WORKDIR "/src/QuizApp.WebAPI/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

EXPOSE 8080:80

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "QuizApp.WebAPI.dll" ]