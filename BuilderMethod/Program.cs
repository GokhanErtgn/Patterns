using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageCreater creater = new MessageCreater();
            creater.Create(new EidGreeting());
            creater.Show();
            creater.Create(new BirthGreeting());
            creater.Show();
            Console.ReadKey();
        }
    }

    public enum MessageType
    {
        BirthdayGreeting,
        EidGreeting,
        ChristmasGreeting,
        GeneralInformation
    }

    public class Message
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Signature { get; set; }

        private MessageType _messageType;

        public Message(MessageType messageType)
        {
            _messageType = messageType;
        }

        public void Show()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Body);
            Console.WriteLine(Signature);
        }
    }

    public abstract class MessageBuilder
    {
        public abstract void CreteTitle();
        public abstract void CreteBody();
        public abstract void CreteSignature();

        private Message _message;

        public Message Message
        {
            get { return _message; }
        }

        public MessageBuilder(MessageType messageType)
        {
            _message = new Message(messageType);
        }
    }

    public class BirthGreeting : MessageBuilder
    {
        public BirthGreeting():base(MessageType.BirthdayGreeting)
        {

        }
        public override void CreteTitle()
        {
            this.Message.Title = "BirthDay";
        }
        public override void CreteBody()
        {
            this.Message.Body = "Happy BirthDay";
        }
        public override void CreteSignature()
        {
            this.Message.Signature = "Gökhan Ertoğan";
        }
    }

    public class EidGreeting : MessageBuilder
    {
        public EidGreeting():base(MessageType.EidGreeting)
        {

        }

        public override void CreteTitle()
        {
            this.Message.Title = "Eid Mübarek :)";
        }
        public override void CreteBody()
        {
            this.Message.Body = "Eid Mübarek :)";
        }
        public override void CreteSignature()
        {
            this.Message.Signature = "Gökhan Ertoğan";
        }
    }

    public class MessageCreater
    {
        private MessageBuilder _messageBuilder;

        public void Create(MessageBuilder messageBuilder)
        {
            _messageBuilder = messageBuilder;
            _messageBuilder.CreteTitle();
            _messageBuilder.CreteBody();
            _messageBuilder.CreteSignature();
        }
        public void Show()
        {
            _messageBuilder.Message.Show();
        }
    }
}
