
using System.Linq;
using Ac4yUtilityContainer;
using System.Collections.Generic;
using CSUsers;

namespace  FBClassesCap
{

    public class AuthenticationRequestCap
    {
      public IEnumerable<AuthenticationRequest> GetList()
      {
          
          return new Context().AuthenticationRequests;

      } // GetList   
   
      public AuthenticationRequest Insert(AuthenticationRequest authenticationRequest)
      {

          using (var context = new Context())
          {                    
              context.Database.EnsureCreated();

              context.AuthenticationRequests.Add(authenticationRequest);
              context.SaveChanges();
          }

          return authenticationRequest;

      } // Insert

      public AuthenticationRequest GetById(int id)
      {

          return new Context().AuthenticationRequests.Find(id);

      } // GetById

      public bool IsExistById(int id)
      {
        return GetById(id) != null;
      }
/*
      public AuthenticationRequest GetByGuid(string guid)
      {

          return new Context().AuthenticationRequests
                    .Where(entity => entity.GUID == guid)
                    .FirstOrDefault<AuthenticationRequest>();

      } // GetByGuid

      public bool IsExistByGuid(string guid)
      {

          return GetByGuid(guid) != null;

      } // IsExistByGuid
*/
      public AuthenticationRequest UpdateById(int id, AuthenticationRequest authenticationRequest)
      {
          AuthenticationRequest actual = null;

            using (var context = new Context())
            {

                actual = context.AuthenticationRequests.Find(id);
                
                Object2Object(authenticationRequest, actual);
                actual.Id = id;
                
                context.SaveChanges();

            }
	    
	    return actual;

      } // UpdateById
/*
      public void UpdateByGuid(string guid, AuthenticationRequest authenticationRequest)
      {

          using (var context = new Context())
          {

              AuthenticationRequest actual = context.AuthenticationRequests.Where(entity => entity.GUID == guid).FirstOrDefault<AuthenticationRequest>();
              int id = actual.Id;
              Object2Object(authenticationRequest, actual);
              actual.Id = id;
              actual.GUID= guid;
              context.SaveChanges();

          }

      } // UpdateByGuid
      */
    public List<AuthenticationRequest> GetListOfAuthenticationRequest()
    {

        using(var context = new Context())
        {
            return context.AuthenticationRequests.ToList();
        }

    } // GetListOfAuthenticationRequest

    public void DeleteAuthenticationRequest(AuthenticationRequest authenticationRequest)
    {

        var context = new Context();

        context.AuthenticationRequests.Remove(authenticationRequest);
        context.SaveChanges();

    } // DeleteAuthenticationRequest

    public void DeleteById(int id)
    {
        
        var context = new Context();

        AuthenticationRequest actual = context.AuthenticationRequests.Find(id);
        context.AuthenticationRequests.Remove(actual);
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

    } // AuthenticationRequestCap

} // Cap
