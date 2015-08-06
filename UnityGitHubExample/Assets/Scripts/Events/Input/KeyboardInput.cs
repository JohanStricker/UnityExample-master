using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class KeyboardInput : MonoBehaviour {

    public GameManager GMgr;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
               
        if (Input.GetKeyUp(KeyCode.W))
        {
            GMgr.Actors.ForEach(p => p.OnW());
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            GMgr.Actors.ForEach(p => p.OnA());
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            GMgr.Actors.ForEach(p => p.OnS());
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GMgr.Actors.ForEach(p => p.OnD());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GMgr.Actors.ForEach(p => p.OnSpace());
        }
    }

}
