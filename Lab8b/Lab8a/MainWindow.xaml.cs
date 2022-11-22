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
using System.Drawing;

namespace Lab8a
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool x , y = true;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void BoldFont_Click(object sender, RoutedEventArgs e)
        {

            
            if (x == false)
            {
                textbox1.FontWeight = FontWeights.Normal;
                x = true;
            }
      
            else
            {
                textbox1.FontWeight = FontWeights.Bold;
                x = false;
            }

            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                textbox1.FontSize = slider.Value;
            }
        }

       

        private void FontsName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textbox1.FontFamily = new FontFamily(((ListBoxItem)FontsName.SelectedItem).Content.ToString());
        }

        private void CursiveFont_Click(object sender, RoutedEventArgs e)
        {
            if (y == false)
            {
                textbox1.FontStyle = FontStyles.Normal;
                y = true;
            }
            else
            {
                textbox1.FontStyle = FontStyles.Italic;
                y = false;
            }
           
        }
    }
}
