using Priority_Queue;

namespace FinalProject
{
    public class CustomerDatabase
    {
        /*  
         *  Set up the customer database. Cusomers will be stored in a priority queue database.
         *  The queue position will be based on the customers "Loyalty Level" - Platinum customers
         *  will receive priority service and customer discounts. The database will be loaded with
         *  five initial "known" customers. Other customers can be added via the GUI.
         */

        // nextCustomerNumber holds the value of the next unique number to give
        // to the next customer
        UniqueCustomerNumber nextCustomerNumber = new UniqueCustomerNumber();

        // Create the priority customer queue used to store customers in priority order
        public SimplePriorityQueue<Customer> customerQueue { get; private set; }

        // CustomerDatabase constructor. The constructor will create five initial customers
        // and add them to the priority queue
        public CustomerDatabase()
        {
            // Create the customer priority queue
            customerQueue = new SimplePriorityQueue<Customer>();

            // Create the known customer objects and store them in the priority queue
            Customer newCustomer = new Customer() { TotalAmountSpent = 1221.05, CustomerNumber = nextCustomerNumber.CustomerNumber, CustomerName = "Anna Smith", CustomerLocation = "Georgia" };
            customerQueue.Enqueue(newCustomer, (int)newCustomer.LoyaltyLevel);
            newCustomer = new Customer() { TotalAmountSpent = 7248.35, CustomerNumber = nextCustomerNumber.CustomerNumber, CustomerName = "Barney Johnson", CustomerLocation = "Tennesse" };
            customerQueue.Enqueue(newCustomer, (int)newCustomer.LoyaltyLevel);
            newCustomer = new Customer() { TotalAmountSpent = 843.25, CustomerNumber = nextCustomerNumber.CustomerNumber, CustomerName = "Charlie West", CustomerLocation = "New York" };
            customerQueue.Enqueue(newCustomer, (int)newCustomer.LoyaltyLevel);
            newCustomer = new Customer() { TotalAmountSpent = 8974.92, CustomerNumber = nextCustomerNumber.CustomerNumber, CustomerName = "Dana Winslow", CustomerLocation = "Texas" };
            customerQueue.Enqueue(newCustomer, (int)newCustomer.LoyaltyLevel);
            newCustomer = new Customer() { TotalAmountSpent = 4948.01, CustomerNumber = nextCustomerNumber.CustomerNumber, CustomerName = "Ethan White", CustomerLocation = "Alabama" };
            customerQueue.Enqueue(newCustomer, (int)newCustomer.LoyaltyLevel);
        } 
        
        // Method to add more customers to the priority queue  
        public void AddCustomer(double spent, string name, string location)
        {
            Customer newCustomer = new Customer
            {
                TotalAmountSpent = spent,
                CustomerNumber = nextCustomerNumber.CustomerNumber,
                CustomerName = name,
                CustomerLocation = location
        };
        customerQueue.Enqueue(newCustomer, (int)newCustomer.LoyaltyLevel);
        }

        // Method to return the highest priority customer from the queue
        public Customer ReturnCustomer()
        {
            if ((customerQueue.Count > 0) && (customerQueue.TryDequeue(out Customer nextCustomer)))
            {
                return nextCustomer;
            }
            return null;
        }
    } // CustomerDatabase class
}
