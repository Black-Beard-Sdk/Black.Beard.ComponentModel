# Factory

For the following class

```CSHARP

private class Test1
{

    public Test1(string arg1, int arg2)
    {
        this.Arg1 = arg1;
        this.Arg2 = arg2;
    }

    public string Arg1 { get; }

    public int Arg2 { get; }

}

```

The factory is strongled typed
```CSHARP

var factory = ObjectCreator.GetActivatorByArguments<Test1>(typeof(string), typeof(int));

Test1 result = factory.Call(null, "t1", 1);

```


The factory is strongled typed
```CSHARP

object instance = ObjectCreator.GetActivatorByTypeAndArguments<object>(typeof(Test1), typeof(string), typeof(int));

Test1 result = (Test1)factory.Call(null, "t1", 1);

```

You can resolve the types of the arguments like that
```CSHARP
var types = ObjectCreator.ResolveTypesOfArguments("t2", 1);
```


You can create an instance of a class with the factory
```CSHARP

    var factory2 = ObjectCreatorByIoc.GetActivator<TestByIoc1>();
    var factory1 = ObjectCreatorByIoc.GetActivator<TestByIoc2>();

    var serviceProvider = new CustomIServiceProvider();
    serviceProvider.Add(factory1);
    serviceProvider.Add(factory2);

    var instance = factory1.CallInstance(serviceProvider);

```

