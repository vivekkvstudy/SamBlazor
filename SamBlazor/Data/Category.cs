using System.ComponentModel.DataAnnotations;

namespace SamBlazor.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the name")]
        public string Name { get; set; }
    }
}
