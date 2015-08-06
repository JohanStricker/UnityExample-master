using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/*
    Make pseudo enum with struct for event ordering i n methods
*/

public struct ActorEvent
{
    public const int KeyW = 0;
    public const int KeyA = 1;
    public const int KeyS = 2;
    public const int KeyD = 3;
    public const int KeySpace = 4;

    public const int MouseLeft = 5;
    public const int MouseRight = 6;

    public const int TimerTick = 7;
    public const int CollisionOccurrence = 8;

    public const int ComparisonLT = 9;
    public const int ComparisonGT = 10;
    public const int ComparisonLTE = 11;
    public const int ComparisonGTE = 12;
    public const int ComparisonEQ = 13;
    public const int ComparisonNEQ = 14;

    public const int Destroy = 15;


}

public class Actor : MonoBehaviour{
                                            // |read-only  | 
    public List<float> FVariables;          // | ID         | TimerTime      a b c
    public List<bool> BVariables;           // | IsActive   | TimerRunning   d e f
    public List<Vector2> VVariables;        // | Loc        | CollidesWith   g h i


    public bool HasInput;

    public int ID;
    public int Type;
    List<Action<Actor,int>> Methods;
    public Timer Timer;

    public void Setup(List<int> Blueprints, int ID, Vector2 Loc, GameManager GMgr)
    {
        // Add read-only float
        FVariables = new List<float>();
        FVariables.Add((float)ID);


        // Add read-only bool
        BVariables = new List<bool>();
        BVariables.Add(true);

        // Add read-only vector
        VVariables = new List<Vector2>();
        VVariables.Add(Loc);

        Methods = new List<Action<Actor,int>>();

        // Split blueprint into methods and variables
        List<int> ActorMethods = Blueprints.GetRange(0, GlobalConstants.ActorBlueprintEventCount);
        List<int> ActorVariables = Blueprints.GetRange(GlobalConstants.ActorBlueprintEventCount, Blueprints.Count - GlobalConstants.ActorBlueprintEventCount);


        // Attach methods to events
        HasInput = false;
        for (int i = 0; i < ActorMethods.Count; i++)
        {
            switch (ActorMethods[i])
            {
                case ActorEvent.KeyA:
                case ActorEvent.KeyD:
                case ActorEvent.KeyS:
                case ActorEvent.KeyW:
                case ActorEvent.KeySpace:
                case ActorEvent.MouseLeft:
                case ActorEvent.MouseRight:
                    HasInput = true;
                    break;
                default:
                    break;
            }
            Methods.Add(GMgr.GetMethod(ActorMethods[i], this));
        }

        // Add variables
        for (int i = 0; i < 4; i++)
        {
            // If they are "equal" to 0 treat as false, else treat as true
            BVariables.Add(Mathf.Abs(ActorVariables[i]) < GlobalConstants.FloatComparisonDifference ? false : true);
        }

        for (int i = 4; i < 8; i++)
        {
            // Add floats
            FVariables.Add(ActorVariables[i]);
        }

        for (int i = 8; i < 16; i++)
        {
            // Add vectors (from floats)
            VVariables.Add(new Vector2(ActorVariables[i], ActorVariables[++i]));

        }
        //timer
        if (BVariables[1])
        {
            Timer = new Timer(FVariables[1]);
            Timer.Start();
        }
    }
    
   
    public void OnW()
    {
        Debug.Log("Actor/DoW: Event fired");
        if (Methods.Count > ActorEvent.KeyW && Methods[ActorEvent.KeyW] != null)
        {
            Methods[ActorEvent.KeyW](this, ActorEvent.KeyW);
        }
    }

    public void OnA()
    {
        Debug.Log("Actor/DoA: Event fired");
        if (Methods.Count > ActorEvent.KeyA && Methods[ActorEvent.KeyA] != null)
        {
            Methods[ActorEvent.KeyA](this, ActorEvent.KeyA);
        }
    }

    public void OnS()
    {
        Debug.Log("Actor/DoS: Event fired");
        if (Methods.Count > ActorEvent.KeyS && Methods[ActorEvent.KeyS] != null)
        {
            Methods[ActorEvent.KeyS](this, ActorEvent.KeyS);
        }
    }

