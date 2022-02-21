using CorrectifProductListSignalR.Data;
using CorrectifProductListSignalR.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace CorrectifProductListSignalR.Pages.Products
{
    public partial class AddProduct
    {
        private HubConnection _hub;
        [Inject]
        public ProductService _service{ get; set; }
        [Inject]
        public NavigationManager _navigation { get; set; }

        public ProductForm MyForm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MyForm = new ProductForm();
            _hub = new HubConnectionBuilder().WithUrl(_navigation.ToAbsoluteUri("/product")).Build();

            await _hub.StartAsync();
            StateHasChanged();
        }

        public async Task SubmitForm()
        {
            _service.AddProduct(new Product
            {
                Name = MyForm.Name,
                Price = MyForm.Price
            });

            await _hub.SendAsync("RefreshList");

            MyForm = new ProductForm();
        }
    }
}
