

namespace PruebasWebNetCore.UIForms.Infrastruture
{
    using PruebasWebNetCore.UIForms.ViewModels;

    class InstanceLocator
    {
        public MainViewModel Main { get; set; }
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
