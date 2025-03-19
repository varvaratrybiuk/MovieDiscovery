# Початок роботи

**Крок 1.** Клонуйте репозиторій

`git clone https://github.com/varvaratrybiuk/MovieDiscovery`

**Крок 2.** Налаштуйте файл конфігурації

[appsettings.Development.json](MovieDiscovery.Server/appsettings.Development.json)

```
{
    "AllowedOrigins": [
       "http://localhost:5173" //Тут вкажіть URL вашої клієнтської частини
    ],
    "ConnectionStrings": {
       "sqlConnection": "Data Source=path_to_your_database_file.db" //Тут вкажіть шлях до вашої бази даних SQLite
       }
}
```

**Крок 3.** Запустіть проєкт

1. Перейдіть до каталогу сервера:

   `cd MovieDiscovery.Server`

1. Виконайте build, для відновлення всіх залежностей і побудови проєкту:

   `dotnet build`

1. Якщо база даних відсутня, заспустіть її створення:

   `dotnet ef database update`

1. Запустіть проєкт:

   `dotnet run`
   або
   `dotnet watch run`
