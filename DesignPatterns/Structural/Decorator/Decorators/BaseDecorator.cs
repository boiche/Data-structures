using Sandbox.Decorator.Drawers;
using System.Drawing;

namespace Sandbox.Decorator.Decorators
{
    public abstract class BaseDecorator : BaseDrawer
    {
        // a reference to the initial drawers
        private BaseDrawer _drawer;

        public void SetDrawer(BaseDrawer drawer) => this._drawer = drawer;
        public override void Draw(Point point, dynamic details)
        {
            if (_drawer != null)
            {
                _drawer.Draw(point, details);
            }
        }
    }
}
