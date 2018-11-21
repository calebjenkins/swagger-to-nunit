using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Swagger_to_nunit
{
    public class SwaggerJson
    {
        public List<TestsContainer> TestsContainers { get; set; }

        public void CreateTests(string nameSpace, string directoryToSave)
        {
            if (nameSpace == null)
                nameSpace = "Api.Tests";

            if (directoryToSave == null)
                directoryToSave = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Tests");

            if (!Directory.Exists(directoryToSave))
                Directory.CreateDirectory(directoryToSave);

            TestsContainers.ForEach(test => File.WriteAllText($@"{directoryToSave}\{test.ApiPath}.cs", test.ClassRepresentation(nameSpace)));
        }
    }
}
