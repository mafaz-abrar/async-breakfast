using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace AsyncBreakfast
{
    // This class handles asynchronous methods and events
    class Kitchen
    {
        // We create a delegate to base our event on.
        // This is a declaration of a delegate type, even though
        // it looks like a variable declaration. The delegate type
        // is just a function signature.
        public delegate void FoodMadeEventHandler(Food food);

        // We declare an event with type FoodMadeEventHandler.
        // We can add event listeners to this event from Main - we 
        // will need an instance of this class first.
        public event FoodMadeEventHandler FoodMade;

        // This method will be the event subscriber. 
        // The signature of the event subscriber must match the 
        // signature of the type of the event to which it is
        // subscribed.
        public void OnFoodMade(Food food)
        {
            Console.WriteLine("We now have a {0}", food.Describe());
        }

        // This asynchronous method ties the other asynchronous tasks together.
        public async Task MakeBreakfast()
        {
            Console.WriteLine("Kitchen ready at {0:HH:mm:ss}.", DateTime.Now);
            DateTime start = DateTime.Now;

            // Fire off the other asynchronous tasks.
            Task friedEggTask = FryEggAsync();
            Task toastedBreadTask = ToastBreadAsync();
            Task madeTeaTask = MakeTeaAsync();

            // This code is performed without waiting for the previous async tasks to finish.
            Console.WriteLine("Began making breakfast at {0:HH:mm:ss}.", DateTime.Now);

            // Use the await keyword:
            // Do not perform the rest of the code until these tasks have been executed.
            await friedEggTask;
            await toastedBreadTask;
            await madeTeaTask;

            // Once the above tasks have been executed (awaits have resolved), do the following:
            Console.WriteLine("Breakfast ready at {0:HH:mm:ss}", DateTime.Now);
            DateTime end = DateTime.Now;

            TimeSpan time = end - start;

            Console.WriteLine("The process took {0} seconds.", Math.Round(time.TotalSeconds));
        }

        private async Task FryEggAsync()
        {
            Console.WriteLine("Frying egg...");
            
            // Don't process the rest of this code
            // until this task is complete.
            await Task.Delay(4000);

            Console.WriteLine("Egg fried.");

            Egg egg = new Egg();

            // Invoke the FoodMade event
            FoodMade(egg);
        }

        private async Task ToastBreadAsync()
        {
            Console.WriteLine("Toasting bread...");

            // Don't process the rest of this code
            // until this task is complete.
            await Task.Delay(2000);

            Console.WriteLine("Bread toasted.");
            
            Bread bread = new Bread();

            // Invoke the FoodMade event
            FoodMade(bread);
        }

        private async Task MakeTeaAsync()
        {
            Console.WriteLine("Making tea...");

            // Don't process the rest of this code
            // until this task is complete.
            await Task.Delay(6000);

            Console.WriteLine("Tea made.");

            Tea tea = new Tea();
            
            // Invoke the FoodMade event
            FoodMade(tea);
        }
    }
}
