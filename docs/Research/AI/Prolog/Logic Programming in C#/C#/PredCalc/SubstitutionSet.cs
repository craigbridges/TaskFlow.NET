using System;
using System.Collections.Generic;

namespace PredCalc
{
    public class SubstitutionSet
    {
        private Dictionary<IUnifiable, Variable> bindings =
            new Dictionary<IUnifiable, Variable>();

        public SubstitutionSet() { }

        public SubstitutionSet(SubstitutionSet s)
        {
            bindings = new Dictionary<IUnifiable, Variable>();
        }

        public void Clear()
        {
            bindings.Clear();
        }

        public void Add(IUnifiable exp, Variable v)
        {
            bindings.Add(exp, v);
        }

        public IUnifiable GetBinding(Variable v)
        {
            foreach (KeyValuePair<IUnifiable, Variable> uv in bindings)
                if (uv.Value == v)
                    return uv.Key;

            return null;
        }

        public bool IsBound(Variable v)
        {
            return bindings.ContainsValue(v);
        }

        public override string ToString()
        {
            string s = "Bindings:\r\n";

            foreach (KeyValuePair<IUnifiable, Variable> kvp in bindings)
                s += kvp.Key.ToString() + " " + kvp.Value.ToString() + "\r\n";

            return s;
        }
    }
}
