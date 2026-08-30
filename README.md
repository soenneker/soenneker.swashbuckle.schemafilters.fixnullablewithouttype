[![](https://img.shields.io/nuget/v/soenneker.swashbuckle.schemafilters.fixnullablewithouttype.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.swashbuckle.schemafilters.fixnullablewithouttype/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.swashbuckle.schemafilters.fixnullablewithouttype/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.swashbuckle.schemafilters.fixnullablewithouttype/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.swashbuckle.schemafilters.fixnullablewithouttype.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.swashbuckle.schemafilters.fixnullablewithouttype/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.swashbuckle.schemafilters.fixnullablewithouttype/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.swashbuckle.schemafilters.fixnullablewithouttype/actions/workflows/codeql.yml)

# Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType

Repairs null-only OpenAPI schema placeholders by giving them an `object | null` type.

## Installation

```bash
dotnet add package Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType
```

## Registration

```csharp
using Soenneker.Swashbuckle.SchemaFilters.FixNullableWithoutType;

builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<FixNullableWithoutTypeSchemaFilter>();
});
```

The filter acts only when Swashbuckle produces a mutable schema whose type is exactly `null`. It changes that type to the OpenAPI 3.1 union of `object` and `null`:

```yaml
type:
  - object
  - "null"
```

Schemas that already have a concrete type, including existing nullable unions, are left unchanged. Schema references are also left unchanged rather than being replaced or resolved by this filter.

Use this as a targeted compatibility filter when generated documents contain null-only schemas that downstream validators or client generators cannot use. It does not affect runtime model binding or JSON serialization.
