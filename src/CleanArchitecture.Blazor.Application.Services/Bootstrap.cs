using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Blazor.Application.Services;
public static class Bootstrap
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {


        // Define types that need matching
        var scopedRegistration = typeof(ScopedRegistrationAttribute);
        var singletonRegistration = typeof(SingletonRegistrationAttribute);
        var transientRegistration = typeof(TransientRegistrationAttribute);

        var types = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(p => p.IsDefined(scopedRegistration, false) || p.IsDefined(transientRegistration, false) || p.IsDefined(singletonRegistration, false) && !p.IsInterface)
    .Select(s => new
    {
        Service = s.GetInterface($"I{s.Name}"),
        Implementation = s
    })
    .Where(x => x.Service != null);

        foreach (var type in types)
        {
            if (type.Implementation.IsDefined(scopedRegistration, false))
            {
                services.AddScoped(type.Service, type.Implementation);
            }

            if (type.Implementation.IsDefined(transientRegistration, false))
            {
                services.AddTransient(type.Service, type.Implementation);
            }

            if (type.Implementation.IsDefined(singletonRegistration, false))
            {
                services.AddSingleton(type.Service, type.Implementation);
            }
        }

    }
}

public class ScopedRegistrationAttribute : Attribute { }

public class SingletonRegistrationAttribute : Attribute { }

public class TransientRegistrationAttribute : Attribute { }
