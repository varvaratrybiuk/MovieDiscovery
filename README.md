# Movie Discovery

## Опис проєкту :smiley:

Даний проєкт дозволяє користувачам знаходити інформацію про фільми на нашому сайті. Якщо користувач переглянув фільм, який викликав у нього позитивні емоції та він хоче, щоб більше людей його побачили, він може створити акаунт і додати опис цього фільму до нашої бази даних. Крім того, користувач може здійснювати пошук за назвою або скористатися функцією випадкового вибору, щоб знайти інформацію про фільм для перегляду.

## Базові команди :hammer:

### Запуск проєкту

**Крок 1.** Клонуйте репозиторій

`git clone https://github.com/varvaratrybiuk/MovieDiscovery`

**Крок 2.** Серверна частина

**_Крок 2.1_** Налаштуйте файл конфігурації

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

**_Крок 2.2_** Запустіть проєкт

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

**Крок 3.** Клієнтська частина

**_Крок 3.1_** Налаштуйте файл конфігурації

- [.env](./MovieDiscovery.Client/.env)

`VITE_API_BASE_URL=http://localhost:5151 //Тут вкажіть URL вашого API`

**_Крок 3.2_** Запустіть проєкт

1. Перейдіть до каталогу клієнтської частини

   `cd MovieDiscovery.Client`

1. Завантажте всі залежності

   `npm install`

1. Запустіть проєкт:

   `npm run dev`

## Політика конфіденційності

Посилання [тут](privacy-policy.md)

## Згенерована документація

Для запуску виконати команди

```
cd MovieDiscovery.Server

docfx build docfx.json --serve
```

На локальному сервері. Посилання [тут](http://localhost:8080)

## Storybook

## Swagger

На локальному сервері. Посилання [тут](http://localhost:5151)

1. Назва проєкту, опис
2. Базові команди
   Запуск проєкту
   Серверна частина
   cd MovieDiscovery.Server
   dotnet run / dotnet watch run
   Клієнтська частина
   cd MovieDiscovery.Client
   npm run dev
3. Файли конфігурації
   .env
   appsettings.Development.json
4. Ліцензії Проєктів
   Backend
   Всі під MIT
   Frontend
