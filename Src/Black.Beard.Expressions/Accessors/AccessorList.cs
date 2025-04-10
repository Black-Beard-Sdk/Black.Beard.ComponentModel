// Ignore Spelling: Accessor

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Bb.Accessors
{
    /// <summary>
    /// list of Accessors
    /// </summary>
    public class AccessorList : IEnumerable<AccessorItem>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorList"/> class.
        /// </summary>
        internal AccessorList()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorList"/> class.
        /// </summary>
        /// <param name="list">The list of <see cref="AccessorItem"/> objects to initialize the collection. Must not be null.</param>
        /// <remarks>
        /// This constructor populates the internal dictionary with the provided list of accessor items, using their names as keys.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var accessorItems = new List&lt;AccessorItem&gt;
        /// {
        ///     new AccessorItem(typeof(MyClass), MemberTypeEnum.Property, MemberStrategy.Properties),
        ///     new AccessorItem(typeof(MyClass), MemberTypeEnum.Field, MemberStrategy.Fields)
        /// };
        /// var accessorList = new AccessorList(accessorItems);
        /// </code>
        /// </example>
        public AccessorList(IEnumerable<AccessorItem> list)
        {
            foreach (var item in list)
                _list.Add(item.Name, item);
        }

        /// <summary>
        /// Tries to retrieve an <see cref="AccessorItem"/> by its name.
        /// </summary>
        /// <param name="name">The name of the accessor to retrieve. Must not be null or empty.</param>
        /// <param name="member">The retrieved <see cref="AccessorItem"/> if found, or null if not found.</param>
        /// <returns>
        /// <c>true</c> if the accessor is found; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method attempts to find an accessor in the collection by its name and returns it if found.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// if (accessorList.TryGetValue("MyProperty", out var accessor))
        /// {
        ///     Console.WriteLine($"Accessor found: {accessor.Name}");
        /// }
        /// else
        /// {
        ///     Console.WriteLine("Accessor not found.");
        /// }
        /// </code>
        /// </example>
        public bool TryGetValue(string name, out AccessorItem? member)
        {
            return _list.TryGetValue(name, out member);
        }

        /// <summary>
        /// Determines whether the collection contains an accessor with the specified name.
        /// </summary>
        /// <param name="name">The name of the accessor to check. Must not be null or empty.</param>
        /// <returns>
        /// <c>true</c> if the collection contains an accessor with the specified name; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method checks if an accessor with the given name exists in the collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// if (accessorList.ContainsKey("MyProperty"))
        /// {
        ///     Console.WriteLine("Accessor exists.");
        /// }
        /// else
        /// {
        ///     Console.WriteLine("Accessor does not exist.");
        /// }
        /// </code>
        /// </example>
        public bool ContainsKey(string name)
        {
            return _list.ContainsKey(name);
        }

        /// <summary>
        /// Adds a new <see cref="AccessorItem"/> to the collection.
        /// </summary>
        /// <param name="propertyAccessor">The <see cref="AccessorItem"/> to add. Must not be null.</param>
        /// <remarks>
        /// This method adds the specified accessor to the collection if it does not already exist.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var accessor = new AccessorItem(typeof(MyClass), MemberTypeEnum.Property, MemberStrategy.Properties);
        /// accessorList.Add(accessor);
        /// </code>
        /// </example>
        public void Add(AccessorItem propertyAccessor)
        {
            if (!_list.ContainsKey(propertyAccessor.Name))
                _list.Add(propertyAccessor.Name, propertyAccessor);
        }

        /// <summary>
        /// Removes an <see cref="AccessorItem"/> from the collection by its instance.
        /// </summary>
        /// <param name="propertyAccessor">The <see cref="AccessorItem"/> to remove. Must not be null.</param>
        /// <remarks>
        /// This method removes the specified accessor from the collection if it exists.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// accessorList.Remove(accessor);
        /// </code>
        /// </example>
        public void Remove(AccessorItem propertyAccessor)
        {
            _list.Remove(propertyAccessor.Name);
        }

        /// <summary>
        /// Removes an <see cref="AccessorItem"/> from the collection by its name.
        /// </summary>
        /// <param name="name">The name of the accessor to remove. Must not be null or empty.</param>
        /// <remarks>
        /// This method removes the accessor with the specified name from the collection if it exists.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// accessorList.Remove("MyProperty");
        /// </code>
        /// </example>
        public void Remove(string name)
        {
            _list.Remove(name);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<AccessorItem> GetEnumerator()
        {
            return _list.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets or sets the <see cref="T:IAccessorItem"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="AccessorItem"/>.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public AccessorItem? this[string name]
        {
            get
            {
                if (_list.ContainsKey(name))
                    return _list[name];
                return null;
            }
            set
            {
                if (value is AccessorItem a)
                {
                    if (_list.ContainsKey(name))
                        _list[name] = a;
                    else
                        _list.Add(value.Name, a);
                }
            }
        }

        /// <summary>
        /// Gets the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="respectCase">If true try to match with sensitive case.</param>
        /// <returns></returns>
        public AccessorItem? Get(string memberName, bool respectCase = true)
        {

            var result = this[memberName];

            if (result == null && !respectCase)
                foreach (var item in this)
                    if (item.Name.ToLower() == memberName.ToLower())
                    {
                        result = item;
                        break;
                    }

            return result;

        }

        /// <summary>
        /// Gets or sets the <see cref="AccessorItem"/> with the specified member.
        /// </summary>
        /// <value>
        /// The <see cref="AccessorItem"/>.
        /// </value>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public AccessorItem? this[MemberInfo member]
        {
            get => this[member.Name];
            set => this[member.Name] = value as AccessorItem;
        }

        /// <summary>
        /// Maps the values of clonable accessors from a source object to a target object.
        /// </summary>
        /// <param name="source">The source object. Must not be null.</param>
        /// <param name="target">The target object. Must not be null.</param>
        /// <remarks>
        /// This method iterates through all clonable accessors in the collection and copies their values from the source object to the target object.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// accessorList.Map(sourceObject, targetObject);
        /// </code>
        /// </example>
        public void Map(object source, object target)
        {
            foreach (var item in _list.Select(c => c.Value))
            {
                if (item.Clonable && item.GetValue != null && item.SetValue != null)
                {
                    var data = item.GetValue(source);
                    item.SetValue(target, data);
                }
            }
        }

        /// <summary>
        /// Gets the count of accessors.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <param name="typeFilter">Return properties that match with the filter.</param>
        /// <returns></returns>
        internal static IEnumerable<PropertyInfo> GetProperties(Type componentType, Func<Type, bool>? typeFilter)
        {
            var type = componentType;
            while (type != null && type != typeof(object) && type != typeof(Type))
            {

                if (typeFilter == null || typeFilter(type))
                    foreach (var item in type.GetProperties(_bindings))
                        yield return item;

                type = type.BaseType;

            }
        }

        internal static IEnumerable<FieldInfo> GetFields(Type componentType, Func<Type, bool> typeFilter)
        {
            var type = componentType;
            while (type != null && type != typeof(object) && type != typeof(Type))
            {

                if (typeFilter(type))
                    foreach (var item in type.GetFields(_bindings))
                        yield return item;

                type = type.BaseType;

            }
        }

        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void Validate(object instance)
        {

            ValidationException e = new("Validation exception. Please see the data collection for more informations.");

            foreach (var item in _list.Select(c => c.Value))
                if (item.GetValue != null)
                {

                    var v1 = item.GetValue(instance);
                    var e1 = item.ValidateMember(instance, false);
                    if (e1 != null)
                        foreach (var item3 in e1.Data.Values)
                            e.Data.Add("exception" + (e.Data.Count + 1).ToString(), item3);

                    var _a = item.GetAttributes<ValidationAttribute>(true).ToList();
                    var validationException = ValidateMember(v1, item.Member, _a);

                    if (validationException != null)
                        foreach (var item3 in validationException.Data.Values)
                            e.Data.Add("exception" + (e.Data.Count + 1).ToString(), item3);

                }

            if (e.Data.Count > 0)
                throw e;

        }

        /// <summary>
        /// Validates the specified dob.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="member">The member.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        private static ValidationException? ValidateMember(object value, MemberInfo member, IEnumerable<ValidationAttribute> attributes)
        {
            List<ValidationResult> results = new();

            bool result = Validator.TryValidateValue(value, new ValidationContext(new object(), null, null), results, attributes);

            if (!result)
            {

                ValidationException v1 = new ValidationException(string.Format("Validation exception on the property '{0}'. Please see the Data collection for more informations.", member.Name));

                foreach (var item in results)
                {
                    ValidationException v = new ValidationException(item.ErrorMessage, null, value) { /*HResult = (int)CommonErrorsEnum.ValidationException Source = ExceptionManager.Source */ };
                    v1.Data.Add("exception" + (v1.Data.Count + 1).ToString(), v);
                }

                return v1;
            }

            return null;

        }

        private readonly Dictionary<string, AccessorItem> _list = new Dictionary<string, AccessorItem>();
        private const BindingFlags _bindings = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
    }

}
