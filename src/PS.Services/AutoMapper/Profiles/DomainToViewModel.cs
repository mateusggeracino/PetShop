using AutoMapper;
using PS.Domain.Models;
using PS.Services.ViewModels;

namespace PS.Services.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Pet, PetViewModel>();
        }
    }
}