namespace AuthApp.Client
{
    using System;
    using OrakTech.BrowserStorage.Brokers;

    public class LayoutService
    {

        public LayoutService(LocalStorageBroker localStorageBroker)
        {
            this.localStorageBroker = localStorageBroker;
        }

        private readonly LocalStorageBroker localStorageBroker;

        public bool IsCleanViewLayout
        {
            get => localStorageBroker.GetItem<bool>("IsCleanViewLayout");
            set
            {
                localStorageBroker.SetItem("IsCleanViewLayout", value);
                OnLayoutChange.Invoke(this, value);
            }
        }

        public event EventHandler<bool> OnLayoutChange;
    }
}
