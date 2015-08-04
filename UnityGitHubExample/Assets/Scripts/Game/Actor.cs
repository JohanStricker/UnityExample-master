using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/*
    Make pseudo enum with struct for event ordering i n methods
*/

public struct ActorEvent
{
    public const int Nothing = 0;

    public const int KeyW = 1;
    public const int KeyA = 2;
    public const int KeyS = 3;
    public const int KeyD = 4;
    public const int KeySpace = 5;

    public const int MouseLeft = 6;
    public const int MouseRight = 7;

    public const int TimerTick = 8;
    public const int CollisionOccurrence = 9;

    public const int ComparisonLT = 10;
    public const int ComparisonGT = 11;
    public const int ComparisonLTE = 12;
    public const int ComparisonGTE = 13;
    public const int ComparisonEQ = 14;
    public const int ComparisonNEQ = 15;


}

public class Actor : MonoBehaviour{
    public List<float> FVariables;
    public List<bool> BVariables;
    public List<Vector2> VVariables;

    public int ID;
    List<Action> Methods;

    public void Setup(List<int> Blueprints)
    {
        Methods = new List<Action>();
        foreach (int method in Blueprints)
        {
            switch (method)
            {
                case ActorEvent.Nothing:
                    // Nothing on event 0
                    Methods.Add(null);
                    break;
                ////////////////
                //Keys
                case ActorEvent.KeyW:
                    // Debug on event 1
                    Methods.Add(DoLog);  
                    break;
                case ActorEvent.KeyA:
                    // Debug on event 2
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.KeyS:
                    // Debug on event 3
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.KeyD:
                    // Debug on event 4
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.KeySpace:
                    // Debug on event 5
                    Methods.Add(DoLog);
                    break;
                ////////////////
                //Mouse
                case ActorEvent.MouseLeft:
                    // Debug on event 6
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.MouseRight:
                    // Debug on event 7
                    Methods.Add(DoLog);
                    break;
                ////////////////
                //General
                case ActorEvent.TimerTick:
                    // Debug on event 8
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.CollisionOccurrence:
                    // Debug on event 9
                    Methods.Add(DoLog);
                    break;
                ////////////////
                //Comparisons
                case ActorEvent.ComparisonLT:
                    // Debug on event 10
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.ComparisonGT:
                    // Debug on event 11
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.ComparisonLTE:
                    // Debug on event 12
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.ComparisonGTE:
                    // Debug on event 13
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.ComparisonEQ:
                    // Debug on event 14
                    Methods.Add(DoLog);
                    break;
                case ActorEvent.ComparisonNEQ:
                    // Debug on event 15
                    Methods.Add(DoLog);
                    break;
                default:
                    Methods.Add(null);
                    break;
            }
        }
    }

    private void DoLog()
    {
        Debug.Log(String.Format("Actor/DoLog: Actor #{0} says HI", ID));
    }
   
    public void OnW()
    {
        Debug.Log("Actor/DoW: Event fired");
        if (Methods.Count > ActorEvent.KeyW && Methods[ActorEvent.KeyW] != null)
        {
            Methods[ActorEvent.KeyW]();
        }
    }

    public void OnA()
    {
        Debug.Log("Actor/DoA: Event fired");
        if (Methods.Count > ActorEvent.KeyA && Methods[ActorEvent.KeyA] != null)
        {
            Methods[ActorEvent.KeyA]();
        }
    }

    public void OnS()
    {
        Debug.Log("Actor/DoS: Event fired");
        if (Methods.Count > ActorEvent.KeyS && Methods[ActorEvent.KeyS] != null)
        {
            Methods[ActorEvent.KeyS]();
        }
    }

    public void OnD()
    {
        Debug.Log("Actor/DoD: Event fired");
        if (Methods.Count > ActorEvent.KeyD && Methods[ActorEvent.KeyD] != null)
        {
            Methods[ActorEvent.KeyD]();
        }
    }

    public void OnSpace()
    {
        Debug.Log("Actor/DoSpace: Event fired");
        if (Methods.Count > ActorEvent.KeySpace && Methods[ActorEvent.KeySpace] != null)
        {
            Methods[ActorEvent.KeySpace]();
        }
    }

    public void OnLeftClick()
    {
        Debug.Log("Actor/DoLeftClick: Event fired");
        if (Methods.Count > ActorEvent.MouseLeft && Methods[ActorEvent.MouseLeft] != null)
        {
            Methods[ActorEvent.MouseLeft]();
        }
    }

    public void OnRightClick()
    {
        Debug.Log("Actor/DoRightClick: Event fired");
        if (Methods.Count > ActorEvent.MouseRight && Methods[ActorEvent.MouseRight] != null)
        {
            Methods[ActorEvent.MouseRight]();
        }
    }

    public void OnTimer()
    {
        Debug.Log("Actor/TimerTicked: Event fired");
        if (Methods.Count > ActorEvent.TimerTick && Methods[ActorEvent.TimerTick] != null)
        {
            Methods[ActorEvent.TimerTick]();
        }
    }

    public void OnCollision()
    {
        Debug.Log("Actor/CollisionOccured: Event fired");
        if (Methods.Count > ActorEvent.CollisionOccurrence && Methods[ActorEvent.CollisionOccurrence] != null)
        {
            Methods[ActorEvent.CollisionOccurrence]();
        }
    }

    public void OnComparisonLT()
    {
        Debug.Log("Actor/ComparisonLesserThan: Event fired");
        if (Methods.Count > ActorEvent.ComparisonLT && Methods[ActorEvent.ComparisonLT] != null)
        {
            Methods[ActorEvent.ComparisonLT]();
        }
    }

    public void OnComparisonGT()
    {
        Debug.Log("Actor/ComparisonGreaterThan: Event fired");
        if (Methods.Count > ActorEvent.ComparisonGT && Methods[ActorEvent.ComparisonGT] != null)
        {
            Methods[ActorEvent.ComparisonGT]();
        }
    }

    public void OnComparisonLTE()
    {
        Debug.Log("Actor/ComparisonLesserThanEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonLTE && Methods[ActorEvent.ComparisonLTE] != null)
        {
            Methods[ActorEvent.ComparisonLTE]();
        }
    }

    public void OnComparisonGTE()
    {
        Debug.Log("Actor/ComparisonGreaterThanEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonGTE && Methods[ActorEvent.ComparisonGTE] != null)
        {
            Methods[ActorEvent.ComparisonGTE]();
        }
    }

    public void OnComparisonEQ()
    {
        Debug.Log("Actor/ComparisonEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonEQ && Methods[ActorEvent.ComparisonEQ] != null)
        {
            Methods[ActorEvent.ComparisonEQ]();
        }
    }

    public void OnComparisonNEQ()
    {
        Debug.Log("Actor/ComparisonNotEqualTo: Event fired");
        if (Methods.Count > ActorEvent.ComparisonNEQ && Methods[ActorEvent.ComparisonNEQ] != null)
        {
            Methods[ActorEvent.ComparisonNEQ]();
        }
    }
    public void OnDestroy()
    {
        Debug.Log("Actor/DoW: Event fired");
        if (Methods.Count > ActorEvent.KeyW && Methods[ActorEvent.KeyW] != null)
        {
            Methods[ActorEvent.KeyW]();
        }
    }
}
