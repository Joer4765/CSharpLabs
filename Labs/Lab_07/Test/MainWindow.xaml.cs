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

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // InitializeComponent();
            // var grid = new Grid();
            // this.Content = grid;
            // var btn = new Button
            // {
            //     FontSize = 26,
            // };
            // var wrapPanel = new WrapPanel();
            // var txt = new TextBlock
            // {
            //     Text = "Multi",
            //     Foreground = Brushes.Blue
            // };
            //
            // wrapPanel.Children.Add(txt);
            //
            // txt = new TextBlock
            // {
            //     Text = "Color",
            //     Foreground = Brushes.Red
            // };
            // wrapPanel.Children.Add(txt);
            //
            // txt = new TextBlock
            // {
            //     Text = "Button",
            //     Foreground = Brushes.White
            // };
            // wrapPanel.Children.Add(txt);
            //
            // btn.Content = wrapPanel;
            // grid.Children.Add(btn);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button was clicked - Direct Event");
            throw new NotImplementedException();
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mouse button went up / was released - Bubbling event");
            throw new NotImplementedException();
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mouse button went up / was released - Tunneling event");
            throw new NotImplementedException();
        }
    }
}