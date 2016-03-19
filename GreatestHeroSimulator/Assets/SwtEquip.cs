using UnityEngine;
using System.Collections;

public class SwtEquip : MonoBehaviour {

    // Use this for initialization
    public GameObject sw1;
    public GameObject sw2;
    public GameObject sh1;
    public GameObject sh2;
    public GameObject map1;
    public GameObject map2;

    void Start () {
	
	}

    void SetWeapon(bool x)
    {
        if (x)
        {
            sw1.active = true;
            sw2.active = false;
        }
        else {
            sw2.active = true;
            sw1.active = false;
        }

    }

    void SetShield(bool x)
    {
        if (x)
        {
            sh1.active = true;
            sh2.active = false;
        }
        else
        {
            sh2.active = true;
            sh1.active = false;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
