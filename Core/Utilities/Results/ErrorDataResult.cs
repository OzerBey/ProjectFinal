using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //versions 
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //Alttaki ikili fazla kullanılmaz ama seçenek olarak yazdık
        public ErrorDataResult(string message) : base(default, false, message) //default :data için çalıştıgın T nin default u 
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
