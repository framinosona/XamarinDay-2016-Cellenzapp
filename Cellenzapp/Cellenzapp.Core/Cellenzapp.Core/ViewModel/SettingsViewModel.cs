using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellenzapp.Core.Helpers;

namespace Cellenzapp.Core.ViewModel
{
    public class SettingsViewModel : CustomViewModelBase
    {
        public bool IsTwitterSynchronized {
            get { return this.IsTwitterSynchronized; }
            set {
                this.IsTwitterSynchronized = value;
                this.RaisePropertyChanged("IsTwitterSynchronized");
            }
        }

        public SettingsViewModel()
        {
            this.IsTwitterSynchronized = Settings.TwitterSynchro;
        }
    }
}
