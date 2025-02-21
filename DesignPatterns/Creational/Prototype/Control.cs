using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.Prototype
{
    /// <summary>
    /// Abstractions for UI controls
    /// </summary>
    public abstract class Control : ICloneable
    {
        protected StringBuilder _htmlBuilder;

        public string Name { get; set; }
        public string Id { get; set; }
        public IEnumerable<string> Classes { get; set; }

        public Control()
        {
            _htmlBuilder = new StringBuilder();
        }

        public abstract void Render();

        public virtual string GetHtml()
        {
            return _htmlBuilder.ToString();
        }
        public ICloneable DeepClone()
        {
            ICloneable _cloneable = default;
            foreach (var item in GetType().GetProperties())
            {
                GetType().GetProperty(item.Name)?.SetValue(_cloneable, item.GetValue(this));
            }
            return _cloneable;
        }
        public ICloneable ShallowClone()
        {
            return MemberwiseClone() as ICloneable;
        }
    }
}
