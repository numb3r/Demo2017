using Xamarin.Forms;

namespace Demo17.Controls
{
    public class CircularProgressBar : ProgressBar
    {
        public static readonly BindableProperty RingProgressColorProperty = BindableProperty.Create("RingProgressColor",
            typeof(Color),
            typeof(CircularProgressBar), Color.FromRgb(234, 105, 92));

        public static readonly BindableProperty RingBaseColorProperty = BindableProperty.Create("RingBaseColor",
            typeof(Color),
            typeof(CircularProgressBar), Color.FromRgb(46, 60, 76));

        public static readonly BindableProperty RingThicknessProperty = BindableProperty.Create("RingThickness",
            typeof(double),
            typeof(CircularProgressBar), 5.0);

        public static readonly BindableProperty RingThirdColorProperty = BindableProperty.Create("RingThirdColor",
            typeof(Color),
            typeof(CircularProgressBar), Color.FromRgb(234, 105, 92));

        public Color RingThirdColor
        {
            get { return (Color)GetValue(RingThirdColorProperty); }
            set { SetValue(RingThirdColorProperty, value); }
        }
        public Color RingProgressColor
        {
            get { return (Color)GetValue(RingProgressColorProperty); }
            set { SetValue(RingProgressColorProperty, value); }
        }
        public Color RingBaseColor
        {
            get { return (Color)GetValue(RingBaseColorProperty); }
            set { SetValue(RingBaseColorProperty, value); }
        }
        public double RingThickness
        {
            get { return (double) GetValue(RingThicknessProperty); }
            set { SetValue(RingThicknessProperty, value); }
        }
    }
}