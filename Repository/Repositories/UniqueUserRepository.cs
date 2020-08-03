
using DB.Entity;
using Repository.Interface;

namespace Repository.Repositories
{
    public class UniqueUserRepository: UniqueRepository<User>
    {
        private class Traits : IUniqueRepositoryTraits<User>
        {
            public static readonly Traits Instance = new Traits();

            public int GetId(User item) => item.ID;

            public bool Equals(User item1, User item2)
            {
                return item1.ID == item2.ID &&
                       item1.FirstName == item2.FirstName &&
                       item1.LastName == item2.LastName &&
                       item1.Position.Type == item2.Position.Type;
            }

            public void CopyTo(User from, User to)
            {
                to.ID = from.ID;
                to.FirstName = from.FirstName;
                to.LastName = from.LastName;
                to.Position.Type = from.Position.Type;
            }
        }

        public UniqueUserRepository(IRepository<User> repository) :
            base(repository, Traits.Instance)
        {

        }
    }
}
