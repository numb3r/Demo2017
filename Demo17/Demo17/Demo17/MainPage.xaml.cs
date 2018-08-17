using System;
using System.IO;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace Demo17
{
	public partial class MainPage : ContentPage
	{

        public MainPage()
		{
			InitializeComponent();
		    BindingContext = new MainPageViewModel();
        }

	    private void SKCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
	    {
	        SKImageInfo info = args.Info;
	        SKSurface surface = args.Surface;
	        SKCanvas canvas = surface.Canvas;

	        canvas.Clear();

	        SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);
	        float radius = Math.Min(info.Width, info.Height) / 4;
	        float innerCircleRadius = radius * (float)0.50;

            //Define SKPath for drawing
	        SKPath outerCirclePath = new SKPath { FillType = SKPathFillType.EvenOdd };
            SKPath innerCirclePath = new SKPath { FillType = SKPathFillType.EvenOdd };


            //Add Circle
	        outerCirclePath.AddCircle(center.X, center.Y, radius);
	        innerCirclePath.AddCircle(center.X, center.Y, innerCircleRadius);

            SKPaint outerCirclePaint = new SKPaint()
	        {
	            Style = SKPaintStyle.Fill,
	            Color = SKColors.DarkBlue
	        };

	        SKPaint innerCirclePaint = new SKPaint()
	        {
	            Style = SKPaintStyle.Fill,
	            Color = SKColors.Black
	        };

            //Draw
            canvas.DrawPath(outerCirclePath, outerCirclePaint);
            canvas.DrawPath(innerCirclePath, innerCirclePaint);



	        //paint.Style = SKPaintStyle.Stroke;
	        //paint.StrokeWidth = 10;
	        //paint.Color = SKColors.Magenta;

	        //canvas.DrawPath(path, paint);
        }
	}
}
