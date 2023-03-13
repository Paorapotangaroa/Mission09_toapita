using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Models
{
    // Adding a purchase model so that it can be recorded in the database
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }
        [BindNever]
        public ICollection<BookItem> Books { get; set; }
        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a valid address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage ="Please enter a valid city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a valid state name")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a valid zip name")]

        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
