using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Bb.TypeDescriptors
{

    [DebuggerDisplay("{Name}")]
    class DynamicPropertyDescriptor : PropertyDescriptor, IDynamicActiveProperty, IDynamicComparerProperty
    {

        internal DynamicPropertyDescriptor(ConfigurationPropertyDescriptor configuration)
            : base(configuration.Name, configuration.Attributes)
        {
            this._configuration = configuration;
            if (configuration.PropertyOrder.HasValue)
                this.PropertyOrder = configuration.PropertyOrder;
        }

        public override string Category => _configuration.Category ?? base.Category;

        public override string Description => _configuration.Description ?? base.Description;

        public override string DisplayName => _configuration.DisplayName ?? base.DisplayName;

        public override AttributeCollection Attributes => base.Attributes;

        public override TypeConverter Converter => base.Converter;


        public override bool IsBrowsable => base.IsBrowsable;


        public override bool IsLocalizable => base.IsLocalizable;


        public override bool SupportsChangeEvents => base.SupportsChangeEvents;

        /// <summary>
        /// Gets the order in which this property will be retrieved from its type descriptor.
        /// </summary>
        public int? PropertyOrder { get; internal set; } = 1000;


        public override bool CanResetValue(object component) => this._configuration.CanResetValue;

        public override Type ComponentType => _configuration.ComponentType;

        public override bool IsReadOnly => _configuration.IsReadOnly;

        public override Type PropertyType => _configuration.Type;

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value) => _configuration.SetValue(component, value);

        public override object GetValue(object component) => _configuration.GetValue(component);

        public override bool ShouldSerializeValue(object component) => _configuration.ShouldSerializeValue;


        public bool IsActive (object instance) => _filter == null ? true : _filter(instance);

        internal Func<object, bool> _filter = null;

        private readonly ConfigurationPropertyDescriptor _configuration;

    }


}
