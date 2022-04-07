using System;

namespace Game2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int computer1_score = 0, computer2_score = 0, user_score = 0, index1, index2;
            string computer1_choice, computer2_choice, user_choice;

            string[] options = new string[2];
            options[0] = "Front";
            options[1] = "Back";

            while(true)
            {
                index1 = r.Next(0, 2);
                index2 = r.Next(0, 2);
                computer1_choice = options[index1];
                computer2_choice = options[index2];

                user_choice = Console.ReadLine();
                Console.WriteLine("computer1: {0:X}", computer1_choice);
                Console.WriteLine("computer2: {0:X}", computer2_choice);

                if (computer1_choice == computer2_choice && user_choice != computer1_choice)
                {
                    user_score++;
                }
                else if (computer1_choice == user_choice && computer2_choice != computer1_choice)
                {
                    computer2_score++;
                }
                else if (computer2_choice == user_choice && computer1_choice != computer2_choice)
                {
                    computer1_score++;
                }
                
                Console.WriteLine("computer1: {0:X}, computer2: {1:Y}, user: {2:Z}", 
                                    Convert.ToString(computer1_score),
                                    Convert.ToString(computer2_score),
                                    Convert.ToString(user_score));

                if (user_score == 5)
                {
                    Console.WriteLine("You Win");
                    break;
                }
                else if (computer1_score == 5)
                {
                    Console.WriteLine("Computer1 Win");
                    break;
                }
                else if (computer2_score == 5)
                {
                    Console.WriteLine("Computer2 Win");
                    break;
                }
            }
            
            Console.WriteLine("The End");
        }
    }
}
