using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Genome g = new Genome();
        g.ActorBlueprints = new List<List<int>>();
        g.ActorBlueprints.Add(new List<int>());
        g.ActorBlueprints.Add(new List<int>());
        g.GlobalVariables = new List<int>();
        g.ActorCounts = new List<int>();
        g.Locations = new List<int>();

        //actor
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
        //variables
        
        //bool
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        //floats
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        //vectors
        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

        g.ActorBlueprints[0].Add(0);
        g.ActorBlueprints[0].Add(0);

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
        //end of first actor



        //actor count
        g.ActorCounts.Add(0);   // first actor
        g.ActorCounts.Add(4);   // Add 4


        //locations x,y x,y x,y
        g.Locations.Add(10);
        g.Locations.Add(20);
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
        g.Locations.Add(10);
        g.Locations.Add(12);
        g.Locations.Add(0);
        g.Locations.Add(4);
        g.Locations.Add(28);
        g.Locations.Add(4);
        g.Locations.Add(13);
        g.Locations.Add(43);
        g.Locations.Add(25);
        g.Locations.Add(25);


        GameGen.Instance.GenerateGame(g);

    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
