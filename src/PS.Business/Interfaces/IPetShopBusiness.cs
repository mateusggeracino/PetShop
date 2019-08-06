using System.Collections.Generic;
using PS.Domain.Models;

namespace PS.Business.Interfaces
{
    public interface IPetShopBusiness
    {
        Pet Insert(Pet pet);
        bool Remove(int id);
        Pet Update(Pet pet);
        Pet Read(int id);
        IEnumerable<Pet> GetAll();
    }
}