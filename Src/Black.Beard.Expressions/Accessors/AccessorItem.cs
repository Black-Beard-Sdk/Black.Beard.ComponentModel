// Ignore Spelling: Accessor Clonable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Bb.Converters;

namespace Bb.Accessors
{


    /// <summary>
    /// Accessor base
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class AccessorItem
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorItem"/> class.
        /// </summary>
        /// <param name="ComponentType">The type of the component. Must not be null.</param>
        /// <param name="memberTypeEnum">The type of the member (e.g., Property, Field).</param>
        /// <param name="strategy">The strategy used to determine member access.</param>
        /// <param name="member">Member.</param>
        /// <param name="memberType">Type of the member</param>
        /// <remarks>
        /// This constructor initializes the base properties of the <see cref="AccessorItem"/> class.
        /// </remarks>
        protected AccessorItem(Type ComponentType, MemberType memberTypeEnum, MemberStrategys strategy, MemberInfo member, Type memberType)
        {
            this.ComponentType = ComponentType;
            this.TypeEnum = memberTypeEnum;
            this.Strategy = strategy;
            this.Member = member;
            this.Name = ResolveName(member.Name);
            this.DeclaringType = member.DeclaringType;
            this.Type = memberType;

        }

        #region Properties

        /// <summary>
        /// Gets or sets the type enum.
        /// </summary>
        /// <value>
        /// The type enum.
        /// </value>
        public MemberType TypeEnum { get; }

        /// <summary>
        /// Gets the strategy accessor.
        /// </summary>
        public MemberStrategys Strategy { get; }

        /// <summary>
        /// Gets a value indicating whether [can write].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can write]; otherwise, <c>false</c>.
        /// </value>
        public bool CanWrite { get { return SetValue != null; } }

        /// <summary>
        /// Gets a value indicating whether [can read].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can read]; otherwise, <c>false</c>.
        /// </value>
        public bool CanRead { get { return GetValue != null; } }

        /// <summary>
        /// Gets a value indicating whether [is clonable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is clonable]; otherwise, <c>false</c>.
        /// </value>
        public bool Clonable { get { return GetValue != null && SetValue != null; } }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the type of the declaring.
        /// </summary>
        /// <value>
        /// The type of the declaring.
        /// </value>
        public Type? DeclaringType { get; }

        /// <summary>
        /// Original type
        /// </summary>
        public Type ComponentType { get; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; }

