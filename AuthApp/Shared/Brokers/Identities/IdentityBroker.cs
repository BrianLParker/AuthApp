namespace AuthApp.Shared.Brokers.Identities
{
    using System;
    using AuthApp.Shared.Models;

    public class IdentityBroker : IIdentityBroker
    {
        private IdentityModel identityModel;
        public IdentityModel IdentityModel
        {
            get => identityModel;
            set
            {
                identityModel = value;
                OnIdentityChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<IdentityModel> OnIdentityChanged;
    }
}
