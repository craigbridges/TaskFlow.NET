using System;

namespace PredCalc
{
    public interface IUnifiable : IPCExpression
    {
        SubstitutionSet Unify(IUnifiable exp, SubstitutionSet s);
    }
}