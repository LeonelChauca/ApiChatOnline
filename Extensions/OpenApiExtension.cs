
using Microsoft.OpenApi.Models;

namespace ApiChatOnline.Extensions
{
    public static class OpenApiExtension
    {
        public static IServiceCollection AddJwtOpenApi(this IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    var scheme = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        Description = "Pega tu token JWT aquí: solo el token, sin la palabra 'Bearer'"
                    };

                    document.Components ??= new OpenApiComponents();
                    document.Components.SecuritySchemes["Bearer"] = scheme;

                    document.SecurityRequirements = new List<OpenApiSecurityRequirement>
                    {
                        new OpenApiSecurityRequirement
                        {
                            [ new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                }
                            ] = Array.Empty<string>()
                        }
                    };

                    return Task.CompletedTask;
                });
            });

            return services;
        }
    }
}