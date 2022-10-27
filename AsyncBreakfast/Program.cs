using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Began making breakfast.");

            Egg friedEgg = FryEgg();
            Bread toastedBread = ToastBread();
            Tea madeTea = MakeTea();

            Console.WriteLine("Breakfast ready!");
        }


        private static Egg FryEgg()
        {
            Console.WriteLine("Frying egg..");
            Task.Delay(2000).Wait();
            Console.WriteLine("Egg fried.");
            Egg egg = new Egg();
            return egg;
        }

        private static Bread ToastBread()
        {
            Console.WriteLine("Toasting bread..");
            Task.Delay(2000).Wait();
            Console.WriteLine("Bread toasted.");
            Bread bread = new Bread();
            return bread;
        }
        
        private static Tea MakeTea()
        {
            Console.WriteLine("Making tea...");
            Task.Delay(2000).Wait();
            Console.WriteLine("Tea made.");

            Tea tea = new Tea();
            return tea;
        }
    }
}
