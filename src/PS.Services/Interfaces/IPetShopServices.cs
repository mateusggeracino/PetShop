using System.Collections;
using System.Collections.Generic;
using PS.Services.ViewModels;

namespace PS.Services.Interfaces
{
    public interface IPetShopServices
    {
        PetViewModel Insert(PetViewModel pet);
        bool Remove(int id);
        PetViewModel Update(PetViewModel pet);
        PetViewModel Read(int id);
        IEnumerable<PetViewModel> GetAll();
    }
}