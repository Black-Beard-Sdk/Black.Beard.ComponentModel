using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.DataAnnotations;
using Bb.ComponentModel.Translations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.ComponentDescriptors
{


    [ExposeClass("Service", ExposedType = typeof(EnumListProvider), LifeCycle = IocScopeEnum.Transiant)]
    public class EnumListProvider : ProviderListBase<object>
    {


        public EnumListProvider(ITranslateService translateService)
        {
            this.TranslateService = translateService;
        }

        public ITranslateService TranslateService { get; set; }


        public override IEnumerable<ListItem<object>> GetItems()
        {
            
            List<ListItem<object>> result = new List<ListItem<object>>();

            var values = Enum.GetValues(Property.PropertyType);
            var fields = Property.PropertyType.GetFields();

            foreach (var item in values)
            {

                var n = item.ToString();
                var display = item.ToString();
                System.Reflection.FieldInfo o = fields.Where(f => f.Name == display).First();
                TranslatedKeyLabel label = o.GetFrom().FirstOrDefault() ?? display;
                if (TranslateService != null)
                    display = TranslateService.Translate(label);
                else
                    display = label.DefaultDisplay;
                
                result.Add(CreateItem(item, n, display, c =>
                {
                    c.Name = n;
                }));

            }

            return result;

        }

    }

}

public class EnumListProvider1<T> : ProviderListBase<T>
    where T : Enum
{


    public EnumListProvider1(ITranslateService translateService)
    {
        this.TranslateService = translateService;
    }

    public ITranslateService TranslateService { get; set; }


    public override IEnumerable<ListItem<T>> GetItems()
    {

        List<ListItem<T>> result = new List<ListItem<T>>();

        var values = Enum.GetValues(Property.PropertyType);
        var fields = Property.PropertyType.GetFields();

        foreach (T item in values)
        {

            var n = item.ToString();
            var display = item.ToString();
            System.Reflection.FieldInfo o = fields.Where(f => f.Name == display).First();
            TranslatedKeyLabel label = o.GetFrom().FirstOrDefault() ?? display;
            if (TranslateService != null)
                display = TranslateService.Translate(label);
            else
                display = label.DefaultDisplay;

            result.Add(CreateItem(item, n, display, c =>
            {
                c.Name = n;
            }));

        }

        return result;

    }



}


