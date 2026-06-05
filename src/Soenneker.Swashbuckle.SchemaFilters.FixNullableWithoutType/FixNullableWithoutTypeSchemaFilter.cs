using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType;

/// <summary>
/// A schema filter sets the type to object for any OpenAPI schema marked as nullable but lacking a defined type.
/// </summary>
public sealed class FixNullableWithoutTypeSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Executes the apply operation.
    /// </summary>
    /// <param name="schema">The schema.</param>
    /// <param name="context">The context.</param>
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema is not OpenApiSchema mutable)
            return;

        if (mutable.Type == JsonSchemaType.Null)
            mutable.Type = JsonSchemaType.Object; // default fallback
    }
}
