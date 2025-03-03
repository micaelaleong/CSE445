// Name: Micaela Leong
// ASU ID: 1225320759

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 2.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
**/

namespace ConsoleApp1
{
    // delegate declaration for creating events
    public delegate void PriceCutEvent(double roomPrice, Thread agentThread);
    public delegate void OrderProcessEvent(Order order, double orderAmount);
    public delegate void OrderCreationEvent();

    public class MainClass
    {
        public static MultiCellBuffer buffer;
        public static Thread[] travelAgentThreads;
        public static bool hotelThreadRunning = true;
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Inside Main");
            buffer = new MultiCellBuffer();

            Hotel hotel = new Hotel();
            TravelAgent travelAgent = new TravelAgent();

            Thread hotelThread = new Thread(new ThreadStart(hotel.hotelFun));
            hotelThread.Start();

            Hotel.PriceCut += new PriceCutEvent(travelAgent.agentOrder);
            Console.WriteLine("Price cut event has been subscribed");
            TravelAgent.orderCreation += new OrderCreationEvent(hotel.takeOrder);
            Console.WriteLine("Order creation event has been subscribed");
            OrderProcessing.OrderProcess += new OrderProcessEvent(travelAgent.orderProcessConfirm);
            Console.WriteLine("Order process event has been subscribed");

