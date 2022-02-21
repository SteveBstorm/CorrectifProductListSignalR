using CorrectifProductListSignalR.Data;
using CorrectifProductListSignalR.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace CorrectifProductListSignalR.Pages.Products
{
    public partial class ProductList
    {
        [Inject]
        public ProductService _service{ get; set; }
        [Inject]
        public NavigationManager _navigation { get; set; }
        public List<Product> MyList { get; set; }

        private HubConnection _hub;

        protected override async Task OnInitializedAsync()
        {
            MyList = await _service.GetAll();

            _hub = new HubConnectionBuilder().WithUrl(_navigation.ToAbsoluteUri("/product")).Build();

            _hub.On("updateList", () =>
            {
               // MyList = await _service.GetAll();
                StateHasChanged();
            });

            await _hub.StartAsync();
        }
    }
}
