using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;

namespace DFC.Swagger.Standard.Tests
{
    public class SwaggerDocumentGeneratorTests
    {
        private HttpRequest _request;
        private Assembly _assembly;
        private const string ApiTitle = "OpenAPI 2 - Swagger";
        private const string ApiDescription = ApiTitle + " Description";
        private const string ApiDefinitionName = "Swagger Generator";

        [SetUp]
        public void Setup()
        {
            _request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                ContentType = "application/json",
            };
            _assembly = Assembly.GetExecutingAssembly();
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullHttpRequest_ThrowsArgumentNullException()
        {
            Assert.That(() => SwaggerDocumentGenerator.GenerateSwaggerDocument(null, ApiTitle, ApiDescription, ApiDefinitionName, _assembly),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullTitle_ThrowsArgumentNullException()
        {
            Assert.That(() => SwaggerDocumentGenerator.GenerateSwaggerDocument(_request, null, ApiDescription, ApiDefinitionName, _assembly),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullAPIDescription_ThrowsArgumentNullException()
        {
            Assert.That(() => SwaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, null, ApiDefinitionName, _assembly),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullApiDefinitionName_ThrowsArgumentNullException()
        {
            Assert.That(() => SwaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, null, _assembly),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullAssembly_ThrowsArgumentNullException()
        {
            Assert.That(() => SwaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, ApiDefinitionName, null),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithValidParams_ReturnsSwaggerDoc()
        {
            var response =
                SwaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, ApiDefinitionName, _assembly);

            Assert.IsNotNull(response);
        }
    }
}