            travelAgentThreads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Creating  travel agent thread {0}", (i + 1));
                travelAgentThreads[i] = new Thread(travelAgent.agentFun);
                travelAgentThreads[i].Name = (i + 1).ToString();
                travelAgentThreads[i].Start();
            }
        }
    }
    public class MultiCellBuffer
    {
        // Each cell can contain an order object
        private const int bufferSize = 3; //buffer size
        int usedCells;
        private Order[] multiCells; // ? mark make the type nullable: allow to assign null value
        public static Semaphore getSemaph;
        public static Semaphore setSemaph;

        public MultiCellBuffer() //constructor 
        {
            usedCells = 0; // initialize usedCells to 0 (nothing has been used yet)
            multiCells = new Order[bufferSize]; // initialize multiCells to be an Order of size bufferSize

            // looked up semaphore documentation for C#
            // https://learn.microsoft.com/en-us/dotnet/api/system.threading.semaphore?view=net-9.0
            getSemaph = new Semaphore(0, bufferSize); // initialize getSemaph to be a new semaphore with initial size 0 and max size bufferSize
            setSemaph = new Semaphore(bufferSize, bufferSize); // initialize setSemaph to be a new semaphore with initial size bufferSize and max size bufferSize

        }

        public void SetOneCell(Order data)
        {
            Console.WriteLine("Setting in buffer cell");
            setSemaph.WaitOne(); // decrements setSemaph count (-1 available cells that can be set)
            // https://stackoverflow.com/questions/70465029/understanding-semaphores-in-c-sharp

            for (int i = 0; i < bufferSize; i++) {
                if (multiCells[i] == null) {
                    multiCells[i] = data; // set cell with given data
                    usedCells++;
                    break;
                }
            }
            getSemaph.Release(); // increments getSemaph count (+1 cells that can be gotten)
            Console.WriteLine("Exit setting in buffer");
        }

        public Order GetOneCell()
        {
            getSemaph.WaitOne(); // decrements getSemaph count (-1 cells that can be gotten)
            Order tempOrder = null; // temporary null Order

            for (int i = 0; i < bufferSize; i++) {
                if (multiCells[i] != null) {
                    multiCells[i] = null; // replace cell's data with null
                    usedCells--;
                    break;
                }
            }

            setSemaph.Release(); // increments setSemaph count (+1 cells that can be set)
            Console.WriteLine("Exit reading buffer");
        }
    }

    public class Order
    {
        // identity of sender of order
        private string senderId;
        // credit card number
        private long cardNo;
        // unit price of room from hotel
        private double unitPrice;
        // quantity of rooms to order
        private int quantity;

        // parametrized constructor
        public Order(string senderId, long cardNo, double unitPrice, int quantity)
        {
            this.senderId = senderId; // set senderId with given argument
            this.cardNo = cardNo; // set cardNo with given argument
            this.unitPrice = unitPrice; // set unitPrice with given argument
            this.quantity = quantity; // set quantity with argument 
        }

        // getter methods; allows for private variables to be accessed
        public string getSenderId()
        {
            return senderId; // returns sender ID
        }

        public long getCardNo()
        {
            return cardNo; // returns card number
        }
        public double getUnitPrice()
        {
            return unitPrice; // returns unit price
        }
        public int getQuantity()
        {
            return quantity; // returns quantity
        }

    }
    public class OrderProcessing
    {
        public static event OrderProcessEvent OrderProcess;
        // method to check for valid credit card number input
        public static bool creditCardCheck(long creditCardNumber)
        {
            if (creditCardNumber >= 5000 && creditCardNumber <= 7000) {
                return true;
            }

            return false;
        }

        // method to calculate the final charge after adding taxes, location charges, etc
        public static double calculateCharge(double unitPrice, int quantity)
        {
            Random rnd = new Random(); 
            double tax = rnd.Next(8, 12) / 100.0; // generates random tax in between 8-12%
            int locationCharge = rnd.Next(20, 81); // generates random location charge in range [20, 80]

            // unitPrice * NoOfTicket + Tax + LocationCharge (given equation)
            double charge = unitPrice * (double)quantity + tax + (double)locationCharge;

            return charge;
        }

        // method to process the order
        public static void ProcessOrder(Order order)
        {
            bool validCard = creditCardCheck(order.getCardNo()); // check that given card is valid

            if (validCard) {
                // calculate total price
                double totalPrice = calculateCharge(order.getUnitPrice(), order.getQuantity());
                // FIX THIS
                OrderProcess(order, totalPrice); // pass OrderProcess with given Order and calculated price
            }            
        }
    }
    public class TravelAgent
    {
        public static event OrderCreationEvent orderCreation;

        public void agentFun()
        {
            Console.WriteLine("Starting travel agent now");
        }
        public void orderProcessConfirm(Order order, double orderAmount)
        {
            // FIX THIS
            Console.WriteLine("Travel Agent " + Thread.CurrentThread.Name + "'s order is confirmed. The amount to be charged is $" + orderAmount);
        }

        private void createOrder(string senderId)
        {
            Console.WriteLine("Inside create order");
            Random rnd = new Random();
            Order order;
            long cardNo = rnd.Next(5000, 7001); // creates random card number in range [5000, 7000]

            order = new Order(senderId, cardNo, price, quantity);
        }
        public void agentOrder(double roomPrice, Thread travelAgent) // Callback from hotel thread
        {
            createOrder(travelAgent.Name);
            orderCreation();
        }
    }
    public class Hotel
    {
        static double currentRoomPrice = 100; // random current agent price
        static int threadNo = 0;
        static int eventCount = 0;
        public static event PriceCutEvent PriceCut;

        public void hotelFun()
        {
            // FIX THIS
            int priceCuts = 0;
            while (priceCuts < 10)
            {
                double newRoomPrice = pricingModel();
                if (newRoomPrice < currentRoomPrice)
                {
                    PriceCut.Invoke(newRoomPrice, Thread.CurrentThread);
                    priceCuts++;
                }
                updatePrice(newRoomPrice); // call updatePrice function
            }
        }

        // using random method to generate random room prices
        public double pricingModel()
        {
            Random rnd = new Random(); 
            double price = rnd.Next(80, 161); // generates random price in the range [80, 160]
            Console.WriteLine("New price is " + price.ToString());
            return price;
        }

        public void updatePrice(double newRoomPrice)
        {
            currentRoomPrice = newRoomPrice; // updates currentRoomPrice variable to given new price
            Console.WriteLine("Updating the price and calling price cut event");
        }

        public void takeOrder() // callback from travel agent
        {
            // add your implementation here
        }
    }
}
