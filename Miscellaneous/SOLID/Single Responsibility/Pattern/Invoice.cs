namespace Miscellaneous.SOLID.Single_Responsibility.Pattern
{
    internal sealed class Invoice
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double DiscountRate { get; set; }
        public double TaxRate { get; set; }
        public double Total { get; set; }

        public Invoice(Book book, int quantity, double discountRate, double taxRate)
        {
            this.Book = book;
            this.Quantity = quantity;
            this.DiscountRate = discountRate;
            this.TaxRate = taxRate;
            this.Total = this.CalculateTotal();
        }

        private double CalculateTotal()
        {
            double price = ((Book.Price - Book.Price * DiscountRate) * this.Quantity);

            double priceWithTaxes = price * (1 + TaxRate);

            return priceWithTaxes;
        }
    }
}
