This repository demonstrates a bug in the 05/14/18 C# [Nullable Reference Types Preview](https://github.com/dotnet/csharplang/wiki/Nullable-Reference-Types-Preview) with Visual Studio 2017 15.7.1.

# Project Setup

It features two assemblies:

* `InterfaceLibrary`
* `TestCs8614`

`TestCs8614` has a reference to `InterfaceLibrary`.

There are two interfaces defined: `IInterfaceInThisAssembly` and `IInterfaceInOtherAssembly`.

The former is defined in `TestCs8614`, the latter in `InterfaceLibrary`. They are both identical, defining a single method with the signature `void Test(int?)`.

An implementation is defined for each interface: `ImplementsThisAssemblyInterface` and `ImplementsOtherAssemblyInterface` respectively.

They are both defined in `TestCs8614`.

# Actual Behavior

The implementation of `ImplementsThisAssemblyInterface` exhibits no compiler warnings.

The implementation of `ImplementsOtherAssemblyInterface` exhibits the following compiler warning on the implementation of the `Test` method:

```
warning CS8614: Nullability of reference types in type of parameter 'nullableInt' doesn't match implicitly implemented member 'void 
```

# Expected Behavior

It is expected that the implementation of `Test` on `ImplementsOtherAssemblyInterface` does not exhibit `CS8614`.
