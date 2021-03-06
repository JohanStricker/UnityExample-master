﻿using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    public List<int> EndEvents;

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

    public int NumTimesActorMoveImpossibleDir = 0;
    public int NumTimesNonExistantActorMoved = 0;
    
    public List<Method> Methods = new List<Method>();
    public Method End = new EndGame();

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

        if (pos.x < 0 || pos.x >= mapGen.placedWalls.GetLength(1) || pos.y < 0 || pos.y >= mapGen.placedWalls.GetLength(0))
        {
            Debug.Log("GameManager/AddActor: Actor placed outside map");
            NumActorsAddedOutsideMap++;
            return;
        }

        // Count and return if tried to add on static map part
        if (mapGen.IsWallAt((int) pos.x, (int) pos.y))
        {
            Debug.Log("GameManager/AddActor: Actor placed on wall");
            NumActorsAddedOnStatic++;
            return;
        }

        // Instantiate and add gameobject
        //ActorGameobjs.Add(Instantiate(ActorPrefab, new Vector3(pos.x + (mapGen.scaleFactor/2), pos.y + (mapGen.scaleFactor / 2), 0), Quaternion.identity) as GameObject);
        ActorGameobjs.Add(Instantiate(ActorPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity) as GameObject);
        Actors.Add(ActorGameobjs.Last().GetComponent<Actor>());
        Actors.Last().ID = NumActors;
        Actors.Last().Type = whichActor;
        Actors.Last().Setup(ActorBlueprints[whichActor], NumActors, pos, this);
        NumActors++;

        // Check if should replace event method with end
        if (Actors.Last().Type == EndEvents[0])
        {
            Actors.Last().Methods[EndEvents[1]] = End.Do;
            Debug.Log(String.Format("GameManager/AddActor: End event added to actor #{0} on event {1}", Actors.Last().ID, EndEvents[1]));
        }

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

        Debug.Log("GameManager/RemoveActor: Actor removed");
    }

    public void MoveActor(int whichActor, float dir)
    {
        Vector2 vDir = new Vector2();

        if (whichActor < 0 || whichActor > Actors.Count)
        {
            NumTimesNonExistantActorMoved++;
            return;
        }

        switch ((int) dir)
        {
            case MovementDirection.N:
                vDir = new Vector2(0, 1);
                break;
            case MovementDirection.NE:
                vDir = new Vector2(1, 1);
                break;
            case MovementDirection.E:
                vDir = new Vector2(1, 0);
                break;
            case MovementDirection.SE:
                vDir = new Vector2(1, -1);
                break;
            case MovementDirection.S:
                vDir = new Vector2(0, -1);
                break;
            case MovementDirection.SW:
                vDir = new Vector2(-1, -1);
                break;
            case MovementDirection.W:
                vDir = new Vector2(-1, 0);
                break;
            case MovementDirection.NW:
                vDir = new Vector2(-1, 1);
                break;
            default:
                Debug.Log("GameManager/MoveActor: Impossible case reached...");
                NumTimesActorMoveImpossibleDir++;
                return;
                break;
        }


        Vector2 newPos = Actors[whichActor].VVariables[0] + vDir;

        if (mapGen.IsWallAt((int)newPos.x, (int)newPos.y))
            return;

        Debug.Log(string.Format("GameManager/MoveActor: Moved actor #{0} from ({1},{2}) to ({3},{4})", Actors[whichActor].ID, Actors[whichActor].VVariables[0].x
                                                                                                    ,Actors[whichActor].VVariables[0].y, newPos.x, newPos.y));

        ActorGameobjs[whichActor].transform.position = newPos;
        Actors[whichActor].VVariables[0] = newPos;

        this.GetComponent<CollisionEvent>().CollisionCheck();
    }
    
    public void AddMethod(List<int> methodBlueprint)
    {
        switch (methodBlueprint[0])
        {
            case MethodType.Null:
                Methods.Add(null);
                break;
           // case MethodType.EndGame:
            //    Methods.Add(new EndGame());
             //   break;
            case MethodType.AddActor:
                Methods.Add(new AddActor());
                break;
            case MethodType.RemoveActor:
                Methods.Add(new RemoveActor());
                break;
            case MethodType.Movement:
                Methods.Add(new Movement());
                break;
            case MethodType.ChangeVariable:
                break;
            default:
                break;
        }

        Methods.Last().InputLocations = methodBlueprint.GetRange(1, 3);
        Methods.Last().OutputLocation = methodBlueprint[4];
        Methods.Last().OtherID = methodBlueprint[5];
        Methods.Last().InputLocationNumbers = methodBlueprint.GetRange(6, 3);
        Methods.Last().OutputLocationNumber = methodBlueprint[9];
        Methods.Last().Constants =  methodBlueprint.GetRange(10, 3).Select(i => (float)i).ToList();
        Methods.Last().GMgr = this;

        Debug.Log(String.Format("GameManager/AddMethod: Method of type {0} added", methodBlueprint[0]));
    }

    public Action<Actor,int> GetMethod(int whichMethod, Actor fromActor)
    {
        // Get the correct method. 0 means no method, means null.
        if (whichMethod < 1 || whichMethod >= Methods.Count+1)
            return null;

        if (Methods[whichMethod - 1] == null)
            return null;

        Debug.Log(String.Format("GameManager/GetMethod: Method #{2} of type {0} returned to actor #{1}", Methods[whichMethod-1].Type, fromActor.ID, whichMethod));

        return Methods[whichMethod-1].Do;
    }

    public void EndGame()
    {
        Debug.Log("Game Ended");
        Time.timeScale = 0.0f;
    }
        
    void Awake() {
        GameGen.Instance.GMgr = this;
        End.GMgr = this;
    }

	// Use this for initialization
	void Start () {
        mapGen = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MapGeneration>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
