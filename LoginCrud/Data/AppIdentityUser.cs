using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LoginCrud.Data
{
    public class AppIdentityUser : IdentityUser
    {
        [StringLength(50)]
        public string? NickName { get; set; }
    }
}
