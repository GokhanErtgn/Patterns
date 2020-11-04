using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightMethod
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Baloon
    {
        public Brush Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Baloon(Color color)
        {
            SolidBrush solidBrush = new SolidBrush(color);
            this.Color = solidBrush;
        }

        public void Draw(Graphics graph)
        {
            graph.FillEllipse(Color, X, Y, Radius, Radius);
        }
    }

    public static class FlyweightBaloon
    {
        private static Dictionary<Color, Baloon> baloons = new Dictionary<Color, Baloon>();

        public static Baloon CreateBaloon(Color color)
        {
            if (!baloons.ContainsKey(color))
            {
                Baloon baloon = new Baloon(color);
                baloons.Add(color,baloon);
            }

            return baloons[color];
        }
    }
}
