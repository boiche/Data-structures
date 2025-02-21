using System;
using System.Drawing;

namespace Sandbox.Decorator.Drawers
{
    public abstract class BaseDrawer
    {
        public abstract void Draw(Point point, dynamic details);
        protected void DrawYSpan(Point point)
        {
            for (int i = 0; i < point.Y; i++)
            {
                Console.WriteLine();
            }
        }

        protected void DrawXSpan(Point point)
        {
            for (int span = 0; span < point.X; span++)
            {
                Console.Write(" ");
            }
        }
    }
}
