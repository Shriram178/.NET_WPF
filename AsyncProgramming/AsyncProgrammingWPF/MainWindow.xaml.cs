using System.Windows;

namespace AsyncProgrammingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartWork_Click(object sender, RoutedEventArgs e)
        {
            _cts = new CancellationTokenSource();
            StatusText.Text = "Status: Working...";

            try
            {
                await Task.Run(() => DoWork(_cts.Token), _cts.Token);
                StatusText.Text = "Status: Completed!";
            }
            catch (OperationCanceledException)
            {
                StatusText.Text = "Status: Canceled.";
            }
            catch (Exception ex)
            {
                StatusText.Text = $"Error: {ex.Message}";
            }
        }

        private void CancelWork_Click(object sender, RoutedEventArgs e)
        {
            _cts?.Cancel();
        }

        private void DoWork(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(500); // simulate heavy work

                // Update UI thread from background thread using Dispatcher
                Dispatcher.Invoke(() =>
                {
                    StatusText.Text = $"Status: Processing {i + 1}/10";
                });
            }
        }
    }
}