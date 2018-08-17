using Xamarin.Forms;

namespace Demo17.Controls
{
    public class RoundedBoxView : BoxView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(RoundedBoxView), 0.0);

        public double CornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
    }
}
