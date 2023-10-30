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
    public class ManagerLogic : IManagerLogic
    {
        private readonly IManagerStorage _managerStorage;

        public ManagerLogic(IManagerStorage managerStorage)
        {
            _managerStorage = managerStorage;
        }

        public bool Create(ManagerBindingModel model)
        {
            if (_managerStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(ManagerViewModel model)
        {
            if (_managerStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

        public ManagerViewModel? ReadElement(ManagerSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _managerStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<ManagerViewModel>? ReadList(ManagerSearchModel? model)
        {
            var list = model == null ? _managerStorage.GetFullList() : _managerStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(ManagerBindingModel model)
        {
            if (_managerStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
    }
}
