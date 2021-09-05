
using CommunityToolkit.Mvvm.ComponentModel;
using DevUtils.Core;

namespace DevUtils.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        private readonly DevUtilContext devUtilContext;

        public MainViewModel(DevUtilContext devUtilContext)
        {
            this.devUtilContext = devUtilContext;
        }
    }
}
