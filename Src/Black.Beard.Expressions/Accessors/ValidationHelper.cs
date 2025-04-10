using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Bb.Accessors
{
    /// <summary>
    /// Validation Helper
    /// </summary>
    public static class ValidationHelper
    {

        /// <summary>
        /// Validates the specified object against the provided validation attributes.
        /// </summary>
        /// <param name="dob">The object to validate. Must not be null.</param>
        /// <param name="member">The member information associated with the object. Must not be null.</param>
        /// <param name="attributes">The collection of <see cref="ValidationAttribute"/> to apply during validation. Must not be null.</param>
        /// <returns>
        /// A <see cref="ValidationException"/> if validation fails, or <c>null</c> if validation succeeds.
        /// </returns>
        /// <remarks>
        /// This method validates the specified object using the provided validation attributes. If validation fails, it returns a <see cref="ValidationException"/> containing detailed error information.
        /// </remarks>
        /// <exception cref="ValidationException">
        /// Thrown if the object fails validation. The exception contains detailed error messages in its <c>Data</c> property.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var attributes = new List&lt;ValidationAttribute&gt;
        /// {
        ///     new RequiredAttribute(),
        ///     new StringLengthAttribute(10) { MinimumLength = 5 }
        /// };
        /// var memberInfo = typeof(MyClass).GetProperty("MyProperty");
        /// var validationResult = myObject.Validate(memberInfo, attributes);
        /// if (validationResult != null)
        /// {
        ///     Console.WriteLine(validationResult.Message);
        /// }
        /// </code>
        /// </example>
        public static ValidationException? Validate(this object dob, MemberInfo member, IEnumerable<ValidationAttribute> attributes)
        {

            List<ValidationResult> results = new List<ValidationResult>();

            bool result = Validator.TryValidateValue(dob, new ValidationContext(new object(), null, null), results, attributes);

            if (!result)
            {

                ValidationException v1 = new ValidationException(string.Format("Validation exception on the property '{0}'. Please see the Data collection for more informations.", member.Name));

                foreach (var item in results)
                {
                    ValidationException v = new ValidationException(item.ErrorMessage, null, dob) { /*HResult = (int)CommonErrorsEnum.ValidationException Source = ExceptionManager.Source */ };
                    v1.Data.Add("exception" + (v1.Data.Count + 1).ToString(), v);
                }

                return v1;
            }

            return null;

        }
    }


}
