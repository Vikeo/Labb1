using System;

namespace Labb1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Be användare mata in en sträng
            Console.WriteLine("Skriv en längre sträng slumpade siffror och kanske några bokstäver om du vill lyxa till det:");
            string input = Console.ReadLine();

            //Om användaren har matat in en tom sträng.
            if (input == "")
            {
                //Medans input är tom, be användaren om en sträng.
                while (input == "")
                {
                    Console.WriteLine("Strängen är tom, vänligen försök igen:");
                    input = Console.ReadLine();
                }
            }

            //Resna innan applikationen gör sitt så att det blir för kluttrigt.
            Console.Clear();

            Console.WriteLine("Dessa delsträngar som börjar och slutar på samma siffra hittades i din sträng:");

            //Variablar som behöver vara utanför while-loopen.
            int startIndex = 0;
            int endIndex = 0;

            int isNumber1 = 0;
            int isNumber2 = 0;
            int isNumber3 = 0;

            bool letterInSubstring = false;

            int loopCounter = 0;

            double total = 0;
            int numberOfSubstring = 0;

            //While loop medans loopCounter är mindre eller lika med än längden av den inmatade strängen.
            while (loopCounter <= input.Length)
            {

                //För varje tecken i strängen, kolla om det är en siffra.
                for (int i = loopCounter; i < input.Length;)
                {

                    //Om det är en siffra, lagra dess index-värde och gå ur loopen.
                    if (int.TryParse(input[i] + "", out isNumber1))
                    {
                        startIndex = input.IndexOf(input[i], i);
                        break;
                    }
                    else
                    {
                        //Om det inte är en siffra, gå ur for-loopen.
                        break;
                    }
                }

                //För varje tecken i strängen efter den första siffran
                for (int j = startIndex + 1; j < input.Length; j++)
                {

                    //Om det är en siffra
                    if (int.TryParse(input[j] + "", out isNumber2))
                    {

                        //Om det är samma siffra som den första siffran, lagra dess index-värde
                        //och gå ur loopen.
                        if (isNumber1 == isNumber2)
                        {
                            endIndex = input.IndexOf(input[j], j);
                            break;
                        }
                    }
                }

                //Om endIndex är lägre än startIndex.
                if (endIndex < startIndex)
                {
                    endIndex = startIndex;
                }

                //Deklarera en delsträng av 'input' med hjälp av index-värdena
                //och lagra den.
                string subInput = input.Substring(startIndex, endIndex - startIndex + 1);

                //För varje tecken i delsträngen, kolla om det är en siffra.
                for (int k = 0; k < subInput.Length; k++)
                {
                    //Om det är en siffra, fortsätt.
                    if (int.TryParse(subInput[k] + "", out isNumber3))
                    {
                        letterInSubstring = false;
                        continue;
                    }

                    //Om det är en icke-siffra i delsträngen, börja om från början av koden.
                    else
                    {
                        letterInSubstring = true;
                        break;
                    }
                }

                //Om delsträngen är tom.
                if (subInput == "")
                {
                    //Ingenting, bara fortsätt.
                }

                //Om delsträngen har en icke-siffra i sig, börja om.
                else if (letterInSubstring == true)
                {
                    //Ingenting, bara fortsätt.
                }

                else if (letterInSubstring == false)
                {

                    int temp1 = subInput[0];
                    int temp2 = subInput[subInput.Length - 1];

                    //Om delsträngens första och sista sista är samma och har samma index.
                    if (startIndex == endIndex && temp1 == temp2)
                    {
                        //Ingenting, bara fortsätt.
                    }

                    //Om delsträngen bara är siffror, skriv ut.
                    else if (temp1 == temp2)
                    {
                        int suffixLength = 0;
                        int prefixLength = startIndex;

                        //Tar reda på hur mycket av den originella strängen ska skrivas innan och efter desträngen
                        for (int k = 0; k < input.Length; k++)
                        {
                            suffixLength++;
                            if (endIndex - startIndex + prefixLength + suffixLength == input.Length)
                            {
                                break;
                            }
                        }
                        string prefix = input.Substring(startIndex - startIndex, startIndex);
                        string suffix = input.Substring(endIndex + 1, suffixLength - 1);
                        subInput = input.Substring(startIndex, endIndex - startIndex + 1);

                        //Skriver ut delsträngen med prefix och suffix
                        Console.Write(prefix);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(subInput);
                        Console.ResetColor();
                        Console.WriteLine(suffix);

                        //Tolka delsträngen som en double och lägg till det på total.
                        total += double.Parse(subInput);

                        //Har koll på hur många gånger delsträngar har skrivits ut.
                        numberOfSubstring++;
                    }

                    //Om första siffran och sista siffran i delsträngen inte är lika.
                    else if (temp1 != temp2)
                    {
                        //Ingenting, bara fortsätt.
                    }
                }

                //Lägger till 1 på loopCounter varje loop.
                loopCounter++;

                //Om loopCounter är lika stor som längden av input-strängen, avsluta.
                if (loopCounter == input.Length)
                {
                    //Om inga delsträngar har skrivits ut.
                    if (numberOfSubstring == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Oops! Det hittades {numberOfSubstring} delsträngar i strängen.");
                        break;
                    }
                    //Om delsträngar har skrivits ut.
                    else
                    {
                        Console.WriteLine($"Totala summan av alla {numberOfSubstring} delsträngar adderade är {total}");
                        break;
                    }

                }
            }
        }
    }
}
