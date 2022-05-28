using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Repositories.Interfaces;

public interface IProjectRepository
{
    Task AddAsync(string folder, string source, string sourceFilename);

    Task AddAsync(string folder, string source, string sourceFilename, string destination);

    Task AddAsync(string folder, string source, string sourceFilename, string destination, string destinationFilename);

    Task TemplateAsync(Project project, string pathFile, string fileNameWithExtension);

    Task TemplateAsync(Project project, string pathFile, string fileNameWithExtension, string newPathFile);

    Task TemplateAsync(Project project, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName);

    void InitGit(Project project);

    void GenerateSolution(Project project, string solutionName);

    void AddProjectsToSolution(Project project, string solutionFile, params string[] projects);

    void StartUnitsTests(Project project);
}
