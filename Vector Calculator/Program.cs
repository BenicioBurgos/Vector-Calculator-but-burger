using System;

namespace Vector_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string op = "h";
            int dimensions;
            float[] v1;
            float[] v2;

            while (true)
            {
                Console.WriteLine("Vector or Burger?");
                input = InputString(new string[] { "Vector", "Burger" });
                if (input == "Burger")
                {
                    Console.WriteLine("How big?");
                    Burger(InputInt());
                }
                else
                {
                    Console.WriteLine("How many dimensions?");
                    v1 = ConstructVector(dimensions = InputInt());
                    Console.WriteLine(ListToString(v1) + " _");
                    if (dimensions == 2)
                    {
                        Console.WriteLine("+ | - | * | Neg | Mag | Norm | Dot | ABet | Proj | Angle");
                        input = InputString(new string[] { "+", "-", "*", "Neg", "Mag", "Norm", "Dot", "ABet", "Proj", "Angle" });
                    }
                    else if (dimensions != 3)
                    {
                        Console.WriteLine("+ | - | * | Neg | Mag | Norm | Dot | ABet | Proj");
                        input = InputString(new string[] { "+", "-", "*", "Neg", "Mag", "Norm", "Dot", "ABet", "Proj" });
                    }
                    else
                    {
                        Console.WriteLine("+ | - | * | Neg | Mag | Norm | Dot | ABet | Proj | X");
                        input = InputString(new string[] { "+", "-", "*", "Neg", "Mag", "Norm", "Dot", "ABet", "Proj", "X" });
                    }
                    Console.Clear();
                    if (input == "*")
                    {
                        op = input;
                        Console.WriteLine(ListToString(v1) + " " + op + " x");
                        Console.WriteLine("Give x");
                        v2 = new float[] { InputFloat() };
                        Console.Clear();
                        Console.WriteLine(ListToString(v1) + " " + op + " " + v2[0] + " = ");
                        Console.WriteLine(Vector.Scale(v1, v2[0]));
                    }
                    else if (input == "Neg")
                    {
                        Console.WriteLine(Vector.Negate(v1));
                    }
                    else if (input == "Mag")
                    {
                        Console.WriteLine(Vector.GetMagnitude(v1));
                    }
                    else if (input == "Norm")
                    {
                        Console.WriteLine(Vector.Normalize(v1));
                    }
                    else if (input == "Angle")
                    {
                        Console.WriteLine(Vector.GetDirection(v1));
                    }
                    else
                    {
                        op = input;
                        v2 = ConstructVector(dimensions);
                        Console.Clear();
                        Console.WriteLine(ListToString(v1) + " " + op + " " + ListToString(v2) + " = ");
                        if (op == "+")
                        {
                            Console.WriteLine(Vector.Add(v1, v2));
                        }
                        else if (op == "-")
                        {
                            Console.WriteLine(Vector.Subtract(v1, v2));
                        }
                        else if (op == "Dot")
                        {
                            Console.WriteLine(Vector.DotProduct(v1, v2));
                        }
                        else if (op == "ABet")
                        {
                            Console.WriteLine(Vector.AngleBetween(v1, v2));
                        }
                        else if (op == "Proj")
                        {
                            Console.WriteLine(Vector.ProjectOnto(v1, v2));
                        }
                        else
                        {
                            Console.WriteLine(Vector.CrossProduct(v1, v2));
                        }
                    }
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static float[] ConstructVector(int dimensions)
        {
            Console.Clear();
            string temp;
            float[] v = new float[dimensions];
            for (int dimension = 0; dimension < dimensions; dimension++)
            {
                if (dimension == 0)
                {
                    temp = "<_";
                }
                else
                {
                    temp = "<" + v[0];
                }
                for (int d = 1; d < dimensions; d++)
                {
                    if (dimension > d)
                    {
                        temp += ", " + v[d];
                    }
                    else if (dimension < d)
                    {
                        temp += ", ?";
                    }
                    else
                    {
                        temp += ", _";
                    }
                }
                Console.WriteLine(temp += ">");
                Console.WriteLine("Give dimension " + (dimension + 1));
                v[dimension] = InputFloat();
                Console.Clear();
            }
            return v;
        }

        public static float InputFloat()
        {
            string output = "";
            while (!float.TryParse(output, out float h))
            {
                output = Console.ReadLine();
            }
            return float.Parse(output);
        }
        
        public static int InputInt()
        {
            string output = "";
            while (!Int32.TryParse(output, out int h))
            {
                output = Console.ReadLine();
            }
            return Int32.Parse(output);
        }

        public static string InputString(string[] options)
        {
            string output = "";
            bool valid = false;
            while (!valid)
            {
                output = Console.ReadLine();
                for (int o = 0; o < options.Length; o++)
                {
                    if (output == options[o])
                    {
                        valid = true;
                    }
                }
            }
            return output;
        }

        public static string ListToString(float[] v)
        {
            string output = "<" + v[0];
            for (int d = 1; d < v.Length; d++)
            {
                output += ", " + v[d];
            }
            return output + ">";
        }

        private static void Burger(int size)
        {
            Console.Clear();
            Random rnd = new Random();
            int r;
            string[] ingredients = new string[] { "patty", "lettuce", "cheese", "tomato", "onion", "ketchup", "mustard", "mayo", "bacon", "pickle" };
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.White, ConsoleColor.DarkRed, ConsoleColor.DarkGreen };
            Console.WriteLine("Bun");
            for (int s = 0; s < size; s++)
            { 
                System.Threading.Thread.Sleep(50);
                r = rnd.Next(0, ingredients.Length);
                Console.ForegroundColor = colors[r];
                Console.WriteLine(ingredients[r]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bun");
        }
    }
}
