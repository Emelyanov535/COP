using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DataBaseImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Implements
{
    public class ManagerStorage : IManagerStorage
    {
        public ManagerViewModel? Delete(ManagerViewModel model)
        {
            using var context = new Database();
            var element = context.Managers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Managers.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ManagerViewModel? GetElement(ManagerSearchModel model)
        {
            using var context = new Database();
            return context.Managers
                .FirstOrDefault(x =>
                (!string.IsNullOrEmpty(model.Id.ToString()) && x.Id ==
                model.Id) ||
                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<ManagerViewModel> GetFilteredList(ManagerSearchModel model)
        {
            using var context = new Database();
            return context.Managers
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ManagerViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Managers
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ManagerViewModel? Insert(ManagerBindingModel model)
        {
            var newCategory = Manager.Create(model);
            if (newCategory == null)
            {
                return null;
            }
            using var context = new Database();
            context.Managers.Add(newCategory);
            context.SaveChanges();
            return newCategory.GetViewModel;
        }

        public ManagerViewModel? Update(ManagerBindingModel model)
        {
            using var context = new Database();
            var component = context.Managers.FirstOrDefault(x => x.Id == model.Id);
            if (component == null)
            {
                return null;
            }
            component.Update(model);
            context.SaveChanges();
            return component.GetViewModel;
        }
    }
}
