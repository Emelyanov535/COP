using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public interface IProviderModel : IId
    {
        string Name { get; }
        string LastShipping { get; }
        int DeliveryFrequencyPerYear { get; }
        string Manager { get; }
    }
}
