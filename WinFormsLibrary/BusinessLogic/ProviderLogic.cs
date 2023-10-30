using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProviderLogic : IProviderLogic
    {
        private readonly IProviderStorage _providerStorage;

        public ProviderLogic(IProviderStorage providerStorage)
        {
            _providerStorage = providerStorage;
        }

        public bool Create(ProviderBindingModel model)
        {
            if (_providerStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(ProviderViewModel model)
        {
            if (_providerStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

        public ProviderViewModel? ReadElement(ProviderSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _providerStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<ProviderViewModel>? ReadList(ProviderSearchModel? model)
        {
            var list = _providerStorage.GetFullList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(ProviderBindingModel model)
        {
            if (_providerStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
    }
}
