using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Bb.Converters;

namespace Bb.ComponentModel.Accessors
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
        /// <param name="memberTypeEnum">The member type enum.</param>
        protected AccessorItem(Type ComponentType, MemberTypeEnum memberTypeEnum, MemberStrategy strategy)
        {
            // TODO: Complete member initialization
            this.ComponentType = ComponentType;
            this.TypeEnum = memberTypeEnum;
            this.Strategy = strategy;
        }


        #region Properties

        /// <summary>
        /// Gets or sets the type enum.
        /// </summary>
        /// <value>
        /// The type enum.
        /// </value>
        public MemberTypeEnum TypeEnum { get; }

        /// <summary>
        /// Gets the strategy accessor.
        /// </summary>
        public MemberStrategy Strategy { get; }

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
        public bool IsClonable { get { return GetValue != null && SetValue != null; } }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the type of the declaring.
        /// </summary>
        /// <value>
        /// The type of the declaring.
        /// </value>
        public Type DeclaringType { get; protected set; }

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
        public Type Type { get; protected set; }

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
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public MemberInfo Member { get; protected set; }

        #endregion Properties



        /// <summary>
        /// Gets or sets the set value method.
        /// </summary>
        /// <value>
        /// The set value.
        /// </value>
        public Action<object, object> SetValue { get; protected set; }

        /// <summary>
        /// Gets or sets the get value method.
        /// </summary>
        /// <value>
        /// The get value.
        /// </value>
        public Func<object, object> GetValue { get; protected set; }

        /// <summary>
        /// Gets the typed value converted in specified type.
        /// </summary>
        /// <typeparam name="T1">The type of the returned value.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public T1 GetTypedValue<T1>(object instance)
        {

            var result = GetValue(instance);
            if (result is T1 t)
                return t;

            if (result != null)
            {
                var t2 = (T1)ConverterHelper.ConvertTo(result, typeof(T1));
                return t2;
            }

            return default;

        }

        /// <summary>
        /// Convert value before setting it.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        public void ConvertBeforeSettingValue(object instance, object value)
        {

            if (value == null)
            {
                SetValue(instance, null);
                return;
            }

            if (value.GetType() != this.Type)
                value = ConverterHelper.ConvertTo(value, this.Type);

            SetValue(instance, value);

        }


        #region attributes

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <returns>the list of attribute</returns>
        public IEnumerable<Attribute> GetAttributes()
        {

            List<Attribute> _attributes = null;

            if (this.Member is PropertyInfo s)
            {

                PropertyDescriptor prop = null;

                var props = TypeDescriptor.GetProperties(ComponentType);
                if (props != null)
                    prop = props.Find(this.Name, false);

                if (prop == null)
                {
                    props = TypeDescriptor.GetProperties(DeclaringType);
                    if (props != null)
                        prop = props.Find(this.Name, false);
                }

                _attributes = prop?.Attributes?.ToList().ToList();

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
        /// <param name="instance">resolve the list of the reflexion or from type descriptor</param>
        /// <returns>the list of attribute</returns>
        public IEnumerable<Attribute> GetAttributes(object instance)
        {

            if (instance == null)
                return GetAttributes();

            List<Attribute> _attributes = null;

            if (!IsStatic && this.Member is PropertyInfo)
            {

                PropertyDescriptor prop = null;

                var props = TypeDescriptor.GetProperties(instance);
                if (props != null)
                    prop = props.Find(this.Name, false);

                if (prop == null)
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
        public bool IfAttribute<T>(out T attribute)
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
        public bool IfAttribute<T>(object instance, out T attribute)
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
        /// Gets the validated value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns>the value has been evaluated</returns>
        public object GetValidatedValue(object instance, IEnumerable<ValidationAttribute> attributes = null)
        {
            var v1 = GetValue(instance);
            ValidateMember(v1, true, attributes);
            return v1;
        }

        /// <summary>
        /// Validates the member.
        /// </summary>
        /// <param name="instance">The model.</param>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <param name="attributes">The validationAttributes list to evaluate.</param>
        /// <returns>Return the result of the evaluation</returns>
        public ValidationException ValidateMember(object instance, bool throwException, IEnumerable<ValidationAttribute> attributes = null)
        {

            var _a = attributes;
            if (_a == null || _a.Count() == 0)
                _a = GetAttributes<ValidationAttribute>(instance).ToList();

            ValidationException validationException = GetValidationException(instance, _a);

            if (throwException && validationException != null)
                throw validationException;

            return validationException;

        }

        private ValidationException GetValidationException(object instance, IEnumerable<ValidationAttribute> attributes)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            bool result = Validator.TryValidateValue(this.GetValue(instance), new ValidationContext(new object(), null, null), results, attributes);
            ValidationException v1 = null;

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

        #endregion validation


        /// <summary>
        /// Displays the name.
        /// </summary>
        /// <returns></returns>
        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    _displayName = this.Name;
                    DisplayNameAttribute a = GetAttributes().OfType<DisplayNameAttribute>().FirstOrDefault();
                    if (a != null)
                        _displayName = a.DisplayName;
                    DisplayAttribute b = GetAttributes().OfType<DisplayAttribute>().FirstOrDefault();
                    if (b != null)
                        _displayName = b.Name;
                }

                return _displayName;
            }
        }

        /// <summary>
        /// Displays the description.
        /// </summary>
        /// <returns></returns>
        public string DisplayDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_displayDesciption))
                {
                    _displayDesciption = this.Name;
                    DescriptionAttribute a = GetAttributes().OfType<DescriptionAttribute>().FirstOrDefault();
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
                    CategoryAttribute a = GetAttributes().OfType<CategoryAttribute>().FirstOrDefault();
                    if (a != null)
                        _category = a.Category;
                }

                return _category;
            }
        }

        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public dynamic DefaultValue
        {
            get
            {
                if (_defaultValue == null)
                {
                    DefaultValueAttribute a = GetAttributes().OfType<DefaultValueAttribute>().FirstOrDefault();
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
        /// Gets a value indicating whether this <see cref="T:IAccessorItem" /> is required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if required; otherwise, <c>false</c>.
        /// </value>
        public bool Required
        {
            get
            {

                if (!_required.HasValue)
                {
                    _required = false;
                    RequiredAttribute a = GetAttributes().OfType<RequiredAttribute>().FirstOrDefault();
                    if (a != null)
                        _required = true;
                }

                return _required.Value;

            }
        }

        #endregion attributes

        internal static AccessorList GetPropertiesImpl(Type componentType, MemberStrategy strategy, Func<Type, bool> filter, Func<MemberInfo, bool> memberFilter)
        {

            if (filter == null)
                filter = (x) => true;

            AccessorList list = null;

            if (strategy.HasFlag(MemberStrategy.ConvertIfDifferent))
                strategy = strategy & ~MemberStrategy.Direct;

            if (!strategy.HasFlag(MemberStrategy.Properties) && !strategy.HasFlag(MemberStrategy.Fields))
                strategy |= MemberStrategy.Properties;

            if (!strategy.HasFlag(MemberStrategy.Instance) && !strategy.HasFlag(MemberStrategy.Static))
                strategy |= MemberStrategy.Instance;


            if (memberFilter != null)
                return GenerateList(componentType, strategy, filter, memberFilter);


            memberFilter = (x) => true;

            if (!_strategyPropertiesAccessors.TryGetValue(strategy, out var _accessors))
                lock (_lock)
                    if (!_strategyPropertiesAccessors.TryGetValue(strategy, out _accessors))
                        _strategyPropertiesAccessors.Add(strategy, _accessors = new Dictionary<Type, AccessorList>());

            if (!_accessors.TryGetValue(componentType, out list))
                lock (_lock)
                    if (!_accessors.TryGetValue(componentType, out list))
                        _accessors.Add(componentType, list = GenerateList(componentType, strategy, filter, memberFilter));

            return list;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AccessorList GenerateList(Type componentType, MemberStrategy strategy, Func<Type, bool> typeFilter, Func<MemberInfo, bool> memberFilter)
        {

            AccessorList list = new AccessorList();

            if (strategy.HasFlag(MemberStrategy.Properties))
                foreach (PropertyInfo item in AccessorList.GetProperties(componentType, typeFilter))
                    if (memberFilter(item) && !list.ContainsKey(item.Name) && IsAccepted(item, strategy))
                        list.Add(new PropertyAccessor(componentType, item, strategy));

            if (strategy.HasFlag(MemberStrategy.Fields))
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
        protected string ResolveName(string name)
        {

            var index = name.LastIndexOf('.');

            if (index > -1)
            {
                return name.Substring(index + 1);
            }

            return name;
        }


        #region private


        private static bool IsAccepted(PropertyInfo item, MemberStrategy strategy)
        {

            if (item.GetIndexParameters().Length > 0)
                return false;

            if (item.GetMethod == null && item.SetMethod == null)
                return false;

            if (!strategy.HasFlag(MemberStrategy.Static))
            {

                if ((item.GetMethod != null && item.GetMethod.IsStatic)
                 || (item.SetMethod != null && item.SetMethod.IsStatic))
                    return false;

            }

            if (!strategy.HasFlag(MemberStrategy.Instance))
            {
                if ((item.GetMethod != null && !item.GetMethod.IsStatic)
                 || (item.SetMethod != null && !item.SetMethod.IsStatic))
                    return false;
            }

            return true;

        }

        private static bool IsAccepted(FieldInfo item, MemberStrategy strategy)
        {

            if (!strategy.HasFlag(MemberStrategy.NotPublicFields) && !item.Attributes.HasFlag(FieldAttributes.Public))
                if (item.Attributes.HasFlag(FieldAttributes.Private) || item.Attributes.HasFlag(FieldAttributes.PrivateScope))
                    return false;

            if (strategy.HasFlag(MemberStrategy.Static) && !strategy.HasFlag(MemberStrategy.Instance))
                return item.IsStatic;

            else if (strategy.HasFlag(MemberStrategy.Instance) && !strategy.HasFlag(MemberStrategy.Static))
                return !item.IsStatic;

            return true;

        }

        List<Attribute> _attributes1;
        private string _displayName = null;
        private string _category = null;
        string _displayDesciption = null;
        private bool? _required = null;
        private dynamic _defaultValue = null;


        /// <summary>
        /// The _accessors
        /// </summary>
        private static Dictionary<MemberStrategy, Dictionary<Type, AccessorList>> _strategyPropertiesAccessors = new Dictionary<MemberStrategy, Dictionary<Type, AccessorList>>();
        /// <summary>
        /// The _lock
        /// </summary>
        private static volatile object _lock = new object();

        #endregion private


    }


}
