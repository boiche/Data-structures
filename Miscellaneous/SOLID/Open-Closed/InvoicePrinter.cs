namespace Miscellaneous.SOLID.Open_closed.Pattern
{
    internal sealed class InvoicePrinter
    {
        public Invoice Invoice { get; set; }

        public void Print()
        {
            Console.WriteLine("***  Invoice  ***");
            Console.WriteLine($"Total: {Invoice.Total}");
            Console.WriteLine($"Tax Rate: {Invoice.TaxRate}");
        }
    }
}
