using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Task_1
{
    public partial class MainWindow
    {
        private string _formula;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadDataButton_Click(object sender, RoutedEventArgs e)
        {
            using (var reader = new StreamReader("formula.txt"))
            {
                _formula = reader.ReadToEnd();
            }
            FormulaDataLabel.Content = _formula;
        }

        private void ProcessDataButton_Click(object sender, RoutedEventArgs e)
        {
            var stack = new Stack<int>();
            var bracketsI = new ArrayList();
            var isBracketsBalanced = true;

            for (var i = 0; i < _formula.Length; i++)
            {
                var c = _formula[i];
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if (c == ')')
                {
                    if (stack.Count > 0)
                    {
                        var openBracketIndex = stack.Pop();
                        bracketsI.Add((openBracketIndex, i));
                    }
                    else
                    {
                        isBracketsBalanced = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0)
            {
                isBracketsBalanced = false;
            }
            
            ResultDataLabel.Content = isBracketsBalanced ? string.Join(", ", bracketsI.ToArray()) : "Brackets aren't balanced";
        }
    }
}