To run the project yourself, you can do the following:

1) Download the files in this project. I'll refer to the directory that contains both DatingApp.API and DatingApp-SPA as
2) Open Visual Studio Code in this workspace. Create two terminals: one for DatingApp-SPA and one for DatingApp.API
3a) In DatingApp-SPA, run "ng serve" to start the angular server.
3b) In DatingApp.API, run "dotnet run" to start the .NET API server.
4) From the above, a localhost URL should have been generated. Take the URL from DatingApp-SPA and go to it (e.g 'http:localhost/4200'). You should see the project in full.

This is a web project created using C#, .NET, TypeScript, Angular, MySQL and a variety of third-party libraries including ngx-bootstrap.
It's a dating website where users can register/log into accounts, and search for matches based on their own filters.
They can like other users and send messages to them, and also customise their own profiles, 
from their text descriptions to their profile photos.

This was inspired by the Udemy course by Neil Cummings: https://www.udemy.com/course/build-an-app-with-aspnet-core-and-angular-from-scratch/
Despite being a course, there were numerous challenges in directly updating it, and configuring it for present tech. It was far
from a direct copy, and I found myself regularly doing my own research to supplement what I had learned in the course.

The purpose of this project was to learn the extent of the .NET Core and Angular frameworks, and see the effectiveness of 
combining the two. The end result is what you can download here and test in a .net runtime environment, 
either by uploading to a server or running on your local machine.
With the understanding I took away from this, I feel confident in programming .NET and Angular for future applications
