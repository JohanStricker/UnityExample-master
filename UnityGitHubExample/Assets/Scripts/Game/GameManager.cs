using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    public GameObject ActorPrefab;
    public List<List<int>> ActorBlueprints = new List<List<int>>();  // Do somehow else than Actor class list

    public List<bool>  BVariables;
    public List<float> FVariables;
    public List<Vector2> VVariables;

    public List<Actor> Actors = new List<Actor>();
    public List<GameObject> ActorGameobjs = new List<GameObject>();
    public int NumActors = 0;
    public int NumNonExistantActorsAdded = 0;
    public int NumNonExistantActorsRemoved = 0;
    public int NumActorsAddedOnStatic = 0;
    public int NumActorsAddedOutsideMap = 0;

    public List<Method> Methods = new List<Method>();

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
        if (pos.x < 0 || pos.x >= mapGen.placedWalls.GetLength(1) || pos.y < 0 || pos.y >= mapGen.placedWalls.GetLength(0))
        {
            Debug.Log("GameManager/AddActor: Actor placed outside map");
            NumActorsAddedOutsideMap++;
            return;
        }

        // Count and return if tried to add on static map part
        if (mapGen.placedWalls[(int) pos.x, mapGen.placedWalls.GetLength(1)-(int) pos.y] != null)
        {
            Debug.Log("GameManager/AddActor: Actor placed on wall");
            NumActorsAddedOnStatic++;
            return;
        }

        // Instantiate and add gameobject
        //ActorGameobjs.Add(Instantiate(ActorPrefab, new Vector3(pos.x + (mapGen.scaleFactor/2), pos.y + (mapGen.scaleFactor / 2), 0), Quaternion.identity) as GameObject);
        ActorGameobjs.Add(Instantiate(ActorPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity) as GameObject);
        Actors.Add(ActorGameobjs.Last().GetComponent<Actor>());
        Actors.Last().Setup(ActorBlueprints[whichActor], NumActors, pos, this);
        Actors.Last().ID = NumActors;
        Actors.Last().Type = whichActor;
        NumActors++;
        // Tie events to methods/mechanics
        Debug.Log("GameManager/AddActor: Actor added");
    }

    public void RemoveActor(int whichActor)
    {
        // Removes an actor
        if (whichActor < 0 || whichActor >= Actors.Count)
        {
            NumNonExistantActorsRemoved++;
            return;
        }

        Actors[whichActor].OnDestroy();

        Destroy(ActorGameobjs[whichActor]);
        Actors.RemoveAt(whichActor);
        ActorGameobjs.RemoveAt(whichActor);
    }
    
    public Action<Actor> GetMethod(int whichMethod, Actor fromActor)
    {
        if (whichMethod < 0 || whichMethod >= Methods.Count)
        {
            return null;
        }

        return Methods[whichMethod].Do;
    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
        Time.timeScale = 0.0f;
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
