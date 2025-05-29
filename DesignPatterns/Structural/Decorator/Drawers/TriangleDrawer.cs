using Sandbox.Decorator.Drawers;
using System;
using System.Drawing;

namespace DesignPatterns.Structural.Decorator.Drawers
{
    public class TriangleDrawer : BaseDrawer
    {
        public override void Draw(Point point, dynamic details)
        {
            int height = details.Height, width = details.Width;
            DrawYSpan(point);
            int outerSpan = width / 2, innerSpan = 0;

            for (int i = 0; i < height; i++)
            {
                DrawXSpan(point);

                if (i == height - 1)
                {
                    Console.WriteLine($"{new string(' ', outerSpan)}{new string('*', width)}");
                    break;
                }
                else if (i == 0)
                {
                    if (width % 2 == 0)
                    {
                        Console.WriteLine($"{new string(' ', outerSpan)}**");
                        innerSpan += 2;
                    }
                    else
                    {
                        Console.WriteLine($"{new string(' ', outerSpan)}*");
                        innerSpan++;
                    }

                    outerSpan--;

                }
                else
                {
                    Console.Write(new string(' ', outerSpan));
                    Console.Write('*');
                    Console.Write(new string(' ', innerSpan));
                    Console.WriteLine('*');
                    outerSpan--;
                    innerSpan += 2;
                }
            }
        }
    }
}
