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

namespace Task_3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Searching SearchingObj
    {
        get;
    }
    public MainWindow()
    {
        InitializeComponent();
        var arr = new int[50]; 
        var A = new int[10]; 
        var B = new int[10]; 

        var randNum = new Random();

        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = randNum.Next(-25, 25);
        }

        for (var i = 0; i < A.Length; i++)
        {
            A[i] = randNum.Next(-25, 25);
        }
        
        for (var i = 0; i < B.Length; i++)
        {
            B[i] = randNum.Next(-25, 25);
        }
        
        SearchingObj = new Searching { arr = arr, search = arr[randNum.Next(0, 50)], a = A, b = B};
        DataContext = SearchingObj;
    }
}