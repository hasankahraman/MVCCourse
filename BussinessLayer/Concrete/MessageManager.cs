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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public Message GetById(int id)
        {
            return _messageDAL.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDAL.List(x => x.ReceiverMail == "admin@admin.com").OrderByDescending(x => x.CreatedAt).ToList(); ;
        }

        public List<Message> GetListSentbox()
        {
            return _messageDAL.List(x => x.SenderMail == "admin@admin.com").OrderByDescending(x => x.CreatedAt).ToList(); ;
        }

        public void MessageAdd(Message message)
        {
            _messageDAL.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDAL.Delete(message);
        }

        public int MessageSentboxCount()
        {
            return _messageDAL.List(x => (x.IsRead == false) && (x.SenderMail == "admin@admin.com")).Count;
        }

        public int MessageUnreadCount()
        {
            return _messageDAL.List(x => (x.IsRead == false) && (x.ReceiverMail == "admin@admin.com")).Count;
        }

        public void MessageUpdate(Message message)
        {
            _messageDAL.Update(message);
        }
    }
}
