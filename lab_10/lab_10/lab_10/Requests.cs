using System;
using System.Collections.Generic;
using System.Text;

using lab_10_library;

namespace lab_10
{
    internal class Requests
    {
        public struct stateCapital
        {
            public string StateName;
            public string Capital;
        }
        public static void capitals(out stateCapital[] res, ref State[] states)
        {
            res = new stateCapital[states.Length];
            for (var i = 0; i < states.Length; i++)
            {
                res[i] = new() { StateName = states[i].Name, Capital = states[i].Capital.Name };
            }
        }

        public static void monarches(out List<string> res, ref State[] states)
        {
            res = new List<string>();
            for (var i = 0; i < states.Length; i++)
            {
                if (states[i] is Monarchy)
                {
                    res.Add(states[i].Name);
                }
            }
        }

        public static void republicHeadsTermSmallerN(out List<string> res, int n, ref State[] states)
        {
            res = new List<string>();
            for (var i = 0; i < states.Length; i++)
            {
                if (states[i] is Republic)
                {
                    Republic rep = (Republic)states[i];
                    if (rep.TermLength < n)
                    {
                        res.Add(rep.HeadName);
                    }
                }
            }
        }
    }
}
