﻿using System;
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
            Bike.Name = TB_Name.Text;
            Bike.Brand = TB_Brand.Text;
            Bike.Type = TB_Type.Text;
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
            BTN_Save.IsEnabled = !string.IsNullOrWhiteSpace(TB_Name.Text) && !string.IsNullOrWhiteSpace(TB_Brand.Text) && !string.IsNullOrWhiteSpace(TB_Type.Text) && DP_Manufactured.SelectedDate !=null;
        }

        
    }
}
