using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoTypeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Car prototip = new Car();
            prototip.CarName = "Alfa Romeo MİTO GTA";
            prototip.TopSpeed = 280;
            prototip.Dominance = 1200;
            prototip.Nitro = 35;

            Car clone1 = (Car)prototip.Clone();
            clone1.CarName = "Mini Cooper S Roadster";

            Car clone2 = (Car)prototip.Clone();
            clone2.CarName = "Scion FR-S";

            Car clone3 = (Car)prototip.Clone();
            clone3.CarName = "Cadillac ATS";

            Car clone4 = (Car)prototip.Clone();
            clone4.CarName = "Cadillac XTS";

            Car clone5 = (Car)prototip.Clone();
            clone5.CarName = "Tesla Model S";


            RaceCars racers = new RaceCars
            {
                clone1,
                clone2,
                clone3,
                clone4,
                clone5
            };

            racers.Race();

            Console.Read();
        }
    }

    public class Car:ICloneable
    {
        public double Acceleration { get; set; }
        public double TopSpeed { get; set; }
        public double Dominance { get; set; }
        public double Nitro { get; set; }
        public string CarName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class RaceCars : List<Car>
    {
        public void Race()
        {
            foreach (var item in this)
            {
                Console.WriteLine("Arabanın Adı:{0} En Üst Hızı: {1}",item.CarName,item.TopSpeed);
            }
        }
            
    }
}
