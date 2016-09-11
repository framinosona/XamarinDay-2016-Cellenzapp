using GalaSoft.MvvmLight;

namespace Cellenzapp.Core.ViewModel
{
    public class CustomViewModelBase : ViewModelBase
    {
        /// <summary>
        ///     The <see cref="IsBusy" /> property's name.
        /// </summary>
        public const string IsBusyPropertyName = "IsBusy";

        private bool _isBusy;

        /// <summary>
        ///     Sets and gets the IsBusy property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public bool IsBusy {
            get { return _isBusy; }

            set {
                if(_isBusy == value) {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged(IsBusyPropertyName);
            }
        }
    }
}