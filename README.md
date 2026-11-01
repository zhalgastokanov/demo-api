# Demo API - вариант B



Учебный сервис на ASP.NET Core 10 для управления проектами и задачами. Поддерживает хранение данных в памяти и PostgreSQL.



\## Основные эндпоинты



\- `GET /api/projects` - список проектов.

\- `POST /api/projects` - создание проекта.

\- `GET /api/projects/{id}` - получение проекта.

\- `GET /api/projects/{id}/stats` - статистика задач проекта.

\- `GET /api/tasks` - список задач с фильтрами.

\- `POST /api/tasks` - создание задачи.

\- `PATCH /api/tasks/{id}/status` - изменение статуса задачи.

\- `GET /health/live` - проверка работы сервиса.

\- `GET /health/ready` - проверка готовности сервиса и подключения к базе.



Статусы задач: Todo, InProgress, Done.



\## Запуск через Docker Compose



Нужны Docker Desktop с Linux-контейнерами и PowerShell 7.



Откройте PowerShell в папке проекта. Перед первым запуском создайте файл .env:



```powershell

notepad .env

```



Добавьте строку и сохраните файл:



```text

DB\_PASSWORD=demo

```



Пароль demo используется только для учебного окружения. Файл .env исключён из Git.



Соберите и запустите сервис и PostgreSQL:



```powershell

docker compose up -d --build --wait

```



Проверьте запуск:



```powershell

docker compose ps

Invoke-RestMethod http://localhost:8080/api/projects

```



API доступен по адресу http://localhost:8080.



При первой инициализации базы скрипт db/seed.sql добавляет учебные проекты и задачи. Данные сохраняются в именованном томе.



Остановка окружения:



```powershell

docker compose down

```



Команда docker compose down -v также удаляет том с данными базы.



\## Разработка в Visual Studio



Нужна Visual Studio с набором ASP.NET и разработка веб-приложений и SDK .NET 10.



Сначала остановите контейнер API, чтобы освободить порт 8080, и запустите базу:



```powershell

docker compose stop api

docker compose up -d --wait db

```



В src/DemoApi/appsettings.Development.json укажите:



```json

"Storage": "Postgres",

"ConnectionStrings": {

&#x20; "Db": "Host=localhost;Port=5432;Database=demo;Username=demo;Password=demo"

}

```



Остальные настройки файла сохраните. Пароль должен совпадать с DB\_PASSWORD в .env.



Откройте DemoApi.slnx, выберите профиль http и нажмите F5.



Swagger доступен по адресу http://localhost:8080/swagger в среде Development.



После работы остановите отладку сочетанием Shift+F5. Для возврата к запуску в контейнерах выполните:



```powershell

docker compose up -d --wait

```



\## Запуск тестов



Запустите PostgreSQL:



```powershell

docker compose up -d --wait db

```



Из корня проекта выполните:



```powershell

dotnet test DemoApi.slnx

```



Также тесты можно запустить через обозреватель тестов Visual Studio.

