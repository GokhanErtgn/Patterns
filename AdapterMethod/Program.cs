using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardReaderAdapter reader = new XBankCardReaderAdapter();
            var result = reader.ReadCardData();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
    public class XBankPOSReader
    {
        public string ReadFromCard()
        {
            return "X bank Pos cihazı çalışıyor";
        }
    }

    public interface ICardReaderAdapter
    {
        string ReadCardData();
    }

    public class XBankCardReaderAdapter : ICardReaderAdapter
    {
        public string ReadCardData()
        {
            XBankPOSReader posReader = new XBankPOSReader();
            return posReader.ReadFromCard();
        }
    }
}
