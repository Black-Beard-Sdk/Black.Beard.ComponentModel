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
