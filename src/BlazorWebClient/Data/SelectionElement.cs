namespace BlazorWebClient.Data;

public class SelectionElement
{
    public const string InitializationReference = "Initialization";

    public const string LanguageReference = "Language";

    public const string ClientReference = "Client";

    public const string SonarReference = "Sonar";

    public const string GithubActionReference = "GithubAction";

    public string Name { get; set; }

    public string Reference { get; }

    public SelectionElement(string name, string reference)
    {
        Name = name;
        Reference = reference;
    }
}
