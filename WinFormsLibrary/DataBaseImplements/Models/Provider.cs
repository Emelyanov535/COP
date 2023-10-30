using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBaseImplements.Models
{
    public class Provider : IProviderModel
    {
        [Required]
        public int DeliveryFrequencyPerYear { get; set; }

        public int Id { get; private set; }

        public string Name { get; set; } = string.Empty;

        public string LastShipping { get; set; } = string.Empty;

        public string Manager { get; set; } = string.Empty;

        public static Provider? Create(ProviderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Provider()
            {
                Id = model.Id,
                DeliveryFrequencyPerYear = model.DeliveryFrequencyPerYear,
                Name = model.Name,
                LastShipping = model.LastShipping,
                Manager = model.Manager,
            };
        }
        public void Update(ProviderBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            DeliveryFrequencyPerYear = model.DeliveryFrequencyPerYear;
            Name = model.Name;
            LastShipping = model.LastShipping;
            Manager = model.Manager;
        }
        public ProviderViewModel GetViewModel => new()
        {
            Id = Id,
            DeliveryFrequencyPerYear= DeliveryFrequencyPerYear,
            Manager = Manager,
            Name = Name,
            LastShipping = LastShipping,
        };
    }
}
