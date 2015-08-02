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
        g.ActorCounts = new List<int>();
        g.Locations = new List<int>();

        g.ActorBlueprints[0].Add(1);
        g.ActorBlueprints[0].Add(2);
        g.ActorBlueprints[0].Add(3);

        g.ActorBlueprints[1].Add(4);
        g.ActorBlueprints[1].Add(5);
        g.ActorBlueprints[1].Add(6);

        g.ActorCounts.Add(0);   // first actor
        g.ActorCounts.Add(4);   // Add 4

        g.ActorCounts.Add(1);   // second actor
        g.ActorCounts.Add(3);   // add 3

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

        GameGen.Instance.GenerateGame(g);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
