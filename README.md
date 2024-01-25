# Movie.API .net 8

# Getting Started

- Make sure you run Update-Database pointing at .Data project.
- Double check appsettings.json DB connection as i only used local
  
---
Data set used: https://www.kaggle.com/datasets/disham993/9000-movies-dataset. 
Ill probably add it to migration seed at some point, however for now, please just import into a table post migration. 

---

GetMany method accepts page params that should work all your ordering and filtering needs, just grab the filter names from Swagger definition, you're able to filter/order by all columns.
?Take=2&Skip=0&OrderBy=Title&Filter=en&FilterByType=OriginalLanguage
See above for quick example.

Ordering defaults by Title, should really be by Id for speed, but change where required.

Any validation just throw BusinessException for 404s and 400s etc.

---
21/01

Ok added a sample Blazor UI with simple paging.
Need to archtecture it better as it was just thrown quickly to see what's differet in .net 8. 

If you want to run it make sure you add both API and the .UI projects to your startup.

Filters Added

--- 
UI needs rafactoring at some point.
