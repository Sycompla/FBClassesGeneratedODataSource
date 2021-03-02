using System;
using System.Collections.Generic;

namespace CSUsers
{
    public class User
    {

public Int32 Id { get; set; }

public String Guid { get; set; }

public DateTime CreatedAt { get; set; }

public DateTime UpdatedAt { get; set; }

public String Name { get; set; }

public String Email { get; set; }

public String Password { get; set; }

public String OAuthToken { get; set; }

public String Language { get; set; }

public String PhoneNumber { get; set; }

public String UserName { get; set; }
	}
}