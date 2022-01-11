using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ServiceLayer.Tests
{
    public class DirectoryServicesValidationTests: IClassFixture<DirectoryServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private DirectoryServicesFixture _directoryServicesFixture;

        public DirectoryServicesValidationTests(DirectoryServicesFixture directoryServicesFixture, ITestOutputHelper testOutputHelper)
        {
            this._directoryServicesFixture = directoryServicesFixture;
            this._testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
        {
            var exception = Record.Exception(() => _directoryServicesFixture.DirectoryServices.ValidateModel(_directoryServicesFixture.DirectoryModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        private void ShouldThrowExceptionIfDirectoryEmpty()
        {
            _directoryServicesFixture.DirectoryModel.DirectoryPath = "";

            var exception = Assert.Throws<ArgumentException>(testCode: () => _directoryServicesFixture.DirectoryServices.ValidateModel(_directoryServicesFixture.DirectoryModel));

            WriteExceptionTestResult(exception);
        }

        private void SetValidSampleValues()
        {
            _directoryServicesFixture.DirectoryModel.DirectoryPath = "C:/Anime";
        }

        private void WriteExceptionTestResult(Exception exception)
        {
            if(exception != null)
            {
                _testOutputHelper.WriteLine(exception.Message);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                JObject json = JObject.FromObject(_directoryServicesFixture.DirectoryModel);
                stringBuilder.Append("****** No Exception Was Thrown ******").AppendLine();
                foreach(JProperty property in json.Properties())
                {
                    stringBuilder.Append(property.Name).Append(" --> ").Append(property.Value).AppendLine();   
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }
    }
}
