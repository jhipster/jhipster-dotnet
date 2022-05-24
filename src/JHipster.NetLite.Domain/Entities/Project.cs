namespace JHipster.NetLite.Domain.Entities;

public class Project
{
    public Project(string folder, string @namespace, string projectName, string sslPort, string gitName, string gitEmail)
    {
        Folder = folder;
        Namespace = @namespace;
        ProjectName = projectName;
        SslPort = sslPort;
        GitName = gitName;
        GitEmail = gitEmail;
    }

    public string Folder { get; set; }

    public string Namespace { get; set; }

    public string ProjectName { get; set; }

    public string SslPort { get; set; }

    public string GitName { get; set; }

    public string GitEmail { get; set; }
}
