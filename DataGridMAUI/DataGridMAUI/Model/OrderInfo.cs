using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridMAUI
{
    public class OrderInfo : INotifyPropertyChanged
    {
        private int orderID;
        private bool isClosed;
        private Image image;
        private string customerID;
        private string customer;
        private string shipCountry;
        private DateTime date;

        public DateTime OrderDate
        {
            get { return date; } set { date = value; }
        }

        public int OrderID
        {
            get { return orderID; }
            set
            {
                this.orderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        public string CustomerID
        {
            get { return customerID; }
            set
            {
                this.customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        public string Customer
        {
            get { return this.customer; }
            set
            {
                this.customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        public string Country
        {
            get { return this.shipCountry; }
            set
            {
                this.shipCountry = value;
                RaisePropertyChanged("Country");
            }
        }

        public string Customers
        {
            get { return this.customer; }
            set
            {
                this.customer = value;
                RaisePropertyChanged("Customers");
            }
        }


        public OrderInfo(int orderId, string customerId, string country, string customer)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.Customer = customer;
            this.Country = country;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
