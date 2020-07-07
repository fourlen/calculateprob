using CalcCS.Expressions;
using CalcCS.Parser;
using System;

namespace CalcCS
{
    /// <summary>
    /// Основная программа
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter the mathematical expression containing floating point numbers, operations +, -, *, / or ():\n> ");
            string expr_str = Console.ReadLine();

            Parser.Parser parser = new Parser.Parser(expr_str);

            try
            {
                IExpression expr = parser.Parse();
                Console.WriteLine(expr.Calculate());
            }
            catch (ParserException pex)
            {
                Console.WriteLine("Parser error: " + pex.Message);
            }
            catch (DivideByZeroException dze)
            {
                Console.WriteLine("Calculation error: " + dze.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("Programmer error: " + ioe.Message);
            }
            catch
            {
                Console.WriteLine("Unknown error");
            }

            Console.Write("Press <Enter> key to exit...");
            Console.ReadKey();
        }
    }
}
