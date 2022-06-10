using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories.Exceptions;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace JHipster.NetLite.Infrastructure.Utils;

public class DotnetCliWrapper
{
    private readonly ProcessStartInfo processStartInfo = new ProcessStartInfo();

    private readonly ILogger<IInitDomainService> _logger;

    public const string SolutionExtension = ".sln";

    private const string ProjectExtension = ".csproj";

    public DotnetCliWrapper(string workingDirectory, ILogger<IInitDomainService> logger)
    {
        _logger = logger;
        InitializeProcessStartInfo(workingDirectory);
        HasDotnet();
    }

    private void InitializeProcessStartInfo(string workingDirectory)
    {
        processStartInfo.FileName = "dotnet"; //NOSONAR
        processStartInfo.UseShellExecute = false;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;
        processStartInfo.WorkingDirectory = workingDirectory;
    }

    private void HasDotnet()
    {
        try
        {
            processStartInfo.Arguments = "--version";

            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
        }
        catch (Exception e)
        {
            _logger.LogError($"Dotnet is not installed : {e.Message}");
            throw new ExecutableNotFoundException(e.Message);
        }
    }

    public void NewSln(string solutionName, bool force)
    {
        if (force)
        {
            processStartInfo.Arguments = $"new sln --name {solutionName} --force";
        }
        else
        {
            processStartInfo.Arguments = $"new sln --name {solutionName}";
        }

        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();
    }

    public void SlnAdd(string solutionFile, params string[] projects)
    {
        processStartInfo.Arguments = $"sln {solutionFile + SolutionExtension} add";
        foreach (string project in projects)
        {
            processStartInfo.Arguments = $"{processStartInfo.Arguments} {project + ProjectExtension}";
        }
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();
    }

    public void Build()
    {
        processStartInfo.Arguments = "build";
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();
    }

    public void Tests()
    {
        processStartInfo.Arguments = "test";
        Process process = new Process();
        process.StartInfo = processStartInfo;
        _logger.LogInformation("launching unit tests");
        process.OutputDataReceived += (sender, args) => _logger.LogInformation(args.Data);
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();
    }
}
