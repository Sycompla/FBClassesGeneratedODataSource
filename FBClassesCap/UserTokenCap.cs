
using System.Linq;
using Ac4yUtilityContainer;
using System.Collections.Generic;
using CSUsers;

namespace  FBClassesCap
{

    public class UserTokenCap
    {
      public IEnumerable<UserToken> GetList()
      {
          
          return new Context().UserTokens;

      } // GetList   
   
      public UserToken Insert(UserToken userToken)
      {

          using (var context = new Context())
          {                    
              context.Database.EnsureCreated();

              context.UserTokens.Add(userToken);
              context.SaveChanges();
          }

          return userToken;

      } // Insert

      public UserToken GetById(int id)
      {

          return new Context().UserTokens.Find(id);

      } // GetById

      public bool IsExistById(int id)
      {
        return GetById(id) != null;
      }
/*
      public UserToken GetByGuid(string guid)
      {

          return new Context().UserTokens
                    .Where(entity => entity.GUID == guid)
                    .FirstOrDefault<UserToken>();

      } // GetByGuid

      public bool IsExistByGuid(string guid)
      {

          return GetByGuid(guid) != null;

      } // IsExistByGuid
*/
      public UserToken UpdateById(int id, UserToken userToken)
      {
          UserToken actual = null;

            using (var context = new Context())
            {

                actual = context.UserTokens.Find(id);
                
                Object2Object(userToken, actual);
                actual.Id = id;
                
                context.SaveChanges();

            }
	    
	    return actual;

      } // UpdateById
/*
      public void UpdateByGuid(string guid, UserToken userToken)
      {

          using (var context = new Context())
          {

              UserToken actual = context.UserTokens.Where(entity => entity.GUID == guid).FirstOrDefault<UserToken>();
              int id = actual.Id;
              Object2Object(userToken, actual);
              actual.Id = id;
              actual.GUID= guid;
              context.SaveChanges();

          }

      } // UpdateByGuid
      */
    public List<UserToken> GetListOfUserToken()
    {

        using(var context = new Context())
        {
            return context.UserTokens.ToList();
        }

    } // GetListOfUserToken

    public void DeleteUserToken(UserToken userToken)
    {

        var context = new Context();

        context.UserTokens.Remove(userToken);
        context.SaveChanges();

    } // DeleteUserToken

    public void DeleteById(int id)
    {
        
        var context = new Context();

        UserToken actual = context.UserTokens.Find(id);
        context.UserTokens.Remove(actual);
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

    } // UserTokenCap

} // Cap
