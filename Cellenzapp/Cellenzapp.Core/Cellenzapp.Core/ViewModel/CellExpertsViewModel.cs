using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using Cellenzapp.Core.Model;
using Cellenzapp.Core.Data;

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

        public async void Load()
        {
            var DataService = SimpleIoc.Default.GetInstance<IDataService>();
            await DataService.TryLoadCellExpertsAsync();
            foreach(var expert in DataService.CellExperts) {
                CellExperts.Add(expert);
            }
        }

    }
}
