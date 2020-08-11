# Yellow Foods
A database-backed REST API in C# ASP.NET Core:
```HTTP
GET api/foods/1
```

```JSON
{
    "id": 1,
    "name": "banana"
}
```

```HTTP
GET api/foods/1/nutritions
```

```JavaScript
[
    {
        "nutrition_id": 1,
        "nutrition_name": "calories",
        "value": 89.0,
        "unit_id": 1,
        "unit_abbrev": "kcal"
    },
    {
        "nutrition_id": 2,
        "nutrition_name": "total fat",
        "value": 0.3,
        "unit_id": 2,
        "unit_abbrev": "g"
    },
    {...}
]
```

## Prerequisites:
- .NET Core 3.1
- Visual Studio 2019
- SQL Server Management Studio 18

## Build and run:
### SSMS:
- Connect to (localdb)\mssqllocaldb
- Object Explorer > Databases > Restore Database... > Device > ... > Add > yellow_foods.bak > OK > OK > OK
### VS:
- Yellow Foods.sln > F5

## Credits:
- AutoMapper by https://automapper.org (MIT License)
