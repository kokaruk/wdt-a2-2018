// <copyright file="Product.cs" company="kokaruk.com">
//   Dimz
// </copyright>
// <summary>
//   Defines the Product type.
// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WdtA2Api.Models
{
    /// <summary>
    /// Product entity
    /// </summary>  
    public class Product
    {
        [Display(Name = "Product ID")]
        public long ProductId { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
