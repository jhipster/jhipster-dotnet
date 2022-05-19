using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Infrastructure.Helpers;
using JHipster.NetLite.Infrastucture.Repositories.Exceptions;
using Microsoft.Extensions.Logging;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Infrastructure.Utils;
using System.Text;
using System.Reflection;
using JHipster.NetLite.Infrastructure.Repositories.Exceptions;

namespace JHipster.NetLite.Infrastructure.Repositories;

public class ProjectLocalRepository : IProjectRepository
{
    private const string InitialCommitMessage = "Initial commit.";

    private readonly string DefaultFolder = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Templates");

    private readonly ILogger<IInitDomainService> _logger;

    public ProjectLocalRepository(ILogger<IInitDomainService> logger) => _logger = logger;

    public async Task Add(string folder, string source, string sourceFilename)
    {
        await Add(folder, source, sourceFilename, ".");
    }

    public async Task Add(string folder, string source, string sourceFilename, string destination)
    {
        await Add(folder, source, sourceFilename, destination, sourceFilename);
    }

    public async Task Add(string folder, string source, string sourceFilename, string destination, string destinationFilename)
    {
        _logger.LogInformation($"Adding file '{destinationFilename}'");
        var folders = source.Split(Path.DirectorySeparatorChar);
        string destinationFolder = Path.Join(folder, destination);
        var foldersPath = destinationFolder;

        string dataToCopy = await File.ReadAllTextAsync(Path.Join(DefaultFolder, source, sourceFilename));

        Directory.CreateDirectory(Path.Join(destinationFolder));
        if (folders.Length >= 2)
        {
            for (int i = 1; i < folders.Length; i++)
            {
                foldersPath = Path.Join(foldersPath, folders[i]);
                Directory.CreateDirectory(foldersPath);
            }
        }
        string destinationPath = Path.Join(foldersPath, destinationFilename);

        await File.WriteAllTextAsync(destinationPath, dataToCopy);

        await AssertFileIsGenerated(destinationPath, dataToCopy);
    }

    public async Task Template(Project project, string pathFile, string fileNameWithExtension)
    {
        await Template(project, pathFile, fileNameWithExtension, ".");
    }

    public async Task Template(Project project, string pathFile, string fileNameWithExtension, string newPathFile)
    {
        await Template(project, pathFile, fileNameWithExtension, newPathFile, fileNameWithExtension);
    }

    public async Task Template(Project project, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {
        AssertRequiredTemplateParameters(project.Folder, pathFile, fileNameWithExtension, newPathFile, newPathName);

        var folders = pathFile.Split(Path.DirectorySeparatorChar);
        string pathFileToCopy = Path.Join(DefaultFolder, pathFile, MustacheHelper.WithExt(fileNameWithExtension));
        string pathFolderToCreate = Path.Join(project.Folder, newPathFile);

        _logger.LogInformation($"Starting templating '{pathFileToCopy}'");

        if (folders.Length >= 2)
        {
            for (int i = 1; i < folders.Length; i++)
            {
                pathFolderToCreate = Path.Join(pathFolderToCreate, folders[i]);
            }
        }
        Directory.CreateDirectory(pathFolderToCreate);
        string pathFileToPaste = Path.Join(pathFolderToCreate, newPathName);

        var dataToPast = await MustacheHelper.Template(pathFileToCopy, project);
        await File.WriteAllTextAsync(pathFileToPaste, dataToPast);

        await AssertFileIsGenerated(pathFileToPaste, dataToPast);

        _logger.LogInformation($"Ending templating '{pathFileToPaste}'");
    }

    public void InitGit(Project project)
    {
        var gitCli = new GitCliWrapper(project.Folder, project.GitName, project.GitEmail, _logger);
        gitCli.Init();
        gitCli.AddAll();
        gitCli.Commit(InitialCommitMessage);
    }

    public void GenerateSolution(Project project, string solutionName)
    {
        DotnetCliWrapper dotnetCLIWrapper = new DotnetCliWrapper(project.Folder, _logger);
        dotnetCLIWrapper.NewSln(solutionName, true);

        AssertSlnIsGenerated(project.Folder, solutionName + DotnetCliWrapper.SolutionExtension);
    }

    public void AddProjectsToSolution(Project project, string solutionFile, params string[] projects)
    {
        DotnetCliWrapper dotnetCLIWrapper = new DotnetCliWrapper(project.Folder, _logger);
        dotnetCLIWrapper.SlnAdd(solutionFile, projects);
    }

    public void StartUnitsTests(Project project)
    {
        var srcFolder = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "..");
        DotnetCliWrapper dotnetCLIWrapper = new DotnetCliWrapper(srcFolder, _logger);
        dotnetCLIWrapper.Tests();
    }

    private async Task AssertFileIsGenerated(string pathFileGenerated, string data)
    {
        string dataFileGenerated;

        if (!File.Exists(pathFileGenerated))
        {
            _logger.LogError($"error generation of file '{pathFileGenerated}'");
            throw new GenerationException($"error generation of file {pathFileGenerated}");
        }

        dataFileGenerated = await File.ReadAllTextAsync(pathFileGenerated);

        if (!dataFileGenerated.Equals(data))
        {
            _logger.LogError($"error generation file '{pathFileGenerated}'");
            throw new GenerationException($"error generation file {pathFileGenerated}");
        }
    }

    private void AssertSlnIsGenerated(string path, string solutionName)
    {
        if (!File.Exists(Path.Join(path, solutionName)))
        {
            _logger.LogError($"error generation dotnet solution '{solutionName}'");
            throw new GenerationException($"error generation dotnet solution '{solutionName}'");
        }
    }

    private void AssertRequiredTemplateParameters(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {
        if (string.IsNullOrEmpty(folder))
        {
            _logger.LogError($"The folder '{folder}' is invalid");
            throw new InvalidFolderException($"The folder '{folder}' is invalid");
        }

        if (string.IsNullOrEmpty(pathFile))
        {
            _logger.LogError($"The file path '{pathFile}' is invalid");
            throw new InvalidPathFileException($"The file path '{pathFile}' is invalid");
        }

        if (string.IsNullOrEmpty(fileNameWithExtension))
        {
            _logger.LogError($"The file name with extension '{fileNameWithExtension}' is invalid");
            throw new InvalidFileNameWithExtensionException($"The file name with extension '{fileNameWithExtension}' is invalid");
        }

        if (string.IsNullOrEmpty(newPathFile))
        {
            _logger.LogError($"The new path file '{newPathFile}' is invalid");
            throw new InvalidNewPathFileException($"The new path file '{newPathFile}' is invalid");
        }

        if (string.IsNullOrEmpty(newPathName))
        {
            _logger.LogError($"The new path name '{newPathName}' is invalid");
            throw new InvalidNewPathNameException($"The new path name '{newPathName}' is invalid");
        }
    }
}
