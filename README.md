# JHipster Dotnet 🔥
[![Sonar Cloud Quality Gate][sonar-gate-image]][sonar-url]
[![Sonar Cloud Reliability Rate][sonar-reliability-image]][sonar-url]
[![Sonar Cloud Security Rate][sonar-security-image]][sonar-url]
[![Sonar Cloud Maintainability Rate][sonar-maintainability-image]][sonar-url]
[![Sonar Cloud Duplicated Code][sonar-duplication-image]][sonar-url]

> JHipster generator

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

[sonar-url]: https://sonarcloud.io/dashboard?branch=main&id=jhipster_jhipster-dotnet
[sonar-coverage-url]: https://sonarcloud.io/component_measures?branch=main&id=jhipster_jhipster-dotnet&metric=coverage&view=list
[sonar-gate-image]: https://sonarcloud.io/api/project_badges/measure?branch=main&project=jhipster_jhipster-dotnet&metric=alert_status
[sonar-coverage-image]: https://sonarcloud.io/api/project_badges/measure?branch=main&project=jhipster_jhipster-dotnet&metric=coverage
[sonar-reliability-image]: https://sonarcloud.io/api/project_badges/measure?branch=main&project=jhipster_jhipster-dotnet&metric=reliability_rating
[sonar-security-image]: https://sonarcloud.io/api/project_badges/measure?branch=main&project=jhipster_jhipster-dotnet&metric=security_rating
[sonar-maintainability-image]: https://sonarcloud.io/api/project_badges/measure?branch=main&project=jhipster_jhipster-dotnet&metric=sqale_rating
[sonar-duplication-image]: https://sonarcloud.io/api/project_badges/measure?branch=main&project=jhipster_jhipster-dotnet&metric=duplicated_lines_density