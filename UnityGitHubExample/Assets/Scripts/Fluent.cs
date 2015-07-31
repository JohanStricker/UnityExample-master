using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Comparison { LT, GT, LTE, GTE, EQ, NEQ};

public class Fluent
{
    public bool Value = false;
    private float valA, valB;
    private bool doesComparison = false;
    private Comparison Comp = Comparison.EQ;
    private List<Fluent> ReqTrue;
    private List<Fluent> ReqFalse;

    public Fluent(List<Fluent> t = null, List<Fluent> f = null)
    {
        // If no arguments to required true fluents, then null, else copy all 
        if (t == null)
            ReqTrue = null;
        else
        {
            ReqTrue = new List<Fluent>();
            t.ForEach(delegate (Fluent d)
            {
                ReqTrue.Add(d);
            });
        }

        // Same for false fluents
        if (f == null)
            ReqFalse = null;
        else
        {
            ReqFalse = new List<Fluent>();
            f.ForEach(delegate (Fluent d)
            {
                ReqFalse.Add(d);
            });
        }
    }

    public void DoComparison(ref float vA, ref float vB, Comparison c)
    {
        // This fluent also (or only) does a comparison
        doesComparison = true;
        valA = vA;
        valB = vB;
        Comp = c;
    }

    public void UpdateValue()
    {
        // Go through all requirements for fluent and update boolean value accordingly (note we assume true and does invert checks to disprove this)
        bool newValue = true;

        //Check all required trues
        if(ReqTrue != null)
        {
            foreach (Fluent t in ReqTrue)
            {
                if (!t.Value)
                    newValue = false;
            }
        }

        // Check all required falses
        if(ReqFalse != null)
        {
            foreach (Fluent f in ReqFalse)
            {
                if (f.Value)
                    newValue = false;
            }
        }

        // Do comparison (unless it is already false, then no need to
        if(doesComparison )
        {
            switch (Comp)
            {
                case Comparison.LT:
                    if (valA >= valB)
                        newValue = false;
                    break;
                case Comparison.GT:
                    if (valA <= valB)
                        newValue = false;
                    break;
                case Comparison.LTE:
                    if (valA > valB)
                        newValue = false;
                    break;
                case Comparison.GTE:
                    if (valA < valB)
                        newValue = false;
                    break;
                case Comparison.EQ:
                    if (Mathf.Abs(valA - valB) > GlobalConstants.FloatComparisonDifference)
                        newValue = false;
                    break;
                case Comparison.NEQ:
                    if (Mathf.Abs(valA - valB) < GlobalConstants.FloatComparisonDifference)
                        newValue = false;
                    break;
                default:
                    break;
            }
        }

        Value = newValue;
    }
}