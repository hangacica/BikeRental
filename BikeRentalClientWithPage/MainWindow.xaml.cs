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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BikeRentalClientWithPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainPage = new MainPage();
        }
        private MainPage mainPage;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
            mainPage.BTN_NewBike.Click += BTN_NewBike_Click;
            mainPage.BTN_DeleteBike.Click += BTN_DeleteBike_Click;
            mainPage.BTN_EditBike.Click += BTN_EditBike_Click;
        }
        private void BTN_EditBike_Click(object sender, RoutedEventArgs e)
        {
            if(mainPage.LB_Bikes.SelectedItem != null)
            {
                var bike = (Bike)mainPage.LB_Bikes.SelectedItem;
                var page = new BikeEditorPage();
                page.TB_Brand.Text = bike.Brand;
                page.TB_Name.Text = bike.Name;
                page.TB_Type.Text = bike.Type;
                page.DP_Manufactured.SelectedDate = bike.Manufactured;                             
                page.BTN_Cancel.Click += BikeEditorPage_BTN_Cancel_Click;
                page.BTN_Save.Click += BikeEditorPage_BTN_Save_Existing_Click;
                MainFrame.Content = page;
            }            
        }

        private void BikeEditorPage_BTN_Save_Existing_Click(object sender, RoutedEventArgs e)
        {
            var page = (BikeEditorPage)MainFrame.Content;
            var bike = (Bike)mainPage.LB_Bikes.SelectedItem;
            bike.Brand = page.TB_Brand.Text;
            bike.Name = page.TB_Name.Text;
            bike.Type = page.TB_Type.Text;
            bike.Manufactured = page.DP_Manufactured.SelectedDate;
            mainPage.LB_Bikes.Items.Refresh();
            MainFrame.Content = mainPage;
        }


        private void BTN_DeleteBike_Click(object sender, RoutedEventArgs e)
        {
            if(mainPage.LB_Bikes.SelectedItem != null)
            {
                var result = MessageBox.Show("Biztos, hogy törölni szeretné a kiválasztott elemet?", "Törlés...", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    mainPage.LB_Bikes.Items.Remove(mainPage.LB_Bikes.SelectedItem);
                }
            }
        }

        private void BTN_NewBike_Click(object sender, RoutedEventArgs e)
        {
            var page = new BikeEditorPage();
            MainFrame.Content = page;
            page.BTN_Cancel.Click += BikeEditorPage_BTN_Cancel_Click;
            page.BTN_Save.Click += BikeEditorPage_BTN_Save_New_Click;
        }

        private void BikeEditorPage_BTN_Save_New_Click(object sender, RoutedEventArgs e)
        {
            var page = (BikeEditorPage)MainFrame.Content;
            var bike = new Bike()
            {
                Brand = page.TB_Brand.Text,
                Name = page.TB_Name.Text,
                Type = page.TB_Type.Text,
                Manufactured = page.DP_Manufactured.SelectedDate,
            };
            mainPage.LB_Bikes.Items.Add(bike);
            MainFrame.Content = mainPage;
        }

        private void BikeEditorPage_BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
        }
    }
}
