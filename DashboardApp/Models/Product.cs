using System.Collections;
using DashboardApp.Models;
using System.ComponentModel.DataAnnotations;

namespace DashboardApp.Models
{
    public class Product
    {
        [Display(Name="SKU")]
        [StringLength(8)]
        [Required(ErrorMessage = "Required")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }


        [Display(Name = "Collection Name")]
        public string CollectionName { get; set; }


        [Display(Name = "Initiating Stock")]
       
        public int CurrentStock { get; set; }

        [Display(Name = "Collection")]
        public int CollectionId { get; set; }


        [Display(Name = "GTIN")]
        [DataType(DataType.EmailAddress)]
        public string Gtin { get; set; }

        [Range(50,1000)]
        [Display(Name = "Product Price")]
        public int Price { get; set; }

        [Display(Name = "Product Weight (in grams)")]
        public double Weight { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Display(Name = "Product Highlights")]
        public string Highlights { get; set; }

        public virtual Product SkuNavigation { get; set; }

        public virtual Collection Collection { get; set; }

    }
}