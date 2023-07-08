﻿namespace BankRobbery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string count = GetCount();
            Dictionary<string,string> result =TypeRespondents(int.Parse(count));
            string bankRobbery = FindRobbery(result);
            Console.WriteLine(bankRobbery);
        }

        private static string FindRobbery(Dictionary<string, string> result)
        {
            string robbery = string.Empty;


            Dictionary<string,int> keyValuePairs= new Dictionary<string,int>();

            foreach (var item in result)
            {
                keyValuePairs.Add(item.Key, 0);
            }


            double countOfRespondent = result.Count;


            foreach (var item in result)
            {
                if (keyValuePairs.ContainsKey(item.Value))
                {
                    keyValuePairs[item.Value]++;
                }
            }

            foreach (var item in keyValuePairs)
            {
                if (item.Value > countOfRespondent / 2)
                {
                    robbery= $"{item.Key} - {(item.Value / countOfRespondent) * 100:F2}% vote percent";
                    break;
                }
                robbery = "udentified";
            }

            return $"The robbery is: {robbery}";
        }

        private static Dictionary<string,string> TypeRespondents(int count)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Attention!");
            Console.WriteLine("If the statement of the respondent is that he/she is innocent type [Innocent]");
            Console.WriteLine("Otherwise type his/her statement about who the robbery is");

            Dictionary<string,string> respondentsAndTheirStatements = new Dictionary<string,string>();

            for(int i= 0; i < count;i++)
            {
                Console.Write($"Enter the name of {i+1} respondent: ");
                string name = Console.ReadLine();

                Console.Write($"Enter his/her statement: ");
                string statement = Console.ReadLine();

                respondentsAndTheirStatements.Add(name,statement);
            }

            return respondentsAndTheirStatements;
        }

        private static string GetCount()
        {
            Console.Write("Enter the number of respondents: ");
            string count = Console.ReadLine();
            int num;
            bool check = int.TryParse(count, out num);
            while (!check || num <=0)
            { 
                Console.WriteLine("Invalid number of respondents");
                Console.Write("Enter the number of respondents: ");
                count = Console.ReadLine();
                check = int.TryParse(count, out num);
            }

            return count;
        }
    }
}