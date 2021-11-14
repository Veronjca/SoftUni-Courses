using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string  BrokerName { get; set; }
        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock other)
        {
            if (other.MarketCapitalization > 10000 && this.MoneyToInvest >= other.PricePerShare)
            {
                this.Portfolio.Add(other);
                this.MoneyToInvest -= other.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock current = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (current.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            this.Portfolio.Remove(current);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }
        
        public string InvestorInformation()
        {
            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:{Environment.NewLine}{string.Join(Environment.NewLine, this.Portfolio)}";
        }
    }
   
}
