# Pet Store API

#Original Business Requirements (What Was in the Email sent to me many moons ago)

·  Browse Swagger documentation at https://petstore.swagger.io/

·  Develop a console application to execute the required sample API(s) to return a list of available Pets from the Pet Store

·  Print a list of available Pets to the console sorted in Categories and displayed in reverse order by Name

·  Write at least one unit test for your code and deliver your code (with instructions in the form of a Readme file in markdown) for review

This is the Re Worked version of the Petsore API done for a job interview at UNIFY technologies.


# Running the Program

1: Clone Repo into visual Studio
2: Run it

# Deliberate Decisions

**Why is the Swagger Petshiop Call Not Async?!**

There's only 1 call ever made in the eintire runtime of this program, While i'd agree that blockign the main thread 
is a bad idea unless the data requested is very large (currently it's only about 100 enteries) Then i dont see much point in implinenting
a async function call.

Needless to mention that the call wont actually speed up the program, as there are only 2 functions, each depending on eachother directly.

**What if i want to Get not available pets? Sold ones?**

The URL that you send a request to will often return the type you're looking for. The appsettings.json file is where the URL is stored, if you want to change things like what pets are treurned then you can change that.

**What is this ASCII art?**

It looks cool.

