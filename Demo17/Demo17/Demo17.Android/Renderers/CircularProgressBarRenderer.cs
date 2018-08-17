using System;
using Android.Graphics;
using Demo17.Controls;
using Demo17.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircularProgressBar), typeof(CircularProgressBarRenderer))]
namespace Demo17.Droid.Renderers
{
    public class CircularProgressBarRenderer : ViewRenderer
    {
        private Paint _paint;
        private RectF _ringDrawArea;
        private bool _sizeChanged = false;

#pragma warning disable 618
        public CircularProgressBarRenderer()
#pragma warning restore 618
        {
            SetWillNotDraw(false);
        }

        protected float Diameter { get; set; }
        protected override void OnDraw(Canvas canvas)
        {
            var element = (CircularProgressBar)Element;

            if (_paint == null)
            {
                var displayDensity = Context.Resources.DisplayMetrics.Density;
                var strokeWidth = (float)Math.Ceiling(element.RingThickness * displayDensity);

                _paint = new Paint
                {
                    StrokeWidth = strokeWidth, 
                    Flags = PaintFlags.AntiAlias,
                };

                _paint.SetStyle(Paint.Style.Stroke);
            }

            if (_ringDrawArea == null || _sizeChanged)
            {
                _sizeChanged = false;

                var minimumLength = Math.Min(canvas.ClipBounds.Width(), canvas.ClipBounds.Height());

                Diameter = minimumLength - _paint.StrokeWidth;
                var radius = Diameter / 2; 

                var left = canvas.ClipBounds.CenterX() - radius;
                var top = canvas.ClipBounds.CenterY() - radius;

                _ringDrawArea = new RectF(left, top, left + Diameter, top + Diameter);
            }

            var backColor = element.RingBaseColor;
            var frontColor = element.RingProgressColor;
            var thirdColor = element.RingThirdColor;
            var progress = (float)element.Progress;


            _paint.Color = backColor.ToAndroid();
            canvas.DrawArc(_ringDrawArea, 270, 360, false, _paint);

            _paint.Color = progress >= 0.75 ? thirdColor.ToAndroid() : frontColor.ToAndroid();

            canvas.DrawArc(_ringDrawArea, 270, 360 * progress, false, _paint);
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ProgressBar.ProgressProperty.PropertyName ||
                e.PropertyName == CircularProgressBar.RingThicknessProperty.PropertyName ||
                e.PropertyName == CircularProgressBar.RingBaseColorProperty.PropertyName ||
                e.PropertyName == CircularProgressBar.RingProgressColorProperty.PropertyName)
            {
                Invalidate();
            }

            if (e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                _sizeChanged = true;
                Invalidate();
            }
        }
    }
}