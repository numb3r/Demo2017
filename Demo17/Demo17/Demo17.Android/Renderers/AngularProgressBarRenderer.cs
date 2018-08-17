using System;
using System.ComponentModel;
using Android.Graphics;
using Demo17.Controls;
using PathfinderX.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(AngularProgressBar), typeof(AngularProgressBarRenderer))]

namespace PathfinderX.Droid.Controls
{
    public class AngularProgressBarRenderer : ViewRenderer
    {
        private const int ADJUSTMENT = 100;
        private Paint _constantCirlcle2Paint;
        private Paint _drainingCirclePaint;
        private Paint _innerCirclePaint;
        private Paint _piePathPaint;
        private RectF _ringDrawArea;
        private bool _sizeChanged;

        private Paint _textPaint;
        private Path path1;
        private Path path2;

        public AngularProgressBarRenderer()
        {
            SetWillNotDraw(false);
        }

        protected float Diameter { get; set; }
        protected Color BaseColor { get; set; }
        protected Color Color1 { get; set; }
        protected Color Color2 { get; set; }
        protected Color Color3 { get; set; }

        protected override void OnDraw(Canvas canvas)
        {
            var element = (AngularProgressBar) Element;

            if (_piePathPaint == null)
            {
                _piePathPaint = new Paint
                {
                    Flags = PaintFlags.AntiAlias,
                    StrokeWidth = 10
                };

                _drainingCirclePaint = new Paint
                {
                    Flags = PaintFlags.AntiAlias
                };
                _innerCirclePaint = new Paint
                {
                    Flags = PaintFlags.AntiAlias
                };
                _constantCirlcle2Paint = new Paint
                {
                    Flags = PaintFlags.AntiAlias
                };
                _textPaint = new Paint
                {
                    Flags = PaintFlags.AntiAlias
                };

                _piePathPaint.SetStyle(Paint.Style.Stroke);
                _innerCirclePaint.SetStyle(Paint.Style.FillAndStroke);
            }


            if (_ringDrawArea == null || _sizeChanged)
            {
                _sizeChanged = false;

                var minimumLength = Math.Min(canvas.ClipBounds.Width(), canvas.ClipBounds.Height() + ADJUSTMENT * 2);

                Diameter = minimumLength - _piePathPaint.StrokeWidth;

                float centerX = canvas.ClipBounds.CenterX();
                float centerY = canvas.ClipBounds.CenterY() + ADJUSTMENT;

                var left = centerX - Diameter / 2;
                var top = centerY - Diameter / 2;
                var right = left + Diameter;
                var bottom = top + Diameter;

                BaseColor = element.BaseColor;
                Color1 = element.Color1;
                Color2 = element.Color2;
                Color3 = element.Color3;

                _ringDrawArea = new RectF(left, top, right, bottom);
            }


            var radius1 = (Diameter - _piePathPaint.StrokeWidth) / 2;
            var radius2 = radius1 / 2; 
            var rad = Diameter / 2;

            var progress = (float) element.Progress;
            var progress1 = progress * 2;
            if (progress1 >= 0 && progress1 <= 0.5)
            {
                _piePathPaint.Color = Color1.ToAndroid();
                _drainingCirclePaint.Color = Color1.ToAndroid();
            }
            else if (progress1 > 0.5 && progress1 <= 0.75)
            {
                _piePathPaint.Color = Color2.ToAndroid();
                _drainingCirclePaint.Color = Color2.ToAndroid();
            }
            else
            {
                _piePathPaint.Color = Color3.ToAndroid();
                _drainingCirclePaint.Color = Color3.ToAndroid();
            }

            var startAngle = (float) element.StartAngle;
            var sweepAngle = (float) element.SweepAngle;

            path1 = new Path();
            //draw an arc from startAngle to upto startAngle + sweepAngle
            path1.ArcTo(_ringDrawArea, startAngle, sweepAngle);
            //draw a line from end point of arc to the center of a canvas 
            path1.LineTo(_ringDrawArea.CenterX(), _ringDrawArea.CenterY());
            //finding a point of contact
            var radian = Math.PI / 180 * startAngle;
            //x-coordinate
            var px = _ringDrawArea.CenterX() + (rad + _piePathPaint.StrokeWidth / 2) * (float) Math.Cos(radian);
            //y-coordinate
            var py = _ringDrawArea.CenterY() + (rad + _piePathPaint.StrokeWidth / 2) * (float) Math.Sin(radian);
            //draw a line from center to P(x,y)
            path1.LineTo(px, py);
            //Clip the path
            canvas.ClipPath(path1);
            //draw a path with paint
            canvas.DrawPath(path1, _piePathPaint);

            //draw a draining circle

            var strokeWidth = radius1 * (1 - progress) * 2;
            _drainingCirclePaint.StrokeWidth = strokeWidth;
            canvas.DrawCircle(_ringDrawArea.CenterX(), _ringDrawArea.CenterY(), radius1 * (1 - progress),_drainingCirclePaint);


            //circle that will create a base for draining circle
            _drainingCirclePaint.StrokeWidth = 0;
            canvas.DrawCircle(_ringDrawArea.CenterX(), _ringDrawArea.CenterY(), radius2, _drainingCirclePaint);

            //Inner cirlce 
            _innerCirclePaint.Color = element.Color4.ToAndroid();
            _innerCirclePaint.StrokeWidth = radius2;
            _innerCirclePaint.SetStyle(Paint.Style.Fill);
            canvas.DrawCircle(_ringDrawArea.CenterX(), _ringDrawArea.CenterY(), radius2 - _piePathPaint.StrokeWidth, _innerCirclePaint);

            ////text placeholder for time remaining
            _textPaint.Color = Color.White.ToAndroid();
            _textPaint.TextSize = 50;
            _textPaint.SetStyle(Paint.Style.Stroke);
            if (!string.IsNullOrEmpty(element.RemainingTime))
                canvas.DrawText(element.RemainingTime, (float)element.TimeRemainingX, (float)element.TimeRemainingY, _textPaint);

            path2 = new Path();
            var sweepAngle2 = sweepAngle * 2 / 3;
            path2.ArcTo(_ringDrawArea, startAngle + (float)8.5, sweepAngle2);
            path2.LineTo(_ringDrawArea.CenterX(), _ringDrawArea.CenterY());
            canvas.ClipPath(path2);

            _constantCirlcle2Paint.Color = _piePathPaint.Color;
            _constantCirlcle2Paint.Alpha = 200;
            _constantCirlcle2Paint.StrokeWidth = radius2;

            canvas.DrawCircle(_ringDrawArea.CenterX(), _ringDrawArea.CenterY(), radius2, _constantCirlcle2Paint);

            _textPaint.TextSize = 40;
            if (!string.IsNullOrEmpty(element.RuleName))
                canvas.DrawText(element.RuleName, (float)element.RuleTextX, (float)element.RuleTextY, _textPaint);

            _innerCirclePaint.Color = element.Color4.ToAndroid();
            _innerCirclePaint.StrokeWidth = radius2 / 2;

            canvas.DrawCircle(_ringDrawArea.CenterX(), _ringDrawArea.CenterY(), radius2 / 2, _innerCirclePaint);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ProgressBar.ProgressProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.BaseColorProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.Color1Property.PropertyName ||
                e.PropertyName == AngularProgressBar.Color2Property.PropertyName ||
                e.PropertyName == AngularProgressBar.Color3Property.PropertyName ||
                e.PropertyName == AngularProgressBar.StartAngleProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.SweepAngleProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.RuleTextXProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.RuleTextYProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.RemainingTimeProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.TimeRemainingXProperty.PropertyName ||
                e.PropertyName == AngularProgressBar.TimeRemainingYProperty.PropertyName)
                Invalidate();

            if (e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                _sizeChanged = true;
                Invalidate();
            }
        }
    }
}