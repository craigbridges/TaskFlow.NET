using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PredCalc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UnifyTester();
        }

        private void UnifyTester()
        {
            Constant friend = new Constant("friend");
            Constant bill = new Constant("bill");
            Constant george = new Constant("george");
            Constant kate = new Constant("kate");
            Constant merry = new Constant("merry");
            Variable X = new Variable("X");
            Variable Y = new Variable("Y");
            List<IUnifiable> expressions = new List<IUnifiable>();
            IUnifiable[] terms = new IUnifiable[2];

            terms[0] = bill;
            terms[1] = george;

            expressions.Add(new SimpleSentence(friend, terms));

            terms[1] = kate;

            expressions.Add(new SimpleSentence(friend, terms));

            terms[1] = merry;

            expressions.Add(new SimpleSentence(friend, terms));

            terms[0] = george;
            terms[1] = bill;

            expressions.Add(new SimpleSentence(friend, terms));

            terms[1] = kate;

            expressions.Add(new SimpleSentence(friend, terms));

            terms[0] = kate;
            terms[1] = merry;

            expressions.Add(new SimpleSentence(friend, terms));

            terms[0] = X;
            terms[1] = Y;

            IUnifiable goal = new SimpleSentence(friend, terms);
            SubstitutionSet s = null;

            textBox1.Text += "Goal: " + goal.ToString() + "\r\n";

            for (int i = 0; i < expressions.Count; i++)
            {
                IUnifiable next = expressions[i];

                s = next.Unify(goal, new SubstitutionSet());
                textBox1.Text += next.ToString() + "\t";

                if (s != null)
                {
                    IPCExpression ipcexp = goal.ReplaceVariables(s);
                    SimpleSentence sent = (SimpleSentence)ipcexp;

                    textBox1.Text += sent.ToString() + "\r\n";
                }

                else
                    textBox1.Text += "False\r\n";
            }

            terms[0] = bill;
            terms[1] = Y;

            goal = new SimpleSentence(friend, terms);
            textBox1.Text += "Goal: " + goal.ToString() + "\r\n";

            for (int i = 0; i < expressions.Count; i++)
            {
                IUnifiable next = expressions[i];

                s = next.Unify(goal, new SubstitutionSet());
                textBox1.Text += next.ToString() + "\t";

                if (s != null)
                {
                    IPCExpression ipcexp = goal.ReplaceVariables(s);

                    textBox1.Text += ipcexp.ToString() + "\r\n";
                }

                else
                    textBox1.Text += "False\r\n";
            }
        }
    }
}