using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Features;

public static class FeatureConfiguration
{
    // Register all the validators from the features here.
    private static void RegisterAllValidators(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        // TODO: register FluentValidation validators here, e.g.
        // services.AddSingleton<IValidator<CreateFoo.Command>, CreateFoo.Validator>();
    }

    // Register all the features (MediatR handlers) here.
    public static void RegisterAllFeatures(IServiceCollection services)
    {
        // TODO: register MediatR handlers here, e.g.
        // services.AddTransient<IRequestHandler<CreateFoo.Command, FooModel>, CreateFoo.Handler>();

        RegisterAllValidators(services);
    }
}
