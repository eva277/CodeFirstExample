using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.Model
{
    public class Producto
    {
        // Comentar si ProxyCreationEnabled = true
        public Producto()
        {
            Lineas = new Collection<LineaPedido>();
        }
        public virtual int ProductoId { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual decimal Precio { get; set; }
        public virtual ICollection<LineaPedido> Lineas { get; set; }
    }
}
