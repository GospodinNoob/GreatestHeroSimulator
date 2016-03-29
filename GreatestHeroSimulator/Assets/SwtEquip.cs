using UnityEngine;
using System.Collections;

public class SwtEquip : MonoBehaviour {

    // Use this for initialization
    public GameObject sw1;
    public GameObject sw2;
    public GameObject sw3;
    public GameObject sh1;
    public GameObject sh2;
    public GameObject sh3;

    void Start () {
	
	}

    void SetWeapon(int x)
    {
        if (x == 1)
        {
            sw1.active = true;
            sw2.active = false;
            sw3.active = false;
        }
        if (x == 2)
        {
            sw2.active = true;
            sw1.active = false;
            sw3.active = false;
        }
        if (x == 3)
        {
            sw2.active = false;
            sw1.active = false;
            sw3.active = true;
        }
    }

    void SetShield(int x)
    {
        if (x == 1)
        {
            sh1.active = true;
            sh2.active = false;
            sh3.active = false;
        }
        if (x == 2)
        {
            sh2.active = true;
            sh1.active = false;
            sh3.active = false;
        }
        if (x == 3)
        {
            sh2.active = false;
            sh1.active = false;
            sh3.active = true;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
