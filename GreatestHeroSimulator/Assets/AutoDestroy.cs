using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization

    private float timer;
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - 0.5 > timer)
        {
            this.gameObject.active = false;
        }
	}
}
