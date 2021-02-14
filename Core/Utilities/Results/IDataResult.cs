using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{//hangi tipi döndürecegini belirt
    //IResult aynı zamanada dedik çünkü mesaj yönetiminin yanı sıra data da döndürmeliyiz
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
