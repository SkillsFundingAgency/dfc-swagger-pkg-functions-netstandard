using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace DFC.Swagger.Standard
{
    public interface ISwaggerDocumentGenerator
    {
        string GenerateSwaggerDocument(HttpRequest req, string apiTitle, string apiDescription,
            string apiDefinitionName, string apiVersion, Assembly assembly, bool includeSubcontractorId = true, bool includeTouchpointId = true);
    }
}
