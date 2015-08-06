using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneTest : MonoBehaviour {

	// Use this for initialization
	void Start () {



        Genome g = new Genome();
        g.EndEvents = new List<int>();
        g.ActorBlueprints = new List<List<int>>();
        g.ActorBlueprints.Add(new List<int>());
        g.ActorBlueprints.Add(new List<int>());
        g.GlobalVariables = new List<int>();
        g.ActorCounts = new List<int>();
        g.Locations = new List<int>();


        //EndEvent
        //the  actor
        g.EndEvents.Add(2);
        //the event
        g.EndEvents.Add(9);
        //end of EndEvent

        //first actor
        //events
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



        //actor count
        g.ActorCounts.Add(0);   // first actor
        g.ActorCounts.Add(100);   // Add 4


        //locations x,y x,y x,y


        g.Locations.Add(0);
        g.Locations.Add(0);
        g.Locations.Add(0);
        g.Locations.Add(2);
        g.Locations.Add(1);
        g.Locations.Add(4);
        g.Locations.Add(6);
        g.Locations.Add(8);
        g.Locations.Add(12);
        g.Locations.Add(50);
        g.Locations.Add(3);
        g.Locations.Add(8);

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

        GameGen.Instance.GenerateGame(g);

    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
