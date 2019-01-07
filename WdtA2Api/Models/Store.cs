// <copyright file="Store.cs" company="kokaruk.com">
//   Dimz
// </copyright>
// <summary>
//   Defines the Store type.
// </summary>

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace WdtA2Api.Models
{
    /// <summary>
    /// The store entity.
    /// </summary>
    public class Store
    {
        [Display(Name = "Store ID")]
        public long StoreId { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
