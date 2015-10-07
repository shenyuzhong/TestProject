using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public class QuadExpr : Expression
    {
        // Stores an object with equation a(bx+c)^2+c
        public QuadExpr() : base()
        {
        }

        public QuadExpr(float A, float B, float C, float D) : base(A, B, C, D)
        {
        }

        public override string PyExpression()
        {
            ExprString.StrData = (AVertStretch.FloatData.ToString() + "*(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")**2+" + DVertShift.FloatData.ToString());
            PlotString.StrData = ExprString.StrData;
            return ExprString.StrData;
        }
    }
}
