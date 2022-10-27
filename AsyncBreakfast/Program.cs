using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        // We need to make main async so that we can 
        // await something in its body.

        // When a method is async, the method will not wait for the completion
        // of any tasks in its body. It will start the tasks, then move on with the
        // rest of the code. If we need to use a return value from that task however,
        // the function will wait until the task completes and then use that value.

        // We can extract the return value of a task e.g. friedEggTask via
        // friedEggTask.Result, which will make the method wait until the task completes.

        // We can also wait for a task to complete by using the await keyword, e.g.
        // 'await friedEggTask' will make the method wait until the task completes.
        static async Task Main(string[] args)
        {
            // Create a kitchen class - this has all our async methods
            Kitchen kitchen = new Kitchen();

            // OnFoodMade will now be subscribed to the event FoodMade. OnFoodMade
            // can be referred to as an event handler; this method is called 
            // whenever the FoodMade event is invoked.
            kitchen.FoodMade += kitchen.OnFoodMade;

            // Start the MakeBreafast task
            Task makeBreakfastTask = kitchen.MakeBreakfast();
            
            // UI Thread: We will do this next commit
            //TalkToUser();
             
            // Wait until MakeBreakfast is completed 
            await makeBreakfastTask;
        }

        private static void TalkToUser()
        {
            Console.WriteLine("Computer: So, how has your day been?");
            Console.ReadLine();
            Console.WriteLine("Computer: Good, good. And how about your family? They okay?");
            Console.ReadLine();
            Console.WriteLine("Computer: That's lovely to hear.");
        }
    }
}
