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
        public ObservableCollection<string> Items { get; set; }

        public RecordPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () => {
                RestClient client = new RestClient();
                var usuario = await client.Get_plano<Plano_>("https://apicad.herokuapp.com/api/v1/draws/all");
                if (usuario != null)
                {
                    Items = new ObservableCollection<string>();
                    foreach (var c in usuario)
                    {
                        Items.Add(c.Plano.name + " " + c.Plano.type_plan);
                    }
                    MyListView.ItemsSource = Items;
                }
            });


        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Usuario existente", "Usuario existente", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}


