using AutoMapper;
using PS.Services.AutoMapper.Profiles;

namespace PS.Services.AutoMapper
{
    public sealed class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModel());
                config.AddProfile(new ViewModelToDomain());
            });
        }
    }
}