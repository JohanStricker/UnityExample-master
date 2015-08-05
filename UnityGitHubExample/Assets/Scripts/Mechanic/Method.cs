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

public struct MethodType
{
    public const int Null = 0;
    public const int EndGame = 1;
    public const int AddActor = 2;
    public const int RemoveActor = 3;
    public const int Movement = 4;
    public const int ChangeVariable = 5;
};

public class Method
{
    public int TimesNonExistantActorReferenced = 0;
    public int TimesInvalidInputLocationChosen = 0;

    public List<int> InputLocations;
    public List<int> InputLocationNumbers;

    public int OutputLocation;
    public int OutputLocationNumber;
    public int OtherID;

    public List<float> Constants;

    public Actor CallingActor;

    public GameManager GMgr;

    public int ID;

    public Method()
    {
        // Construct
    }

    public virtual void Do(Actor fromActor)
    {
        // Do the method
        //CallingActor = fromActor;
    }
    
}
