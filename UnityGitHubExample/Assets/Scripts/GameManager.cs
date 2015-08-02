using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


    public GameObject ActorPrefab;
    public List<List<int>> ActorBlueprints;  // Do somehow else than Actor class list

    public List<float> Variables;
    public List<Actor> Actors;
    public List<GameObject> ActorGameobjs;
    public int NumNonExistantActorsAdded = 0;
    public int NumActorsAddedOnStatic = 0;

    public MapGeneration mapGen;

    public void AddActor(int whichActor, Vector2 pos)
    {
        // Adds an actor

        // Count and return if non-existant actor tried added
        if (whichActor < 0 || whichActor >= ActorBlueprints.Count)
        {
            NumNonExistantActorsAdded++;
            return;
        }


        // Count and return if tried to add on static map part
        if (mapGen.placedWalls[(int) pos.x, (int) pos.y] != null)
        {
            NumActorsAddedOnStatic++;
            return;
        }
            
        // Instantiate and add gameobject
        ActorGameobjs.Add(Instantiate(ActorPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity) as GameObject);

        // Tie events to methods/mechanics
        Actors.Add(new Actor());
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

    //the one to rule them all
    private static GameManager _instance;

    //used by other classes to access this manager
    public static GameManager Instance { get; private set; }
    /*public static GameManager instance{
        get {
            if (_instance == null){
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }*/
    
    void Awake() {
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances
            Destroy(gameObject);
        }

        // Here we save our singleton instance
        Instance = this;

        // Furthermore we make sure that we don't destroy between scenes (this is optional)
        DontDestroyOnLoad(gameObject);


    }

	// Use this for initialization
	void Start () {
        mapGen = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MapGeneration>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
