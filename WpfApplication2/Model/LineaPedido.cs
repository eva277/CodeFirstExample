using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.Model
{
    public class LineaPedido
    {
        public virtual int LineaPedidoId { get; set; }
        public virtual int PedidoId { get; set; }
        public virtual int ProductoId { get; set; }
        public virtual int Unidades { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
