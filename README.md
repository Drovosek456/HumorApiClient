# HumorApiClient

Консольное приложение на C# для работы с [Humor API](https://humorapi.com) — сервисом для получения шуток.

## Описание

Приложение позволяет получать шутки через REST API с помощью интерактивного консольного меню.

## Возможности

- Получить случайную шутку (`/jokes/random`)
- Поиск шуток по ключевому слову (`/jokes/search`)

## Технологии

- C# / .NET Framework
- HttpClient
- Newtonsoft.Json
- Humor API

## Структура проекта
HumorApp/

├── Models/
│   ├── Joke.cs
│   └── JokeSearchResponse.cs
├── Services/
│   └── HumorApiService.cs
└── Program.cs

## Как запустить

1. Клонировать репозиторий
2. Открыть `HumorApp.sln` в Visual Studio
3. Получить API-ключ на [humorapi.com](https://humorapi.com)
4. Вставить ключ в `HumorApiService.cs`
5. Запустить проект (F5)

## Автор

Drovosek456
