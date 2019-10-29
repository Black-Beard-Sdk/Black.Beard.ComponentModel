using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Bb.ComponentModel.Accessors
{
    /// <summary>
    /// Validation Helper
    /// </summary>
    public static class ValidationHelper
    {

        /// <summary>
        /// Validates the specified dob.
        /// </summary>
        /// <param name="dob">The dob.</param>
        /// <param name="member">The member.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static ValidationException Validate(this object dob, MemberInfo member, IEnumerable<ValidationAttribute> attributes)
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
