using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.Model
{
    public class Pedido
    {
        // Comentar si ProxyCreationEnabled = true
        public Pedido()
        {
            Lineas = new Collection<LineaPedido>();
        }
        public virtual int PedidoId { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<LineaPedido> Lineas { get; set; }
    }
}
