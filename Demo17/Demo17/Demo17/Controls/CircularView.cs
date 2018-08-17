using Xamarin.Forms;

namespace Demo17.Controls
{
    public class CircularView : View
    {
        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(nameof(FillColor), typeof(Color), typeof(CircularView), Color.Black);
        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(CircularView), Color.Black);
        public static readonly BindableProperty ActiveProperty = BindableProperty.Create(nameof(Active), typeof(bool), typeof(CircularView), false);
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public Color StrokeColor
        {
            get { return (Color)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }

        public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }
    }
}
