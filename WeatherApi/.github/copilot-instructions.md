# Weather Coding Exercise - Copilot Instructions

## Project Goal

Build a small historical weather application.

## Technology

Backend:
- C#
- ASP.NET Core Web API
- .NET 10

Frontend:
- Angular 19
- TypeScript

Testing:
- xUnit

## Backend Guidelines

- Use ASP.NET Core Controllers.
- Use dependency injection.
- Use async/await for I/O operations.
- Use IHttpClientFactory for external HTTP calls.
- Use System.Text.Json for JSON serialization.
- Keep responsibilities separated into sensible models and services.
- Do not use a database.
- Do not add unnecessary NuGet packages or design patterns.
- Prefer readable code.

## Date Processing

Read input dates from dates.txt.

The file contains:
- 02/27/2021
- June 2, 2022
- Jul-13-2020
- April 31, 2022

Support the required date formats.

Normalize valid dates to:

yyyy-MM-dd

Invalid dates such as April 31, 2022 must be handled gracefully and must not crash the application.

## Weather Integration

Use the Open-Meteo Historical Weather API.

Dallas coordinates:
- Latitude: 32.78
- Longitude: -96.8

Retrieve:
- Minimum temperature
- Maximum temperature
- Precipitation sum

Handle:
- HTTP failures
- Empty responses
- Missing weather data
- Dates that return no data

## Local Storage

Store successful weather results as JSON under:

weather-data/{yyyy-MM-dd}.json

Before calling Open-Meteo, check whether a stored file already exists for the date.

Avoid unnecessary repeat API calls.

## Backend API

Expose:

GET /api/weather

Return a consistent response containing:
- Normalized date
- Minimum temperature
- Maximum temperature
- Precipitation
- Status or error information

## Frontend

Use Angular 19.

The UI must:
- Call GET /api/weather
- Display weather results in a table
- Show a loading state
- Show an error state
- Allow sorting by date or temperature

Keep the visual design simple and clear.

## Testing

Use xUnit.

Prioritize tests for:
- Supported date formats
- Invalid dates
- Important service behavior

## AI Development Guidelines

- Work on one feature at a time.
- Do not generate the entire application at once.
- Explain non-obvious implementation decisions.
- Flag assumptions.
- Do not silently change requirements.
- Do not create unnecessary abstractions.
- Do not add packages unless they are actually needed.