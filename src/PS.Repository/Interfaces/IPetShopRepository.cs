using System.Collections.Generic;
using PS.Domain.Models;
using PS.Repository.Interfaces.Base;

namespace PS.Repository.Interfaces
{
    public interface IPetShopRepository : IRepository<Pet>
    {
    }
}