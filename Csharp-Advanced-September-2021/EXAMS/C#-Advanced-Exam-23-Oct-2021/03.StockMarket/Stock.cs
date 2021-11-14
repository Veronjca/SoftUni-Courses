using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public decimal marketCapitalization;
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
        }
    
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization 
        {
            get { return this.marketCapitalization = this.PricePerShare * this.TotalNumberOfShares; }
            set
            {
                this.marketCapitalization  = value;
            }
        }

        public override string ToString()
        {
            return $"Company: {this.CompanyName}{Environment.NewLine}Director: {this.Director}{Environment.NewLine}Price per share: ${this.PricePerShare}{Environment.NewLine}Market capitalization: ${this.MarketCapitalization}";
        }
    }
}
