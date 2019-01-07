using System;
using Microsoft.Azure.WebJobs.Description;

namespace DFC.Swagger.Core.Annotations
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
