using Bb.ComponentModel.Accessors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Bb.TypeDescriptors
{

    /// <summary>
    /// A runtime-customizable implementation of <see cref="PropertyDescriptor"/>.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public sealed class DynamicExistingPropertyDescriptor : PropertyDescriptor, IDynamicActiveProperty, IDynamicComparerProperty
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicPropertyDescriptor"/> class.
        /// </summary>
        /// <param name="descriptor">
        /// The <see cref="PropertyDescriptor"/> will be based.
        /// </param>
        public DynamicExistingPropertyDescriptor(PropertyDescriptor descriptor, AccessorItem accessor = null)
            : base(Preconditions.CheckNotNull(descriptor, nameof(descriptor)))
        {
            _accessor = accessor;
            _descriptor = descriptor;
            _editorDictionary = new Dictionary<Type, object>();
            _active = true;
        }

        /// <summary>
        /// Returns a value indicating whether resetting an object changes its value.
        /// </summary>
        /// <param name="component">The component to test for reset capability.</param>
        /// <returns>true if resetting the component changes its value; otherwise, false.</returns>
        public override bool CanResetValue(object component)
        {
            return _descriptor.CanResetValue(component);
        }

        /// <summary>
        /// Gets an editor of the specified type.
        /// </summary>
        /// <param name="editorBaseType">
        /// The base type of editor, which is used to differentiate between multiple
        /// editors that a property supports.
        /// </param>
        /// <returns>
        /// An instance of the requested editor type, or null if an editor cannot be found.
        /// </returns>
        public override object GetEditor(Type editorBaseType)
        {

            if (editorBaseType != null)
                if (_editorDictionary.TryGetValue(editorBaseType, out object editor))
                    return editor;

            return _descriptor.GetEditor(editorBaseType);

        }

        /// <summary>
        /// Returns the current value of the property on a component.
        /// </summary>
        /// <param name="component">
        /// The component with the property for which to retrieve the value.
        /// </param>
        /// <returns>The value of a property for a given component.</returns>
        public override object GetValue(object component)
        {

            if (component is CustomTypeDescriptor)
                return _descriptor.GetValue(component);

            if (_accessor != null)
                return _accessor.GetValue(component);

            return _descriptor.GetValue(component);

        }

        /// <summary>
        /// Resets the value for this property of the component to the default value.
        /// </summary>
        /// <param name="component">
        /// The component with the property value that is to be reset to the default value.
        /// </param>
        public override void ResetValue(object component)
        {

            if (component is DynamicTypeDescriptor)
                _descriptor.ResetValue(component);


            else
            {
                if (_accessor != null)
                    _accessor.SetValue(component, _accessor.DefaultValue);
                else
                    _descriptor.ResetValue(component);
            }

            OnValueChanged(component, new EventArgs());

        }

        /// <summary>
        /// Sets the value of the component to a different value.
        /// </summary>
        /// <param name="component">
        /// The component with the property value that is to be set.
        /// </param>
        /// <param name="value">
        /// The new value.
        /// </param>
        public override void SetValue(object component, object value)
        {

            if (component is DynamicTypeDescriptor)
                _descriptor.SetValue(component, value);

            else
            {
                if (_accessor != null)
                    _accessor.SetValue(component, value);
                else
                    _descriptor.SetValue(component, value);
            }

            OnValueChanged(component, new EventArgs());

        }

        /// <summary>
        /// Determines a value indicating whether the value of this property needs to be persisted.
        /// </summary>
        /// <param name="component">
        /// The component with the property to be examined for persistence.
        /// </param>
        /// <returns>true if the property should be persisted; otherwise, false.</returns>
        public override bool ShouldSerializeValue(object component)
        {
            return _descriptor.ShouldSerializeValue(component);
        }


        #region Fluent interface

        /// <summary>
        /// Sets value that determines whether the dynamic property descriptor is active.
        /// </summary>
        /// <param name="active">
        /// The value that determines whether the dynamic property descriptor is active.
        /// </param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetActive(bool active)
        {
            _active = active;
            return this;
        }

        /// <summary>
        /// Sets the override for the <see cref="Category"/> property.
        /// </summary>
        /// <param name="category">The new value for the <see cref="Category"/> property.</param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetCategory(string category)
        {
            _categoryOverride = category;
            return this;
        }

        /// <summary>
        /// Sets the override for the <see cref="Converter"/> property.
        /// </summary>
        /// <param name="converter">The new value for the <see cref="Converter"/> property.</param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetConverter(TypeConverter converter)
        {
            _converterOverride = converter;
            return this;
        }

        /// <summary>
        /// Sets the override for the <see cref="Description"/> property.
        /// </summary>
        /// <param name="description">The new value for the <see cref="Description"/> property.</param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetDescription(string description)
        {
            _descriptionOverride = description;
            return this;
        }

        /// <summary>
        /// Sets the override for the <see cref="DisplayName"/> property.
        /// </summary>
        /// <param name="displayName">The new value for the <see cref="DisplayName"/> property.</param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetDisplayName(string displayName)
        {
            _displayNameOverride = displayName;
            return this;
        }

        /// <summary>
        /// Sets the editor for this type.
        /// </summary>
        /// <param name="editorBaseType">
        /// The base type of editor, which is used to differentiate between multiple editors
        /// that a property supports.
        /// </param>
        /// <param name="editor">
        /// An instance of the requested editor type.
        /// </param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetEditor(Type editorBaseType, object editor)
        {
            if (editorBaseType != null)
            {

                if (_editorDictionary.ContainsKey(editorBaseType))
                {

                    if (editor == null)
                        _editorDictionary.Remove(editorBaseType);

                    else
                        _editorDictionary[editorBaseType] = editor;

                }
                else
                {

                    if (editor != null)
                        _editorDictionary.Add(editorBaseType, editor);

                }
            }

            return this;

        }

        /// <summary>
        /// Sets the override for the <see cref="IsReadOnly"/> property.
        /// </summary>
        /// <param name="readOnly">The new value for the <see cref="IsReadOnly"/> property.</param>
        /// <returns>This <see cref="DynamicPropertyDescriptor"/> instance.</returns>
        public DynamicExistingPropertyDescriptor SetReadOnly(bool? readOnly)
        {
            _isReadOnlyOverride = readOnly;
            return this;
        }

        #endregion

        public bool IsActive(object instance) => _filter == null ? true : _filter(instance);


        private Func<object, bool> _filter = null;


        #region properties


        public override AttributeCollection Attributes
        {
            get
            {

                if (_attributes == null)
                    _attributes = new List<Attribute>(base.Attributes.OfType<Attribute>().ToArray());

                return new AttributeCollection(_attributes.ToArray());
            
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the dynamic property descriptor is active.
        /// If not, it won't be returned by the <see cref="DynamicTypeDescriptor.GetProperties()"/>
        /// or <see cref="DynamicTypeDescriptor.GetProperties(Attribute[])"/> methods.
        /// </summary>
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        /// <summary>
        /// Gets the name of the category to which the member belongs,
        /// as specified in the <see cref="CategoryAttribute"/>.
        /// </summary>
        public override string Category { get => _categoryOverride ?? _descriptor.Category; }

        /// <summary>
        /// Gets the type of the component this property is bound to.
        /// </summary>
        public override Type ComponentType { get => _descriptor.ComponentType; }

        /// <summary>
        /// Gets the type converter for this property.
        /// </summary>
        public override TypeConverter Converter { get => _converterOverride ?? _descriptor.Converter; }

        /// <summary>
        /// Gets the description of the member,
        /// as specified in the <see cref="DescriptionAttribute"/>. 
        /// </summary>
        public override string Description { get => _descriptionOverride ?? _descriptor.Description; }

        /// <summary>
        /// Gets the name that can be displayed in a window, such as a Properties window.
        /// </summary>
        public override string DisplayName { get => _displayNameOverride ?? _descriptor.DisplayName; }

        /// <summary>
        /// Gets a value indicating whether this property is read-only.
        /// </summary>
        public override bool IsReadOnly { get => _isReadOnlyOverride ?? _descriptor.IsReadOnly; }

        /// <summary>
        /// Gets the order in which this property will be retrieved from its type descriptor.
        /// </summary>
        public int? PropertyOrder { get; internal set; } = 1000;

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public override Type PropertyType { get => _descriptor.PropertyType; }

        private readonly AccessorItem _accessor;

        #endregion properties

        internal void Apply(ConfigurationPropertyDescriptor property, Func<object, bool> filter)
        {

            if (_filter == null)
                _filter = filter;
            else
            {
                _filter = (o) =>
                {
                    if (filter(o))
                        return _filter(o);
                    return false;
                };
            }

            if (_attributes == null)
                _attributes = new List<Attribute>(base.Attributes.OfType<Attribute>().ToArray());

            foreach (var item in property.Attributes)
                _attributes.Add(item);

            if (!string.IsNullOrEmpty(property.Category))
                this._categoryOverride = property.Category;

            if (!string.IsNullOrEmpty(property.Description))
                this._descriptionOverride = property.Description;

            if (!string.IsNullOrEmpty(property.DisplayName))
                this._displayNameOverride = property.DisplayName;

            if (property.PropertyOrder.HasValue)
                this.PropertyOrder = property.PropertyOrder;

            //if (property.Converter != null)
            //    this._converterOverride = property.Converter;

            //if (property.IsReadOnly.HasValue)
            //    this._isReadOnlyOverride = property.IsReadOnly;

        }


        #region private

        /// <summary>
        /// The <see cref="PropertyDescriptor"/> on which this <see cref="DynamicPropertyDescriptor"/> is based.
        /// </summary>
        private readonly PropertyDescriptor _descriptor;

        /// <summary>
        /// A dictionary mapping editor base types to editor instances.
        /// </summary>
        private readonly IDictionary<Type, object> _editorDictionary;

        /// <summary>
        /// Gets or sets a value indicating whether the dynamic property descriptor is active.
        /// If not, it won't be returned by the <see cref="DynamicTypeDescriptor.GetProperties()"/> 
        /// or <see cref="DynamicTypeDescriptor.GetProperties(Attribute[])"/> methods.
        /// </summary>
        private bool _active;
        private List<Attribute> _attributes;

        /// <summary>
        /// If this value is not null, it will be returned by the Category property;
        /// otherwise, the base descriptor's Category property will be returned.
        /// </summary>
        private string _categoryOverride;

        /// <summary>
        /// If this value is not null, it will be returned by the Converter property;
        /// otherwise, the base descriptor's Converter property will be returned.
        /// </summary>
        private TypeConverter _converterOverride;

        /// <summary>
        /// If this value is not null, it will be returned by the Description property;
        /// otherwise, the base descriptor's Description property will be returned.
        /// </summary>
        private string _descriptionOverride;

        /// <summary>
        /// If this value is not null, it will be returned by the DisplayName property;
        /// otherwise, the base descriptor's DisplayName property will be returned.
        /// </summary>
        private string _displayNameOverride;

        /// <summary>
        /// If this value is not null, it will be returned by the IsReadOnly property;
        /// otherwise, the base descriptor's IsReadOnly property will be returned.
        /// </summary>
        private bool? _isReadOnlyOverride;

        #endregion private


    }


}
