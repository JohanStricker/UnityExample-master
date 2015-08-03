using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct MethodVariableLocation
{
    public const int Constants = 0;
    public const int CallingActor = 1;
    public const int Global = 2;
    public const int OtherActor = 3;
};

public class Method
{
    public List<int> InputLocations;
    public List<int> InputLocationNumbers;

    public int OutputLocation;
    public int OutputLocationNumber;

    public List<float> Constants;

    public Actor CallingActor;

    public int ID;

    public Method()
    {
        // Construct
    }

    public virtual void Do(ref Actor fromActor)
    {
        // Do the method
        CallingActor = fromActor;
    }
}
