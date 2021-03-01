using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //token üretimi yapacak yerimiz 
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
