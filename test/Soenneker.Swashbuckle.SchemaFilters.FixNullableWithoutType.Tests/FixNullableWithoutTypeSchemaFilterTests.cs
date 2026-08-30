using Microsoft.OpenApi;
using Soenneker.Tests.Unit;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;

namespace Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType.Tests;

public sealed class FixNullableWithoutTypeSchemaFilterTests : UnitTest
{
    [Test]
    public void Default()
    {

    }

    [Test]
    public void Apply_should_ignore_schema_references()
    {
        var filter = new FixNullableWithoutTypeSchemaFilter();
        var schema = new OpenApiSchemaReference("RequestDataOptions", new OpenApiDocument(), "3.0");
        var context = new SchemaFilterContext(typeof(string), null!, new SchemaRepository(), null, null);

        filter.Apply(schema, context);
    }

    [Test]
    public async Task Apply_should_preserve_nullability_when_adding_object_type()
    {
        var filter = new FixNullableWithoutTypeSchemaFilter();
        var schema = new OpenApiSchema { Type = JsonSchemaType.Null };
        var context = new SchemaFilterContext(typeof(object), null!, new SchemaRepository(), null, null);

        filter.Apply(schema, context);

        await Assert.That(schema.Type).IsEqualTo(JsonSchemaType.Object | JsonSchemaType.Null);
    }
}
