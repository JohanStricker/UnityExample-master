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
}

public class Actor : MonoBehaviour{
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
                case ActorEvent.KeyW:
                    // Debug on event 1
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

    
    public void OnCollision()
    {

    }

    public void OnTimer()
    {

    }

    public void OnClick()
    {

    }

    public void OnW()
    {
        if (Methods.Count > 1 && Methods[1] != null)
        {
            Methods[1]();
        }
    }

    public void OnA()
    {

    }

    public void OnS()
    {

    }

    public void OnD()
    {

    }

    public void OnComparison()
    {

    }
}
