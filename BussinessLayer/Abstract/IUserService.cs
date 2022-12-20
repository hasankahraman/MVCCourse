using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        void UserAdd(User user);
        User GetById(int id);
        void UserDelete(User user);
        void UserUpdate(User user);
        bool Login(User user);
    }
}
