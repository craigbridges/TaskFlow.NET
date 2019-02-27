using System;

namespace PredCalc
{
    public interface IPCExpression
    {
        IPCExpression ReplaceVariables(SubstitutionSet s);
    }
}