using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void AboutAdd(About about)
        {
            _aboutDAL.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDAL.Update(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDAL.Update(about);
        }

        public About GetById(int id)
        {
            return _aboutDAL.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDAL.List();
        }
    }
}
