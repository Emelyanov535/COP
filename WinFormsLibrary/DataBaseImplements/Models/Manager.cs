using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplements.Models
{
    public class Manager : IManagerModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int Id { get; private set; }

        public static Manager? Create(ManagerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Manager()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
            };
        }
        public void Update(ManagerBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            Name = model.Name;
            Surname = model.Surname;
        }
        public ManagerViewModel GetViewModel => new()
        {
            Id = Id,
            Name = Name,
            Surname = Surname
        };
    }
}
