using AutoMapper;
using PS.Domain.Models;
using PS.Services.ViewModels;

namespace PS.Services.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<PetViewModel, Pet>();
        }
    }
}