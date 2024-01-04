using System.Windows;

namespace WpfApplication1
{
    public partial class MainWindow
    {
        private readonly Deque _deque = new Deque();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateOutput(string data)
        {
            OutputText.Text = data;
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            UpdateOutput(_deque.ToString());
        }

        private void Size_Click(object sender, RoutedEventArgs e)
        {
            UpdateOutput(_deque.Count.ToString());
        }

        private void IsEmpty_Click(object sender, RoutedEventArgs e)
        {
            UpdateOutput(_deque.IsEmpty() ? "List is empty" : "List is not empty");
        }

        private void PushFront_Click(object sender, RoutedEventArgs e)
        {
            string data = DataEntry.Text;
            if (!string.IsNullOrEmpty(data))
            {
                _deque.PushFront(data);
                DataEntry.Clear();
                UpdateOutput(_deque.ToString());
            }
        }

        private void PushBack_Click(object sender, RoutedEventArgs e)
        {
            var data = DataEntry.Text;
            if (string.IsNullOrEmpty(data)) return;
            _deque.PushBack(data);
            DataEntry.Clear();
            UpdateOutput(_deque.ToString());
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _deque.Clear();
            UpdateOutput(string.Empty);
        }

        private void PopFront_Click(object sender, RoutedEventArgs e)
        {
            var data = _deque.PopFront();
            UpdateOutput(data);
        }

        private void PopBack_Click(object sender, RoutedEventArgs e)
        {
            var data = _deque.PopBack();
            UpdateOutput(data);
        }

        private void Front_Click(object sender, RoutedEventArgs e)
        {
            var data = _deque.Front();
            UpdateOutput(data);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var data = _deque.Back();
            UpdateOutput(data);
        }
    }
}
