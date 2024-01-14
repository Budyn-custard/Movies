Quick test .net 8 Movie API

Data set used: https://www.kaggle.com/datasets/disham993/9000-movies-dataset. 
Ill probably add it to migration seed at some point, however for now, please just import into a table. 

Will be adding quick CRUD and UI to it to try the new Server Side Rendering in Blazor released in .net8


---
Needs FilterService at some point.
- For any validation in methods, use BusinessException to throw your BadRequests
- Needs some soert of ApiResponse model too, with the details. Will probs implement too.
