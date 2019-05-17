# Hair Salon

#### An MVC web application for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist.

#### By **Marissa Perry**

## Description

An MVC web application that uses C#, ASP.NET, SQL, and PHPDatabase to allow owner to see a list of stylists, select the stylist and see their details along with a list of clients for the stylist. Has the ability to add new stylists when hired. Has ability to add new clients to stylists. 5/10/19
*UPDATE 5/17/19* Program has the ability to display specialties and add a specialty to a stylist. Delete one or all stylists and clients. Edit the name of stylist and all info of client.


### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
|**Program welcomes user and prompts user to view or enter stylist**|
|**USER ENTERS STYLIST(USING DATABASE)**|
| **Program recognizes when user enters a stylists**| Input: "Kelly" | Output: "Kelly"|
|**USER SELECTS STYLIST FROM LIST**|
| **When user selects a stylist from list, stylist details are open in show view**| Input: "Selects Kelly" | Output: "Kelly is a lead stylist and specializes in punky color and blonde" "A list of Kellys clients" |
|**USER ADDS CLIENTS TO STYLISTS(USING DATABASE ONE TO MANY)**|
| **Program recognizes when user enters a client under a stylist** | User input: "Mindy" | Output: "Mindy(under Kelly)" |
|**USER ADDS SPECIALTIES TO STYLIST(USING MANY TO MANY DATABASE)**|
| **Program recognizes when user enters a specialty under a stylist** | User input: "Long Hair" | Output: "Long Hair(under Kelly)" |
|**USER CAN VIEW AND SELECT FROM A LIST OF SPECIALTIES**|
| **When user selects a specialty a list of stylists open in a show view** |
|**USER CAN DELETE A STYLIST OR A CLIENT**|
|**USER CAN EDIT STYLIST NAME AND ALL CLIENT INFO**|




## Setup/Installation Requirements

Needs .Net 2.2, SQL, MAMP, database(PHPAdmin)

1. Open terminal/command line
2. Clone repository to your desktop
3. Select "WordCounter2.Solution"
4. Select "WordCounter"
5. dotnet restore/dotnet build/dotnet run
6. Open http://localhost:5000 in browser

To recreate database:
1. Start MAMP and click Open WebStart page in the MAMP window.
2. In the website you're taken to, select phpMyAdmin from the Tools      dropdown.
3. Select the Import tab.
4. Note that it's important to make sure you're not importing to a database that already exists, so make sure that a database with the same name as the one you're importing isn't already present.
5. Select your database file, and click Go.


## Known Bugs
* No known issues

## Technologies Used
* HTML
* CSS
* C#
* .NET
* MAMP
* SQL
* MySql
* PHPDatabase



## Support and contact details

_Email me with any questions, comments, or concerns. ohthatmarissa@gmail.com_

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2019 **_{Marissa Perry}_**
