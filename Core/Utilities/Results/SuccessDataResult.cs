using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //burada işlem sonucu default true dur.
    public class SuccessDataResult<T> : DataResult<T>
    {
        //versions 
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        //Alttaki ikili fazla kullanılmaz ama seçenek olarak yazdık
        public SuccessDataResult(string message) : base(default, true, message) //default :data için çalıştıgın T nin default u 
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }

    }
}
