using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApplication2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        private UnitOfWork uow = new UnitOfWork();
        
        public MainWindow()
        {
            InitializeComponent();
            

        }
        
        private Boolean validado(Object obj)
        {

            ValidationContext validationContext = new ValidationContext(obj, null, null);
            List<System.ComponentModel.DataAnnotations.ValidationResult> errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            Validator.TryValidateObject(obj, validationContext, errors, true);
           
            if (errors.Count() > 0)
            {
                
                string mensageErrores = string.Empty;
                foreach (var error in errors)
                {
                    error.MemberNames.First();
                   
                    mensageErrores += error.ErrorMessage + Environment.NewLine;
                }
                MessageBox.Show(mensageErrores); return false;
            }
            else
            {
                return true;


            }
           
        }
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente();
            cli.Nombre = textBoxNombre.Text;
            cli.Apellidos = textBoxApellidos.Text;
            cli.Email = textBoxMail.Text;
            cli.Direccion = TextBoxDireccion.Text;
            //GetModelErrors(cli);
            if (validado(cli))
            {
                uow.RepositorioCliente.Insert(cli);
                uow.Save();
            }





        }
    }
}
