using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Began making breakfast at {0:HH:mm:ss}.", DateTime.Now);
            DateTime start = DateTime.Now;

            Task<Egg> friedEggTask = FryEggAsync();
            Task<Bread> toastedBreadTask = ToastBreadAsync();
            Task<Tea> madeTeaTask = MakeTeaAsync();

            Egg friedEgg = await friedEggTask;
            Console.WriteLine("We now have {0}", friedEgg.Describe());

            Bread toastedBread = await toastedBreadTask;
            Console.WriteLine("We now have {0}", toastedBread.Describe());

            Tea madeTea = await madeTeaTask;
            Console.WriteLine("We now have {0}", madeTea.Describe());

            Console.WriteLine("Breakfast ready at {0:HH:mm:ss}", DateTime.Now);
            DateTime end = DateTime.Now;

            TimeSpan time = end - start;

            Console.WriteLine("The process took {0} seconds.", Math.Round(time.TotalSeconds));
        }

        // Changing the signature to async, returning Task
        private static async Task<Egg> FryEggAsync()
        {
            Console.WriteLine("Frying egg..");

            // Awaiting a task
            await Task.Delay(4000);

            Console.WriteLine("Egg fried.");
            
            Egg egg = new Egg();
            return egg;
        }

        private static async Task<Bread> ToastBreadAsync()
        {
            Console.WriteLine("Toasting bread..");

            await Task.Delay(2000);

            Console.WriteLine("Bread toasted.");
            Bread bread = new Bread();
            return bread;
        }
        
        private static async Task<Tea> MakeTeaAsync()
        {
            Console.WriteLine("Making tea...");

            await Task.Delay(6000);

            Console.WriteLine("Tea made.");

            Tea tea = new Tea();
            return tea;
        }
    }
}
