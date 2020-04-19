# Coffee-Machine
Simple drink machine application that remember last user choice, in this app we assume that each user has a badge that saved in the database (taking from external system)

 - Front end (folder CoffeeClientApp): 
    - Angular 9 
    - Angular Material 9
    - jasmine For basic UI and service test
 - Backend
   - ASP.NET Core 3.1 web API 
   - EF Core 3.1 (DbInitializer class seed the database data)
   - XUnit, use EF InMemory database to test services
   - Sql server localdb

![](CoffeeMachineUI.png)

badge numbers to test the app 
"KS5VYB", "WEJ2AC", "HP7SY3", "4PUA7N", "G2CPY7", "UK82YX", "TWKH4M"
