using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//başarısız olanı bussiness e gönderiyoruz
                {
                    return logic; //uymayan kural varsa döndür
                }
            }

            return null; //başarılı ise bir şey göndermesine gerek yok
        }
    }
}
