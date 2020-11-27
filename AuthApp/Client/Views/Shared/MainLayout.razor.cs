namespace AuthApp.Client.Views.Shared
{
    using Microsoft.AspNetCore.Components;

    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] LayoutService LayoutService { get; set; }

        protected override void OnInitialized() => LayoutService.OnLayoutChange += OnLayoutChange;

        private void OnLayoutChange(object sender, bool e) => StateHasChanged();
    }
}