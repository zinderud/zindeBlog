# zinde Blog
 

As well as just the basics of hosting a TypeScript-coded Angular 2 site on ASP.NET Core.

<h3>Frameworks - Tools - Libraries</h3>
<ul>
<li>ASP.NET Core</li>
<li>Entity Framework Core</li>
<li>Automapper</li>
<li>Angular 2</li>
<li>Typescript</li>
<li>Bootstrap 3</li>
<li>Gulp</li>
<li>Bower</li>
</ul>
Let’s view all of them in detail.

  -  ASP.NET Core 1.0: Microsoft’s redesigned, open source and cross-platform framework.
    -Entity Framework Core: The latest version of the Entity Framework Object Relational Mapper.
    -Angular 2: The famous AngularJS re-written and re-designed from scratch. Angular 2 is a development platform for building mobile and desktop applications
    -TypeScript: A typed super-set of JavaScript that compiles to plain JavaScript. One of the best ways to write JavaScript applications.
    -NPM: A Package Manager responsible to automate the installation and tracking of external packages.
    -Bower: A Package Manager for the Web and as it’s official website says, optimized for the front-end.
   - Gulp: A task runner that uses Node.js and works in a Streamline way.
  -  
  


You can also:
  - installs Bower globally
	npm install -g bower
   - installs Gulp globally
   npm install -g gulp
   - installs typescript globally
    npm install -g typescript
- installs Typescript Definition Manager
npm install -g tsd
npm install -g typings



<ul>
<li>npm install</li>
<li>typings install</li>
<li>bower install</li>
<li>gulp build-spa</li>
</ul>


<li>Run the following command to restore Nuget Packages (dependencies)
<ul>
<li>dotnet restore</li>
</ul>
</li>
<li>Application uses SQL Server so in case you want to run the app in Linux or MAC simply set <b>"InMemoryProvider": true</b> in <i>appsettings.json</i> and skip to the last 3 steps to run the app.</li>
<li>Open <strong>appsettings.json</strong> file and alter the database connection string to reflect your SQL Server environment.</li>
<li>Open a console/terminal and navigate to src/PhotoGallery where the project.json exists. Run the following commands to enable migrations and create the database:
<ol>
<li>dotnet ef migrations add initial</li>
<li>dotnet ef database update</li>
</ol>
</li>
 
<ul>
<li>dotnet run</li>
</ul>
</li>
<li>Open a browser and navigate to http://localhost:5000/</li>
