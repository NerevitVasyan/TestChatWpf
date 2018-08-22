namespace TestChat
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ChatContext : DbContext
    {
        
        public ChatContext()
            : base("name=ChatConnString")
        {
        }

       
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }

   
}