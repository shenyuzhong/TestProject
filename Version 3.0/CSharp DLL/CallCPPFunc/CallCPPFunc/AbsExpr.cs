using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public class AbsExpr  : Expression
    {
        // Stores an object with equation a(bx+c)^2+c
        public AbsExpr() : base()
        {
        }

        public AbsExpr(float A, float B, float C, float D) : base(A, B, C, D)
        {
        }

        public override string PyExpression()
        {
            //ExprString.StrData = (AVertStretch.FloatData.ToString() + "*abs(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")+" + DVertShift.FloatData.ToString());
            ExprString.StrData = (AVertStretch.FloatData.ToString() + "*(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")+" + DVertShift.FloatData.ToString());
            PlotString.StrData = (AVertStretch.FloatData.ToString() + "*abs(" + BHorizStretch.FloatData.ToString() + "*" + Var.StrData + "-" + CHorizShift.FloatData.ToString() + ")+" + DVertShift.FloatData.ToString());
            return ExprString.StrData;
        }
    }
}
