using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {


    public GameManager GMgr;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            GMgr.Actors.ForEach(p => p.OnLeftClick());
        }
        if (Input.GetMouseButtonUp(1))
        {
            GMgr.Actors.ForEach(p => p.OnRightClick());
        }

    }
}
