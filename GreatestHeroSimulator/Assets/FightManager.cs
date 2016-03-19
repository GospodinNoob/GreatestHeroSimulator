using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {


    float timer1;
    float timer2;

    float timer1e;
    float timer2e;

    bool firstAction;
    bool secondAction;
    Vector4 action1;
    Vector4 action2;

    Vector4 action1e;
    Vector4 action2e;

    public GameObject main;

    public GameObject shield;
    public GameObject sword;

    public GameObject enemySword;
    public GameObject enemyShield;

    private int stateLeft;
    private int newLeft;
    private int newRight;
    private int stateRight;

    private int stateELeft;
    private int newELeft;
    private int newERight;
    private int stateERight;

    private bool firstEAction;
    private bool secondEAction;

    float debugTimer;
    int debugFlag;

    Animation swordAnim;
    Animation shieldAnim;

    Animation swordEAnim;
    Animation shieldEAnim;

    float waitTimerLeft;
    float waitTimerRight;

    public bool fight;

    // Use this for initialization
    void Start () {
        swordAnim = sword.GetComponent<Animation>();
        swordEAnim = enemySword.GetComponent<Animation>();
        shieldAnim = shield.GetComponent<Animation>();
        shieldEAnim = enemyShield.GetComponent<Animation>();
        firstAction = false;
        secondAction = false;
        firstEAction = false;
        secondEAction = false;
        timer1 = Time.time;
        timer2 = Time.time;
        timer1e = Time.time;
        timer2e = Time.time;
        waitTimerLeft = 0;
        waitTimerRight = 0;
        stateLeft = 1;
        stateRight = 1;
        stateELeft = 1;
        stateERight = 1;
        swordEAnim.wrapMode = WrapMode.Once;
        swordAnim.wrapMode = WrapMode.Once;
        debugTimer = Time.time;
        debugFlag = 1;
       // swordAnim.GetComponent<AnimationState>().speed = 2F;
        shieldAnim.wrapMode = WrapMode.Once;
        shieldEAnim.wrapMode = WrapMode.Once;
        //shield.GetComponent<Animation>().GetComponent<AnimationState>().speed = 2F;

         //  DoAction(new Vector4(1, 0, 0, 1));
    }

    float Abs(float x)
    {
        if (x < 0)
        {
            return -x;
        }
        else
        {
            return x;
        }
    }

    public void Fight(GameObject m)
    {
       // Debug.Log(0);
        main = m;
        // Debug.Log(fight);
        fight = true;
       // Debug.Log(fight);
    }

    // Update is called once per frame

    void OnGUI() {
        if (firstAction)
        {
        //    GUI.Label(new Rect(Screen.width / 2 * action1.x, Screen.height / 3 * action1.y, Screen.height / 2, Screen.width / 3), "AAAAAAAAAA");
        }
    }

	void Update () {
        //  Debug.Log(fight);
       // DoAction(new Vector4(0, 0, 0, 0));
        if (fight)
        {
           /* if ((debugTimer + 1 < Time.time) && (debugFlag == 1))
            {
                DoAction(new Vector4(1, 0, 0, 1));
                debugFlag = 2;
            }
            
            if ((debugTimer + 2 < Time.time) && (debugFlag == 2))
            {
                DoAction(new Vector4(1, 2, 2, 1));
                debugFlag = 3;
            }/*
            if ((debugTimer + 3 < Time.time) && (debugFlag == 3))
            {
                DoAction(new Vector4(0, 0, 0, 0));
                debugFlag = 4;
            }
            if ((debugTimer + 4 < Time.time) && (debugFlag == 4))
            {
                DoAction(new Vector4(0, 2, 2, 0));
                debugFlag = 5;
            }*/
            if (firstAction)
            {

                if ((action1.x == action1.w))
                {
                    if (Time.time - timer1 > 0.15 * Abs(action1.y - action1.z))
                    {
                        firstAction = false;
                        stateRight = newRight;
                    }
                }
            }
            if (secondAction)
            {

                if ((action2.x == action2.w))
                {
                    if (Time.time - timer2 > 0.15 * Abs(action2.y - action2.z))
                    {
                        // Debug.Log(5);
                        secondAction = false;
                        stateLeft = newLeft;
                    }
                }
            }
            if (firstEAction)
            {
                //Debug.Log(waitTimerRight);
                if ((action1e.x == action1e.w))
                {
                    if (Time.time - timer1e > 0.15 * Abs(action1e.y - action1e.z))
                    {
                        firstEAction = false;
                        stateERight = newERight;
                        //  Debug.Log(stateERight);
                        // Debug.Log(stateLeft);
                        //Debug.Log("----------");
                    }
                }
            }
            else
            {
                if ((stateERight != stateLeft))
                {
                    // Debug.Log(waitTimerRight);
                    //Debug.Log(Time.time);
                    //Debug.Log("------------");
                    if (waitTimerRight + 2 < Time.time)
                    {
                        ActiveEnemy(new Vector4(1, stateERight, stateERight, 1));
                        waitTimerRight = Time.time;
                    }
                }
                else
                {
                    int rand = 1;
                    if ((int)Time.time / 2 == 0)
                    {
                        rand = -1;
                    }
                    // Debug.Log((stateERight + rand + 3) % 3);
                    if (waitTimerRight + 2 < Time.time)
                    {
                        firstEAction = true;
                        ActiveEnemy(new Vector4(1, (stateERight + rand + 3) % 3, (stateERight + rand + 3) % 3, 1));
                    }
                }
            }
            if (secondEAction)
            {

                if ((action2e.x == action2e.w))
                {
                    if (Time.time - timer2e > 0.15 * Abs(action2e.y - action2e.z))
                    {
                        waitTimerLeft = Time.time;
                        secondEAction = false;
                        stateELeft = newELeft;
                    }
                }
            }
            else
            {
                if ((stateELeft != stateRight) && (waitTimerLeft + 1.5 < Time.time))
                {
                 //   if ((stateELeft == 0) && ((int)Time.time % 2 == 0))
                   // {
                    //    ActiveEnemy(new Vector4(0, stateELeft, stateELeft, 0));
                   // }
                    //else
                    //{
                        ActiveEnemy(new Vector4(0, stateRight, stateRight, 0));
                       // Debug.Log(new Vector4(0, stateRight, stateRight, 0));
                    //}
                    //waitTimerLeft = Time.time;
                    secondEAction = true;
                }
                else
                {
                    //       int rand = 1;
                    //     if ((int)Time.time / 2 == 0)
                    //   {
                    //     rand = -1;
                    //}/
                    //ActiveEnemy(new Vector4(0, (stateELeft + rand + 3) % 3, (stateELeft + rand + 3) % 3, 0));
                }
            }
        }
    }

       void DoAction(Vector4 act)
       {
           if (act.x == 1)
           {
               timer1 = Time.time;
               if (act.w == 1)
               {
                   if (act.y == act.z)
                   {
                       if (stateRight != act.y)
                       {
                           firstAction = true;
                           newRight = (int)act.y;
                           //Debug.Log(stateRight);
                           //Debug.Log(newRight);
                           //Debug.Log("---------");
                           if (stateRight == 0)
                           {
                               if (act.y == 1)
                               {
                                   swordAnim.Play("SwordUpMId");
                               }
                               if (act.y == 2)
                               {
                                   swordAnim.Play("SwordUp-Down");
                               }
                           }
                           if (stateRight == 1)
                           {
                               if (act.y == 0)
                               {
                                   swordAnim.Play("SwordMid-Up");
                               }
                               if (act.y == 2)
                               {
                                   swordAnim.Play("New Animation");
                               }
                           }
                           if (stateRight == 2)
                           {
                               if (act.y == 1)
                               {
                                   swordAnim.Play("SwordDown-Mid");
                               }
                               if (act.y == 0)
                               {
                                   swordAnim.Play("SwordDown-Up");
                               }
                           }
                       }
                       else
                       {
                           if (stateRight == 0)
                           {
                               swordAnim.Play("SwA24-4");
                           }
                           if (stateRight == 1)
                           {
                               swordAnim.Play("SwA5-5");
                           }
                           if (stateRight == 2)
                           {
                               swordAnim.Play("SwA26-6");
                           }
                       }
                   }
               }
           }
           if (act.x == 0)
           {
               timer2 = Time.time;
               if (act.w == 0)
               {
                   if (act.y == act.z)
                   {
                       if (stateLeft != act.y)
                       {
                           secondAction = true;
                           newLeft = (int)act.y;
                          // Debug.Log(stateRight);
                           //Debug.Log(newRight);
                           //Debug.Log("---------");
                           if (stateLeft == 0)
                           {
                               if (act.y == 1)
                               {
                                   shieldAnim.Play("ShieldUp-Mid");
                               }
                               if (act.y == 2)
                               {
                                   shieldAnim.Play("ShieldDown-Up2");
                               }
                           }
                           if (stateLeft == 1)
                           {
                               if (act.y == 0)
                               {
                                   shieldAnim.Play("ShieldMId-Up");
                               }
                               if (act.y == 2)
                               {
                                   shieldAnim.Play("ShieldMId-Down");
                               }
                           }
                           if (stateLeft == 2)
                           {
                               if (act.y == 1)
                               {
                                   shieldAnim.Play("ShieldDown-Mid");
                               }
                               if (act.y == 0)
                               {
                                   shieldAnim.Play("ShieldUp-Down2");
                               }
                           }
                       }
                       else
                       {
                           if (stateLeft == 0)
                           {
                               shieldAnim.Play("ShA1-1");
                           }
                           if (stateLeft == 1)
                           {
                               shieldAnim.Play("ShA2-2");
                           }
                       }
                   }
               }
           }
       }
       /*
    void DoAction(Vector4 act)
    {
        if (act.x == 1)
        {
            firstAction = true;
            newLeft = (int)act.z;
            timer1 = Time.time;
            if(stateRight == 0)
            {
                if (act.w == 1)
                {
                    if (act.y == 0)
                    {
                        if (act.z == 0)
                        {
                            swordAnim.Play("SwA24-4");
                        }
                        if (act.z == 1)
                        {
                            swordAnim.Play("SwordUpMId");
                        }
                        if (act.z == 2)
                        {
                            swordAnim.Play("SwordUp-Down");
                        }
                    }
                }
            }
            if (stateRight == 1)
            {
                if (act.w == 1)
                {
                    if (act.y == 0)
                    {
                        if (act.z == 0)
                        {
                            swordAnim.Play("SwordMid-Up");
                        }
                        if (act.z == 1)
                        {
                            swordAnim.Play("SwA5-5");
                        }
                        if (act.z == 2)
                        {
                            swordAnim.Play("New Animation");
                        }
                    }
                }
            }
            if (stateRight == 2)
            {
                if (act.w == 1)
                {
                    if (act.y == 0)
                    {
                        if (act.z == 0)
                        {
                            swordAnim.Play("SwA24-4");
                        }
                        if (act.z == 1)
                        {
                            swordAnim.Play("SwordDown-Up");
                        }
                        if (act.z == 2)
                        {
                            swordAnim.Play("SwA26-6");
                        }
                    }
                }
            }
        }
        if (act.x == 0)
        {
            timer2 = Time.time;
            if (act.w == 0)
            {
                if (act.y == act.z)
                {
                    if (stateLeft != act.y)
                    {
                        secondAction = true;
                        newLeft = (int)act.y;
                        // Debug.Log(stateRight);
                        //Debug.Log(newRight);
                        //Debug.Log("---------");
                        if (stateLeft == 0)
                        {
                            if (act.y == 1)
                            {
                                shieldAnim.Play("ShieldUp-Mid");
                            }
                            if (act.y == 2)
                            {
                                shieldAnim.Play("ShieldDown-Up2");
                            }
                        }
                        if (stateLeft == 1)
                        {
                            if (act.y == 0)
                            {
                                shieldAnim.Play("ShieldMId-Up");
                            }
                            if (act.y == 2)
                            {
                                shieldAnim.Play("ShieldMId-Down");
                            }
                        }
                        if (stateLeft == 2)
                        {
                            if (act.y == 1)
                            {
                                shieldAnim.Play("ShieldDown-Mid");
                            }
                            if (act.y == 0)
                            {
                                shieldAnim.Play("ShieldUp-Down2");
                            }
                        }
                    }
                    else
                    {
                        if (stateLeft == 0)
                        {
                            shieldAnim.Play("ShA1-1");
                        }
                        if (stateLeft == 1)
                        {
                            shieldAnim.Play("ShA2-2");
                        }
                    }
                }
            }
        }
    }*/

    void DoEnemyAction(Vector4 act)
    {
        if (act.x == 1)
        {
            timer1e = Time.time;
            if (act.w == 1)
            {
                if (act.y == act.z)
                {
                   // Debug.Log(stateERight);
                    if (stateERight != act.y)
                    {
                        firstEAction = true;
                        newERight = (int)act.y;
                        //Debug.Log(stateRight);
                        //Debug.Log(newRight);
                        //Debug.Log("---------");
                        if (stateERight == 0)
                        {
                            if (act.y == 1)
                            {
                                swordEAnim.Play("SwordUpMId");
                            }
                            if (act.y == 2)
                            {
                                swordEAnim.Play("SwordUp-Down");
                            }
                        }
                        if (stateERight == 1)
                        {
                            if (act.y == 0)
                            {
                               // Debug.Log(1);
                                swordEAnim.Play("SwordMid-Up");
                            }
                            if (act.y == 2)
                            {
                                swordEAnim.Play("New Animation");
                            }
                        }
                        if (stateERight == 2)
                        {
                            if (act.y == 1)
                            {
                                swordEAnim.Play("SwordDown-Mid");
                            }
                            if (act.y == 0)
                            {
                                swordEAnim.Play("SwordDown-Up");
                            }
                        }
                    }
                    else
                    {
                        if (stateERight == 0)
                        {
                           // Debug.Log(0);
                            //Debug.Log("-------");
                            swordEAnim.Play("SwA24-4");
                        }
                        if (stateERight == 1)
                        {
                            swordEAnim.Play("SwA5-5");
                        }
                        if (stateERight == 2)
                        {
                         //   Debug.Log(7);
                            swordEAnim.Play("SwA26-6");
                        }
                    }
                }
            }
        }
        if (act.x == 0)
        {
            timer2e = Time.time;
            if (act.w == 0)
            {
                if (act.y == act.z)
                {
                    if (stateELeft != act.y)
                    {
                        secondEAction = true;
                        newELeft = (int)act.y;
                        // Debug.Log(stateRight);
                        //Debug.Log(newRight);
                        //Debug.Log("---------");
                        if (stateELeft == 0)
                        {
                            if (act.y == 1)
                            {
                                shieldEAnim.Play("ShieldUp-Mid");
                            }
                            if (act.y == 2)
                            {
                                shieldEAnim.Play("ShieldDown-Up2");
                            }
                        }
                        if (stateELeft == 1)
                        {
                            if (act.y == 0)
                            {
                                shieldEAnim.Play("ShieldMId-Up");
                            }
                            if (act.y == 2)
                            {
                                shieldEAnim.Play("ShieldMId-Down");
                            }
                        }
                        if (stateELeft == 2)
                        {
                            if (act.y == 1)
                            {
                                shieldEAnim.Play("ShieldDown-Mid");
                            }
                            if (act.y == 0)
                            {
                                shieldEAnim.Play("ShieldUp-Down2");
                            }
                        }
                    }
                    else
                    {
                        if (stateELeft == 0)
                        {
                          //  shieldEAnim.Play("ShA1-1");
                        }
                        if (stateELeft == 1)
                        {
                          //  shieldEAnim.Play("ShA2-2");
                        }
                    }
                }
            }
        }
    }

    public void Active(Vector4 move)
    {
        if (move.x == 0)
        {
            action2 = move;
            main.SendMessage("setPSh", new Vector4(stateLeft, move.w * 3 + move.z, Time.time, Time.time + (float)0.25 * (Abs(move.y - move.z) + Abs(move.x - move.w))));
        }
        else
        {
            action1 = move;
          //  Debug.Log(new Vector4(move.x * 3 + move.y, move.w * 3 + move.z, Time.time, Time.time + (float)0.25));
            main.SendMessage("setPSw", new Vector4(stateRight + 3, move.w * 3 + move.z, Time.time, Time.time + (float)0.25 * (Abs(move.y - move.z) + Abs(move.x - move.w))));
        }
        DoAction(move);
    }

    public void ActiveEnemy(Vector4 move)
    {
        if (move.x == 1)
        {
            action1e = move;
            main.SendMessage("setESw", new Vector4(move.x * 3 + move.y, move.w * 3 + move.z, Time.time, Time.time + (float)0.25 * (Abs(move.y - move.z) + Abs(move.x - move.w))));
        }
        else
        {
            action2e = move;
            main.SendMessage("setESh", new Vector4(move.x * 3 + move.y, move.w * 3 + move.z, Time.time, Time.time + (float)0.25 * (Abs(move.y - move.z) + Abs(move.x - move.w))));
        }
        DoEnemyAction(move);
    }
}
