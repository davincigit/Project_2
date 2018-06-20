using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aero_csharp
{
    class Calculator
    {
        public double AspectRatio { get; private set; }
        public double FuselageArea { get; private set; }
        public double WettedArea { get; private set; }
        public double LoD { get; private set; }

        private Input inputs;

        public Calculator(Input inputs)
        {
            this.inputs = inputs;

            this.CalculateAspectRatio();
            this.CalculateFuselageArea();
            this.CalculateWettedArea();
            this.CalculateLoD();
        }

        private void CalculateLoD()
        {
            this.LoD = 10.0 + 4 * (this.AspectRatio / (this.WettedArea / this.inputs.WingArea) - 1.0);
        }

        private void CalculateWettedArea()
        {
            this.WettedArea = this.FuselageArea + 2 * this.inputs.WingArea - 2 * this.inputs.FuselageDiameter * (this.inputs.WingArea / this.inputs.WingSpan) + 4 * (1.25 * this.inputs.FuselageDiameter) * (0.125 * this.inputs.FuselageLength) + 2 * (1.5 * this.inputs.FuselageDiameter) * (0.15 * this.inputs.FuselageDiameter);
        }

        private void CalculateFuselageArea()
        {
            this.FuselageArea = (Math.PI * (this.inputs.FuselageDiameter * 0.6 * this.inputs.FuselageLength) + Math.PI * (Math.Pow((this.inputs.FuselageDiameter / 2), 2)) * 0.4 * this.inputs.FuselageLength) / 3 + Math.PI * (Math.Pow((this.inputs.FuselageDiameter / 2), 2));
        }

        private void CalculateAspectRatio()
        {
            this.AspectRatio = Math.Pow(this.inputs.WingSpan, 2) / this.inputs.WingArea;
        }
    }
}
