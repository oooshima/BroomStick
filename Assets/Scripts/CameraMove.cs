using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float x = 0;
	public float y = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.transform.Rotate ( 0, x  , 0 );
		this.transform.Rotate ( y, 0, 0 );
	}
}