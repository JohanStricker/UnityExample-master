using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MechanicType { Movement, Spawn, Destroy, SpawnOther, Collision, Timer };

public class Mechanic {
    public Fluent Trigger;
    private List<Fluent> FluentArgs;
    private List<float> ValueArgs;


    public Mechanic(List<Fluent> fArgs = null, List<float> vArgs = null)
    {
        
        // If no arguments to fluents, make null, otherwise add all
        if (fArgs == null)
            FluentArgs = null;
        else
        {
            FluentArgs = new List<Fluent>();
            fArgs.ForEach(delegate (Fluent f)
            {
                FluentArgs.Add(f);
            });
        }

        // Same for vArgs
        if (vArgs == null)
            ValueArgs = null;
        else
        {
            vArgs = new List<float>();
            vArgs.ForEach(delegate (float v)
                            {
                                ValueArgs.Add(v);
                            });
        }
    }
}
