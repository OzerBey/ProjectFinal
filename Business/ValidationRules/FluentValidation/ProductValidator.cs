using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //kurallar buraya yazılır (everything (:)
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);//p nin product name min lenght i 2 karakter olamlıdır
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//category ıd si 1 olan ürünler oldugunda unitprice i 10 dan büyük ya da eşit olmalıdır
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı !!");

        }

        private bool StartWithA(string arg) //arg oradaki gelen eleman yani productnamde dir
        {
            return arg.StartsWith("A");// eger a ile başlıyorsa true döner
        }
    }
}
