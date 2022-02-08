using System.ComponentModel;

namespace Bb.ComponentModel.DataAnnotations
{
    public interface ILogin
    {

        [DisplayName("p:ILoginModel,k:Login,l:en-us,d:Login")]
        [Description("p:ILoginModel,k:LoginDescription,l:en-us,d:Login")]
        public string Login { get; set; }


        [Description("p:ILoginModel,k:PassordDescription,l:en-us,d:Password")]
        [PasswordPropertyText(true)]
        public string Password { get; set; }

    }

}
