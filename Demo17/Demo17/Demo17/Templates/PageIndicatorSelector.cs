using Xamarin.Forms;

namespace Demo17.Templates
{
    public class PageIndicatorSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(PageIndicatorTemplate));
        }
    }
}