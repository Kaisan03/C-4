using System.ComponentModel.DataAnnotations;
namespace DuAnBanGiayCs4.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập PassWord")]
        public string PassWord { get; set; }
    }
}
