namespace FinalProject
{
    // Create an enumeration for customer loyalty level. Platinum is the 
    // highest priority, Silver is the lowest
    public enum Customer_Loyalty_Level
    {
        PLATINUM,
        GOLD,
        SILVER        
    }

    // The Customer class holds all data and methods necessary to define and manipulate
    // customer data. 
    public class Customer
    {
        // Customer is at Silver Level from $0 to $2,500
        const double SILVER_LEVEL = 2500.00;
        // Customer is at Gold Level from $2,501 to $7,500
        const double GOLD_LEVEL = 7500.00;
        // Customer is at Platinum Level when above $7,500

        // Store the total amount the customer has spent at this company
        private double totalAmountSpent;
        // Store the unique customer number 
        public int CustomerNumber { get; set; }
        // Store the customer name
        public string CustomerName { get; set; }
        // Store the state where the custoemr lives 
        public string CustomerLocation { get; set; }
        // Store the customer loyalty level (silver, gold, platinum)
        public Customer_Loyalty_Level LoyaltyLevel { get; set; }
        // totalAmountSpent accessor method - based on the amount set for totalAmountSpent,
        // set the customer LoyaltyLevel
        public double TotalAmountSpent
        {
            get { return totalAmountSpent; }
            set 
            { 
                totalAmountSpent = value;
                if (totalAmountSpent <= SILVER_LEVEL)
                {
                   LoyaltyLevel = Customer_Loyalty_Level.SILVER;
                }
                else if(totalAmountSpent <= GOLD_LEVEL)
                {
                    LoyaltyLevel = Customer_Loyalty_Level.GOLD;
                }
                else
                {
                    LoyaltyLevel = Customer_Loyalty_Level.PLATINUM;
                }
            }
        }

        // Deafult Customer Constructor
        public Customer()
        {
            TotalAmountSpent = 0.00;
            CustomerNumber = -1;
            CustomerName = "N/A";
            CustomerLocation = "N/A";
        }

        // Customer Constructor
        public Customer(double spent, int number, string name, string location)
        {
            TotalAmountSpent = spent;
            CustomerNumber = number;
            CustomerName = name;
            CustomerLocation = location;
        }
    }

    // This class is responsible for assigning unique customer numbers to new
    // customers
    public class UniqueCustomerNumber()
    {
        // Start customer numbers at 1000
        private int customerNumber = 1000;

        // CustomerNumber accessor method - increment customer number by one
        // and return that value. This will be the value used as the unique
        // customer number
        public int CustomerNumber
        {
            get
            {
                customerNumber++;
                return customerNumber;
            }
        }
    }
}

