using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType;

/// <summary>
/// A schema filter sets the type to object for any OpenAPI schema marked as nullable but lacking a defined type.
/// </summary>
public sealed class FixNullableWithoutTypeSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Replaces a null-only placeholder type with an object-or-null schema.
    /// </summary>
    /// <param name="schema">Schema to read or generate.</param>
    /// <param name="context">Context for the schema being generated.</param>
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema is not OpenApiSchema mutable)
            return;

        if (mutable.Type == JsonSchemaType.Null)
            mutable.Type = JsonSchemaType.Object | JsonSchemaType.Null;
    }
}
