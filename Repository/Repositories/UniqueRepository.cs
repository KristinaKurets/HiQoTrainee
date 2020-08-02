using System;
using System.Collections.Generic;
using System.Text;
using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Repositories
{
    public class UniqueRepository<T> : AbstractRepository<T> where T: class
    {
        private readonly AbstractRepository<T> repository;

        public UniqueRepository(HqrbContext context, AbstractRepository<T> repository) : base(context) 
            => this.repository = repository;
        

        public void CreateUnique(IEnumerable<User> users)
        {
            //userRepositoryGetAllUsers();
            //if(length == 0)
            //{
            //  userRep.AddRange(users);
            //}
            //else
            //{
            //  List usersToAdd = new List<User>();
            //  comporator for user which work like this(
            //  foreach(user in users)
            //  {
            //      if(user != userRep.Read(user.id))
            //      {
            //          userRep.Update( userRep.Read(user.id));
            //          userRep.Create(user);
            //      }
            //      else if( userRep.Read(user.id) == null)
            //      {
            //          usersToAdd.Add(user)
            //      }
            //  }
            //  userRep.AddRange(usersToAdd);
            //}
        }

        public override DbSet<T> GetDbSet() => repository.GetDbSet();
        
    }
}
