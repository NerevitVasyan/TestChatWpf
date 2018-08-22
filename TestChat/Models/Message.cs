using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat
{
    public class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }



        public  User Sender { get; set; }
        //public User Receiver { get; set; }
    }
}
