using HandlebarsDotNet;
using Humanizer;
using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Infrastructure.Helpers;

public static class MustacheHelper
{
    public const string Extension = ".mustache";

    public static async Task<string> Template(string filePath, Project project)
    {
        var source = await File.ReadAllTextAsync(filePath);
        var template = Handlebars.Compile(source);
        return template(new
        {
            projectName = project.ProjectName.Pascalize(),
            namespaceValue = project.Namespace,
            sslPort = project.SslPort
        });
    }

    public static string WithExt(string value)
    {
        if (!value.EndsWith(Extension))
        {
            return value + Extension;
        }

        return value;
    }

    public static string WithoutExt(string value)
    {
        if (value.EndsWith(Extension))
        {
            return value.Replace(Extension, "");
        }

        return value;
    }
}
