using UnityEngine;
using System.Collections;

public class ShieldAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Animation>().Play("ShieldMId-Up");
    }
}
