using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneTest : MonoBehaviour {

	// Use this for initialization
	void Start () {



        Genome g = new Genome();
        g.EndEvents = new List<int>();
        g.ActorBlueprints = new List<List<int>>();
        g.MethodBlueprints = new List<List<int>>();
        g.GlobalVariables = new List<int>();
        g.ActorCounts = new List<int>();
        g.Locations = new List<int>();


        #region End event

        //EndEvent
        //the  actor
        g.EndEvents.Add(1);
        //the event
        g.EndEvents.Add(8);
        //end of EndEvent

        #endregion

        #region Actors
        #region Actor 0
        g.ActorBlueprints.Add(new List<int>());
        //first actor
        //events
        g.ActorBlueprints[0].Add(1);
        g.ActorBlueprints[0].Add(1);
        g.ActorBlueprints[0].Add(1);
        g.ActorBlueprints[0].Add(1);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
             
        //bool(4)
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        //floats(4)
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        //vectors(4 sets of 2)
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        //end of first actor

        #endregion

        #region Actor 1
        g.ActorBlueprints.Add(new List<int>());
        //first actor
        //events
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);

        //bool(4)
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        //floats(4)
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);

        //vectors(4 sets of 2)
        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);

        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);

        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);

        g.ActorBlueprints[1].Add(0);
        g.ActorBlueprints[1].Add(0);
        //end of first actor

        #endregion
        #endregion


        #region Actor count
        //actor count

        // Actor 0
        g.ActorCounts.Add(0);   // first actor
        g.ActorCounts.Add(1);   // Add 4

        // Actor 1
        g.ActorCounts.Add(1);
        g.ActorCounts.Add(10);
        #endregion
        
        #region Locations

        g.Locations.Add(1);
        g.Locations.Add(1);

        g.Locations.Add(4);
        g.Locations.Add(1);

        //randoms locations
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 47));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 33));
        g.Locations.Add(Random.Range(0, 33));
        #endregion

        #region Methods

        #region Method 0  movement for player

        g.MethodBlueprints.Add(new List<int>());

        g.MethodBlueprints[0].Add(MethodType.Movement);

        // input location
        g.MethodBlueprints[0].Add(MethodVariableLocation.Constants);
        g.MethodBlueprints[0].Add(MethodVariableLocation.Constants);
        g.MethodBlueprints[0].Add(MethodVariableLocation.Constants);

        // output location
        g.MethodBlueprints[0].Add(MethodVariableLocation.CallingActor);

        // output location id (if other)
        g.MethodBlueprints[0].Add(0);

        // input variables
        g.MethodBlueprints[0].Add(0);
        g.MethodBlueprints[0].Add(0);
        g.MethodBlueprints[0].Add(0);

        // output variable
        g.MethodBlueprints[0].Add(0);

        // constants
        g.MethodBlueprints[0].Add(1);
        g.MethodBlueprints[0].Add(33);
        g.MethodBlueprints[0].Add(7);


        #endregion


        #endregion

        #region Global variables
        //global variables
        //bool
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        //float
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        //vector2d
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);
        g.GlobalVariables.Add(0);

        #endregion

        GameGen.Instance.GenerateGame(g);

    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
