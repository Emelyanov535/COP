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
    public interface IProviderStorage
    {
        List<ProviderViewModel> GetFullList();
        List<ProviderViewModel> GetFilteredList(ProviderSearchModel model);
        ProviderViewModel? GetElement(ProviderSearchModel model);
        ProviderViewModel? Insert(ProviderBindingModel model);
        ProviderViewModel? Update(ProviderBindingModel model);
        ProviderViewModel? Delete(ProviderViewModel model);
    }
}