    public void OnD()
    {
        Debug.Log("Actor/DoD: Event fired");
        if (Methods.Count > ActorEvent.KeyD && Methods[ActorEvent.KeyD] != null)
        {
            Methods[ActorEvent.KeyD](this, ActorEvent.KeyD);
        }
    }

    public void OnSpace()
    {
        Debug.Log("Actor/DoSpace: Event fired");
        if (Methods.Count > ActorEvent.KeySpace && Methods[ActorEvent.KeySpace] != null)
        {
            Methods[ActorEvent.KeySpace](this, ActorEvent.KeySpace);
        }
    }

    public void OnLeftClick()
    {
        Debug.Log("Actor/DoLeftClick: Event fired");
        if (Methods.Count > ActorEvent.MouseLeft && Methods[ActorEvent.MouseLeft] != null)
        {
            Methods[ActorEvent.MouseLeft](this, ActorEvent.MouseLeft);
        }
    }

    public void OnRightClick()
    {
        Debug.Log("Actor/DoRightClick: Event fired");
        if (Methods.Count > ActorEvent.MouseRight && Methods[ActorEvent.MouseRight] != null)
        {
            Methods[ActorEvent.MouseRight](this, ActorEvent.MouseRight);
        }
    }
    // this need work
    public void OnTimer()
    {
        Debug.Log("Actor/TimerTicked: Event fired");
        if (Methods.Count > ActorEvent.TimerTick && Methods[ActorEvent.TimerTick] != null)
        {
            Debug.Log("suck my balls");
            Methods[ActorEvent.TimerTick](this, ActorEvent.TimerTick);
        }
    }

    public void OnCollision()
    {
        Debug.Log("Actor/CollisionOccured: Event fired");
        if (Methods.Count > ActorEvent.CollisionOccurrence && Methods[ActorEvent.CollisionOccurrence] != null)
        {
            Methods[ActorEvent.CollisionOccurrence](this, ActorEvent.CollisionOccurrence);
        }
    }

    public void OnComparisonLT()
    {
        Debug.Log("Actor/ComparisonLesserThan: Event fired");
        if (Methods.Count > ActorEvent.ComparisonLT && Methods[ActorEvent.ComparisonLT] != null)
        {
            Methods[ActorEvent.ComparisonLT](this, ActorEvent.ComparisonLT);
        }
    }

    public void OnComparisonGT()
    {
        Debug.Log("Actor/ComparisonGreaterThan: Event fired");
        if (Methods.Count > ActorEvent.ComparisonGT && Methods[ActorEvent.ComparisonGT] != null)
        {
            Methods[ActorEvent.ComparisonGT](this, ActorEvent.ComparisonGT);
        }
    }

    public void OnComparisonLTE()
    {
        Debug.Log("Actor/ComparisonLesserThanEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonLTE && Methods[ActorEvent.ComparisonLTE] != null)
        {
            Methods[ActorEvent.ComparisonLTE](this, ActorEvent.ComparisonLTE);
        }
    }

    public void OnComparisonGTE()
    {
        Debug.Log("Actor/ComparisonGreaterThanEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonGTE && Methods[ActorEvent.ComparisonGTE] != null)
        {
            Methods[ActorEvent.ComparisonGTE](this, ActorEvent.ComparisonGTE);
        }
    }

    public void OnComparisonEQ()
    {
        Debug.Log("Actor/ComparisonEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonEQ && Methods[ActorEvent.ComparisonEQ] != null)
        {
            Methods[ActorEvent.ComparisonEQ](this, ActorEvent.ComparisonEQ);
        }
    }

    public void OnComparisonNEQ()
    {
        Debug.Log("Actor/ComparisonNotEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonNEQ && Methods[ActorEvent.ComparisonNEQ] != null)
        {
            Methods[ActorEvent.ComparisonNEQ](this, ActorEvent.ComparisonNEQ);
        }
    }
    public void OnDestroy()
    {
        Debug.Log("Actor/DoW: Event fired");
        if (Methods.Count > ActorEvent.KeyW && Methods[ActorEvent.KeyW] != null)
        {
            Methods[ActorEvent.Destroy](this, ActorEvent.Destroy);
        }
    }
}
