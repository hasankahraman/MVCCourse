using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public Writer GetById(int id)
        {
            return _writerDAL.Get(x=> x.WriterId == id);
        }

        public int GetWriterIdBySession(string email)
        {
            return _writerDAL.Get(x => x.Email == email).WriterId;
        }

        public List<Writer> List()
        {
            return _writerDAL.List();
        }

        public bool Login(Writer writer)
        {
            if (_writerDAL.Get(x => (x.Email == writer.Email) && (x.Password == writer.Password)) != null)
            {
                return true;
            }
            return false;
        }

        public void WriterAdd(Writer writer)
        {
            _writerDAL.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDAL.Update(writer);
        }
    }
}
