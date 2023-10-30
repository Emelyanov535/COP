using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModels
{
    public class ProviderViewModel : IProviderModel
    {
        public int DeliveryFrequencyPerYear { get; set; }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastShipping { get; set; } = string.Empty;

        public string Manager { get; set; } = string.Empty;
    }
}
