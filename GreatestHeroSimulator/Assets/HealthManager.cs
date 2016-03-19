using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    // Use this for initialization
    public GameObject main;
    bool options;

    public GUIStyle stNorm;
    public GUIStyle stNorm1;
    public GUIStyle stAxeT;
    public GUIStyle stAxeF;
    public GUIStyle stSwT;
    public GUIStyle stSwF;
    public GUIStyle stSh1T;
    public GUIStyle stSh1F;
    public GUIStyle stSh2T;
    public GUIStyle stSh2F;
    public GUIStyle stM1T;
    public GUIStyle stM2F;
    public GUIStyle stM2T;
    public GUIStyle stM1F;

    private Vector4 pSwState;
    private Vector4 pShState;
    private Vector4 eSwState;
    private Vector4 eShState;
    private bool pSw;
    private bool pSh;
    private bool eSw;
    private bool eSh;

    public GameObject blood;

    public void SetBlood(GameObject go)
    {
        blood = go;
    }

    public void GetBlood()
    {
        blood.SendMessage("Gen");
    }

    int wins = 0;
    int lose = 0;
    bool win;

    public AudioSource AS;
    public AudioSource ASe;
    public AudioSource AS1;
    public AudioSource AS1e;
    public AudioSource AS2;
    public AudioSource AS2e;
    public AudioSource fon;
    public AudioClip hitSound;
    public AudioClip swToShSound;
    public AudioClip shieldHitSound;
    public AudioClip fonClip;

    private int enemyHealth;
    private int playerHealth;

    private bool menu;
    private bool fight;

    public GameObject mainPref;

    private float audioTimer;
    private bool audioFlag;
    private float audioTimerE;
    private bool audioFlagE;
    private float audioTimer1;
    private bool audioFlag1;
    private float audioTimer2;
    private bool audioFlag2;
    private float audioTimer1e;
    private bool audioFlag1e;
    private float audioTimer2e;
    private bool audioFlag2e;
    bool sword;
    bool map;
    bool shield;

    public void Fight()
    {
        options = false;
        win = false;
        pSwState = new Vector4(4, 4, 0, 0);
        pShState = new Vector4(1, 1, 0, 0);
        eSwState = new Vector4(4, 4, 0, 0);
        eShState = new Vector4(1, 1, 0, 0);
        main = GameObject.Instantiate(mainPref);
        this.gameObject.GetComponent<Camera>().enabled = false;
        this.gameObject.GetComponent<AudioListener>().enabled = false;
        audioTimer = Time.time;
        audioFlag = false;
        audioTimerE = Time.time;
        audioFlagE = false;
        audioTimer1 = Time.time;
        audioFlag1 = false;
        audioTimer2 = Time.time;
        audioFlag2 = false;
        audioTimer1e = Time.time;
        audioFlag1e = false;
        audioTimer2e = Time.time;
        audioFlag2e = false;
        fight = !fight;
        enemyHealth = 10;
        playerHealth = 10;
        AS1.clip = swToShSound;
        AS.clip = hitSound;
        AS2.clip = shieldHitSound;
        AS1e.clip = swToShSound;
        ASe.clip = hitSound;
        AS2e.clip = shieldHitSound;
    }
    
	void Start () {
        menu = true;
        fon.enabled = false;
        fon.clip = fonClip;
        fon.enabled = true;
        sword = true;
        shield = true;
        map = false;
    }

    void PlayHit()
    {
        audioFlag = true;
        audioTimer = Time.time;
    }

    public void PlaySwShield()
    {
        audioFlag1 = true;
        audioTimer1 = Time.time;
    }

    public void PlayShieldHit()
    {
        audioFlag2 = true;
        audioTimer2 = Time.time;
    }

    void PlayEHit()
    {
        audioFlagE = true;
        audioTimerE = Time.time;
    }

    public void PlayESwShield()
    {
        audioFlag1e = true;
        audioTimer1e = Time.time;
    }

    public void PlayEShieldHit()
    {
        audioFlag2e = true;
        audioTimer2e = Time.time;
    }

    void OnGUI()
    {
        AS.enabled = audioFlag;
        if (Time.time - 1 > audioTimer)
        {
            audioFlag = false;
        }
        ASe.enabled = audioFlagE;
        if (Time.time - 1 > audioTimerE)
        {
            audioFlagE = false;
        }
        AS1.enabled = audioFlag1;
        if (Time.time - 1 > audioTimer1)
        {
            audioFlag1 = false;
        }
        AS2.enabled = audioFlag2;
        if (Time.time - 1 > audioTimer2)
        {
            audioFlag2 = false;
        }
        AS1e.enabled = audioFlag1e;
        if (Time.time - 1 > audioTimer1e)
        {
            audioFlag1e = false;
        }
        AS2e.enabled = audioFlag2e;
        if (Time.time - 1 > audioTimer2e)
        {
            audioFlag2e = false;
        }
        if (menu)
        {
            if (options)
            {
                GUIStyle gs;
                gs = stSwF;
                if (sword)
                {
                    gs = stSwT;
                }
                if (GUI.Button(new Rect(0, 0, Screen.width / 4, Screen.height / 2), "Sword", gs))
                {
                    sword = true;
                }
                gs = stAxeF;
                if (!sword)
                {
                    gs = stAxeT;
                }
                if (GUI.Button(new Rect(Screen.width / 4, 0, Screen.width / 4, Screen.height / 2), "Axe", gs))
                {
                    sword = false;
                }
                gs = stSh1F;
                if (shield)
                {
                    gs = stSh1T;
                }
                if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 4, Screen.height / 2), "Viking shield", gs))
                {
                    shield = true;
                }
                gs = stSh2F;
                if (!shield)
                {
                    gs = stSh2T;
                }
                if (GUI.Button(new Rect(Screen.width / 4 * 3, 0, Screen.width / 4, Screen.height / 2), "Knight shield", gs))
                {
                    shield = false;
                }
                gs = stM1F;
                if (map)
                {
                    gs = stM1T;
                }
                if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width / 4, Screen.height / 2), "Map1", gs))
                {
                    map = true;
                }
                gs = stM2F;
                if (!map)
                {
                    gs = stM2T;
                }
                if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 4, Screen.height / 2), "Map2", gs))
                {
                    map = false;
                }
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Back", stNorm))
                {
                    options = !options;
                }
            }
            else
            {
                if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "Start", stNorm))
                {
                    menu = false;
                    Fight();
                    main.SendMessage("Fight", this.gameObject);
                    main.SendMessage("SetWeapon", sword);
                    main.SendMessage("SetShield", shield);

                }
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Exit", stNorm))
                {
                    Application.Quit();
                }
                if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2), "Options", stNorm))
                {
                    options = !options;
                }
                if (!((wins == 0) && (lose == 0)))
                {
                    if (win)
                    {
                        GUI.Label(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "You win", stNorm1);
                    }
                    else
                    {
                        GUI.Label(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "You lose", stNorm1);
                    }
                }
                else
                {
                    GUI.Label(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "", stNorm1);
                }
                GUI.Label(new Rect(0, Screen.height / 4 * 3, Screen.width / 2, Screen.height / 2), wins.ToString() + ":" + lose.ToString(), stNorm1);
            }

        }
        else
        {
            string s = playerHealth.ToString();
            GUI.Label(new Rect(0, 0, Screen.width / 2, Screen.height), s);//playerHealth.ToString);
            s = enemyHealth.ToString();
            GUI.Label(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height), s);// enemyHealth.ToString);
        }
    }

    public void setPSw(Vector4 action)
    {
        pSwState = action;
        pSw = true;
    }

    public void setPSh(Vector4 action)
    {
        pShState = action;
       // Debug.Log(action);
        pSh = true;
    }

    public void setESw(Vector4 action)
    {
        eSwState = action;
        eSw = true;
        //Debug.Log(1);
    }

    public void setESh(Vector4 action)
    {
        eShState = action;
        eSh = true;
    }


    void DoPSwAction(Vector4 action)
    {
      //  Debug.Log(action);
        //Debug.Log(eShState);
        if (action.x == action.y)
        {
            // if ((eShState.x == (action.y + 3) % 6) && (eShState.w < Time.time))
            //{

            //}
            //else
            //{
                if ((eShState.y == (action.y + 3) % 6) && (eShState.w > Time.time))
                {
                    PlaySwShield();
                }
                else
                {
                   // if (((int)action.x == 5) && ((int)eShState.x))
                    enemyHealth -= 1;
                    PlayHit();
                    GetBlood();
                }
            //}
        }
    }

    void DoPShAction(Vector4 action)
    {
        if (action.x == action.y)
        {
            if (action.x == 0) {//(((int)pShState.x == 0) && ((int)pShState.y == 0)){
       //         enemyHealth -= 1;
                //Debug.Log(0);
         //       PlayShieldHit();
            }
        }
    }

    void DoESwAction(Vector4 action)
    {
        // Debug.Log(2);
      //  Debug.Log(action);
       // Debug.Log(pShState);
        if (action.x == action.y)
        {
           // if ((pShState.x == (action.y + 3) % 6) && (pShState.w < Time.time))
            //{
             //   Debug.Log(1);
           // }
           // else
           // {
                if ((pShState.y == (action.y + 3) % 6) && (pShState.w > Time.time))
                {
                // Debug.Log(2);
                PlayESwShield();
                }
                else
                {
                    // if (((int)action.x == 5) && ((int)eShState.x))
                    playerHealth -= 1;
                    PlayEHit();
                }
            //}
        }
    }

    void DoEShAction(Vector4 action)
    {
        if (action.x == action.y)
        {
            if (((int)eShState.x == 0) && ((int)eShState.y == 0))
            {
           //     playerHealth -= 1;
             //   PlayEShieldHit();
            }
        }
    }
    // Update is called once per frame
    void Update () {
        fon.enabled = true;
        if (fight)
        {
           // Debug.Log(10);
            if ((pSwState.w < Time.time) && pSw)
            {
                DoPSwAction(pSwState);
                pSw = false;
            }
            if ((pShState.w < Time.time) && pSh)
            {
                DoPShAction(pShState);
                pSh = false;
            }
            if ((eSwState.w < Time.time) && eSw)
            {
                DoESwAction(eSwState);
                eSw = false;
            }
            if ((eShState.w < Time.time) && eSh)
            {
                DoEShAction(eShState);
                eSh = false;
            }
            if (playerHealth < 1)
            {
                fight = false;
                menu = true;
                this.gameObject.GetComponent<Camera>().enabled = true;
                this.gameObject.GetComponent<AudioListener>().enabled = true;
                win = false;
                lose++;
                Destroy(main);
            }
            if (enemyHealth < 1)
            {
                fight = false;
                menu = true;
                this.gameObject.GetComponent<Camera>().enabled = true;
                this.gameObject.GetComponent<AudioListener>().enabled = true;
                win = true;
                wins++;
                Destroy(main);
            }
        }
	}
}
