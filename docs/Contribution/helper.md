# Helper

## Contribution
This page is a contribution aid focused on programming. For the contribution from the point of view of the Open Source part we invite you to look at the [contributing file](https://github.com/jhipster/jhipster-dotnet/blob/main/CONTRIBUTING.md)

### Adding an endpoint
If you want to add a new feature that requires the addition of an endpoint here is the procedure: 

1. Add your controller class in the *controllers* folder in the *Core* layer.
2. Faite héritez votre classe de ControllerBase (ASP .NET MVC) et décorez la de ces propriétés : *[ApiController]* and *[Route("[controller]")]*.
3. Then add your methods by decorating them with a first property representing the Http verb of the method and a second property representing the route to call this method. 
For example, here are the attributes of a method from the project initialization controller: [HttpPost] and [Route("/api/projects/init")].
4. Feel free to decorate your controller methods with these comments:
```
/// <summary>
/// Generating the Readme file, initializes the project solution and Git
/// </summary>
/// <param name="projectDto"></param>
/// <returns></returns>
/// <remarks>
/// Sample request:
///
/// {
/// "folder": "C:/Sample",
/// "namespace": "sample",
/// "projectName": "SampleProject",
/// "sslPort": "12345"
/// }
///
/// </remarks> 
```
This represents an example of a context to be filled in with Swagger.
5. Finally add your Application service in the Application layer and your Domain service in the Domain layer. Don't forget to add the corresponding interfaces as well (La couche Application appellera la couche Domain qui appellera ensuite la classe ProjectLocalRepository dans la couche Infrastructure).