
using System.Linq;
using Ac4yUtilityContainer;
using System.Collections.Generic;
using CSUsers;

namespace  FBClassesCap
{

    public class UserCap
    {
      public IEnumerable<User> GetList()
      {
          
          return new Context().Users;

      } // GetList   
   
      public User Insert(User user)
      {

          using (var context = new Context())
          {                    
              context.Database.EnsureCreated();

              context.Users.Add(user);
              context.SaveChanges();
          }

          return user;

      } // Insert

      public User GetById(int id)
      {

          return new Context().Users.Find(id);

      } // GetById

      public bool IsExistById(int id)
      {
        return GetById(id) != null;
      }
/*
      public User GetByGuid(string guid)
      {

          return new Context().Users
                    .Where(entity => entity.GUID == guid)
                    .FirstOrDefault<User>();

      } // GetByGuid

      public bool IsExistByGuid(string guid)
      {

          return GetByGuid(guid) != null;

      } // IsExistByGuid
*/
      public User UpdateById(int id, User user)
      {
          User actual = null;

            using (var context = new Context())
            {

                actual = context.Users.Find(id);
                
                Object2Object(user, actual);
                actual.Id = id;
                
                context.SaveChanges();

            }
	    
	    return actual;

      } // UpdateById
/*
      public void UpdateByGuid(string guid, User user)
      {

          using (var context = new Context())
          {

              User actual = context.Users.Where(entity => entity.GUID == guid).FirstOrDefault<User>();
              int id = actual.Id;
              Object2Object(user, actual);
              actual.Id = id;
              actual.GUID= guid;
              context.SaveChanges();

          }

      } // UpdateByGuid
      */
    public List<User> GetListOfUser()
    {

        using(var context = new Context())
        {
            return context.Users.ToList();
        }

    } // GetListOfUser

    public void DeleteUser(User user)
    {

        var context = new Context();

        context.Users.Remove(user);
        context.SaveChanges();

    } // DeleteUser

    public void DeleteById(int id)
    {
        
        var context = new Context();

        User actual = context.Users.Find(id);
        context.Users.Remove(actual);
        context.SaveChanges();

    } // DeleteById
    
        public void Object2Object(object source, object target)
        {

            var properties = source.GetType().GetProperties();

            foreach (var item in properties)
            {
                if (item.GetValue(source, null) != null)
                {
                    target.GetType().GetProperty(item.Name).SetValue(target, item.GetValue(source, null), null);
                }
            }

        } // Object2Object

    } // UserCap

} // Cap
