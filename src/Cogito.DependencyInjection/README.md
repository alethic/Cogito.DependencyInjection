# Cogito.DependencyInjection

Attribute-driven registration for `Microsoft.Extensions.DependencyInjection`.

## Why

The same argument as any attribute-based registration: a service's lifetime belongs next to the
service, not in a startup file that every feature has to edit. If you are already using
`Cogito.Autofac`'s attributes, these give you the equivalent without taking an Autofac dependency.

## Install

```shell
dotnet add package Cogito.DependencyInjection
```

## Use

Declare the lifetime on the implementation:

```csharp
[AddSingletonService<IGreeter>]
public class Greeter : IGreeter
{
    public string Greet(string name) => $"Hello, {name}.";
}
```

then scan:

```csharp
services.AddFromAttributes(typeof(Greeter).Assembly);
```

Available as generic and non-generic forms, for each lifetime and for keyed services:
`AddSingletonService`, `AddScopedService`, `AddTransientService`, `AddKeyedSingletonService`,
`AddKeyedScopedService`, `AddKeyedTransientService`.

Implement `IServiceRegistrationAttribute` for a registration these do not cover.

## License

MIT.
