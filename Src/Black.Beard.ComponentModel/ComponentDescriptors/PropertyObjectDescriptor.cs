using Bb.ComponentModel.Translations;
using Bb.TypeDescriptors;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Bb.ComponentDescriptors
{


    [DebuggerDisplay("{Name} : {Type}")]
    public class PropertyObjectDescriptor
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyObjectDescriptor"/> class.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="parent"></param>
        /// <param name="strategyKey"></param>
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

        /// <summary>
        /// return true if the property is in the list and a strategy is defined
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool Create(string name, Type type, out object result)
        {

            result = null;

            var _strategy = StrategyMapper.Get(name);
            if (_strategy != null)
            {
                if (_strategy.TryGetValueByType(type, out var strategies))
                {
                    result = strategies?.CreateInstance();
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// return the value of the property for the current instance
        /// </summary>
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

        /// <summary>
        /// Refresh
        /// </summary>
        public void PropertyChange()
        {
            Parent.HasChanged(this);
        }

        private void AssignStrategy(StrategyEditor strategy)
        {

            EditorType = strategy.ComponentView;
            KindView = strategy.PropertyKingView;

            strategy.Initializer?.Invoke(_strategy, this);

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

        /// <summary>
        /// Validate the property in the instance
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Validate(out DiagnosticValidatorItem result)
        {
            result = PropertyDescriptor.ValidateValue(Value, Parent.TranslateService);
            return result.IsValid;
        }

        /// <summary>
        /// Return true if Validation of the property in the instance is valid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Validate(object value, out DiagnosticValidatorItem result)
        {
            result = PropertyDescriptor.ValidateValue(value, Parent.TranslateService);
            return result.IsValid;
        }

        /// <summary>
        /// Return the translated display
        /// </summary>
        /// <returns></returns>
        public string GetDisplay()
        {
            return Parent.TranslateService.Translate(Display);
        }

        /// <summary>
        /// Return the translated description
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return Parent.TranslateService.Translate(Description);
        }

        /// <summary>
        /// Return the translated category
        /// </summary>
        /// <returns></returns>
        public string GetCategory()
        {
            return Parent.TranslateService.Translate(Category);
        }

        /// <summary>
        /// Action to execute after validation UI status is changed
        /// </summary>
        public Action<IComponentFieldBase> UIPropertyValidationHasChanged { get; set; }

        /// <summary>
        /// Action to execute after validation status is changed
        /// </summary>
        public Action<PropertyObjectDescriptor> PropertyValidationHasChanged { get; set; }

        public Action<PropertyObjectDescriptor> PropertyHasChanged { get; set; }

        /// <summary>
        /// Name of the property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Type of the property
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Global strategy name
        /// </summary>
        public string StrategyName { get; }

        /// <summary>
        /// Validation error text
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// Return true if the validaiton is failed
        /// </summary>
        public bool InError { get; set; }


        public Type SubType { get; set; }

        public ObjectDescriptor Parent { get; }

        public bool IsValid { get; private set; }

        /// <summary>
        /// PropertyDescriptor
        /// </summary>
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


        private readonly StrategyMapper _strategy;

    }


}
