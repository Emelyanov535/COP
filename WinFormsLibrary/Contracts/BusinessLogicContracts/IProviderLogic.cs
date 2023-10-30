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
    public interface IProviderLogic
    {
        List<ProviderViewModel>? ReadList(ProviderSearchModel? model);
        ProviderViewModel? ReadElement(ProviderSearchModel model);
        bool Create(ProviderBindingModel model);
        bool Update(ProviderBindingModel model);
        bool Delete(ProviderViewModel model);
    }
}
