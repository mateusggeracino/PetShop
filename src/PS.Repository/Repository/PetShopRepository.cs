using Microsoft.Extensions.Configuration;
using PS.Domain.Models;
using PS.Repository.Interfaces;
using PS.Repository.Repository.Base;

namespace PS.Repository.Repository
{
    public sealed class PetShopRepository : Repository<Pet>, IPetShopRepository
    {
        public PetShopRepository(IConfiguration config) : base(config, "developerdb05")
        {
        }
    }
}