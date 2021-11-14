using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentDays = int.Parse(Console.ReadLine());
            

            int counter = 0;
            double totalMoney = 0;
            
            for (int i = 1; i <= tournamentDays; i++)
            {
                string sport = Console.ReadLine();

                double raisedMoneyForTheDay = 0;
                int ifWin = 0;
                int ifLost = 0;

                while (sport != "Finish")
                {
                    string winOrLose = Console.ReadLine();

                    if (winOrLose == "win")
                    {
                        ifWin++;
                        raisedMoneyForTheDay += 20;
                    }
                    else
                    {
                        ifLost++;
                    }

                    sport = Console.ReadLine();
                }

                if (ifWin > ifLost)
                {
                    counter++;
                    raisedMoneyForTheDay *= 1.1;
                }
                totalMoney += raisedMoneyForTheDay;
            }

            if (counter > tournamentDays / 2)
            {
                totalMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
