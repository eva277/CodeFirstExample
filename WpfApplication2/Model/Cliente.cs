using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WpfApplication2.DAL;

namespace WpfApplication2.Model
{
    [PropertyChanged.ImplementPropertyChanged]
    public class Cliente: PropertyValidateModel 
    {
       
        public Cliente()
        {
            Pedidos = new Collection<Pedido>();
        }
        public  int ClienteId { get; set; }
        [Required]
        public  string Nombre { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public  string  Apellidos { get; set; }
        [Display(Name = "Nombre Completo")]
        public string nombreCompleto
        {
            get { return Nombre + " " + Apellidos; }
        }
        public virtual string Direccion { get; set; }
       
        [StringLength(12, MinimumLength = 9)]
        [Phone]
        [Display(Name = "Móbil")]
        [DataType(DataType.PhoneNumber,
            ErrorMessage = "O número de teléfono non é válido")]
        public string Movil { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email Address is Invalid")]
        public string Email   { get; set; } 
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
