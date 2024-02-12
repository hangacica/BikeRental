using System;
using System.Collections.Generic;
using System.IO;
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

namespace BikeRentalClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string BikeDBPath = "bikes.csv";
        private void NewBike_Click(object sender, RoutedEventArgs e)
        {
            BikeEditorWindow window = new BikeEditorWindow();
            if (window.ShowDialog() == true)
            {
                LB_Bikes.Items.Add(window.Bike);
                Save();               
            }            
        }
        private void DeleteBike_Click(object sender, RoutedEventArgs e)
        {
            LB_Bikes.Items.Remove(LB_Bikes.SelectedItem);
            Save();
        }
        private void EditBike_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Bikes.SelectedItem == null) return;            
            BikeEditorWindow window = new BikeEditorWindow();
            window.Bike = (Bike)LB_Bikes.SelectedItem;
            if (window.ShowDialog() == true)
            {
                int index = LB_Bikes.SelectedIndex;
                LB_Bikes.Items.RemoveAt(index);
                LB_Bikes.Items.Insert(index, window.Bike);
                Save();
            }                     
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(BikeDBPath))
            {
                string[] lines = File.ReadAllLines(BikeDBPath);
                foreach (string line in lines)
                {
                    Bike bike = Bike.FromCsv(line);
                    LB_Bikes.Items.Add(bike);
                }
            }
            else
            {
               File.Create(BikeDBPath);
            }            
        }

        private void Save()
        {
            List<string> op = new List<string>();
            foreach (Bike item in LB_Bikes.Items)
            {
                op.Add(item.ToCsv());
            }
            File.WriteAllLines(BikeDBPath, op);
        }

        private void LB_Bike_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BTN_EditBike.IsEnabled = LB_Bikes.SelectedItem != null;
            BTN_DeleteBike.IsEnabled = LB_Bikes.SelectedItem !=null;
        }
    }
}
