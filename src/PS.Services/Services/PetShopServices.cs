using System.Collections.Generic;
using AutoMapper;
using PS.Business.Interfaces;
using PS.Domain.Models;
using PS.Services.Interfaces;
using PS.Services.ViewModels;

namespace PS.Services.Services
{
    public class PetShopServices : IPetShopServices
    {
        private readonly IPetShopBusiness _petShopBusiness;
        private readonly IMapper _mapper;
        public PetShopServices(IPetShopBusiness petShopBusiness, IMapper mapper)
        {
            _petShopBusiness = petShopBusiness;
            _mapper = mapper;
        }

        public PetViewModel Insert(PetViewModel pet)
        {
            var petShopEntity = _mapper.Map<Pet>(pet);
            return _mapper.Map<PetViewModel>(_petShopBusiness.Insert(petShopEntity));
        }

        public bool Remove(int id)
        {
            return _petShopBusiness.Remove(id);
        }

        public PetViewModel Update(PetViewModel pet)
        {
            var petShopEntity = Mapper.Map<Pet>(pet);
            return _mapper.Map<PetViewModel>(_petShopBusiness.Update(petShopEntity));
        }

        public PetViewModel Read(int id)
        {
            return _mapper.Map<PetViewModel>(_petShopBusiness.Read(id));
        }

        public IEnumerable<PetViewModel> GetAll()
        {
            var pets = _petShopBusiness.GetAll();
            return _mapper.Map<IEnumerable<PetViewModel>>(pets);
        }
    }
}