        /// <summary>
        /// Gets or sets a value indicating whether [is static].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is static]; otherwise, <c>false</c>.
        /// </value>
        public bool IsStatic { get; protected set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public object? Tag { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public MemberInfo Member { get; }

        #endregion Properties



        /// <summary>
        /// Gets or sets the set value method.
        /// </summary>
        /// <value>
        /// The set value.
        /// </value>
        public Action<object, object?>? SetValue { get; protected set; }

        /// <summary>
        /// Gets or sets the get value method.
        /// </summary>
        /// <value>
        /// The get value.
        /// </value>
        public Func<object, object>? GetValue { get; protected set; }

        /// <summary>
        /// Gets the typed value converted in specified type.
        /// </summary>
        /// <typeparam name="T1">The type of the returned value.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public T1? GetTypedValue<T1>(object instance)
        {

            if (GetValue != null)
            {

                var result = GetValue(instance);
                if (result is T1 t)
                    return t;

                if (result != null)
                {
                    var t2 = (T1?)ConverterHelper.ConvertTo(result, typeof(T1));
                    return t2;
                }

            }

            return default;

        }

        /// <summary>
        /// Convert value before setting it.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        public void ConvertBeforeSettingValue(object instance, object? value)
        {

            if (value == null)
            {
                SetValue?.Invoke(instance, value);
                return;
            }

            if (value.GetType() != this.Type)
                value = ConverterHelper.ConvertTo(value, this.Type);

            SetValue?.Invoke(instance, value);

        }


        #region attributes

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <returns>the list of attribute</returns>
        public IEnumerable<Attribute> GetAttributes()
        {

            List<Attribute>? _attributes = null;

            if (this.Member is PropertyInfo)
            {

                PropertyDescriptor? prop = null;

                var props = TypeDescriptor.GetProperties(ComponentType);
                if (props != null)
                    prop = props.Find(this.Name, false);

                if (prop == null && DeclaringType != null)
                {
                    props = TypeDescriptor.GetProperties(DeclaringType);
                    if (props != null)
                        prop = props.Find(this.Name, false);
                }

                _attributes = prop?.Attributes?.ToList().ToList();

            }

            _attributes ??= Member.GetCustomAttributes().ToList();

            return _attributes;

        }

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <param name="instance">resolve the list of the reflexion or from type descriptor</param>
        /// <returns>the list of attribute</returns>
        public IEnumerable<Attribute> GetAttributes(object instance)
        {

            if (instance == null)
                return GetAttributes();

            List<Attribute>? _attributes = null;

            if (!IsStatic && this.Member is PropertyInfo)
            {

                PropertyDescriptor? prop = null;

                var props = TypeDescriptor.GetProperties(instance);
                if (props != null)
                    prop = props.Find(this.Name, false);

                if (prop == null && DeclaringType != null)
                {
                    props = TypeDescriptor.GetProperties(DeclaringType);
                    if (props != null)
                        prop = props.Find(this.Name, false);
                }

                _attributes = prop?.Attributes?
                    .ToList()
                    .ToList();

            }

            if (_attributes == null)
                _attributes = Member.GetCustomAttributes()
                    .OfType<Attribute>()
                    .ToList();

            return _attributes;

        }

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <returns>the list of attribute</returns>
        public IEnumerable<T> GetAttributes<T>()
            where T : Attribute
        {
            return GetAttributes().OfType<T>();
        }

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <param name="instance">instance to evaluate</param>
        /// <returns></returns>
        public IEnumerable<T> GetAttributes<T>(object instance)
            where T : Attribute
        {
            return GetAttributes(instance).OfType<T>();
        }

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <typeparam name="T">Attribute to search</typeparam>
        /// <param name="attributes">The attribute list to return.</param>
        /// <returns></returns>
        public bool IfAttributes<T>(out List<T> attributes)
            where T : Attribute
        {
            attributes = GetAttributes<T>().ToList();
            return attributes.Count > 0;
        }

        /// <summary>
        /// Resolve the attribute's list.
        /// </summary>
        /// <typeparam name="T">Attribute to search</typeparam>
        /// <param name="instance">instance to evaluate</param>
        /// <param name="attributes">The attribute list to return.</param>
        /// <returns></returns>
        public bool IfAttributes<T>(object instance, out List<T> attributes)
            where T : Attribute
        {
            attributes = GetAttributes<T>(instance).ToList();
            return attributes.Count > 0;
        }

        /// <summary>
        /// Resolve the attribute
        /// </summary>
        /// <typeparam name="T">Attribute to search</typeparam>
        /// <returns>Return the list of attribute to search</returns>
        /// <exception cref="InvalidOperationException">Multiple attributes found</exception>
        public bool IfAttribute<T>(out T? attribute)
            where T : Attribute
        {
            var o = GetAttributes<T>().ToList();
            if (o.Count > 1)
                throw new InvalidOperationException("Multiple attributes found");
            attribute = o.FirstOrDefault();
            return attribute != null;
        }

        /// <summary>
        /// Resolve the attribute
        /// </summary>
        /// <typeparam name="T">Attribute to search</typeparam>
        /// <param name="instance">instance to evaluate</param>
        /// <param name="attribute">The attribute to return.</param>
        /// <returns>Return the attribute to search</returns>
        /// <exception cref="InvalidOperationException">Multiple attributes found</exception>
        public bool IfAttribute<T>(object instance, out T? attribute)
            where T : Attribute
        {
            var o = GetAttributes<T>(instance).ToList();
            if (o.Count > 1)
                throw new InvalidOperationException("Multiple attributes found");
            attribute = o.FirstOrDefault();
            return attribute != null;
        }

        /// <summary>
        /// Determines whether this instance contains attribute.
        /// </summary>
        /// <typeparam name="T">Attribute to search</typeparam>
        /// <returns>true if the object contains one or more of the specified attribute</returns>
        public bool ContainsAttribute<T>()
            where T : Attribute
        {
            return GetAttributes<T>().Any();
        }

        /// <summary>
        /// Determines whether this instance contains attribute.
        /// </summary>
        /// <typeparam name="T">Attribute to search</typeparam>
        /// <param name="instance">instance to evaluate</param>
        /// <returns>true if the object contains one or more of the specified attribute</returns>
        public bool ContainsAttribute<T>(object instance)
            where T : Attribute
        {
            return GetAttributes<T>(instance).Any();
        }

        #region validation

        /// <summary>
        /// Gets the validated value of the member.
        /// </summary>
        /// <param name="instance">The instance of the object containing the member. Must not be null.</param>
        /// <param name="attributes">The validation attributes to apply. Can be null.</param>
        /// <returns>
        /// The validated value of the member.
        /// </returns>
        /// <remarks>
        /// This method retrieves the value of the member and validates it using the provided or default validation attributes.
        /// </remarks>
        /// <exception cref="ValidationException">
        /// Thrown if the value does not pass validation and <c>throwException</c> is set to true.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var accessor = new AccessorItem(typeof(MyClass), MemberTypeEnum.Property, MemberStrategy.Properties);
        /// var value = accessor.GetValidatedValue(myInstance);
        /// Console.WriteLine(value);
        /// </code>
        /// </example>
        public object? GetValidatedValue(object instance, IEnumerable<ValidationAttribute>? attributes = null)
        {
            if (GetValue != null)
            {
                var v1 = GetValue(instance);
                ValidateMember(v1, true, attributes);
                return v1;
            }
            return null;
        }

        /// <summary>
        /// Validates the member value against the specified validation attributes.
        /// </summary>
        /// <param name="instance">The instance of the object containing the member. Must not be null.</param>
        /// <param name="throwException">Indicates whether to throw an exception if validation fails.</param>
        /// <param name="attributes">The validation attributes to apply. Can be null.</param>
        /// <returns>
        /// A <see cref="ValidationException"/> if validation fails, or null if validation succeeds.
        /// </returns>
        /// <remarks>
        /// This method validates the member value using the provided or default validation attributes.
        /// </remarks>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails and <c>throwException</c> is set to true.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var accessor = new AccessorItem(typeof(MyClass), MemberTypeEnum.Property, MemberStrategy.Properties);
        /// var exception = accessor.ValidateMember(myInstance, true);
        /// if (exception != null)
        /// {
        ///     Console.WriteLine("Validation failed: " + exception.Message);
        /// }
        /// </code>
        /// </example>
        public ValidationException? ValidateMember(object instance, bool throwException, IEnumerable<ValidationAttribute>? attributes = null)
        {

            var _a = attributes;
            if (_a == null || !_a.Any())
                _a = GetAttributes<ValidationAttribute>(instance).ToList();

            ValidationException? validationException = GetValidationException(instance, _a);

            if (throwException && validationException != null)
                throw validationException;

            return validationException;

        }

        private ValidationException? GetValidationException(object instance, IEnumerable<ValidationAttribute> attributes)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (GetValue != null)
            {

                bool result = Validator.TryValidateValue(this.GetValue(instance), new ValidationContext(new object(), null, null), results, attributes);
                ValidationException? v1 = null;

                if (!result)
                {
                    v1 = new ValidationException(string.Format("Validation exception on the property '{0}'. Please see the Data collection for more informations.", this.Member.Name));

                    foreach (var item in results)
                    {
                        ValidationException v = new ValidationException(item.ErrorMessage, null, instance);
                        v1.Data.Add("exception" + (v1.Data.Count + 1).ToString(), v);
                    }
                }
                return v1;

            }

            return null;

        }

        #endregion validation


        /// <summary>
        /// Gets the display name of the member.
        /// </summary>
        /// <value>
        /// The display name of the member, as defined by <see cref="DisplayNameAttribute"/> or <see cref="DisplayAttribute"/>.
        /// </value>
        /// <remarks>
        /// This property retrieves the display name of the member, falling back to the member's name if no display attributes are present.
        /// </remarks>
        public string? DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    _displayName = this.Name;
                    DisplayNameAttribute? a = GetAttributes().OfType<DisplayNameAttribute>().FirstOrDefault();
                    if (a != null)
                        _displayName = a.DisplayName;
                    DisplayAttribute? b = GetAttributes().OfType<DisplayAttribute>().FirstOrDefault();
                    if (b != null)
                        _displayName = b.Name;
                }

