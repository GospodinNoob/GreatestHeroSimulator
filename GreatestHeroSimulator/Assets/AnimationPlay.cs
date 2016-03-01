using UnityEngine;
using System.Collections;

public class AnimationPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animation>().Play("SwordMid-Up");
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Animation>().Play("SwordMid-Up");
    }
}
