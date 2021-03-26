# Yellow Foods
A database-backed REST API in C# ASP.NET Core:
```HTTP
GET api/foods/1
```

```JavaScript
{
  "id": 1,
  "name": "Banana"
}
```

```HTTP
GET api/foods/1/nutriententries
```

```JavaScript
[
  {
    "id": 1,
    "nutrientId": 7,
    "foodId": 1,
    "unitId": 2,
    "amount": 1.10
  },
  {
    "id": 21,
    "nutrientId": 1,
    "foodId": 1,
    "unitId": 1,
    "amount": 89.00
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
- YellowFoods.sln > F5

## Credits:
- Microsoft.EntityFrameworkCore.Tools by https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design by https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design (Apache-2.0 license)
- AutoMapper.Extensions.Microsoft.DependencyInjection by https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection (MIT license)
