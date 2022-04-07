using System;

namespace Game1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            int computer_number = r.Next(0, 100);
            int user_number;
            int count = 0;

            while (true)
            {
                user_number = Convert.ToInt32(Console.ReadLine());
                count++;

                if (computer_number == user_number)
                {
                    Console.WriteLine("You Win");
                    Console.WriteLine(count);
                    break;
                }
                else if (computer_number > user_number)
                {
                    Console.WriteLine("Go Up");
                }
                else if (computer_number < user_number)
                {
                    Console.WriteLine("Go Down");
                }
            }

            Console.WriteLine("The End");
            
        }
    }
}
