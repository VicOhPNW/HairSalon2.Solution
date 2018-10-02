# Hair Salon

##### C# exercise By Victoria O., Epicodus - September 21, 2018

## *Description*
_Hair Salon_ is a web app for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

This is an exercise to apply and test our understanding of C# unit week 3 lessons. Primary Objectives:
* Do the database table and column names follow both the specific requirements for this project and general .NET naming conventions?
* Are the instructions for re-creating your database thorough and clear?
* Is there a one-to-many relationship set up correctly in the database?
* Is CRUD functionality implemented for BOTH Client and Stylist classes? Including: Create, Read (all and singular) Update and Delete (all and singular).
* Can the user create a new instance of the Specialty class and view all instances of the Specialty class?
* Can the user view both sides of the many-many relationship between Stylist and Specialty: For a particular instance of a class, can you view all of the instances of the other class that are related to it? And vice versa?
* Is the many-to-many relationship set up correctly in the database?
* Does the project demonstrate understanding of this week's concepts? If prompted, are you able to discuss your code with an instructor using correct terminology?

## *Specifications*
* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.
* And here are the user stories that the salon owner would like you to add:
* As an employee, I need to be able to delete stylists (all and single).
* As an employee, I need to be able to delete clients (all and single).
* As an employee, I need to be able to view clients (all and single).
* As an employee, I need to be able to edit JUST the name of a stylist. (You can choose to allow employees to edit additional properties but it is not required.)
* As an employee, I need to be able to edit ALL of the information for a client.
* As an employee, I need to be able to add a specialty and view all specialties that have been added.
* As an employee, I need to be able to add a specialty to a stylist.
* As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
* As an employee, I need to see the stylist's specialties on the stylist's details page.
* As an employee, I need to be able to add a stylist to a specialty.

## *Known Bugs & Issues*
User interface is not stylized as much as it could be.

## *Setup/Installation Requirements*

1. Clone this repository by using Terminal command:
```
    $ git clone https://github.com/VicOhPNW/HairSalon2.Solution
```
```
    via the terminal, enter the program (HairSalon) directory and _dotnet restore_ & _dotnet build_
```
```
    Lastly, run _dotnet run_ and terminal should provide the folloing url: http://localhost:5000. Open this in a browser.
```
2. Create the database using MySQL and follow these SQL commands:
```
1. > CREATE DATABASE victoria_oh;
```
```
2. > USE victoria_oh
```
```
3. Build the following tables:
> CREATE TABLE clients (id serial PRIMARY KEY, client_name VARCHAR(255), stylist_id INT(11));
> CREATE TABLE stylists (id serial PRIMARY KEY, stylist_name VARCHAR(255));
> CREATE TABLE specialties (id serial PRIMARY KEY, service VARCHAR(255));
> CREATE TABLE stylists_specialties (id serial PRIMARY KEY, stylist_id INT(11), specialty_id INT(11));
```
3. Build a test database - we'll do this in phpMyAdmin:
```
1. From the MAMP application, select Open WebStart page and from the Tools menu, select phpMyAdmin.
```
```
2. On the left sidebar of the phpMyAdmin screen, select the victoria_oh database and a new screen will appear. This view shows us the tables we created above.
```
```
3. Select Operations from the tabs at the top of the screen.
```
```
4. In the box labelled Copy database to: enter the name of our new database (victoria_oh_test).
Choose the "structure only" radio button, and select the boxes for CREATE DATABASE before copying and Add AUTO_INCREMENT value.
```
```
5. Click Go and you'll see a new database has appeared in the sidebar called victoria_oh_test.
We should now see this database back the MySQL shell when you run > SHOW DATABASES;
```

## *Support and contact details*
Contact: Victoria, ohvictori@gmail.com

## *Technologies Used*
* C#, ASP.NET Core 1.1
* phpMyAdmin
* MSTest
* HTML

#### *Copyright* (c) 2018 Victoria Oh, Epicodus
