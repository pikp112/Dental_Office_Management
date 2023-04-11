# **Dental Office Management**

![](https://camo.githubusercontent.com/deab10366c6377e3d4cc454a26f96225e2cc196214b129b95c9d5284207b64d7/68747470733a2f2f696d672e736869656c64732e696f2f7374617469632f76313f6c6162656c3d254630253946253843253946266d6573736167653d496625323055736566756c267374796c653d7374796c653d666c617426636f6c6f723d424334453939)
![](https://visitor-badge.glitch.me/badge?page_id=nuyonu/N-Tier-Architecture)

This is a n-layer architecture project based on [Common web application architectures][common-web-architectures]. The technologies used can be found below. 

---

## Technologies
- .NET 6
- ASP.NET Core 6
- Blazor WebAssembly
- Swagger (Documentation)
- Entity Framework Core (SQL Server)
- ASP.NET Core Identity (SQL Server)
- AutoMapper
- FluentValidation

---
## Front-end images

<img src="https://github.com/pikp112/images/blob/main/img1.png" alt="drawing" width="600"/>
---

## Dependencies between projects

<div align="center">

<img src="https://github.com/pikp112/images/blob/main/DiagramWhiteClinicalManagement.drawio.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/structure.png" alt="drawing" width="400"/>
   
</div>

---

## **Getting Started**

<!-- Before you begin, please read the [requirements](#requirements).  -->

A quick method to use the exposed solution is to download a copy of this project, if you meet all the requirements, the project will run without any problems and can be used from the first second.

## Database migrations

Migrations will be applied automatically. If you want to add new migrations to be applied to over the database, you will need to run the command below in the root folder

```c#
dotnet ef migrations add Migration-Name --project N-Tier.DataAccess -o Persistence/Migrations --startup-project N-Tier.API
```

<!-- ## **Maintainers** -->
<!-- // TODO -->

## **Support**

If you are having problems, please let me know by raising a [new issue](https://github.com/nuyonu/N-Tier-Architecture/issues/new/choose).


[common-web-architectures]: https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures
