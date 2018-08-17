using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Demo17.Controls
{
    public class CustomStackLayout : StackLayout 
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(CustomStackLayout), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomStackLayout), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public static readonly BindableProperty ItemSelectedProperty = BindableProperty.Create(nameof(ItemSelected), typeof(ICommand), typeof(CustomStackLayout));

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.CreateStack();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == ItemsSourceProperty.PropertyName)
                this.CreateStack();
            base.OnPropertyChanged(propertyName);
        }

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, (object)value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)this.GetValue(ItemTemplateProperty); }
            set { this.SetValue(ItemTemplateProperty, (object)value); }
        }

        public ICommand ItemSelected
        {
            get { return (ICommand)this.GetValue(ItemSelectedProperty); }
            set { this.SetValue(ItemSelectedProperty, (object)value); }
        }

        private void CreateStack()
        {
            this.Children.Clear();
            if (this.ItemsSource == null || this.ItemsSource.Count<object>() == 0 || this.ItemsSource.First<object>() == null)
                return;
            this.CreateCells();
        }

        private void CreateCells()
        {
            foreach (object obj in this.ItemsSource)
            {
                var test = obj as CustomStackLayout;
                this.Children.Add(this.CreateCellView(obj));
            }
        }

        private View CreateCellView(object item)
        {
            View content;
            BindableObject bindableObject = (BindableObject)(content = (View)this.ItemTemplate.CreateContent());
            if (bindableObject == null)
                return content;
            bindableObject.BindingContext = item;

            content.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = ItemSelected, 
                CommandParameter = item
            });
            
            return content;
        }
    }
}
