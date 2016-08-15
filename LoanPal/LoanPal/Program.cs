﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanPal
{
    class Program
    {
        static void Main(string[] args)
        {

            string firstName;
            string lastName;
            string [] address;
            string purpose;
            int home_value ;
            int creditScore; 

            bot bot = new bot();

            firstName = bot.getFirstName();
            lastName = bot.getLastName(firstName);
            address = bot.getAddress();
            purpose = bot.getPurpose();
            creditScore = bot.getCreditScore();
            home_value = bot. getAmount();
        }
    }

    class bot
    {
        public string [] getAddress(bool welcomeMessage= true)
        {
            string [] address = new string [4];
            if (welcomeMessage)
            {
                Console.WriteLine("Let's get you started!");
                Console.WriteLine("Can I have the address of your Dream house?");
                Console.WriteLine("ex. 699 2nd Street, San Francisco, CA 94107");
            }
            string response = Console.ReadLine();
            string[] words = response.Split(',');

            if (words.Length != 3)
            {
                Console.WriteLine("your address "+response + " has a typo");
                Console.WriteLine("Please use this format. ex. 699 2nd Street, San Francisco, CA 94107");
                words = getAddress(false);
            }
            //format address
            //street
             address[0] = words[0].Trim();
            //city
             address[1] = words[1].Trim();
            //State
             address[2] = words[2].Trim().Substring(0,2);
            //zip
             address[3] = words[2].Trim().Substring(2).Trim();
            try{
                int.Parse(address[3]);
            }
            catch(Exception e)
            {
                Console.WriteLine("your zip  "+address[3] + " has a typo, please type agian");
                address[3] =Console.ReadLine();
            }

            return address;
        }
        public string getFirstName()
        {
            Console.WriteLine("Hello, Welcome to loanpal. What's your first Name?");
            string firstName = Console.ReadLine().Trim();
            return firstName;
        }

        public string getLastName(string firstName)
        {
            Console.WriteLine("Thanks. " + firstName + ". What's your Last Name?");
            string lastName = Console.ReadLine().Trim();
            return lastName;
        }
        public string getPurpose()
        {
            Console.WriteLine("What's the purpose of your loan?");
            string purpose = Console.ReadLine().Trim();
            return purpose;
        }
        public int getAmount()
        {
            int amount = 0;
            Console.WriteLine("Hello, Welcome to loanpal. What's your first Name?");
            try
            {
                string amount_response = Console.ReadLine().Trim();
                amount = int.Parse(amount_response);
            }
            catch(Exception e)
            {
                Console.WriteLine("please enter a valid amount between 0~100000000");
            }
            return amount;
        }
        public int getCreditScore()
        {
            int score = 0;
            Console.WriteLine("Whats your credit score?");
            string score_response = Console.ReadLine().Trim();
            int.Parse(score_response);
            if (score < 0 || score > 860)
            {
                Console.WriteLine("you entered " + score_response + ", Score must be between 0~850");
                score = getCreditScore();
            }

            return score;
        }
    }
}
