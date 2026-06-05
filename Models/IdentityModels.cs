using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace JewelryStore.Models
{
    // Користувач
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
    }

    // Контекст Identity
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }

    // Менеджер користувачів
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store) { }

        public static ApplicationUserManager Create(
            IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            ApplicationUserManager manager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(db));
            return manager;
        }
    }

    // Модель реєстрації
    public class RegisterModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.DataType(
            System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "Паролі не співпадають")]
        [System.ComponentModel.DataAnnotations.DataType(
            System.ComponentModel.DataAnnotations.DataType.Password)]
        public string PasswordConfirm { get; set; }
    }

    // Модель входу
    public class LoginModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.DataType(
            System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}