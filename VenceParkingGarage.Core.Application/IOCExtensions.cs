using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using MediatR;

namespace VenceParkingGarage.Core.Application
{
    public static class IOCExtensions
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
