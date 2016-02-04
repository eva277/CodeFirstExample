using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication2.Model;
namespace WpfApplication2.DAL
{
    public class RepositorioCliente: RepositorioGenerico<Cliente>
    {
        public RepositorioCliente(TiendaContext context)
            : base(context)
        {
        }

        public IEnumerable<Cliente> GetFiltrado(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (usuario => usuario.Nombre.ToUpper().Contains(buscado.ToUpper())
                                            || usuario.Email.ToUpper().Contains(buscado.ToUpper())
                                            ));
            }
            else return Get();
        }
        public IEnumerable<Cliente> GetFiltradoAlfabeticamente(String buscado)
        {
            if (!string.IsNullOrWhiteSpace(buscado))
            {
                return Get(filter: (usuario => usuario.Nombre.ToUpper().Contains(buscado.ToUpper())
                                            || usuario.Email.ToUpper().Contains(buscado.ToUpper())),
                                                                                      
                            orderBy: clientes => clientes.OrderBy(
                                m => new {  m.Apellidos, m.Nombre }));
            }
            else return Get(orderBy: clientes => clientes.OrderBy
                (m => new { m.Apellidos,  m.Nombre }));
        }
        public virtual void Delete(int idCliente)
        {
            //Cliente cliente = (from Cliente c in context.Clientes.
            //                   Include("Pedido")
            //                   where c.ClienteId == idCliente
            //                   select c).Single();
            Cliente  cliente= context.Clientes.Include("Pedido").Where(c=>c.ClienteId == idCliente).Single();
            //                   

            Delete(cliente);
        }
    }
}
