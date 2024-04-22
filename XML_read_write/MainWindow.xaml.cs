using System.Data;
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
using System.IO;
using Path = System.IO.Path;

namespace XML_read_write
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string file_path = "";
       
        public MainWindow()
        {
            InitializeComponent();
            contact_manager.get_list_file(cb_list_file);
            //contact_manager.create_file(Const_Value.file_path);
  
        }

        private void cb_list_file_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            file_path = @"store\" + cb_list_file.SelectedItem.ToString();
            contact_manager.load_xml(DGV, file_path);

        }

        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            contact_item item = new contact_item();           
            item.Id = DGV.Items.Count.ToString();
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

            if(file_path != "")
            {
                contact_manager.add_xml(item, file_path);
                contact_manager.load_xml(DGV, file_path);
            }
            else
            {
                MessageBox.Show("chua chon danh sach contact");
            }

             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string file_path = @"store\" + tb_new_list.Text + @".xml";
            try
            {
                int i = contact_manager.create_file(file_path);
                if(i == 1)
                {
                    MessageBox.Show($"tao file {file_path} thanh cong");
                    contact_manager.get_list_file(cb_list_file);
                }
                else
                {
                    MessageBox.Show($"file da ton tai");

                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
    }
}