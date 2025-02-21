using System;
using System.Drawing;

namespace Sandbox.Decorator.Drawers
{
    public class CircleDrawer : BaseDrawer
    {
        public override void Draw(Point point, dynamic details)
        {
            double radius = details.Radius;
            DrawYSpan(point);

            double rIn = radius - 0.4, rOut = radius + 0.4;
            for (double i = radius; i >= -radius; --i)
            {
                DrawXSpan(point);
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + i * i;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
