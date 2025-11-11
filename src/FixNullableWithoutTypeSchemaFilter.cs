using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType;

/// <summary>
/// A schema filter sets the type to object for any OpenAPI schema marked as nullable but lacking a defined type.
/// </summary>
public sealed class FixNullableWithoutTypeSchemaFilter : ISchemaFilter
{
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        var mutable = (OpenApiSchema)schema;

        if (mutable.Type == JsonSchemaType.Null)
            mutable.Type = JsonSchemaType.Object; // default fallback
    }
}