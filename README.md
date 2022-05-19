# JHipster Dotnet 🔥

## Description

JHipster is a development platform to quickly generate, develop & deploy modern web applications & microservice architectures.

**JHipster Dotnet** will help you to start your project, by generating step by step only what you need.

- you will only generate the code you want, no additional unused code

## Prettier

We use the dotnet CLI to format our code

To launch format all code:

- go to the src folder which contains the ".editorconfig" file
- run in command prompt: dotnet format

## Generate your project

Go to https://localhost:7107, select your option and generate the code you want, step by step, and only what you need.

If needed more advanced features, go to https://localhost:7107/swagger/index.html and use your own JSON to generate the code you want. Here an example:

<!-- prettier-ignore-start -->
```yaml
{
   "folder": "C:/Sample",
   "namespace": "sample",
   "projectName": "SampleProject",
   "sslPort": "12345",
   "GitName": "Jean.dupont",
   "GitEmail": "jean.dupont@gmail.com"
}
```
<!-- prettier-ignore-end -->

You can use the different existing APIs to:

- init the project

Sonar:

- Sonar analysis

Client:

- Blazor

Continuous Integration:

- GitHub Actions