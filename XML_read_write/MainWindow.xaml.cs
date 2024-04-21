using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XML_read_write.all_class;

namespace XML_read_write
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i = 0;
         
        public MainWindow()
        {
            InitializeComponent();
            contact_manager.create_file();
            contact_manager.load_xml(DGV);
        }

        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            contact_item item = new contact_item(); 
            item.Id = i.ToString();
            item.F_name = tb_fname.Text;
            item.L_name = tb_lname.Text;
            item.Phone = tb_phone.Text;
            foreach(RadioButton rb in gender_group.Children)
            {
                if(rb.IsChecked == true)
                {
                    item.Gender = rb.Content.ToString();
                    break;
                }
            }

            contact_manager.add_xml(item);
            contact_manager.load_xml(DGV);
            i++;
        }
    }
}