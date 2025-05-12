using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType;

/// <summary>
/// A schema filter sets the type to object for any OpenAPI schema marked as nullable but lacking a defined type.
/// </summary>
public sealed class FixNullableWithoutTypeSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema is {Nullable: true, Type: null})
        {
            schema.Type = "object"; // default fallback
        }
    }
}