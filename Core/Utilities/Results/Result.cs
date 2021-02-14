using System;
using System.Collections.Generic;
using System.Text;



namespace Core.Utilities.Results
{

    //congrete of IResult  : IResult ın somut kısmıdır
    public class Result : IResult   // ciplak sisnif kalmasin :)
    {//constructor
        public Result(bool success, string message) : this(success)   //this(success) : iki parametre gönderilen bir yapısı icin paramteresi success olan classı da calıstır demektir 
        {
            // !! _getter olan bir özellikleri (properties) constructor ile set edebiliriz
            //getter readonly bir yapıdadır readonly yapıda olanlar constructor da set edilebilir
            Message = message;
        }

        public Result(bool success) //overloading 
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
