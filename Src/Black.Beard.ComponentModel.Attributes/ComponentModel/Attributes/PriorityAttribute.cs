using System;
using System.Linq;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Specifies the priority of a class.
    /// </summary>
    /// <remarks>
    /// This attribute is used to assign a priority value to a class, which can be used for sorting or ordering purposes.
    /// </remarks>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PriorityAttribute : Attribute, IComparable<PriorityAttribute>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityAttribute"/> class with the specified priority.
        /// </summary>
        /// <param name="priority">The priority value to assign to the class.</param>
        /// <example>
        /// <code lang="C#">
        /// [Priority(1)]
        /// public class MyClass { }
        /// </code>
        /// </example>
        public PriorityAttribute(int priority)
        {
            this.Priority = priority;
        }

        /// <summary>
        /// Gets the priority value assigned to the class.
        /// </summary>
        /// <returns>The priority value.</returns>
        public int Priority { get; }

        /// <summary>
        /// Compares the current <see cref="PriorityAttribute"/> with another <see cref="PriorityAttribute"/> to determine their relative order.
        /// </summary>
        /// <param name="other">The other <see cref="PriorityAttribute"/> to compare with.</param>
        /// <returns>
        /// A value less than zero if this instance precedes <paramref name="other"/> in the sort order;
        /// zero if they are equal; or a value greater than zero if this instance follows <paramref name="other"/>.
        /// </returns>
        /// <remarks>
        /// If <paramref name="other"/> is <c>null</c>, this instance is considered to have a higher priority.
        /// </remarks>
        public int CompareTo(PriorityAttribute other)
        {

            if (other == null)
                return 1;

            return this.Priority.CompareTo(other.Priority);

        }

        /// <summary>
        /// Resolves the priority value for a specified type.
        /// </summary>
        /// <param name="type">The type for which to resolve the priority.</param>
        /// <returns>The priority value of the type, or a default value of 10000 if no priority is specified.</returns>
        /// <remarks>
        /// This method retrieves the priority value from the <see cref="PriorityAttribute"/> applied to the specified type.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int priority = PriorityAttribute.ResolvePriority(typeof(MyClass));
        /// </code>
        /// </example>
        public static int ResolvePriority(Type type)
        {

            int result = 10000;

            var attribute = type.GetCustomAttributes(typeof(PriorityAttribute), true).FirstOrDefault();
            
            if (attribute != null)
                result = ((PriorityAttribute)attribute).Priority;

            return result;

        }

        /// <summary>
        /// Determines whether two <see cref="PriorityAttribute"/> instances are equal.
        /// </summary>
        /// <param name="left">The first <see cref="PriorityAttribute"/> to compare.</param>
        /// <param name="right">The second <see cref="PriorityAttribute"/> to compare.</param>
        /// <returns><c>true</c> if the priority values are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PriorityAttribute left, PriorityAttribute right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left is null || right is null)
                return false;

            return left.Priority == right.Priority;
        }

        /// <summary>
        /// Determines whether two <see cref="PriorityAttribute"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="PriorityAttribute"/> to compare.</param>
        /// <param name="right">The second <see cref="PriorityAttribute"/> to compare.</param>
        /// <returns><c>true</c> if the priority values are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PriorityAttribute left, PriorityAttribute right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the priority of one <see cref="PriorityAttribute"/> is greater than another.
        /// </summary>
        /// <param name="left">The first <see cref="PriorityAttribute"/> to compare.</param>
        /// <param name="right">The second <see cref="PriorityAttribute"/> to compare.</param>
        /// <returns><c>true</c> if the priority of <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator >(PriorityAttribute left, PriorityAttribute right)
        {
            if (left is null)
                return false;

            if (right is null)
                return true;

            return left.Priority > right.Priority;
        }

        /// <summary>
        /// Determines whether the priority of one <see cref="PriorityAttribute"/> is less than another.
        /// </summary>
        /// <param name="left">The first <see cref="PriorityAttribute"/> to compare.</param>
        /// <param name="right">The second <see cref="PriorityAttribute"/> to compare.</param>
        /// <returns><c>true</c> if the priority of <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator <(PriorityAttribute left, PriorityAttribute right)
        {
            if (right is null)
                return false;

            if (left is null)
                return true;

            return left.Priority < right.Priority;
        }

        /// <summary>
        /// Determines whether the priority of one <see cref="PriorityAttribute"/> is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first <see cref="PriorityAttribute"/> to compare.</param>
        /// <param name="right">The second <see cref="PriorityAttribute"/> to compare.</param>
        /// <returns><c>true</c> if the priority of <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator >=(PriorityAttribute left, PriorityAttribute right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Determines whether the priority of one <see cref="PriorityAttribute"/> is less than or equal to another.
        /// </summary>
        /// <param name="left">The first <see cref="PriorityAttribute"/> to compare.</param>
        /// <param name="right">The second <see cref="PriorityAttribute"/> to compare.</param>
        /// <returns><c>true</c> if the priority of <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator <=(PriorityAttribute left, PriorityAttribute right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="PriorityAttribute"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="PriorityAttribute"/>.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="PriorityAttribute"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is PriorityAttribute other)
                return this == other;

            return false;
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="PriorityAttribute"/>.
        /// </summary>
        /// <returns>The hash code for the current <see cref="PriorityAttribute"/>.</returns>
        public override int GetHashCode()
        {
            return Priority.GetHashCode();
        }

    }

}
