using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //base () base class a gönderilecek veri base class =Result inherit ettigi classtır
        {

        }

        public SuccessResult() : base(true) //boş paramtreli direkt true demektir diye olsuturduk  
        //base in result una true gönderiyor
        {

        }
    }
}
