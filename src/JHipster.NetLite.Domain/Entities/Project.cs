namespace JHipster.NetLite.Domain.Entities;

public class Project
{
    public Project(string folder, string @namespace, string projectName, string sslPort)
    {
        Folder = folder;
        Namespace = @namespace;
        ProjectName = projectName;
        SslPort = sslPort;
    }

    public string Folder { get; set; }

    public string Namespace { get; set; }

    public string ProjectName { get; set; }

    public string SslPort { get; set; }
}
