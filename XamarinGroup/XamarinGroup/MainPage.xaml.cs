using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinGroup.Models;
using XamarinGroup.Repository;

namespace XamarinGroup
{
    public partial class MainPage : ContentPage
    {
        GroupRepository _GRepo;

        public MainPage()
        {
            InitializeComponent();
            _GRepo = new GroupRepository();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {

            string query = searchquery.Text;

            if (!string.IsNullOrWhiteSpace(query))
            {
                Search SearchData = await _GRepo.GetSearchMovie(this.RequestUri(_GRepo.SearchEndpoint), query);
                BindingContext = SearchData;
            }
        }
        //?api_key=11b2435829c14693e68170a0500f2746&language=en-US&query=Titanic&page=1&include_adult=false

        public string RequestUri(string endpoint , string query)
        {
            string requestUri = endpoint;
            requestUri += $"?api_key=11b2435829c14693e68170a0500f2746&language=en-US&query=" + query + "&page=1&include_adult=false";
            return requestUri;
        }


    }
}
