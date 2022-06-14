using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Conrete;

namespace DataAccessLayer.Abstract
{
    public interface ISubscribeMailDal:IRepository<SubscribeMail>
    {
    }
}
