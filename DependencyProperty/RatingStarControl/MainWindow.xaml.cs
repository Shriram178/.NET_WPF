using System.ComponentModel;
using System.Windows;

namespace RatingStarControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _myRating = 3;
        public int MyRating
        {
            get => _myRating;
            set
            {
                _myRating = value;
                OnPropertyChanged(nameof(MyRating));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}