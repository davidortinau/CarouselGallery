using CarouselGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarouselGallery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstagramPage : ContentPage
    {
        public InstagramPage()
        {
            InitializeComponent();
        }

        

        private void cv_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            Description.Text = (e.CurrentItem as InstaPic).Description;
        }
    }
}