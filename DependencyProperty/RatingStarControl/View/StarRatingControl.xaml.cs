using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RatingStarControl.View
{
    /// <summary>
    /// Interaction logic for StarRatingControl.xaml
    /// </summary>
    public partial class StarRatingControl : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(nameof(Rating),  // Name of the property
                typeof(int),                             // Type of the property
                typeof(StarRatingControl),              // Owner of the property
                new PropertyMetadata(0, OnRatingChanged)); // Default value and callback for property changes

        public int Rating
        {
            get => (int)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public List<string> Stars => GenerateStars(Rating);

        public StarRatingControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (StarRatingControl)d;
            control.OnPropertyChanged(nameof(Stars));
        }

        private List<string> GenerateStars(int rating)
        {
            var stars = new List<string>();
            for (int i = 1; i <= 5; i++)
                stars.Add(i <= rating ? "★" : "☆");
            return stars;
        }

        private void Star_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock star && star.DataContext is string starChar)
            {
                int index = Stars.IndexOf(starChar) + 1;
                Rating = index;
                OnPropertyChanged(nameof(Stars));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

