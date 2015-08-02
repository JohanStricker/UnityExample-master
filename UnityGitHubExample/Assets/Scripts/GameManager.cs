using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    public GameObject ActorPrefab;
    public List<List<int>> ActorBlueprints = new List<List<int>>();  // Do somehow else than Actor class list

    public List<float> Variables;
    public List<Actor> Actors = new List<Actor>();
    public List<GameObject> ActorGameobjs = new List<GameObject>();
    public int NumNonExistantActorsAdded = 0;
    public int NumActorsAddedOnStatic = 0;
    public int NumActorsAddedOutsideMap = 0;

    public MapGeneration mapGen;

    public void AddActor(int whichActor, Vector2 pos)
    {
        // Adds an actor

        // Count and return if non-existant actor tried added
        if (whichActor < 0 || whichActor >= ActorBlueprints.Count)
        {
            Debug.Log("GameManager/AddActor: Actor does not exist");
            NumNonExistantActorsAdded++;
            return;
        }


        Debug.Log(mapGen);
        if (pos.x < 0 || pos.x >= mapGen.placedWalls.GetLength(0) || pos.y < 0 || pos.y >= mapGen.placedWalls.GetLength(1))
        {
            Debug.Log("GameManager/AddActor: Actor placed outside map");
            NumActorsAddedOutsideMap++;
            return;
        }

        // Count and return if tried to add on static map part
        if (mapGen.placedWalls[(int) pos.x, (int) pos.y] != null)
        {
            Debug.Log("GameManager/AddActor: Actor placed on wall");
            NumActorsAddedOnStatic++;
            return;
        }
            
        // Instantiate and add gameobject
        ActorGameobjs.Add(Instantiate(ActorPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity) as GameObject);

        // Tie events to methods/mechanics
        Actors.Add(new Actor());
        Debug.Log("GameManager/AddActor: Actor added");
    }

    public void RemoveActor(ref Actor toRemove)
    {
        // Removes an actor
        for (int i = 0; i < Actors.Count; i++)
        {
            if (Actors[i].Equals(toRemove))
            {
                Destroy(ActorGameobjs[i]);
                Actors.RemoveAt(i);
                ActorGameobjs.RemoveAt(i);
            }
        }
    }
    
    
    void Awake() {
        GameGen.Instance.GMgr = this;
    }

	// Use this for initialization
	void Start () {
        mapGen = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MapGeneration>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
