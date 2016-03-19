using UnityEngine;
using System.Collections;

public class BloodGen : MonoBehaviour {

    // Use this for initialization

    public GameObject blood;
    public GameObject main;
    public GameObject go;

	void Start () {
        main = GameObject.Find("Menu");
        main.SendMessage("SetBlood", this.gameObject);
    }

    void Gen()
    {
        go.active = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
