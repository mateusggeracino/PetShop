using System;
using System.Collections.Generic;
using System.Linq;
using PS.Business.Interfaces;
using PS.Domain.Models;
using PS.Domain.Validations;
using PS.Repository.Interfaces;

namespace PS.Business
{
    public sealed class PetShopBusiness : IPetShopBusiness
    {
        private readonly IPetShopRepository _petShopRepository;

        public PetShopBusiness(IPetShopRepository petShopRepository)
        {
            _petShopRepository = petShopRepository;
        }

        public Pet Insert(Pet pet)
        {
            if (ValidatePet(pet)) return pet;

            SetDefaultInfo(pet);
            return _petShopRepository.Insert(pet);
        }

        private void SetDefaultInfo(Pet pet)
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            pet.Id = random.Next(1, 9999);
            pet.Registration = DateTime.Now;
        }

        private bool ValidatePet(Pet pet)
        {
            var petValidator = new PetValidator();
            pet.ValidationResult = petValidator.Validate(pet);
            return pet.ValidationResult.Errors.Any();
        }

        public bool Remove(int id)
        {
            return _petShopRepository.Remove(id);
        }

        public Pet Update(Pet pet)
        {
            return _petShopRepository.Update(pet);
        }

        public Pet Read(int id)
        {
            return _petShopRepository.Read(id);
        }

        public IEnumerable<Pet> GetAll()
        {
            return _petShopRepository.GetAll();
        }
    }
}