                return _displayName;
            }
        }

        /// <summary>
        /// Gets the description of the member.
        /// </summary>
        /// <value>
        /// The description of the member, as defined by <see cref="DescriptionAttribute"/>.
        /// </value>
        /// <remarks>
        /// This property retrieves the description of the member, falling back to the member's name if no description attributes are present.
        /// </remarks>
        public string DisplayDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_displayDesciption))
                {
                    _displayDesciption = this.Name;
                    DescriptionAttribute? a = GetAttributes().OfType<DescriptionAttribute>().FirstOrDefault();
                    if (a != null)
                        _displayDesciption = a.Description;
                }

                return _displayDesciption;
            }
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category
        {
            get
            {
                if (string.IsNullOrEmpty(_category))
                {
                    _category = string.Empty;
                    CategoryAttribute? a = GetAttributes().OfType<CategoryAttribute>().FirstOrDefault();
                    if (a != null)
                        _category = a.Category;
                }

                return _category;
            }
        }

        /// <summary>
        /// Gets the default value of the member.
        /// </summary>
        /// <value>
        /// The default value of the member, as defined by <see cref="DefaultValueAttribute"/>.
        /// </value>
        /// <remarks>
        /// This property retrieves the default value of the member, converting it to the appropriate type if necessary.
        /// </remarks>
        public dynamic? DefaultValue
        {
            get
            {
                if (_defaultValue == null)
                {
                    DefaultValueAttribute? a = GetAttributes().OfType<DefaultValueAttribute>().FirstOrDefault();
                    if (a != null)
                    {
                        _defaultValue = a.Value;
                        if (_defaultValue != null)
                        {
                            Type t = _defaultValue.GetType();
                            if (t == typeof(string) && t != Type)
                                _defaultValue = ConverterHelper.Unserialize(_defaultValue, Type);
                        }
                    }
                }
                return _defaultValue;
            }
        }

        /// <summary>
        /// Determines whether the member is required.
        /// </summary>
        /// <value>
        /// <c>true</c> if the member is required; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// This property checks for the presence of a <see cref="RequiredAttribute"/> to determine whether the member is required.
        /// </remarks>
        public bool Required
        {
            get
            {

                if (!_required.HasValue)
                {
                    _required = false;
                    RequiredAttribute? a = GetAttributes().OfType<RequiredAttribute>().FirstOrDefault();
                    if (a != null)
                        _required = true;
                }

                return _required.Value;

            }
        }

        #endregion attributes

        internal static AccessorList GetPropertiesImpl(Type componentType, MemberStrategys strategy, Func<Type, bool>? filter, Func<MemberInfo, bool>? memberFilter)
        {

            if (filter == null)
                filter = (x) => true;

            AccessorList? list = null;

            if (strategy.HasFlag(MemberStrategys.ConvertIfDifferent))
                strategy = strategy & ~MemberStrategys.Direct;

            if (!strategy.HasFlag(MemberStrategys.Properties) && !strategy.HasFlag(MemberStrategys.Fields))
                strategy |= MemberStrategys.Properties;

            if (!strategy.HasFlag(MemberStrategys.Instance) && !strategy.HasFlag(MemberStrategys.Static))
                strategy |= MemberStrategys.Instance;


            if (memberFilter != null)
                return GenerateList(componentType, strategy, filter, memberFilter);


            memberFilter = (x) => true;

            if (!_strategyPropertiesAccessors.TryGetValue(strategy, out var _accessors))
                lock (_lock)
                    if (!_strategyPropertiesAccessors.TryGetValue(strategy, out _accessors))
                    {
                        _accessors = new Dictionary<Type, AccessorList>();
                        _strategyPropertiesAccessors.Add(strategy, _accessors);
                    }

            if (!_accessors.TryGetValue(componentType, out list))
                lock (_lock)
                    if (!_accessors.TryGetValue(componentType, out list))
                    {
                        list = GenerateList(componentType, strategy, filter, memberFilter);
                        _accessors.Add(componentType, list);
                    }

            return list;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AccessorList GenerateList(Type componentType, MemberStrategys strategy, Func<Type, bool> typeFilter, Func<MemberInfo, bool> memberFilter)
        {

            AccessorList list = new AccessorList();

            if (strategy.HasFlag(MemberStrategys.Properties))
                foreach (PropertyInfo item in AccessorList.GetProperties(componentType, typeFilter))
                    if (memberFilter(item) && !list.ContainsKey(item.Name) && IsAccepted(item, strategy))
                        list.Add(new PropertyAccessor(componentType, item, strategy));

            if (strategy.HasFlag(MemberStrategys.Fields))
                foreach (FieldInfo item in AccessorList.GetFields(componentType, typeFilter))
                    if (memberFilter(item) && !list.ContainsKey(item.Name) && IsAccepted(item, strategy))
                        list.Add(new FieldAccessor(componentType, item, strategy));

            return list;

        }

        /// <summary>
        /// Resolve the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static string ResolveName(string name)
        {

            var index = name.LastIndexOf('.');

            if (index > -1)
            {
                return name.Substring(index + 1);
            }

            return name;
        }


        #region private


        private static bool IsAccepted(PropertyInfo item, MemberStrategys strategy)
        {

            if (item.GetIndexParameters().Length > 0)
                return false;

            if (item.GetMethod == null && item.SetMethod == null)
                return false;

            if (!strategy.HasFlag(MemberStrategys.Static)
                && ((item.GetMethod != null && item.GetMethod.IsStatic)
                 || (item.SetMethod != null && item.SetMethod.IsStatic)))
                return false;

            if (!strategy.HasFlag(MemberStrategys.Instance)
                && ((item.GetMethod != null && !item.GetMethod.IsStatic)
                 || (item.SetMethod != null && !item.SetMethod.IsStatic)))
                return false;

            return true;

        }

        private static bool IsAccepted(FieldInfo item, MemberStrategys strategy)
        {

            if (!strategy.HasFlag(MemberStrategys.NotPublicFields) && !item.Attributes.HasFlag(FieldAttributes.Public)
                && (item.Attributes.HasFlag(FieldAttributes.Private) || item.Attributes.HasFlag(FieldAttributes.PrivateScope)))
                    return false;

            if (strategy.HasFlag(MemberStrategys.Static) && !strategy.HasFlag(MemberStrategys.Instance))
                return item.IsStatic;

            else if (strategy.HasFlag(MemberStrategys.Instance) && !strategy.HasFlag(MemberStrategys.Static))
                return !item.IsStatic;

            return true;

        }

        private string? _displayName = null;
        private string? _category = null;
        private string? _displayDesciption = null;
        private bool? _required = null;
        private dynamic? _defaultValue = null;


        /// <summary>
        /// The _accessors
        /// </summary>
        private static Dictionary<MemberStrategys, Dictionary<Type, AccessorList>> _strategyPropertiesAccessors = new Dictionary<MemberStrategys, Dictionary<Type, AccessorList>>();
        /// <summary>
        /// The _lock
        /// </summary>
        private static readonly object _lock = new object();

        #endregion private


    }


}
