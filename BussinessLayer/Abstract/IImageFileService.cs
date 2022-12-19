using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        //void ImageFileAdd(ImageFile imageFile);
        //ImageFile GetById(int id);
        //void ImageFileDelete(ImageFile imageFile);
        //void ImageFileUpdate(ImageFile imageFile);
    }
}
