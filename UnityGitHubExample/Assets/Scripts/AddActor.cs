using UnityEngine;
using System.Collections;

public class AddActor : Method {

    private Actor ActorToAdd;
    private int _chosenBlueprint;

	public AddActor(int chosenBlueprint)
    {
    }

    public override void Do(Vector2 v)
    {
        GameManager.Instance.AddActor(_chosenBlueprint, v);
    }

    


}
