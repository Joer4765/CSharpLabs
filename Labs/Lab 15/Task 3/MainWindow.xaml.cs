using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace Task_3
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var footballerSurnames = new List<string>
            {
                "Ronaldo",
                "Messi",
                "Neymar",
                "Pogba",
                "Salah",
                "Modric",
                "Griezmann",
                "Kane",
                "Lewandowski",
                "Sterling",
                "Ramos",
                "Aguero",
                "Cavani",
                "Iniesta",
                "Ter Stegen",
                "Alaba",
                "Isco",
                "Kroos",
                "Hazard",
                "Suarez"
            };
            
            var footballerSurnames2 = new List<string> { "Ronaldo", "Messi", "Neymar", "Pogba", "Salah", "Modric", "Griezmann", "Kane", "Lewandowski", "Sterling", "Ramos", "Aguero", "Cavani", "Iniesta", "Ter Stegen", "Alaba", "Isco", "Kroos", "Hazard", "Suarez" };

        }

        private void ProcessData_Click(object sender, RoutedEventArgs e)
        {
            var cll = new CircularLinkedList();
            var regex = new Regex("\".+\"");
            var matchCollection = regex.Matches(InDataBox.Text);
            foreach (Match match in matchCollection)
            {
                cll.AddEnd(match.Value);
            }
            // foreach (var c in InDataBox.Text.Split(','))
            // {
            //     cll.AddEnd(c);
            // }

            var cll1 = new CircularLinkedList();
            var size = 0;
            var i = 0;
            var el = cll.Head?.Next;
            while (size < 10)
            {
                i += 1;
                if (i % 12 == 0)
                {
                    if (el != null)
                    {
                        cll1.AddEnd(el.Data);
                        cll.DeleteNode(el.Data);
                    }

                    size += 1;
                }

                el = el?.Next;
            }
            
            var cll2 = new CircularLinkedList();
            
            var cllEl = cll.Head?.Next;
            while (true)
            {
                var newEl = true;
                if (cll1.Head != null)
                {
                    var cll1El = cll1.Head.Next;
            
                    while (true)
                    {
                        if (cll1El != null && cllEl != null && cllEl.Data == cll1El.Data)
                        {
                            newEl = false;
                            break;
                        }

                        if (cll1El == null) continue;
                        cll1El = cll1El.Next;
                        if (cll1El == cll1.Head.Next)
                            break;
                    }
                }

                if (newEl)
                {
                    if (cllEl != null) cll2.AddEnd(cllEl.Data);
                }

                if (cllEl == null) continue;
                cllEl = cllEl.Next;
                if (cllEl == cll.Head.Next)
                    break;
            }
            
            Group1DataLabel.Text = cll1.ToString();
            Group2DataLabel.Text = cll2.ToString();
        }
    }
}
