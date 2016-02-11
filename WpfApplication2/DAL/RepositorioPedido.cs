using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication2.Model;
namespace WpfApplication2.DAL
{
    public class RepositorioPedido: RepositorioGenerico<Pedido>
    {
        public RepositorioPedido(TiendaContext context)
            : base(context)
        {
        }
        public ICollection<Pedido> getPedidosCliente(int cliId) {
            return dbSet.Include("Cliente").ToList();
        }
       
        public virtual void Delete(int idCliente)
        {
           
            Pedido  pedido= context.Pedidos.Include("LineaPedido").Where(c=>c.ClienteId == idCliente).Single();
                             

            Delete(pedido);
        }
    }
}
