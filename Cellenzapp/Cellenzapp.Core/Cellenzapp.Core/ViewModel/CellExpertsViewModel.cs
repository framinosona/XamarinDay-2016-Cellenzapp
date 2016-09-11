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
            var DataService = SimpleIoc.Default.GetInstance<IDataService>();
            DataService.TryLoadCellExpertsAsync().ContinueWith((succeded) => {
                CellExperts.Concat(DataService.CellExperts);
            });
        }

    }
}
