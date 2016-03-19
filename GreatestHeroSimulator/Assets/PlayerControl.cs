using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


    bool t1;
    bool t2;
    Touch touch1;
    Touch touch2;
    public GameObject main;
    private bool fight;

    bool fl;




    int debugFlag;
    float debugTimer;
    // Use this for initialization
    void Start () {
        t1 = false;
        t2 = false;
        fl = false;
        fight = true;
        debugFlag = 1;
        debugTimer = Time.time;
        // main.SendMessage("Active", new Vector4(1, 0, 0, 1));
        //main.SendMessage("Active", new Vector4(1, 0, 0, 1));
    }

    public void Fight(GameObject gO)
    {
        fight = !fight;
    }


    public void Active1(int id, Vector2 s, Vector2 f)
    {
        int idS= 0;
        int idF = 0;
        if (s.y < Screen.height / 3)
        {
            idS = 2;
        }
        if ((s.y > Screen.height / 3) && (s.y < Screen.height / 3 * 2))
        {
            idS = 1;
        }
        if (s.y > Screen.height / 3 * 2)
        {
            idS = 0;
        }
        if (f.x < Screen.width / 2)
        {
            idF = 0;
        }
        else
        {
            idF = 1;
        }
        if (f.y < Screen.height / 3)
        {
            main.SendMessage("Active", new Vector4(id, idS, 2, idF));
        //   fl = true;
        }
        if ((f.y > Screen.height / 3) && (f.y < Screen.height / 3 * 2))
        {
            main.SendMessage("Active", new Vector4(id, idS, 1, idF));
          //  fl = true;
        }
        if (f.y > Screen.height / 3 * 2)
        {
            main.SendMessage("Active", new Vector4(id, idS, 0, idF));
            //fl = true;
        }
    }

    public void Action(Vector2 s, Vector2 f)
    {
        if (s.x < Screen.width / 2)
        {
            Active1(0, s, f);
            fl = true;
        }
        else
        {
            Active1(1, s, f);
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (fl)
        {
           // GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "FHGJDGFUKDGFUGDFUDGFUGDFKUGSEFKUGESKUFGEKUYGF");
        }
    }

	void Update () {
        if (fight)
        {
       /*     if ((debugTimer + 1 < Time.time) && (debugFlag == 1))
 {
                main.SendMessage("Active", new Vector4(1, 0, 0, 1));
                debugFlag = 2;
 }
 if ((debugTimer + 2 < Time.time) && (debugFlag == 2))
 {
                main.SendMessage("Active", new Vector4(1, 0, 0, 1));
                debugFlag = 3;
 }
 if ((debugTimer + 3 < Time.time) && (debugFlag == 3))
 {
                main.SendMessage("Active", new Vector4(1, 0, 0, 1));
                debugFlag = 4;
 }*/
            foreach (Touch touch in Input.touches)
            {
                //  fl = true;
                if (t1)
                {
                    if (touch.fingerId == touch1.fingerId)
                    {
                        if (touch.phase == TouchPhase.Ended)
                        {
                            Action(touch1.position, touch.position);
                            t1 = false;
                        }
                    }
                    else
                    {
                        if (t2)
                        {
                            if (touch.fingerId == touch2.fingerId)
                            {
                                if (touch.phase == TouchPhase.Ended)
                                {
                                    Action(touch2.position, touch.position);
                                    t2 = false;
                                }
                            }
                        }
                        else
                        {
                            t2 = true;
                            touch2 = touch;
                        }
                    }
                }
                else
                {
                    if (t2)
                    {
                        if (touch.fingerId == touch2.fingerId)
                        {
                            if (touch.phase == TouchPhase.Ended)
                            {
                                Action(touch2.position, touch.position);
                                t2 = false;
                            }
                        }
                        else
                        {
                            t1 = true;
                            touch1 = touch;
                        }
                    }
                    else
                    {
                        t2 = true;
                        touch2 = touch;
                    }
                }
            }
        }
    }
}
