using System;


namespace Part_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
          
                GetAppInfo();
                GetInfo();

        }

        static void GetAppInfo()
        {

            string appName = "Present Value Calculator";
            string appVersion = "1.0.0";
            string appAuthor = "Guilherme Eckert";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();

        }

        static void GetInfo()
        {

       
           Console.WriteLine("Please enter initial cash flow (decimal): ");

            string P = Console.ReadLine();
            makesurefloat(input: P);

            Console.WriteLine("Please enter interest rate (decimal): ");
            string R = Console.ReadLine();

            makesurefloat(input: R);

            Console.WriteLine("Please enter growth rate (decimal): ");

            string G = Console.ReadLine();
            makesurefloat(input: G);

            Console.WriteLine("Please period in years (integer) : ");

            string N = Console.ReadLine();
            MakeSureInt(input: N);
           
            Functionality(P, R, G, N);

        }


        static void Functionality(string P, string R, string G, string N)
        {
            int n = int.Parse(N);
            float p = float.Parse(P);
            float r = float.Parse(R) / 100;
            float g = float.Parse(G) / 100;

        
            float total = (p / (r - g)) * (1 - (float)Math.Pow((1 + g) / (1 + r), n));


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Present value : ${0}", total);
            Console.ResetColor();


        }


        static void MakeSureInt(string input )
        {
            bool res;
            int a;
            res = int.TryParse(input, out a);
            Console.WriteLine("String is a numeric representation: " + res);
            if (res == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while calculing present value");
                Console.WriteLine("Please check your input");
                System.Environment.Exit(-1);
            }


        }

        static void makesurefloat(string input)
        {
            bool res;
            float a;
            res = float.TryParse(input, out a);
            if(a == 0 )
            {
                while(true)
                {
                    Console.WriteLine("try again? [Y or N]");

                    //Get answer
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        GetInfo();

                    }
                    else if (answer == "N")
                    {
                        System.Environment.Exit(-1);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Console.WriteLine("String is a numeric representation: " + res);
            if (res == false )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while calculing present value");
                Console.WriteLine("Please check your input");
                System.Environment.Exit(-1);
            }
        }

  

    }
}