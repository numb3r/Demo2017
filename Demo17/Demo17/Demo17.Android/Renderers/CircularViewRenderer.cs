using Demo17.Controls;
using Demo17.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircularView), typeof(CircularViewRenderer))]
namespace Demo17.Droid.Renderers
{
    public class CircularViewRenderer : ViewRenderer<CircularView, Android.Views.View>
    {
        public CircularViewRenderer()
        {
            this.SetWillNotDraw(false);
        }


        protected override void OnElementChanged(ElementChangedEventArgs<CircularView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var circleDotView = new Android.Views.View(Forms.Context);
                SetNativeControl(circleDotView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CircularView.ActiveProperty.PropertyName)
            {
                Invalidate();
            }
        }
    }
}