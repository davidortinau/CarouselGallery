using CarouselGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CarouselGallery.Behaviors
{
    public class DisneyCarouselBehavior : Behavior<CarouselView>
    {
        public static readonly BindableProperty ScaleProperty =
          BindableProperty.Create(nameof(Scale), typeof(double), typeof(DisneyCarouselBehavior), 1.0d,
              BindingMode.TwoWay, null);

        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        protected override void OnAttachedTo(CarouselView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Scrolled += OnScrolled;
        }

        protected override void OnDetachingFrom(CarouselView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Scrolled -= OnScrolled;
        }

        private void OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            var carousel = (CarouselView)sender;
            var carouselItems = carousel.ItemsSource.Cast<object>().ToList();
            var currentIndex = e.CenterItemIndex;
            var lastIndex = e.LastVisibleItemIndex;
            var firstIndex = e.FirstVisibleItemIndex;
            var layout = carousel.ItemsLayout;
            var adjust = Device.RuntimePlatform == Device.Android ? 2.6 : 1;

            if (layout is LinearItemsLayout linearItemsLayout)
            {
                if (linearItemsLayout.Orientation == ItemsLayoutOrientation.Horizontal)
                {
                    var firstItem = carouselItems[firstIndex] as DisneyItemViewModel;
                    var lastItem = carouselItems[lastIndex] as DisneyItemViewModel;
                    firstItem.Scale = lastItem.Scale = Scale;

                    var currentItem = carouselItems[currentIndex] as DisneyItemViewModel;
                    currentItem.Scale = 1.0;
                }

                
            }
        }
    }
}
