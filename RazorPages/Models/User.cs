using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Rola jest wymagana")]
        [StringLength(20, ErrorMessage = "Rola nie może być dłuższa niż 20 znaków")]
        public string Role { get; set; }
    }
}
