using CarouselGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var centerIndex = e.CenterItemIndex;
            var nextIndex = e.LastVisibleItemIndex;
            var prevIndex = e.FirstVisibleItemIndex;
            var layout = carousel.ItemsLayout;
            var adjust = Device.RuntimePlatform == Device.Android ? 1 : 1;

            if (layout is LinearItemsLayout linearItemsLayout)
            {
                if (linearItemsLayout.Orientation == ItemsLayoutOrientation.Horizontal)
                {
                    var carouselWidth = carousel.Width;
                    var offset = (carouselWidth * (centerIndex + 1)) - (e.HorizontalOffset / adjust);
                    var scaleChange = (1 - Scale) * (offset / carouselWidth);

                    Debug.WriteLine($"CurrentIndex: {centerIndex}, Scale: {scaleChange}, offset: {offset}, hOffset: {e.HorizontalOffset}");

                    var firstItem = carouselItems[prevIndex] as DisneyItemViewModel;
                    var lastItem = carouselItems[nextIndex] as DisneyItemViewModel;
                    firstItem.Scale = lastItem.Scale = 1 - scaleChange;// - scale;

                    var currentItem = carouselItems[centerIndex] as DisneyItemViewModel;
                    currentItem.Scale = Scale + scaleChange;// - scale;
                }

                
            }
        }
    }
}
