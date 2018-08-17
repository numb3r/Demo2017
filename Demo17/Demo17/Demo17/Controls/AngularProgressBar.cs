using Xamarin.Forms;

namespace Demo17.Controls
{
    public class AngularProgressBar : ProgressBar
    {
        public static readonly BindableProperty BaseColorProperty = BindableProperty.Create("BaseColor", typeof(Color), typeof(AngularProgressBar), Color.FromRgb(46, 60, 76));

        public static readonly BindableProperty Color1Property = BindableProperty.Create("Color1", typeof(Color), typeof(AngularProgressBar), Color.FromRgb(1, 180, 0));

        public static readonly BindableProperty Color2Property = BindableProperty.Create("Color2", typeof(Color), typeof(AngularProgressBar), Color.FromRgb(255, 255, 0));

        public static readonly BindableProperty Color3Property = BindableProperty.Create("Color3", typeof(Color), typeof(AngularProgressBar), Color.FromRgb(255, 0, 0));

        public static readonly BindableProperty Color4Property = BindableProperty.Create("Color4", typeof(Color), typeof(AngularProgressBar), Color.FromRgb(16, 41, 50));

        public static readonly BindableProperty StartAngleProperty = BindableProperty.Create("StartAngle", typeof(double), typeof(AngularProgressBar), 0.0);

        public static readonly BindableProperty SweepAngleProperty = BindableProperty.Create("SweepAngle", typeof(double), typeof(AngularProgressBar), 0.0);

        public static readonly BindableProperty RemainingTimeProperty = BindableProperty.Create("RemainingTime", typeof(string), typeof(AngularProgressBar), "08:50");

        public static readonly BindableProperty RuleNameProperty = BindableProperty.Create("RuleName", typeof(string), typeof(AngularProgressBar), "8");

        public static readonly BindableProperty TimeRemainingXProperty = BindableProperty.Create("TimeRemainingX", typeof(double), typeof(AngularProgressBar), 0.0);

        public static readonly BindableProperty TimeRemainingYProperty = BindableProperty.Create("TimeRemainingY", typeof(double), typeof(AngularProgressBar), 0.0);

        public static readonly BindableProperty RuleTextXProperty = BindableProperty.Create("RuleTextX", typeof(double), typeof(AngularProgressBar), 0.0);

        public static readonly BindableProperty RuleTextYProperty = BindableProperty.Create("RuleTextY", typeof(double), typeof(AngularProgressBar), 0.0);


        public Color Color1
        {
            get { return (Color)GetValue(Color1Property); }
            set { SetValue(Color1Property, value); }
        }

        public Color Color2
        {
            get { return (Color)GetValue(Color2Property); }
            set { SetValue(Color2Property, value); }
        }

        public Color Color3
        {
            get { return (Color)GetValue(Color3Property); }
            set { SetValue(Color3Property, value); }
        }

        public Color Color4
        {
            get { return (Color)GetValue(Color4Property); }
            set { SetValue(Color4Property, value); }
        }
        public Color BaseColor
        {
            get { return (Color)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }

        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public double SweepAngle
        {
            get { return (double)GetValue(SweepAngleProperty); }
            set { SetValue(SweepAngleProperty, value); }
        }


        public string RemainingTime
        {
            get { return (string)GetValue(RemainingTimeProperty); }
            set { SetValue(RemainingTimeProperty, value); }
        }

        public string RuleName
        {
            get { return (string)GetValue(RuleNameProperty); }
            set { SetValue(RuleNameProperty, value); }
        }

        public double TimeRemainingX
        {
            get { return (double)GetValue(TimeRemainingXProperty); }
            set { SetValue(TimeRemainingXProperty, value); }
        }

        public double TimeRemainingY
        {
            get { return (double)GetValue(TimeRemainingYProperty); }
            set { SetValue(TimeRemainingYProperty, value); }
        }

        public double RuleTextX
        {
            get { return (double)GetValue(RuleTextXProperty); }
            set { SetValue(RuleTextYProperty, value); }
        }

        public double RuleTextY
        {
            get { return (double)GetValue(RuleTextYProperty); }
            set { SetValue(RuleTextYProperty, value); }
        }
    }
}
