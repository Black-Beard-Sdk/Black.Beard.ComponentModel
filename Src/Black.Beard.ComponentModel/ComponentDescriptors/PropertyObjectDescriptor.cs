using Bb.ComponentModel.Translations;
using Bb.TypeDescriptors;
using System;
using System.ComponentModel;
using System.Linq;

namespace Bb.ComponentDescriptors
{



    public class PropertyObjectDescriptor
    {

        public PropertyObjectDescriptor(PropertyDescriptor property, ObjectDescriptor parent, string strategyKey)
        {

            _strategy = string.IsNullOrEmpty(strategyKey)
                ? StrategyMapper.Get(string.Empty)
                : StrategyMapper.Get(strategyKey);

            StrategyName = _strategy.Key;
            Parent = parent;
            Name = property.Name;
            PropertyDescriptor = property;
            Display = property.DisplayName.GetTranslation(property.Name);
            Description = property.Description;
            Category = property.Category.GetTranslation();
            Browsable = property.IsBrowsable;
            ReadOnly = property.IsReadOnly;
            DefaultValue = null;
            Minimum = int.MinValue;
            Maximum = int.MaxValue;
            Type = PropertyDescriptor.PropertyType;
            Step = 1;
            Line = 1;
            ComponentType = property.ComponentType;

            if (Type.IsGenericType && Type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                IsNullable = true;
                SubType = Type.GetGenericArguments()[0];
            }
            else
                SubType = typeof(void);
        }

        internal PropertyObjectDescriptor Build()
        {

            if (_strategy.TryGetValueByType(Type, out StrategyEditor? strategyEditor))
                AssignStrategy(strategyEditor);

            IsValid = EditorType != null;

            return this;

        }

        public static bool Create(string name, Type type, out object result)
        {

            result = null;

            var _strategy = StrategyMapper.Get(name);

            if (_strategy.TryGetValueByType(type, out var strategies))
            {
                result = strategies?.CreateInstance();
                return true;
            }

            return false;

        }

        public object Value
        {
            get
            {

                object result = PropertyDescriptor.GetValue(Parent.Instance);

                //if (result == null)
                //    return this.DefaultValue;

                return result;

            }

            set
            {
                PropertyDescriptor.SetValue(Parent.Instance, value);
                PropertyChange();
            }

        }

        public void PropertyChange()
        {
            Parent.HasChanged(this);
        }

        private void AssignStrategy(StrategyEditor strategy)
        {

            EditorType = strategy.ComponentView;
            KindView = strategy.PropertyKingView;

            if (strategy.Initializer != null)
                strategy.Initializer(_strategy, this);

            var i = strategy.AttributeInitializers;
            if (i != null)
            {
                var attributes = PropertyDescriptor.Attributes.OfType<Attribute>().ToList();
                foreach (Attribute attribute in attributes)
                    if (i.TryGetValue(attribute.GetType(), out var a))
                        a(attribute, _strategy, this);
            }

            foreach (var item in strategy.Initializers)
                item(Type, _strategy, this);

        }

        public bool Validate(out DiagnosticValidatorItem result)
        {
            result = PropertyDescriptor.ValidateValue(Value, Parent.TranslateService);
            return result.IsValid;
        }

        public bool Validate(object value, out DiagnosticValidatorItem result)
        {
            result = PropertyDescriptor.ValidateValue(value, Parent.TranslateService);
            return result.IsValid;
        }

        public string GetDisplay()
        {
            return Parent.TranslateService.Translate(Display);
        }

        public string GetDescription()
        {
            return Parent.TranslateService.Translate(Description);
        }

        public string GetCategory()
        {
            return Parent.TranslateService.Translate(Category);
        }


        public Action<IComponentFieldBase> UIPropertyValidationHasChanged { get; set; }

        public Action<PropertyObjectDescriptor> PropertyValidationHasChanged { get; set; }

        public Action<PropertyObjectDescriptor> PropertyHasChanged { get; set; }

        public Type Type { get; set; }

        private readonly StrategyMapper _strategy;

        public string StrategyName { get; }

        public string ErrorText { get; set; }

        public bool InError { get; set; }

        public Type SubType { get; set; }

        public string Name { get; }
        public ObjectDescriptor Parent { get; }

        public bool IsValid { get; private set; }

        public PropertyDescriptor PropertyDescriptor { get; set; }

        public TranslatedKeyLabel Display { get; set; }

        public TranslatedKeyLabel Description { get; set; }

        public TranslatedKeyLabel Category { get; set; }

        public bool Browsable { get; set; }

        public bool ReadOnly { get; set; }

        public object DefaultValue { get; set; }

        public bool Required { get; set; }

        public string DataFormatString { get; set; }

        public bool HtmlEncode { get; set; }

        public string KindView { get; set; }

        public bool IsNullable { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        public float Step { get; set; }

        public bool IsPassword { get; set; }

        public Type EditorType { get; set; }

        public Type ListProvider { get; set; }

        public int Line { get; set; }

        public Type ComponentType { get; }

        public StringType Mask { get; set; }

        public bool Enabled { get; set; }

    }


}
