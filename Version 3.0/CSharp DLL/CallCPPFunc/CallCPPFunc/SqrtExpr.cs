using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public class SqrtExpr : Expression
    {
        public SqrtExpr() : base()
        {
        }

        public SqrtExpr(float A, float B, float C, float D) : base(A, B, C, D)
        {
        }

        public override string PyExpression()
        {
            ExprString.StrData = (AVertStretch.FloatData.ToString() + "*sqrt(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")+" + DVertShift.FloatData.ToString());
            PlotString.StrData = (AVertStretch.FloatData.ToString() + "*(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")**0.5+" + DVertShift.FloatData.ToString());
            return ExprString.StrData;
        }
    }
}
