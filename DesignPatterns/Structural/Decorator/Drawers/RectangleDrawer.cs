using System;
using System.Drawing;

namespace Sandbox.Decorator.Drawers
{
    public class RectangleDrawer : BaseDrawer
    {
        public override void Draw(Point point, dynamic details)
        {
            int height = details.Height, width = details.Width;
            if (height < 3)
            {
                throw new InvalidOperationException("Can't draw shorter rectangle than 3 units.");
            }
            DrawYSpan(point);

            for (int i = 0; i < height; i++)
            {
                DrawXSpan(point);
                if (i == 0 || i == height - 1)
                {
                    Console.WriteLine(new string('*', width));
                }
                else
                {
                    Console.Write('*');
                    Console.Write(new string(' ', width - 2));
                    Console.WriteLine('*');
                }
            }
        }
    }
}
