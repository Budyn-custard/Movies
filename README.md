Quick test .net 8 Movie API

Data set used: https://www.kaggle.com/datasets/disham993/9000-movies-dataset. 
Ill probably add it to migration seed at some point, however for now, please just import into a table. 

Will be adding quick CRUD and UI to it to try the new Server Side Rendering in Blazor released in .net8


---
Needs FilterService at some point.
- For any validation in methods, use BusinessException to throw your BadRequests
- Needs some soert of ApiResponse model too, with the details. Will probs implement too.


GetMany method accepts page params that should work all your ordering and filtering needs, just grab the filter names from Swagger definition, you're able to filter/order by all columns.
?Take=2&Skip=0&OrderBy=Title&Filter=en&FilterByType=OriginalLanguage
See above for quick example.

Ordering defaults by Title, should really be by Id for speed, but change where required.
---
21/01

Ok added a sample Blazor UI with simple paging.
Need to archtecture it better as it was just thrown quickly to see what's differet in .net 8. 

If you want to run it make sure you add both API and the .UI projects to your startup.

Still need to add some filter drop down etc to the UI.
Will add a little react and angular playgrounds next. Maybe MAUI too
