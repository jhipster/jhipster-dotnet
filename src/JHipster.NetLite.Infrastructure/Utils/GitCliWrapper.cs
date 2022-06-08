using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastructure.Utils;

public class GitCliWrapper
{
    private const string GitName = "JHipster";

    private const string GitEmail = "ugo.vignon@gmail.com";

    private readonly ProcessStartInfo processStartInfo = new ProcessStartInfo();

    private readonly ILogger<IInitDomainService> _logger;

    public GitCliWrapper(string workingDirectory, ILogger<IInitDomainService> logger)
    {
        _logger = logger;
        InitializeProcessStartInfo(workingDirectory);
        HasGit();
    }

    private void InitializeProcessStartInfo(string workingDirectory)
    {
        processStartInfo.FileName = "git"; //NOSONAR
        processStartInfo.UseShellExecute = false;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;
        processStartInfo.WorkingDirectory = workingDirectory;
    }

    private void HasGit()
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
            _logger.LogError($"Git is not installed : {e.Message}");
            throw new ExecutableNotFoundException(e.Message);
        }
    }

    public GitCliWrapper Init()
    {
        processStartInfo.Arguments = "init";

        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();

        return this;
    }

    public GitCliWrapper AddAll()
    {
        Process process = new Process();
        processStartInfo.Arguments = $"add -A";
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();

        return this;
    }

    public GitCliWrapper Commit(string message)
    {
        Process process = new Process();
        processStartInfo.Arguments = $"commit -m \"{message}\" --author=\"{GitName} <{GitEmail}>\"";
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();

        return this;
    }

    public ArrayList GetCommits()
    {
        ArrayList commits = new ArrayList();
        StringBuilder sb = new StringBuilder();
        int nbCommitInfo = 0;

        Process process = new Process();
        processStartInfo.Arguments = "log";
        process.StartInfo = processStartInfo;

        process.OutputDataReceived += (sender, args) =>
        {
            sb.AppendLine(args.Data);
            nbCommitInfo++;

            if (nbCommitInfo == 6)
            {
                nbCommitInfo = 0;
                commits.Add(sb.ToString());
                sb.Clear();
            }
        };
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();

        return commits;
    }
}
