using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string from = "Gökhan Ertoğan";
            string to = "Ertoğan Gökhan";

            IMail standartMail = new GeneralMail(from,to);
            IMail mailWithSign = new SingDecorator(standartMail,"Gökhan Ertoğan");
            IMail mailWithEncrypt = new EncryptDecorator(mailWithSign);

            mailWithEncrypt.Send();
            Console.ReadLine();

        }
    }

    public interface IMail
    {
        void Send();
    }

    public class GeneralMail : IMail
    {
        private string _from;
        private string _to;

        public GeneralMail(string from, string to)
        {
            this._from = from;
            this._to = to;
        }

        public void Send()
        {
            Console.WriteLine("Mail, {0} kişisinden {1} kişisine gidiyor",_from,_to);
        }
    }

    public abstract class Decorator : IMail
    {
        private IMail _mail;

        public Decorator(IMail mail)
        {
            this._mail = mail;
        }

        public virtual void Send()
        {
            _mail.Send();
        }
    }

    public class EncryptDecorator : Decorator
    {
        public EncryptDecorator(IMail mail) : base(mail)
        {
        }
        public override void Send()
        {
            base.Send();
            Console.WriteLine("Encrypted");
        }
    }

    public class SingDecorator : Decorator
    {
        private string _sign;
        public SingDecorator(IMail mail,string sign) : base(mail)
        {
            this._sign = sign;
        }

        public override void Send()
        {
            base.Send();
            Console.WriteLine("Signed by {0}",_sign);
        }
    }
}
