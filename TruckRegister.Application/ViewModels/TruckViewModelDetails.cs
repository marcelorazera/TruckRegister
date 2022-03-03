using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckRegister.Application.ViewModels
{
    public class TruckViewModelDetails
    {
        public Guid Id { get; set; }        

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Fabrication Year")]
        public int FabricationYear { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayName("Model Year")]
        public int ModelYear { get; set; }

        [DisplayName("Created")]
        public DateTime Created { get; set; }

        [DisplayName("Changed")]
        public DateTime? Changed { get; set; }
    }
}