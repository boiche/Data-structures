using System.Drawing;

namespace Sandbox.Decorator.Drawers
{
    public interface IDrawer
    {
        void Draw(Point point, dynamic details);
    }
}
