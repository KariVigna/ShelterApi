using ShelterApi.Models;

namespace ShelterApi.Contracts
{
    public interface IPetRepository : IRepositoryBase<Pet>
    {
        PagedList<Pet> GetPets(PagedParameters petParameters);
        Pet GetPetById(Guid petId);
    }
}