using System;
using System.IO;
using System.Linq;

namespace Swagger_to_nunit
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args[0].Contains("json") || !File.Exists(args[0]))
            {
                throw new ArgumentException("Please, check first argument: should be path to swagger.json file");
            }

            var json = args[0];
            string nameSpace = args.Length > 1 && args[1] == null ? args[1] : null;
            string directoryToSave = args.Length > 2 && args[2] == null ? args[2] : null;

            var swaggerModels = SwaggerJsonModel.CreateApiModels(json);

            swaggerModels.ForEach(model => SwaggerJsonModel.GetTests(model).CreateTests(nameSpace, directoryToSave));

            Console.WriteLine("Created");
        }
    }
}
