using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {

            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);//ilgili contexti dogrula demektir
            if (!result.IsValid) //geçersiz ise
            {
                throw new ValidationException(result.Errors);//kurala uymuyorsa hata fırlat
            }
        }
    }
}
