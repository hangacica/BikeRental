using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BikeRentalClient
{
    /// <summary>
    /// Interaction logic for BikeEditorWindow.xaml
    /// </summary>
    public partial class BikeEditorWindow : Window
    {
        public BikeEditorWindow()
        {
            InitializeComponent();
        }
        public Bike? Bike { get; set; }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Bike = new Bike();
            Bike.Name = TB_Name.Text.Trim();
            Bike.Brand = TB_Brand.Text.Trim();
            Bike.Type = TB_Type.Text.Trim();
            Bike.Manufactured = DP_Manufactured.SelectedDate;
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Bike != null)
            {
                TB_Name.Text = Bike.Name;
                TB_Brand.Text = Bike.Brand;
                TB_Type.Text = Bike.Type;
                DP_Manufactured.SelectedDate = Bike.Manufactured;
            }
        }

        private void Property_Changed(object sender, EventArgs e)
        {
            BTN_Save.IsEnabled = FormIsValid();
                
        }

        private bool FormIsValid()
        {
            try
            {
                return !string.IsNullOrWhiteSpace(TB_Name.Text) && !string.IsNullOrWhiteSpace(TB_Brand.Text) && !string.IsNullOrWhiteSpace(TB_Type.Text) && DateTime.Parse(DP_Manufactured.Text) != null;
            }
            catch (Exception)
            {
                return false;
            }             
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape: Close(); break;
                case Key.Enter: 
                    if (FormIsValid())
                    {
                        Save_Click(sender, e); 
                        e.Handled = true; 
                    }
                    break;
            }
        }

        private void DP_Release_KeyDown(object sender, KeyEventArgs e)
        {
            string asd = "valami";
        }

        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox tb)
            {
                tb.CaretIndex = tb.Text.Length;
            }            
        }
    }
}
