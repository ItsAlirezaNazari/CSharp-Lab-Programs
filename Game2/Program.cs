using System;

namespace Game2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int user_score = 0, computer_score = 0, index;
            string computer_choice, user_choice;

            string[] options = new string[3];
            options[0] = "Rock";
            options[1] = "Paper";
            options[2] = "Scissor";

            for (int i = 0; i < 5; i++)
            {
                index = r.Next(0, 3);
                computer_choice = options[index];

                user_choice = Console.ReadLine();
                Console.WriteLine(computer_choice);

                if (computer_choice == "Rock" && user_choice == "Paper")
                {
                    user_score++;
                }
                else if (computer_choice == "Rock" && user_choice == "Scissor")
                {
                    computer_score++;
                }
                else if (computer_choice == "Paper" && user_choice == "Rock")
                {
                    computer_score++;
                }
                else if (computer_choice == "Paper" && user_choice == "Scissor")
                {
                    user_score++;
                }
                else if (computer_choice == "Scissor" && user_choice == "Rock")
                {
                    user_score++;
                }
                else if (computer_choice == "Scissor" && user_choice == "Paper")
                {
                    computer_score++;
                }
            }
            
            if (user_score > computer_score)
            {
                Console.WriteLine("You Win");
            }
            else if (user_score < computer_score)
            {
                Console.WriteLine("Computer Win");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}
