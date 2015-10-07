using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public class CbrtExpr : Expression
    {
        public CbrtExpr() : base()
        {
        }

        public CbrtExpr(float A, float B, float C, float D) : base(A, B, C, D)
        {
        }

        public override string PyExpression()
        {
            ExprString.StrData = (AVertStretch.FloatData.ToString() + "*cbrt(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")+" + DVertShift.FloatData.ToString());
            PlotString.StrData = (AVertStretch.FloatData.ToString() + "*cbrt(abs(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + "))*sign(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")+" + DVertShift.FloatData.ToString());
            return ExprString.StrData;
        }
    }
}
