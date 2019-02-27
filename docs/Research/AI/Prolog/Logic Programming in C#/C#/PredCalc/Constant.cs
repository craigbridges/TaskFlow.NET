using System;

namespace PredCalc
{
    public class Constant : IUnifiable
    {
        private string printName = null;
        private static int nextId = 1;
        private int id;

        public Constant()
        {
            id = nextId++;
        }

        public Constant(string printName)
        {
            id = nextId++;
            this.printName = printName;
        }

        public SubstitutionSet Unify(IUnifiable exp,
            SubstitutionSet s)
        {
            if (this == exp)
                return new SubstitutionSet(s);

            if (exp is Variable)
                return exp.Unify(this, s);

            return null;
        }

        public IPCExpression ReplaceVariables(SubstitutionSet s)
        {
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null ||
                !(obj is Constant))
                return false;

            Constant cons = (Constant)obj;

            return printName.CompareTo(cons.printName) == 0 &&
                id == cons.id;
        }

        public override int GetHashCode()
        {
            return (int)Math.Pow(2, id - 1);
        }

        public override string ToString()
        {
            if (printName != null)
                return printName;

            return "Constant_" + id.ToString();
        }
    }
}