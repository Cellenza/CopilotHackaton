# Copilot Lab Movie API

This is a simple movies API. It provides a list of movies with their respective details.

## Backend

These instructions will get you a copy of the project up and running on your local machine.

1. Open the backend folder, used Copilot to explain the code.

`COPILOT : @workspace explain this code.`

2. Install the dependencies and start the server.

`COPILOT : How to install the dependencies and start the server`

3. Open your browser and access the API documentation.

4. Make some requests.

## Frontend

### Installing Angular

1. Ask Copilot how to install Angular.

`COPILOT : Give me all the steps to create an angular project`

2. Follow the steps to create an Angular project.

    - For the **ng new command**, you must include the following option **--standalone false** to specify that you want a project structure with module.
   
    - We recommend using the **SCSS** style.
   
3. Run the project and open the browser at the specified URL.

   - In your browser open the console and keep it open.

### Displaying the List of Movies

1. Generate interfaces or types based on the backend response.

   - Open Swagger and make a Get request, or get the corresponding schema. 
   
   - Ask Copilot the explain the JSON.
   
     `COPILOT : Can you explain this JSON response : (paste the Sample JSON)`
   
   - Ask Copilot how to generate interfaces based on the JSON object.
   
     `COPILOT : Can you generate inerfaces based on the JSON object`
   
   - Ask Copilot how to create interfaces for the Angular project.
   
     `COPILOT : How can I create interfaces in my Angular project from the previous JSON response`
   
   - Make sure you are in the Angular project before running the commands.
   
2. Ask Copilot how to get the list of movies from the API.
   
   `COPILOT : @workspace for my angular project how to get the list of movie from an api`

3. Ask Copilot how to generate the MovieService.
   
   `COPILOT : @workspace how to generate the MovieService that you have suggested`

4. Ask Copilot how to generate the MovieListComponent.
   
   `COPILOT : @workspace how to generate the MovieListComponent that you have suggested`

5. Ask Copilot how to display the list of movies.
   
   `COPILOT : @workspace how to displayed all the fields from my list of movies`

6. Verify that the list of movies is displayed.

7. Ask Copilot why the list of movies is not displayed.
   
    `COPILOT : @workspace in my angular app instead of the list of movie i see hello`

### Styling the List of Movies

It's your turn 😉

### Pagination of Movies

It's your turn 😉
