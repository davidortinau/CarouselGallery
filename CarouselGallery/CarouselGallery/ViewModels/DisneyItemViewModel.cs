
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarouselGallery.ViewModels
{
    public class DisneyItemViewModel : BaseViewModel
    {
        private double scale;

        public double Scale { get => scale; set => SetProperty(ref scale, value); }

        public string ImageSource { get; set; }
    }
}