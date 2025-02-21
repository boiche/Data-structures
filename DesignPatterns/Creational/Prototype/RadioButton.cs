namespace DesignPatterns.Creational.Prototype
{
    public class RadioButton : Control
    {
        public bool Checked { get; set; }
        public object Value { get; set; }

        public RadioButton() : base() { }

        public override void Render()
        {
            _htmlBuilder.Append($"<input type=\"radio\" name=\"{Name}\" value=\"{Value}\">{Value}<br>");
        }
    }
}
