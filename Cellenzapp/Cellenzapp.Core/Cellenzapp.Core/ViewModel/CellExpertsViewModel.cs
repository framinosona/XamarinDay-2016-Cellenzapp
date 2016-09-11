using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using Cellenzapp.Core.Model;
using Cellenzapp.Core.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;

namespace Cellenzapp.Core.ViewModel
{
    public class CellExpertsViewModel : CustomViewModelBase
    {
        public ObservableCollection<CellExpert> CellExperts { get; set; }

        public CellExpertsViewModel()
        {
            CellExperts = new ObservableCollection<CellExpert>();

            Load();
        }

        public async Task Load()
        {
            var DataService = SimpleIoc.Default.GetInstance<IDataService>();
            await DataService.TryLoadCellExpertsAsync();
            CellExperts.Clear();
            foreach(var expert in DataService.CellExperts) {
                CellExperts.Add(expert);
            }
        }


        RelayCommand refreshCommand;
        public RelayCommand RefreshCommand {
            get { return refreshCommand ?? (refreshCommand = new RelayCommand(async () => await ExecuteRefreshCommandAsync())); }
        }

        async Task ExecuteRefreshCommandAsync()
        {
            if(IsBusy)
                return;

            IsBusy = true;

            try {
                await Load();

            } catch(Exception ex) {
                Debugger.Break();
            } finally {
                IsBusy = false;
            }
        }

    }
}
