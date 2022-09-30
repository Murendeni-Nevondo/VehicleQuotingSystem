namespace VehicleQuotingSystem.ViewModels
{
    public class SearchQuoteViewModel
    {
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public int Year { get; set; }

        public List<QuoteVm> Quotes { get; set; }
    }
}
