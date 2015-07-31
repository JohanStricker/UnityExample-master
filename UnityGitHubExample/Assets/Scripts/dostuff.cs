using UnityEngine;
using System.Collections;

public class dostuff : MonoBehaviour {

	public GameObject stuff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			GameObject g;
			g = Instantiate(stuff, this.transform.position + this.transform.up * 1.5f, this.transform.rotation) as GameObject;
			g.rigidbody.AddForce(this.transform.up * 5);
		}
	}
}
