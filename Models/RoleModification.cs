using System.ComponentModel.DataAnnotations;

namespace Muresan_Razvan_Lab2.Models
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] AddIds { get; set; }
        public string[]? DeleteIds { get; set; }
    }
}
