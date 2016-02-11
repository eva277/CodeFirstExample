using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication2.DAL;
using WpfApplication2.Model;
namespace WpfApplication2
{
    public partial class MainWindow : Window
    {
        PropertyValidateModel validador = new PropertyValidateModel();
        private UnitOfWork uow = new UnitOfWork();
        Cliente c;
        public MainWindow()
        {

            c = new Cliente { Nombre = "nombre",Apellidos="   " };
            InitializeComponent();
            DataContext = c;

        }
       
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            c.Nombre = textBoxNombre.Text;
            c.Apellidos = textBoxApellidos.Text;
            c.Email = textBoxMail.Text;
            c.Movil = TexBoxTfno.Text;
            c.Direccion = TextBoxDireccion.Text;
            if (validador.errrores(c)!="")
            { MessageBox.Show(validador.errrores(c)); }
            else { 
                uow.RepositorioCliente.Insert(c);
                uow.Save();

            }




        }

        

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
          
            
           
        }

        
        private void buttonModificar_Click(object sender, RoutedEventArgs e)
        {   
            if (validador.errrores(c) != "")
            { MessageBox.Show(validador.errrores(c)); }
            else {
                uow.RepositorioCliente.Update(c);
                uow.Save();

            }

        }

        private void buttonEliminar_Click(object sender, RoutedEventArgs e)
        {   Cliente cli = uow.RepositorioCliente.Get(c=>c.Email.Equals(textBoxMail.Text)).FirstOrDefault();

            uow.RepositorioCliente.Delete(cli);
        }

        private void buttonVer_Click(object sender, RoutedEventArgs e)
        {
            //Cliente cli = uow.RepositorioCliente.getClienteConPedidos(Convert.ToInt32(textBoxId.Text));
            //dataGrid.ItemsSource = cli.Pedidos.ToList();
            

            dataGrid.ItemsSource =uow.RepositorioPedido.getPedidosCliente(Convert.ToInt32(textBoxId.Text)). Select(p => new { p.PedidoId, p.ClienteId, p.Cliente.nombreCompleto, Fecha=p.FechaCreacion.ToString("MM/dd/yyyy") }).ToList();
        }
    }
}
