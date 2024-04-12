# Black.Beard.ComponentModel

[![Build status](https://ci.appveyor.com/api/projects/status/2vvwy6m9dkr50du7?svg=true)](https://ci.appveyor.com/project/gaelgael5/black-beard-componentmodel)


## PropertyDescriptors
Method helper for resolve types and methods.

[PropertyDescriptor.md](./Docs/PropertyTypeDescriptor.md)


## Auto discovering

Method helper for resolve types and methods.

[Exposing class for auto discovering.md](./Docs/ExposedTypes.md)

## factory for create fast activator & fast method calling
[Factory.md](./Docs/factory.md)

## Provider List

```Csharp

    // the provider that provide the list of items
    public class TestProviderList : ProviderListBase<CultureInfo>
    {

        /// <summary>
        /// Get the list of items
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ListItem<CultureInfo>> GetItems()
        {

            List<ListItem<CultureInfo>> result = new List<ListItem<CultureInfo>>();

            var items = CultureInfo.GetCultures(CultureTypes.AllCultures);

            foreach (var item in items)
            {
                var tag = item;
                var display = item.EnglishName;
                var key = item.IetfLanguageTag;

                result.Add(CreateItem(tag, display, key, a =>
                {
                    a.Name = item.Name;
                }));
            }
            return result;

        }

    }

    // a class that use the provider
    public class Class1
    {
        [ListProvider(typeof(TestProviderList))]
        public CultureInfo Culture { get; set; }
    }

    // code for call the list provider
    var class1 = new Class1()
    {
        Culture = CultureInfo.CurrentCulture,
    };

    var property = typeof(Class1).GetPropertyDescriptors("Culture").First();
    var attribute = property.GetAttribute<ListProviderAttribute>();
    var provider = attribute.GetProvider(property, class1);
    var items = provider.GetItems();

    var current = items.First(c => c.Selected);
    
```


