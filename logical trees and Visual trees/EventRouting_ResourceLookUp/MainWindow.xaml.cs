using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace EventRouting_ResourceLookUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Add bubbling handlers that run even if event is marked as handled
            //this.AddHandler(MouseDownEvent, new MouseButtonEventHandler(Window_MouseDown), true);
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Window → Tunneling PreviewMouseDown");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Window ← Bubbling MouseDown");
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("StackPanel → Tunneling PreviewMouseDown");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("StackPanel ← Bubbling MouseDown");
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Button → Tunneling PreviewMouseDown");
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Button ← Bubbling MouseDown");
        }
    }
}