﻿using UnityEngine;
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
    public int TimesNonExistantActorReferenced = 0;
    public int TimesInvalidInputLocationChosen = 0;

    public List<int> InputLocations;
    public List<int> InputLocationNumbers;

    public int OutputLocation;
    public int OutputLocationNumber;

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
