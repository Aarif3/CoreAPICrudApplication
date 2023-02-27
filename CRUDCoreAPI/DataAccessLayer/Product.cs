using System.ComponentModel.DataAnnotations;

namespace CRUDCoreAPI.DataAccessLayer
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required!!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Description is required!!")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Price is required!!")]
        public int Price { get; set; }
    }
}
