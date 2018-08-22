using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat
{
    public class TestFill
    {
        public void Fill()
        {
            using (ChatContext db = new ChatContext())
            {
                User user1 = new User { Nickname = "Vasyan" };
                User user2 = new User { Nickname = "Kolya" };
                User user3 = new User { Nickname = "Semen" };

                Message mes1 = new Message() { Text = "Hello", Sender = user1, Date = DateTime.Now };
                Message mes2 = new Message() { Text = "Hi. How are you?", Sender = user2, Date = DateTime.Now };
                Message mes3 = new Message() { Text = "Norm))00", Sender = user2, Date = DateTime.Now };
                Message mes4 = new Message() { Text = "Hi guys!", Sender = user3, Date = DateTime.Now };

                db.Messages.Add(mes1);
                db.Messages.Add(mes2);
                db.Messages.Add(mes3);
                db.Messages.Add(mes4);
                db.SaveChanges();
            }
        }
    }
}
