using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BusinessLogicContracts
{
    public interface IManagerLogic
    {
        List<ManagerViewModel>? ReadList(ManagerSearchModel? model);
        ManagerViewModel? ReadElement(ManagerSearchModel model);
        bool Create(ManagerBindingModel model);
        bool Update(ManagerBindingModel model);
        bool Delete(ManagerViewModel model);
    }
}
