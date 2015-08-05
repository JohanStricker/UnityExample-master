using UnityEngine;
using System.Collections;

public class TimerTick : MonoBehaviour {

    public GameManager GMgr;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        foreach (Actor A in GMgr.Actors) {
            if(A.BVariables[1] && A.FVariables[1]>=0.1)
                if (A.Timer.isfinished())
                {
                    A.OnTimer();
                    A.Timer.Start();
                }
        }

	}
}
