using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> List();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetById(int id);
        bool Login(Writer writer);
        int GetWriterIdBySession(string email);
    }
}
