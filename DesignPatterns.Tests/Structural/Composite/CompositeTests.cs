using DesignPatterns.Structural.Composite.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DesignPatterns.Tests.Structural.Composite
{
    [TestClass]
    public class CompositeTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            HtmlTag htmlTag = new();
            BodyTag bodyTag = new();
            ParagraphTag paragraphTag = new()
            {
                Content = "something"
            };

            bodyTag.Add(paragraphTag);
            htmlTag.Add(bodyTag);

            Assert.AreEqual(1, htmlTag.Children.Count);
            Assert.AreEqual(1, bodyTag.Children.Count);
            Assert.IsInstanceOfType<BodyTag>(htmlTag.Children.First());
            Assert.IsInstanceOfType<ParagraphTag>(bodyTag.Children.First());
        }
    }
}
