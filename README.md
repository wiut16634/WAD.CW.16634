### Calculation of Theme
If we divide 16634 to 20 it gives 14 in remainder. Theme number 14 - Survey Form

### Web application repository on github
[link to the github repository](https://github.com/wiut16634/WAD.CW.16634)
### Libraries used for building API
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServe
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Identity.EntityFrameworkCore


### Front END Dependencies
- open source images for page backgrounds
- Angular components
## How to Run the Application
### Back-end part
-- before running front-end part, you need to run ASP.NET API. 
- Open WAD.CW.16634 solution,
- Open nuget package terminal and type ```bash
update-database
``` (needed to create a local db, because there are ready migration history it will automatically create needed tables)
- Run application
### Front-end part
-- open SurveyManagerFrontEnd
- Run the angular project
```bash
ng serve
```