using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler icin baslangıç
    //Uygulamamizi kullanan kisilere işleminin olup olmadıgı ve mesaj icerigi olarak geri dönüş vermek amaclıdır.
    public interface IResult
    {
        bool Success { get; } //readonly    success or not
        string Message { get; } //return a message
    }
}
