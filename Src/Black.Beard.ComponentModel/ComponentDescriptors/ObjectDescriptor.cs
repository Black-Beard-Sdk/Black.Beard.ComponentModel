using Bb.ComponentModel.Translations;
using Bb.TypeDescriptors;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Bb.ComponentDescriptors
{

    public class ObjectDescriptor
    {

        public ObjectDescriptor(object instance,
            Type type,
            ITranslateService translateService,
            IServiceProvider serviceProvider,
            string strategyName,
            Func<PropertyDescriptor, bool> propertyDescriptorFilter = null,
            Func<PropertyObjectDescriptor, bool> propertyFilter = null)
        {
            this.StrategyName = strategyName;
            Instance = instance;
            _type = type;
            TranslateService = translateService;
            ServiceProvider = serviceProvider;
            _items = new List<PropertyObjectDescriptor>();
            _invaLidItems = new List<PropertyObjectDescriptor>();


            if (propertyDescriptorFilter != null)
                PropertyDescriptorFilter = propertyDescriptorFilter;
            else
                PropertyDescriptorFilter = (p) =>
                {
                    if (p is IDynamicActiveProperty i)
                        return i.IsActive(Instance);
                    return true;
                };

            if (propertyFilter != null)
                PropertyFilter = propertyFilter;
            else
                PropertyFilter = (p) => true;

            if (_type != null)
                Analyze();

        }


        public Func<PropertyDescriptor, bool> PropertyDescriptorFilter { get; }

        public Func<PropertyObjectDescriptor, bool> PropertyFilter { get; }

        private void Analyze()
        {
            if (_type != null)
            {
                if (_type.IsValueType || _type == typeof(string))
                    Trace.WriteLine($"the list of string or value types are not managed. Please use Mapper<{_type.Name}>");

                else
                {

                    var properties = TypeDescriptor.GetProperties(Instance);
                    foreach (PropertyDescriptor property in properties)
                        if (PropertyDescriptorFilter(property) && property.IsBrowsable)
                        {
                            var p = new PropertyObjectDescriptor(property, this, StrategyName)
                                .Build();
                            p.Enabled = PropertyFilter == null || PropertyFilter(p);
                            if (p.IsValid)
                                _items.Add(p);
                            else
                                _invaLidItems.Add(p);
                        }

                }
            }
        }

        public ITranslateService TranslateService { get; }

        public IServiceProvider ServiceProvider { get; }
        public string StrategyName { get; }
        public object Instance { get; set; }

        public IEnumerable<TranslatedKeyLabel> Categories()
        {

            var result = _items
                .Where(c => c.Browsable)
                .Select(x => x.Category).ToList();

            var h = new HashSet<string>();
            foreach (var item in result)
                if (h.Add(item.ToString()))
                    yield return item;

        }

        public void ValidationHasChanged<T>(IComponentFieldBase<T> componentFieldBase)
        {

            UiPropertyValidationHasChanged?.Invoke(componentFieldBase);

            PropertyValidationHasChanged?.Invoke(componentFieldBase.Property);

        }

        public Action<IComponentFieldBase> UiPropertyValidationHasChanged { get; set; }

        public Action<PropertyObjectDescriptor> PropertyValidationHasChanged { get; set; }

        public IEnumerable<PropertyObjectDescriptor> ItemsByCategories(TranslatedKeyLabel category)
        {

            var c = category.ToString();

            var result = _items
                .Where(c => c.Browsable)
                .Where(x => x.Category.ToString() == c)
                // .OrderBy(c => c.Display.ToString())
                ;

            foreach (var item in result)
                yield return item;

        }


        public IEnumerable<PropertyObjectDescriptor> Items { get => _items; }

        public IEnumerable<PropertyObjectDescriptor> InvalidItems { get => _invaLidItems; }

        private readonly Type _type;
        private readonly List<PropertyObjectDescriptor> _items;
        private readonly List<PropertyObjectDescriptor> _invaLidItems;


        internal void HasChanged(PropertyObjectDescriptor propertyObjectDescriptor)
        {
            PropertyHasChanged?.Invoke(propertyObjectDescriptor);
        }

        public DiagnosticValidator Validate()
        {

            var validator = new DiagnosticValidator();

            foreach (var item in _items)
                if (item.Enabled && !item.Validate(out var result))
                    validator.Add(result);

            return validator;

        }

        public Action<PropertyObjectDescriptor> PropertyHasChanged { get; set; }

    }


}