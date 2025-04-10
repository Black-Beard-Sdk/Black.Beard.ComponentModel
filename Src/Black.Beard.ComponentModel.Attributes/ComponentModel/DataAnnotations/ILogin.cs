using System.ComponentModel;

namespace Bb.ComponentModel.DataAnnotations
{


    /// <summary>
    /// Represents a login model.
    /// </summary>
    public interface ILogin
    {

        /// <summary>
        /// Gets or sets the login name.
        /// </summary>
        [DisplayName("p:ILoginModel,k:Login,l:en-us,d:Login")]
        [Description("p:ILoginModel,k:LoginDescription,l:en-us,d:Login")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Description("p:ILoginModel,k:PassordDescription,l:en-us,d:Password")]
        [PasswordPropertyText(true)]
        public string Password { get; set; }

    }

}
