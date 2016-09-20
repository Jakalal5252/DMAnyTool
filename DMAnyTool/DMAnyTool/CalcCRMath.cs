using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAnyTool
{
    public  class CalcCRMath
    {
        const double HALF = .5;
        const double THIRD = .33333333333;
        const double FOURTH = .25;
        const double SIXTH = .16666666667;
        const double EIGHTH = .125;
        const double TENTH = .1;

        /// <summary>
        /// Calculates the adjusted party level of a group of players.
        /// </summary>
        /// <param name="partySizeInput">The number of players at a given level in the party.</param>
        /// <param name="partyLevelsInput">The levels of the players in a given party.</param>
        /// <returns>The adjusted party level given the amount and level of the party members.</returns>
        public static string CalculatePartyLevel(string[] partySizeInput, string[] partyLevelsInput)
        {
            double[] partySize = ConvertInputNumbers(partySizeInput);
            double[] partyLevel = ConvertInputNumbers(partyLevelsInput);
            
            double partyEffectiveLevel = PartyEffectiveLevel(partySize, partyLevel);
            

            return partyEffectiveLevel.ToString();
        }   

        public static string CalculateMonsterCR(string[] monsterNumberInput, string[] monsterCRInput)
        {
            double[] monsterNumber = ConvertInputNumbers(monsterNumberInput);
            double[] monsterCR = ConvertInputNumbers(monsterCRInput);

            double monsterEffectiveCR = MonsterEffectiveCR(monsterNumber, monsterCR);
            return monsterEffectiveCR.ToString();
        }

        public static string CalculateDifficulty(string partyLevel, string monsterCR)
        {
            double difference = 2 * (Math.Log(Convert.ToInt32(monsterCR),2) - Math.Log(Convert.ToInt32(partyLevel),2));
             return CaluclateDifficultyPhrase(difference);
        }
        /// <summary>
        /// Converts an array of strings to the proper numerical value
        /// </summary>
        /// <param name="inputlevels">Player or monster levels.</param>
        /// <returns>An array of player or monster levels in numberical form.</returns>
        public static double[] ConvertInputNumbers(string[] inputlevels)
        {
            double d;
            double[] levelArray = new double[inputlevels.Length];
            int index = 0;
            foreach ( string s in inputlevels)
            { 
                d = 0;
                if (s == "1/2")
                { d = HALF; }
                if (s == "1/3")
                { d = THIRD; }
                if (s == "1/4")
                { d = FOURTH; }
                if (s == "1/6")
                { d = SIXTH; }
                if (s == "1/8")
                { d = EIGHTH; }
                if (s == "1/10")
                { d = TENTH; }
                if (d == 0)
                { d = Convert.ToDouble(s); }
                levelArray[index] = d;
                index++;
            }
            return levelArray;
        }

        public static double CRtoPL(double x)
        {
            double level = 0;
            if (x < 2)
            {
                level = x;
            }
            else
            {
                level = Math.Pow(2, (x/2));
            }
            return level;
        }

        public static double PLtoCR(double x)
        {
            double level = 0;
            if (x < 2)
            {
                level = x;
            }
            else
            {
                level = 2 * (Math.Log(x) * Math.Log(Math.E, 2));
            }
            return level;
        }

        public static double PartyEffectiveLevel(double[] partySize, double[] partyLevels)
        {

            double[] partyPower = new double[partySize.Length];
            int i = 0;
            double sum = 0;
            foreach(double d in partyPower)
            {
                partyPower[i] =( partySize[i] * CRtoPL(partyLevels[i]));
                sum += partyPower[i];
                i++;
            }

            double partyTotalPower =(sum / 4);
            return Math.Round(PLtoCR(partyTotalPower));
        }

        public static double MonsterEffectiveCR(double[] monsterNumbers, double[] monsterCRs)
        {

            double[] monsterPower = new double[monsterNumbers.Length];
            int i = 0;
            double sum = 0;
            foreach (double d in monsterPower)
            {
                monsterPower[i] = (monsterNumbers[i] * CRtoPL(monsterCRs[i]));
                sum += monsterPower[i];
                i++;
            }
            return Math.Round(PLtoCR(sum));
        }

        public static string CaluclateDifficultyPhrase(double x)
        {
            string difficulty = "Unknown";
            if (x < -9) difficulty = "Trivial";
            else if (x < -4) difficulty = "Very Easy";
            else if (x < 0) difficulty = "Easy";
            else if (x <= 0) difficulty = "Challenging";
            else if (x <= 4) difficulty = "Very Difficult";
            else if (x <= 7) difficulty = "Overpowering";
            else difficulty = "Unbeatable";
            return difficulty;
        }
    }
}
