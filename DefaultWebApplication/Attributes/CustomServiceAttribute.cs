using Microsoft.Extensions.DependencyInjection;
using System;

namespace DefaultWebApplication.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomServiceAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; set; }
    }
}
