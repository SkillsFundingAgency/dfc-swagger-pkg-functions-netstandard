using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NSubstitute;
using NUnit.Framework;

namespace DFC.Swagger.Standard.Tests
{
    public class SwaggerDocumentGeneratorTests
    {
        private ISwaggerDocumentGenerator _swaggerDocumentGenerator;
        private HttpRequest _request;
        private Assembly _assembly;
        private const string ApiTitle = "OpenAPI 2 - Swagger";
        private const string ApiDescription = ApiTitle + " Description";
        private const string ApiDefinitionName = "Swagger Generator";

        [SetUp]
        public void Setup()
        {
            _swaggerDocumentGenerator = Substitute.For<ISwaggerDocumentGenerator>();
            _request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                ContentType = "application/json",
            };
            _assembly = Assembly.GetExecutingAssembly();
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullHttpRequest_ThrowsArgumentNullException()
        {
            _swaggerDocumentGenerator
                .GenerateSwaggerDocument(null, ApiTitle, ApiDescription, ApiDefinitionName, _assembly)
                .Returns(x=> throw new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() =>
                _swaggerDocumentGenerator
                    .GenerateSwaggerDocument(null, ApiTitle, ApiDescription, ApiDefinitionName, _assembly));
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullTitle_ThrowsArgumentNullException()
        {
            _swaggerDocumentGenerator.GenerateSwaggerDocument(_request, null, ApiDescription, ApiDefinitionName, _assembly)
                .Returns(x => throw new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() =>
                _swaggerDocumentGenerator
                    .GenerateSwaggerDocument(_request, null, ApiDescription, ApiDefinitionName, _assembly));
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullAPIDescription_ThrowsArgumentNullException()
        {
            _swaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, null, ApiDefinitionName, _assembly)
                .Returns(x => throw new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() =>
                _swaggerDocumentGenerator
                    .GenerateSwaggerDocument(_request, ApiTitle, null, ApiDefinitionName, _assembly));
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullApiDefinitionName_ThrowsArgumentNullException()
        {
            _swaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, null, _assembly)
                .Returns(x => throw new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() =>
                _swaggerDocumentGenerator
                    .GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, null, _assembly));
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithNullAssembly_ThrowsArgumentNullException()
        {
            _swaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, ApiDefinitionName, null)
                .Returns(x => throw new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() =>
                _swaggerDocumentGenerator
                    .GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, ApiDefinitionName, null));
        }

        [Test]
        public void SwaggerDocumentGenerator_WhenCalledWithValidParams_ReturnsSwaggerDoc()
        {
            var response =
                _swaggerDocumentGenerator.GenerateSwaggerDocument(_request, ApiTitle, ApiDescription, ApiDefinitionName, _assembly);

            Assert.IsNotNull(response);
        }
    }
}