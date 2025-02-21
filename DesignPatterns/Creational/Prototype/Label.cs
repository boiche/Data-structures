namespace DesignPatterns.Creational.Prototype
{
    public class Label : Control
    {
        public string Text { get; set; }
        public string For { get; set; }

        public Label() : base() { }

        public override void Render()
        {
            _htmlBuilder.Append($"<label for=\"{For}\">{Text}</label>");
        }
    }
}
