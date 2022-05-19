namespace JHipster.NetLite.Domain.Entities;

public class Project
{
    private const string DefaultNamespace = "Smaple";

    private const string DefaultProjectName = "SampleProject";

    private const string DefaultSslPort = "12345";

    public Project(string folder, string @namespace, string projectName, string sslPort, string gitName, string gitEmail)
    {
        Folder = folder;

        if (string.IsNullOrEmpty(@namespace) || string.IsNullOrWhiteSpace(@namespace))
        {
            Namespace = DefaultNamespace;
        }
        else
        {
            Namespace = @namespace;
        }

        if (string.IsNullOrEmpty(projectName) || string.IsNullOrWhiteSpace(projectName))
        {
            ProjectName = DefaultProjectName;
        }
        else
        {
            ProjectName = projectName;
        }

        if (string.IsNullOrEmpty(sslPort) || string.IsNullOrWhiteSpace(sslPort))
        {
            SslPort = DefaultSslPort;
        }
        else
        {
            SslPort = sslPort;
        }

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
