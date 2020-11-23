namespace AuthApp.Client.Models
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

    public class BaseFetchData<TItem> : ComponentBase
    {
        public BaseFetchData(string apiEndpoint) => this.apiEndpoint = apiEndpoint;

        [Inject]
        HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                data = await Http.GetFromJsonAsync<TItem[]>(apiEndpoint);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }

        protected TItem[] data;
        protected string message;
        string apiEndpoint;
    }
}