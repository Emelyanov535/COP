using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StoragesContracts
{
    public interface IManagerStorage
    {
        List<ManagerViewModel> GetFullList();
        List<ManagerViewModel> GetFilteredList(ManagerSearchModel model);
        ManagerViewModel? GetElement(ManagerSearchModel model);
        ManagerViewModel? Insert(ManagerBindingModel model);
        ManagerViewModel? Update(ManagerBindingModel model);
        ManagerViewModel? Delete(ManagerViewModel model);
    }
}
