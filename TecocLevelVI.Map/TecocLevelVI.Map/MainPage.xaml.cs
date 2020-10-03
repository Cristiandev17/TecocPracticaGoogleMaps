using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecocLevelVI.Map.Repository;
using TecocLevelVI.Map.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace TecocLevelVI.Map
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var main = (MainViewModel)BindingContext;
            if (!string.IsNullOrEmpty(main.Address) )
            {
                map.Pins.Clear();
                var location = await GoogleRepository.GetLocation(main.Address);
                var coordinates = location.results.FirstOrDefault().geometry.location;
                var pin = new Pin
                {
                    Position = new Position(coordinates.lat, coordinates.lng),
                    Label = location.results.FirstOrDefault().formatted_address,
                    Type = PinType.SearchResult
                };
                map.Pins.Add(pin);
            }
            



        }
    }
}
