using ShelterApi.Contracts;
using ShelterApi.Models;

namespace ShelterApi.Repository
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(ShelterApiContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Pet> GetPets(PagedParameters petParameters)
        {
            return PagedList<Pet>.ToPagedList(FindAll(),
                petParameters.PageNumber,
                petParameters.PageSize);
        }

        public Pet GetPetById(Guid petId)
        {
            return FindByCondition(pet => pet.PetId.Equals(petId))
                .DefaultIfEmpty(new Pet())
                .FirstOrDefault();
        }

    }
}