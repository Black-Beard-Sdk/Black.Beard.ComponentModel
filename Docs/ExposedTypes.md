# Resolve exposed type

You must add the package for access to ExposeClassAttribute
```SH
    Install-Package Black.Beard.ComponentModel.Attributes
```

## Case 1
```CSHARP

    // And now add attribute on the class
    // You can categorize the exposed types
    [ExposeClass("my context name", ExposedType = typeof(Test1), LifeCycle = IocScopeEnum.Singleton, Name = "test 1")]
    public class ClassToExpose : Test1
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

## Case 2
```CSHARP

        [ExposeClass(ConstantsCore.Initialization,
        ExposedType = typeof(IInjectBuilder<MyContext>))]
        public class InjectBuilder : IInjectBuilder<MyContext>
        {


            public object Run(object context)
            {
                return Run((MyContext)context);
            }


            public object Run(MyContext context)
            {
                // do action
                return null;
            }


        }

        public class MyContext
        {


        }


        // Looking for exposed class
        var items = ExposedTypes.Instance
            .GetTypes(ConstantsCore.Initialization, typeof(IInjectBuilder<MyContext>))
            .Where(c => typeof(IInjectBuilder<MyContext>).IsAssignableFrom(c.Key))
            .ToList()
                ;

        var ctx = new MyContext();
        foreach (var item in items)
        {
            var instance = (IInjectBuilder<MyContext>)Activator.CreateInstance(item.Key);
            instance.Run(ctx);
        }

```