using GalaSoft.MvvmLight;

namespace Cellenzapp.Core.ViewModel
{
    public class CustomViewModelBase : ViewModelBase
    {
        /// <summary>
        ///     The <see cref="IsLoading" /> property's name.
        /// </summary>
        public const string IsLoadingPropertyName = "IsLoading";

        private bool _isLoading;

        /// <summary>
        ///     Sets and gets the IsLoading property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public bool IsLoading
        {
            get { return _isLoading; }

            set
            {
                if (_isLoading == value)
                {
                    return;
                }

                _isLoading = value;
                RaisePropertyChanged(IsLoadingPropertyName);
            }
        }
    }
}