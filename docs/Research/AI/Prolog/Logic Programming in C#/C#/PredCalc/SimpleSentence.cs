using System;

namespace PredCalc
{
    public class SimpleSentence : IUnifiable
    {
        IUnifiable[] terms;

        public SimpleSentence(Constant predicateName,
            IUnifiable[] terms)
        {
            this.terms = new IUnifiable[terms.Length + 1];
            this.terms[0] = predicateName;

            for (int i = 0; i < terms.Length; i++)
                this.terms[i + 1] = terms[i];
        }

        public SimpleSentence(IUnifiable[] terms)
        {
            this.terms = terms;
        }

        public SubstitutionSet Unify(IUnifiable p,
            SubstitutionSet s)
        {
            if (p is SimpleSentence)
            {
                SimpleSentence s1 = (SimpleSentence)p;

                if (terms.Length != s1.terms.Length)
                    return null;

                SubstitutionSet sNew = new SubstitutionSet(s);

                for (int i = 0; i < terms.Length; i++)
                {
                    sNew = terms[i].Unify(s1.terms[i], sNew);

                    if (sNew == null)
                        return null;
                }

                return sNew;
            }

            if (p is Variable)
                return p.Unify(this, s);

            return null;
        }

        public IPCExpression ReplaceVariables(SubstitutionSet s)
        {
            IUnifiable[] newTerms = new IUnifiable[terms.Length];

            for (int i = 0; i < terms.Length; i++)
                newTerms[i] = (IUnifiable)terms[i].ReplaceVariables(s);

            return new SimpleSentence(newTerms);
        }

        public override string ToString()
        {
            string s = string.Empty;

            for (int i = 0; i < terms.Length; i++)
            {
                if (s == string.Empty)
                    s = terms[i].ToString();
                else
                    s += " " + terms[i].ToString();

                if (s == string.Empty)
                    return "null";
            }

            return "(" + s + ")";
        }
    }
}