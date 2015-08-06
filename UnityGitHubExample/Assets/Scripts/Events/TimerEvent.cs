using UnityEngine;
using System.Collections;

public class TimerEvent : MonoBehaviour {


    public GameManager GMgr;

    public void TimerTick()
    {
        foreach (Actor A in GMgr.Actors)
        {
            if (A.BVariables[1] && A.FVariables[1] >= 0.1)
                if (A.Timer.isfinished())
                {
                    A.OnTimer();
                    A.Timer.Start();
                }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimerTick();
	}
}
