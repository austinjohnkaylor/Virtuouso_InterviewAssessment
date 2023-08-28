# Virtuouso_InterviewAssessment

## Problem
Create a C# program that solves the following dependency problem:

- A person needs to figure out which order his/her clothes need to be put on. 
- The person creates a file that contains the dependencies.
 
This input is a declared array of dependencies with the **[0] index** being the **dependency** and the **[1] index** being the **clothing item**. 
 
A simple input would be:
 
```csharp
var input = new string[,]
{
    //dependency    //item
    {"t-shirt", "dress shirt"},
    {"dress shirt", "pants"},
    {"dress shirt", "suit jacket"},
    {"tie", "suit jacket"},
    {"pants", "suit jacket"},
    {"belt", "suit jacket"},
    {"suit jacket", "overcoat"},
    {"dress shirt", "tie"},
    {"suit jacket", "sun glasses"},
    {"sun glasses", "overcoat"},
    {"left sock", "pants"}, // left sock before pants
    {"pants", "belt"}, // pants before belt
    {"suit jacket", "left shoe"},
    {"suit jacket", "right shoe"},
    {"left shoe", "overcoat"},
    {"right sock", "pants"},
    {"right shoe",  "overcoat"},
    {"t-shirt", "suit jacket"}
};
```

In this example, it shows that they must put on their _left sock_ before their _pants_. Also, 
they must put on their _pants_ before their _belt_.
 
From this data, write a program that provides the order that each object needs to be put on.
 
The output should be a line-delimited list of objects. If there are multiple objects that
can be done at the same time, list each object on the same line, alphabetically 
sorted, comma separated.
 
Therefore, the output for this sample file would be:
 
```
left sock,right sock, t-shirt
dress shirt
pants, tie
belt
suit jacket
left shoe, right shoe, sun glasses
overcoat
```
 
## Evaluation Criteria
 
You will be evaluated on the following criteria:
1. Correctness of the solution
2. Algorithmic, logic, and programming skills
3. Performance considerations
4. Design and code structure (modular, etc)
5. Coding style
6. Usability
7. Testability
8. Documentation