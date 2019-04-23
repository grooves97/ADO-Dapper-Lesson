using System;


namespace DCA.Models
{
    public class Mail : Entity
    {
        public Receiver Receiver { get; set; }
        public Guid ReceiverId { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
    }
}