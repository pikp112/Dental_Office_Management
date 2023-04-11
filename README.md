# **Dental Office Management**

![](https://camo.githubusercontent.com/deab10366c6377e3d4cc454a26f96225e2cc196214b129b95c9d5284207b64d7/68747470733a2f2f696d672e736869656c64732e696f2f7374617469632f76313f6c6162656c3d254630253946253843253946266d6573736167653d496625323055736566756c267374796c653d7374796c653d666c617426636f6c6f723d424334453939)
![](https://visitor-badge.glitch.me/badge?page_id=nuyonu/N-Tier-Architecture)

This is a n-layer architecture project based on [Common web application architectures][common-web-architectures]. The technologies used can be found below.

---

## Project idea

This website is in the field of dental medicine, through which:

a) a CLIENT can create an account, an online appointment depending on the availability of the dentist he wants, can view a price list.

b) a DENTIST can create an account, view the appointments by calendar days (he will also be able to see the names of the patients, the schedule days depending on the appointments of the patients), he can modify his list of products.

c) you can view the list of dentists in Romania. Through this list, the name of the dentist can be searched, filtered (by city, availability after a certain period etc.) and sorted (by dentist names, city names, average prices of services provided by dentists etc.).

There are both common and private interfaces depending on the TYPE of user: for example, the client will not be able to see how many clients they have that day because they have registered as a doctor; the dentist will not be able to make an appointment.
OPTIONAL:

a) If the CLIENT is scheduled for the first time at the dentist he select, a consultation lasting 30 min will be required. He will be able to choose to do the consultation on the same day or before the day requested for the appointment.

b) The CLIENT will receive a confirmation message by email/phone after doing and appointment.

c) If the CLIENT is scheduled for the first time at the medical dentist, it is mandatory to complete an OBSERVATION SHEET (it will be completed online, the client will give his consent for the entered data). If he doesn’t complete the form, he will not be able to schedule.

d) The DENTIST can send a message to the CLIENT for a possible postponement / cancellation of the appointment at least 2 hours before the appointment made by the client.

e) The DENTIST will have a page where he can see the list of clients. It will be able to search for a client by name, filter the list of clients (by age, appointment period, etc.) and sort (by name, age).

f) The location on the map of the dentist's office can be viewed according to the customer's selection.

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

<img src="https://github.com/pikp112/images/blob/main/img1.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img2.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img3.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img4.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img5.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img6.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img7.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img8.png" alt="drawing" width="800"/>
<img src="https://github.com/pikp112/images/blob/main/img9.png" alt="drawing" width="800"/>

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
