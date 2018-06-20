using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace aero_csharp
{
    class Input
    {
        public double WingArea { get; private set; }
        public double WingSpan { get; private set; }
        public double FuselageLength { get; private set; }
        public double FuselageDiameter { get; private set; }

        public Input(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            string[] lines = File.ReadAllLines(filePath);

            this.ReadInputs(lines);
        }

        private void ReadInputs(string[] lines)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            foreach (var item in lines)
            {
                if(item.Trim().StartsWith("#"))
                {
                    continue;
                }

                string[] splitedValues = item.Split('=');

                if (splitedValues.Length > 1)
                {
                    double result = 0.0;
                    if(Double.TryParse(splitedValues[1], out result))
                    {
                        dict.Add(splitedValues[0].Trim().ToUpperInvariant(), result);
                    }
                }
            }

            this.WingArea = dict["WINGAREA"];
            this.WingSpan = dict["WINGSPAN"];
            this.FuselageLength = dict["FUSELAGELENGTH"];
            this.FuselageDiameter = dict["FUSELAGEDIAMETER"];
        }
    }
}
