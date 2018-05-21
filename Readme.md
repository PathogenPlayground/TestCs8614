This repository demonstrates a bug in the 05/14/18 C# [Nullable Reference Types Preview](https://github.com/dotnet/csharplang/wiki/Nullable-Reference-Types-Preview) with Visual Studio 2017 15.7.1. It corresponds to [dotnet/roslyn#27008](https://github.com/dotnet/roslyn/issues/27008).

# Project Setup

It features two assemblies:

* `InterfaceLibrary`
* `TestCs8614`

`TestCs8614` has a reference to `InterfaceLibrary`.

There are two interfaces defined: [`IInterfaceInThisAssembly`](https://github.com/PathogenPlayground/TestCs8614/blob/c902cd9873faef4945b89e5665c6cb7dd4c6302a/TestCs8614/Program.cs#L6-L9) and [`IInterfaceInOtherAssembly`](https://github.com/PathogenPlayground/TestCs8614/blob/c902cd9873faef4945b89e5665c6cb7dd4c6302a/InterfaceLibrary/IInterfaceInOtherAssembly.cs#L3-L6).

The former is defined in `TestCs8614`, the latter in `InterfaceLibrary`. They are both identical, defining a single method with the signature `void Test(int?)`.

An implementation is defined for each interface: [`ImplementsThisAssemblyInterface`](https://github.com/PathogenPlayground/TestCs8614/blob/c902cd9873faef4945b89e5665c6cb7dd4c6302a/TestCs8614/Program.cs#L11-L16) and [`ImplementsOtherAssemblyInterface`](https://github.com/PathogenPlayground/TestCs8614/blob/c902cd9873faef4945b89e5665c6cb7dd4c6302a/TestCs8614/Program.cs#L18-L24) respectively.

They are both defined in `TestCs8614`.

# Actual Behavior

The implementation of `ImplementsThisAssemblyInterface` exhibits no compiler warnings.

The implementation of `ImplementsOtherAssemblyInterface` exhibits the following compiler warning on the implementation of the `Test` method:

```
warning CS8614: Nullability of reference types in type of parameter 'nullableInt' doesn't match implicitly implemented member 'void 
```

# Expected Behavior

It is expected that the implementation of `Test` on `ImplementsOtherAssemblyInterface` does not exhibit `CS8614`.
