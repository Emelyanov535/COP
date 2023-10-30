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
    public class ProviderStorage : IProviderStorage
    {
        public ProviderViewModel? Delete(ProviderViewModel model)
        {
            using var context = new Database();
            var element = context.Providers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Providers.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ProviderViewModel? GetElement(ProviderSearchModel model)
        {
            using var context = new Database();
            return context.Providers
                .FirstOrDefault(x =>
                (!string.IsNullOrEmpty(model.Id.ToString()) && x.Id ==
                model.Id) ||
                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<ProviderViewModel> GetFilteredList(ProviderSearchModel model)
        {
            using var context = new Database();
            return context.Providers
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ProviderViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Providers
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ProviderViewModel? Insert(ProviderBindingModel model)
        {
            var newCategory = Provider.Create(model);
            if (newCategory == null)
            {
                return null;
            }
            using var context = new Database();
            context.Providers.Add(newCategory);
            context.SaveChanges();
            return newCategory.GetViewModel;
        }

        public ProviderViewModel? Update(ProviderBindingModel model)
        {
            using var context = new Database();
            var component = context.Providers.FirstOrDefault(x => x.Id == model.Id);
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
