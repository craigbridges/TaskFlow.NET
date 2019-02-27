using System;

namespace PredCalc
{
    public class Variable : IUnifiable
    {
        private string printName = null;
        private static int nextId = 1;
        private int id;

        public Variable()
        {
            id = nextId++;
        }

        public Variable(string printName)
        {
            id = nextId++;
            this.printName = printName;
        }

        public SubstitutionSet Unify(IUnifiable p,
            SubstitutionSet s)
        {
            if (this == p)
                return s;

            if (s.IsBound(this))
                return s.GetBinding(this).Unify(p, s);

            SubstitutionSet sNew = new SubstitutionSet(s);

            sNew.Add(p, this);

            return sNew;
        }

        public IPCExpression ReplaceVariables(SubstitutionSet s)
        {
            if (s.IsBound(this))
                return s.GetBinding(this).ReplaceVariables(s);
            else
                return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null ||
                !(obj is Constant))
                return false;

            Variable vary = (Variable)obj;

            return printName.CompareTo(vary.printName) == 0 &&
                id == vary.id;
        }

        public override int GetHashCode()
        {
            return (int)Math.Pow(2, id - 1);
        }

        public override string ToString()
        {
            if (printName != null)
                return printName;

            return "V" + id.ToString();
        }
    }
}