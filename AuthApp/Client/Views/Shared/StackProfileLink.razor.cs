namespace AuthApp.Client.Views.Shared
{
    using AuthApp.Client.Models;
    using Microsoft.AspNetCore.Components;

    public partial class StackProfileLink
    {
        [Parameter]
        public StackProfileTheme Theme { get; set; }

        string query => Theme switch
        {
            StackProfileTheme.Clean => "?theme=clean",
            StackProfileTheme.Dark => "?theme=dark",
            StackProfileTheme.Hotdog => "?theme=hotdog",
            _ => ""
        };
    }
}
