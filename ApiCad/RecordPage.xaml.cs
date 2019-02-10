using ApiCad.Entidades;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiCad
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordPage : ContentPage
    {
        public ObservableCollection<ElementsViewModel> Items { get; set; }

        public RecordPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () => {
                RestPlano client = new RestPlano();
                var plano = await client.Get_plano<Plano_>("https://apicad.herokuapp.com/api/v1/draws/all");
                if (plano != null)
                {
                    Items = new ObservableCollection<ElementsViewModel>();
                    foreach (var c in plano)
                    {
                        //Items.Add(c.Plano.name + " " + c.Plano.type_plan);
                        Items.Add(new ElementsViewModel
                        {
                            Image   = "icon_map.png",
                            Name    = c.Plano.name,
                            Type    = c.Plano.type_plan
                        });
                    }
                    listView.ItemsSource = Items;
                }
            });


        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Mapa", "llevar al mapa", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}


