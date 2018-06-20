using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace aero_csharp
{
    class Program
    {
        static int Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            int exitCode = 0;
            StreamWriter output = null;
            try
            {
                output = File.CreateText(Path.Combine(currentDirectory, "result.txt"));

               Input inputs = new Input(Path.Combine(currentDirectory, "input.txt"));

                Calculator calc = new Calculator(inputs);

                output.WriteLine(string.Format("FUSELAGEAREA : {0}", calc.FuselageArea));
                output.WriteLine(string.Format("WETTEDAREA : {0}", calc.WettedArea));
                output.WriteLine(string.Format("LoD : {0}", calc.LoD));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Application error :" + ex.Message);
                exitCode = 1;
            }
            finally
            {
                if (output != null)
                {
                    output.Close();
                }
            }

            return exitCode;
        }
    }
}
