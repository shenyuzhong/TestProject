using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public class CubeExpr : Expression
    {
        // Stores an object with equation a(bx+c)^2+c
        public CubeExpr() : base()
        {
        }

        public CubeExpr(float A, float B, float C, float D) : base(A, B, C, D)
        {
        }

        public override string PyExpression()
        {
            ExprString.StrData = (AVertStretch.FloatData.ToString() + "*(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")**3+" + DVertShift.FloatData.ToString());
            PlotString.StrData = ExprString.StrData;
            return ExprString.StrData;
        }
    }
}
