# Hair Salon

##### C# exercise By Victoria O., Epicodus - September 21, 2018

## *Description*
_Hair Salon_ is a web app for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.


This is an exercise to apply and test our understanding of C# unit week 3 lessons. Primary Objectives:
* Do the database table and column names follow both the specific requirements for this project and general .NET naming conventions?
* Are the instructions for re-creating your database thorough and clear?
* Is there a one-to-many relationship set up correctly in the database?
* Is **CREATE** functionality included for one class and is **CREATE** and **VIEW** functionality included for the other class?
* Have all of the standards from previous weeks been met?
* Does the project demonstrate understanding of this week's concepts? If prompted, are you able to discuss your code with an instructor using correct terminology?


## *Specifications*
1. A salon employee is able to see a list of all stylists at the salon.
    * inputs: "Panatda", "John"
    * output: "Panatda, John" (in list format)

2. A salon employee is able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
  * input: "Panatda"
  * output: "Panatda" and her client list

3. A salon employee is able to add a new stylist to their employee list.
  * input: "John"
  * output: "Panatda, John"

4. A salon employee is able to add new clients to a specific stylist - a client cannot be added if no stylists have been added.
  * input: "Victoria"
  * output: if no stylist: false; if a stylist is chosen, "Victoria" will be visible on a stylist's client list (see spec 2).


## *Known Bugs & Issues*



## *Setup/Installation Requirements*

1. Clone this repository by using Terminal command:
```
    $ git clone https://github.com/VicOhPNW/HairSalon.Solution.git
```
2. Create the database:

## *Support and contact details*
Contact: Victoria, ohvictori@gmail.com

## *Technologies Used*
* C#, ASP.NET Core 1.1
* phpMyAdmin

#### *Copyright* (c) 2018 Victoria Oh, Epicodus
