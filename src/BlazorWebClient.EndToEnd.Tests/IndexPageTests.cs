using FluentAssertions;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorWebClient.EndToEnd.Tests
{
    [TestClass]
    public class IndexPageTests
    {
        private const string PathApplication = "https://localhost:7050";

        private const float GenerationWaitTime = 5000f;

        private string _generationFolderTestMessage = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Test");

        public IndexPageTests()
        {
            Microsoft.Playwright.Program.Main(new string[] { "install" });
        }

        [TestMethod]
        public async Task Should_ShowErrorsMessage_When_EmptyForm()
        {
            //Arrange
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync(PathApplication);
            await page.ClickAsync("#submitter");

            //Act
            var nbElements = await page.Locator(".validation-message").CountAsync();

            //Assert
            nbElements.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Should_Generate_When_CallApi()
        {
            //Arrange
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync(PathApplication);

            //Act
            await page.TypeAsync("#folder", _generationFolderTestMessage, new PageTypeOptions { Delay = 50 });
            await page.ClickAsync("#submitter");
            await page.WaitForTimeoutAsync(GenerationWaitTime);

            //Assert
            new DirectoryInfo(_generationFolderTestMessage).GetFiles().Length.Should().BeGreaterThan(0);

            var directory = new DirectoryInfo(_generationFolderTestMessage) { Attributes = FileAttributes.Normal };

            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }

            directory.Delete(true);
        }
    }
}
