using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Structural.Composite.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.Behavioral.Visitor
{
    [TestClass]
    public partial class VisitorTests
    {
        [TestMethod]
        public void GeneratesDocument_Successfully()
        {
            const string testContent = "This is HTML paragraph";
            HtmlStringifyVisitor visitor = new();
            HtmlTag htmlTag = new();
            BodyTag bodyTag = new();
            ParagraphTag paragraphTag = new()
            {
                Content = testContent
            };

            bodyTag.Add(paragraphTag);
            htmlTag.Add(bodyTag);

            visitor.Visit(htmlTag);

            Assert.IsNotNull(visitor.Result);
            Assert.IsTrue(visitor.Result.Contains("<p>"));
            Assert.IsTrue(visitor.Result.Contains(testContent));
            Assert.IsTrue(visitor.Result.StartsWith(htmlTag.OpenTag));
            Assert.IsTrue(visitor.Result.EndsWith(htmlTag.CloseTag));
        }
    }
}
