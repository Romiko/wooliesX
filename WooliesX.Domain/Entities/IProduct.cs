namespace WooliesX.Domain.Entities
{
    public interface IProduct
    {
        string Name { get; set; }
        double? Price { get; set; }
        double? Quantity { get; set; }
    }
}