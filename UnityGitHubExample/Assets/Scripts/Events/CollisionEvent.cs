using UnityEngine;
using System.Collections;
using System.Linq;

public class CollisionEvent : MonoBehaviour {

    public GameManager GMgr;

    public void CollisionCheck()
    {
        for (int i = 0; i < GMgr.Actors.Count() - 1; i++)
        {
            for (int j = 0; j < GMgr.Actors.Count() - 1; j++)
            {
                //self id check
                if (GMgr.Actors[i].ID == GMgr.Actors[j].ID)
                    continue;

                //possition check
                if (GMgr.Actors[i].VVariables[0] == GMgr.Actors[j].VVariables[0])
                {
                    //actor type check
                    if (GMgr.Actors[i].VVariables[1].x == GMgr.Actors[j].Type || GMgr.Actors[i].VVariables[1].y == GMgr.Actors[j].Type)
                    {
                        //then Actors[i].OnCollision(with actor[j]);
                        GMgr.Actors[i].OnCollision();
                        Debug.Log(string.Format("CollisionEvent/CollisionCheck: Actor {0} collides with {1}", i, j));
                    }
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
