# Pet Store API
This is the reworked version of the petstore API done for a job interview at UNIFY solutions.


# **Business Requirements (The Email sent to me many moons ago)**

·  Browse Swagger documentation at https://petstore.swagger.io/

·  Develop a console application to execute the required sample API(s) to return a list of available Pets from the Pet Store

·  Print a list of available Pets to the console sorted in Categories and displayed in reverse order by Name

·  Write at least one unit test for your code and deliver your code (with instructions in the form of a Readme file in markdown) for review



# Running the Program

1: Clone repo into visual Studio

2: Run it!

# Deliberate Decisions

**Why is the Swagger Petshop Call Not Async?!**

There's only 1 call ever made in the entire runtime of this program, while I agree that blocking the main thread 
is a bad idea, unless the data requested is very large (currently it's only about 100 enteries) Then I dont see much point in implinenting
an async function call. Furthermore, an async call wont actually speed up the program. There are only 2 functions.

**What if I want to Get unavailable pets? Sold ones? Anything Else**

The URL that you send a request to will often return the type you're looking for. The appsettings.json file is where the URL is stored, if you want to change things like what pets are returned then you can change that. If you'd like to spend time playing with the API call then refer to the the swagger.io documentation

**What is this ASCII art?**

It looks cool.
