using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public class Plot
    {
        public Plot()
        {
            // Set default expression to x**2 and default variable to x
            Expr = new ManagedString("x**2");
            Var = new ManagedString("x");

            // Set default plot color to red
            RPlotColor = new ManagedFloat(1f);
            GPlotColor = new ManagedFloat(0f);
            BPlotColor = new ManagedFloat(0f);

            // Set default line width to 2
            LineWidth = new ManagedFloat(2f);

            // Set default values for variable parameters
            XStart = new ManagedFloat(-10f);
            XStop = new ManagedFloat(10f);
            XStep = new ManagedFloat(0.1f);
        }

        public ManagedString Expr, Var;

        public ManagedFloat RPlotColor, GPlotColor, BPlotColor;
        
        public void SetPlotColor(float RColor, float GColor, float BColor)
        {
            RPlotColor.FloatData = RColor;
            GPlotColor.FloatData = GColor;
            BPlotColor.FloatData = BColor;
        }

        public ManagedFloat LineWidth;

        public ManagedFloat XStart, XStop, XStep;
        
    }
}
