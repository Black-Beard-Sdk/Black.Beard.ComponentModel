# Resolve exposed type

You must add the package for access to ExposeClassAttribute
```SH
    Install-Package Black.Beard.ComponentModel.Attributes
```

```CSHARP

    // And now add attribute on the class
    // You can categorize the exposed types
    [ExposeClass("my context name", ExposedType = typeof(Test1), LifeCycle = IocScopeEnum.Singleton, Name = "test 1")]
    public class ClassToExpose
    {

    }
```


You must add the package resolve the exposed types
```SH
    Install-Package Black.Beard.ComponentModel
```

```CSHARP

    // Now you acces to exposed type by this method
    ExposedTypes.Instance
        .GetTypes("my context name")
        .ToList()
        ;



```