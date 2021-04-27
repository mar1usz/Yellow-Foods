# Yellow Foods HATEOAS
A database-backed REST API in C# ASP.NET Core:
```HTTP
GET /api/foods/1
```

```JavaScript
{
  "id": 1,
  "name": "Banana",
  "links": [
    { "rel": "self", "href": "/api/foods", "action": "GET" },
    { "rel": "self", "href": "/api/foods/1", "action": "GET" },
    { "rel": "self", "href": "/api/foods", "action": "POST" },
    { "rel": "self", "href": "/api/foods/1", "action": "PUT" },
    { "rel": "self", "href": "/api/foods/1", "action": "DELETE" }
  ]
}
```

```HTTP
GET /api/foods/1/nutriententries
```

```JavaScript
[
  {
    "id": 1,
    "foodId": 1,
    "nutrientId": 7,
    "unitId": 2,
    "amount": 1.10,
    "links": [
      { "rel": "self", "href": "/api/foods/1/nutriententries", "action": "GET" },
      { "rel": "self", "href": "/api/foods/1/nutriententries/1", "action": "GET" },
      { "rel": "self", "href": "/api/foods/1/nutriententries", "action": "POST" },
      { "rel": "self", "href": "/api/foods/1/nutriententries/1", "action": "PUT" },
      { "rel": "self", "href": "/api/foods/1/nutriententries/1", "action": "DELETE" },
      { "rel": "food", "href": "/api/foods", "action": "GET" },
      { "rel": "food", "href": "/api/foods/1", "action": "GET" },
      { "rel": "food", "href": "/api/foods", "action": "POST" },
      { "rel": "food", "href": "/api/foods/1", "action": "PUT" },
      { "rel": "food", "href": "/api/foods/1", "action": "DELETE" },
      { "rel": "nutrient", "href": "/api/nutrients", "action": "GET" },
      { "rel": "nutrient", "href": "/api/nutrients/1", "action": "GET" },
      { "rel": "unit", "href": "/api/units", "action": "GET" },
      { "rel": "unit", "href": "/api/units/2", "action": "GET" }
    ]
  },
  {
    "id": 21,
    "foodId": 1,
    "nutrientId": 1,
    "unitId": 1,
    "amount": 89.00,
    "links": [
      { "rel": "self", "href": "/api/foods/1/nutriententries", "action": "GET" },
      { "rel": "self", "href": "/api/foods/1/nutriententries/21", "action": "GET" },
      { "rel": "self", "href": "/api/foods/1/nutriententries", "action": "POST" },
      { "rel": "self", "href": "/api/foods/1/nutriententries/21", "action": "PUT" },
      { "rel": "self", "href": "/api/foods/1/nutriententries/21", "action": "DELETE" },
      { "rel": "food", "href": "/api/foods", "action": "GET" },
      { "rel": "food", "href": "/api/foods/1", "action": "GET" },
      { "rel": "food", "href": "/api/foods", "action": "POST" },
      { "rel": "food", "href": "/api/foods/1", "action": "PUT" },
      { "rel": "food", "href": "/api/foods/1", "action": "DELETE" },
      { "rel": "nutrient", "href": "/api/nutrients", "action": "GET" },
      { "rel": "nutrient", "href": "/api/nutrients/21", "action": "GET" },
      { "rel": "unit", "href": "/api/units", "action": "GET" },
      { "rel": "unit", "href": "/api/units/1", "action": "GET" }
    ]
  },
  {...}
]
```

## Prerequisites:
- .NET Core 3.1
- Visual Studio 2019 (with ".NET desktop development" workload installed)
- SQL Server Management Studio 18

## Build and run:
### SSMS:
- Connect to `(localdb)\mssqllocaldb`
- Object Explorer > Databases > Restore Database... > Device > ... > Add > YellowFoodsContext.bak > OK > OK > OK
### VS:
- src\YellowFoods.sln > F5

## Credits:
- Microsoft.VisualStudio.Web.CodeGeneration.Design by https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design (Apache-2.0 license)
- Microsoft.EntityFrameworkCore.Tools by https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools (Apache-2.0 license)
- Microsoft.AspNetCore.Routing by https://www.nuget.org/packages/Microsoft.AspNetCore.Routing (Apache-2.0 license)
- AutoMapper.Extensions.Microsoft.DependencyInjection by https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection (MIT license)
