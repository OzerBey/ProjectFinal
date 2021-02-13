using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //sql cümleciklerinin bulunacagı kisim :)
    public interface IOrderDal :IEntityRepository<Order>
    {

    }
}
