using DesignPatterns.Structural.Decorator.Drawers;
using Sandbox.Decorator.Decorators;
using Sandbox.Decorator.Shapes;
using System.Drawing;

namespace DesignPatterns.Structural.Decorator.Decorators
{
    public class TriangleDecorator : BaseDecorator
    {
        public TriangleDecorator()
        {
            SetDrawer(new TriangleDrawer());
        }
        public override void Draw(Point point, dynamic details)
        {
            // this speecific decorating method is supposed to 'extend' the draw method
            // by adding logic before/after execution of the method 

            base.Draw(point, (Triangle)details);
        }
    }
}
