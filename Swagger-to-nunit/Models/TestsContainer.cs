using System;
using System.Collections.Generic;
using System.Text;

namespace Swagger_to_nunit
{
    public class TestsContainer
    {
        public string ApiPath { get; set; }
        public List<TestModel> TestModels { get; set; }

        public string ClassRepresentation(string nameSpace)
        {
           
                var tests = "";
                var uses = "using NUnit.Framework; \r\nusing System.Net; \r\n";
                nameSpace = $"namespace {nameSpace} \r\n{{ ";
                TestModels.ForEach(test => tests = $"{tests}{test.StringRepresantation()}");

                var className = $"{uses}{nameSpace}\r\npublic class {ApiPath}\r\n{{{tests} \r\n}}\r\n}}";

                return className;
        }
    }
}
