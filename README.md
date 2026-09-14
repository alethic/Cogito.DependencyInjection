# Cogito.DependencyInjection

[![Build](https://github.com/alethic/Cogito.DependencyInjection/actions/workflows/Cogito.DependencyInjection.yml/badge.svg)](https://github.com/alethic/Cogito.DependencyInjection/actions/workflows/Cogito.DependencyInjection.yml)

Attribute-driven registration for Microsoft.Extensions.DependencyInjection.

## Packages

**[Cogito.DependencyInjection](https://www.nuget.org/packages/Cogito.DependencyInjection)** — Attribute-driven registration for `Microsoft.Extensions.DependencyInjection`.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.DependencyInjection.sln
dotnet msbuild -p:Configuration=Release Cogito.DependencyInjection.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
