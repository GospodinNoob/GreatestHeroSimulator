using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class HealthManager : MonoBehaviour {

    // Use this for initialization
    public GameObject main;
    bool options;

    public GameObject go1;

    public Texture2D gal;

    public GUIStyle stNorm;
    public GUIStyle stNormTex;
    public GUIStyle stNorm1;
    public GUIStyle stAxeT;
    public GUIStyle stAxeF;
    public GUIStyle stSwT;
    public GUIStyle stSwF;
    public GUIStyle stSh1T;
    public GUIStyle stSh1F;
    public GUIStyle stSh2T;
    public GUIStyle stSh2F;
    public GUIStyle stSh3T;
    public GUIStyle stSh3F;
    public GUIStyle levelSt1;
    public GUIStyle levelSt2;
    public GUIStyle stHalberdT;
    public GUIStyle stHalberdF;
    public GUIStyle stAdv;

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

    int winsLow = 0;
    int loseLow = 0;
    int winsMed = 0;
    int loseMed = 0;
    int winsHigh = 0;
    int loseHigh = 0;
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
    private bool adv;
    int sword;
    int level;
    int shield;

    public Texture2D enemyHT;
    public Texture2D playerHT;
    public Texture2D plSw;
    public Texture2D eSwT;
    public Texture2D plSh;
    public Texture2D eShT;

    public Texture2D locked;

    private bool paidSw;
    private bool paidSh;

    public void ShowAd()
    {
     //   if (Advertisement.IsReady())
       // {
        //    Advertisement.Show();
       // }
        adv = false;
    }

    public void Fight()
    {
        options = false;
        win = false;
        go1.active = false;
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

    private void Save()
    {
        PlayerPrefs.SetInt("Weapon", sword);
        PlayerPrefs.SetInt("Shield", sword);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("WL", winsLow);
        PlayerPrefs.SetInt("WM", winsMed);
        PlayerPrefs.SetInt("WH", winsHigh);
        PlayerPrefs.SetInt("LL", loseLow);
        PlayerPrefs.SetInt("LM", loseMed);
        PlayerPrefs.SetInt("LH", loseHigh);
        if (paidSw)
        {
            PlayerPrefs.SetInt("PaidSw", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PaidSw", 0);
        }
        if (paidSh)
        {
            PlayerPrefs.SetInt("PaidSh", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PaidSh", 0);
        }
    }

    private void Load()
    {
        sword = PlayerPrefs.GetInt("Weapon");
        shield = PlayerPrefs.GetInt("Shield");
        level = PlayerPrefs.GetInt("Level");
        winsLow = PlayerPrefs.GetInt("WL");
        winsMed = PlayerPrefs.GetInt("WM");
        winsHigh = PlayerPrefs.GetInt("WH");
        loseLow = PlayerPrefs.GetInt("LL");
        loseMed = PlayerPrefs.GetInt("LM");
        loseHigh = PlayerPrefs.GetInt("LH");
        if (PlayerPrefs.GetInt("PaidSw") == 1)
        {
            paidSw = true;
        }
        else
        {
            paidSh = false;
        }
        if (PlayerPrefs.GetInt("PaidSh") == 1)
        {
            paidSh = true;
        }
        else
        {
            paidSh = false;
        }
    }
    
	void Start () {
        menu = true;
        fon.enabled = false;
        fon.clip = fonClip;
        fon.enabled = true;
        sword = 1;
        shield = 1;
        level = 1;
        loseHigh = 0;
        loseMed = 0;
        loseLow = 0;
        winsHigh = 0;
        winsLow = 0;
        winsMed = 0;
        paidSh = false;
        paidSw = false;
        adv = false;
        if (PlayerPrefs.GetInt("New") != 1)
        {
            Save();
            PlayerPrefs.SetInt("New", 1);
        }
        else
        {
            Load();
        }
        go1.active = true;
      //  ShowAd();
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

    private float exitTimer;
    private float exitClickTimer;

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
        if (adv)
        {
         //   GUI.Label(new Rect(0, 0, Screen.width, Screen.height / 4), "Please watch the full video, it will help game better!", stAdv);
          //  GUI.Label(new Rect(0, Screen.height / 4, Screen.width, Screen.height / 4), "Would you like to watch the advertising?", stAdv);
            /// GUI.Label(new Rect(0, 0, Screen.height / 4, Screen.width), "Please watch the full video, it will help game better!", stAdv);
            // GUI.Label(new Rect(0, Screen.height / 4, Screen.height / 4, Screen.width), "Would you like to watch the advertising?", stAdv);
        //    if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Yes", levelSt1)) 
         //   {
          //      ShowAd();
          //  }
          //  if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "No", levelSt1))
          //  {
          //      adv = false;
           // }
        }
        else
        {
            if (menu)
            {
                if (options)
                {
                    GUIStyle gs;
                    gs = stSwF;
                    if (sword == 1)
                    {
                        gs = stSwT;
                    }
                    if (GUI.Button(new Rect(0, 0, Screen.width / 6, Screen.height / 2), "", gs))
                    {
                        sword = 1;
                    }
                    gs = stAxeF;
                    if (sword == 2)
                    {
                        gs = stAxeT;
                    }
                    if (GUI.Button(new Rect(Screen.width / 6, 0, Screen.width / 6, Screen.height / 2), "", gs) && (winsHigh > 0))
                    {
                        sword = 2;
                    }
                    if (winsHigh == 0)
                    {
                        GUI.DrawTexture(new Rect(Screen.width / 6, 0, Screen.width / 6, Screen.height / 2), locked);
                    }
                      gs = stHalberdF;
                     if (sword == 3)
                     {
                       gs = stHalberdT;
                     }
                     if (GUI.Button(new Rect(Screen.width / 3, 0, Screen.width / 6, Screen.height / 2), "", gs) && !(winsHigh == 0))
                     {
                         sword = 3;
                     }
                     if ((winsHigh == 0))
                     {
                         GUI.DrawTexture(new Rect(Screen.width / 3, 0, Screen.width / 6, Screen.height / 2), locked);
                     }



                    gs = stSh1F;
                    if (shield == 1)
                    {
                        gs = stSh1T;
                    }
                    if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 6, Screen.height / 2), "", gs))
                    {
                        shield = 1;
                    }
                    gs = stSh2F;
                    if (shield == 2)
                    {
                        gs = stSh2T;
                    }
                    if (GUI.Button(new Rect(Screen.width / 6 * 4, 0, Screen.width / 6, Screen.height / 2), "", gs) && (winsHigh > 0))
                    {

                        shield = 2;
                    }
                    if (winsHigh == 0)
                    {
                        GUI.DrawTexture(new Rect(Screen.width / 6 * 4, 0, Screen.width / 6, Screen.height / 2), locked);
                    }
                     gs = stSh3F;
                    if (shield == 3)
                     {
                        gs = stSh3T;
                     }
                      if (GUI.Button(new Rect(Screen.width / 6 * 5, 0, Screen.width / 6, Screen.height / 2), "", gs) && !(winsHigh == 0))
                     {

                     shield = 3;
                     }
                       if (winsHigh == 0)
                      {
                         GUI.DrawTexture(new Rect(Screen.width / 6 * 5, 0, Screen.width / 6, Screen.height / 2), locked);
                     }
                    gs = levelSt1;
                    if (level == 1)
                    {
                        gs = levelSt2;
                    }
                    if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 6), "Easy", gs))
                    {
                        level = 1;
                    }
                    gs = levelSt1;
                    if (level == 2)
                    {
                        gs = levelSt2;
                    }
                    if (GUI.Button(new Rect(0, Screen.height / 6 * 4, Screen.width / 2, Screen.height / 6), "Medium", gs) && (winsLow > 0))
                    {
                        level = 2;
                    }
                    if (winsLow == 0)
                    {
                        GUI.DrawTexture(new Rect(0, Screen.height / 6 * 4, Screen.width / 2, Screen.height / 6), locked);
                    }
                    gs = levelSt1;
                    if (level == 3)
                    {
                        gs = levelSt2;
                    }
                    if (GUI.Button(new Rect(0, Screen.height / 6 * 5, Screen.width / 2, Screen.height / 6), "Hard", gs) && (winsMed > 0))
                    {
                        level = 3;
                    }
                    if (winsMed == 0)
                    {
                        GUI.DrawTexture(new Rect(0, Screen.height / 6 * 5, Screen.width / 2, Screen.height / 6), locked);
                    }
                    // GUI.Label(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "", stNorm1);
                    // if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 4, Screen.height / 2), "Map2", gs))
                    //  {
                    //     map = false;
                    //}
                     if (winsLow > 0)
                    {
                    GUI.DrawTexture(new Rect(0, Screen.height / 2, Screen.height / 6, Screen.height / 6), gal);
                    }
                    if (winsMed > 0)
                    {
                        GUI.DrawTexture(new Rect(0, Screen.height / 2, Screen.height / 6, Screen.height / 6), gal);
                    }
                    if (winsHigh > 0)
                    {
                        GUI.DrawTexture(new Rect(0, Screen.height / 2, Screen.height / 6, Screen.height / 6), gal);
                    }
                    if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Back", stNorm))
                    {
                        Save();
                        options = !options;
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height / 3), "Start", stNorm))
                    {
                        menu = false;
                        Fight();
                        main.SendMessage("Fight", this.gameObject);
                        main.SendMessage("SetWeapon", sword);
                        main.SendMessage("SetShield", shield);
                        main.SendMessage("SetLevel", level);

                    }
                 //   if (GUI.RepeatButton(new Rect(0, Screen.height / 3, Screen.width / 2, Screen.height / 2), "Exit", stNorm))
                   // {
                     //   if (exitClickTimer - 1.2 > exitTimer)
                      //  {
                          //  ShowAd();
                        //    Save();
                          //  Application.Quit();
                            //Debug.Log(11);
                        //}
                        //exitClickTimer = Time.time;
                   // }
                    //else
                    //{
                      //  if (Event.current.type == EventType.Repaint)
                       // {
                        //    exitTimer = Time.time;
                        //}
                   // }
                    if (GUI.Button(new Rect(0, Screen.height / 3, Screen.width / 2, Screen.height / 3), "Options", stNorm))
                    {
                        options = !options;
                    }
                    if (level == 1)
                    {

                        if (!((winsLow == 0) && (loseLow == 0)))
                        {
                            if (win)
                            {
                                GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "You win", stNorm1);
                            }
                            else
                            {
                                GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "You lose", stNorm1);
                            }
                        }
                        else
                        {
                            GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "", stNorm1);
                        }
                        GUI.Label(new Rect(0, Screen.height / 6 * 5, Screen.width / 2, Screen.height / 6), winsLow.ToString() + ":" + loseLow.ToString(), stNorm1);
                    }
                    if (level == 2)
                    {

                        if (!((winsMed == 0) && (loseMed == 0)))
                        {
                            if (win)
                            {
                                GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "You win", stNorm1);
                            }
                            else
                            {
                                GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "You lose", stNorm1);
                            }
                        }
                        else
                        {
                            GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "", stNorm1);
                        }
                        GUI.Label(new Rect(0, Screen.height / 6 * 5, Screen.width / 2, Screen.height / 6), winsMed.ToString() + ":" + loseMed.ToString(), stNorm1);
                    }
                    if (level == 3)
                    {

                        if (!((winsHigh == 0) && (loseHigh == 0)))
                        {
                            if (win)
                            {
                                GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "You win", stNorm1);
                            }
                            else
                            {
                                GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "You lose", stNorm1);
                            }
                        }
                        else
                        {
                            GUI.Label(new Rect(0, Screen.height / 3 * 2, Screen.width / 2, Screen.height / 3), "", stNorm1);
                        }
                        GUI.Label(new Rect(0, Screen.height / 6 * 5, Screen.width / 2, Screen.height / 6), winsHigh.ToString() + ":" + loseHigh.ToString(), stNorm1);
                    }
                }

            }
            else
            {
                string s = playerHealth.ToString();
                // Debug.Log(eShState.y);
                if (level != 3)
                {
                    GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 3 * (pSwState.y - 3), Screen.width / 8, Screen.height / 12), plSw);
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 3 * pShState.y, Screen.width / 8, Screen.height / 12), plSh);
                    GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 3 * (eSwState.y - 3), Screen.width / 8, Screen.height / 12), eSwT);
                    GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 3 * eShState.y, Screen.width / 10, Screen.height / 12), eShT);
                }

                GUI.DrawTexture(new Rect(0, 0, Screen.width / 6, Screen.height / 4), playerHT);
                GUI.DrawTexture(new Rect(Screen.width / 6 * 5, 0, Screen.width / 6, Screen.height / 4), enemyHT);
                GUI.Label(new Rect(0, 0, Screen.width / 6, Screen.height / 4), s, stNormTex);//playerHealth.ToString);
                s = enemyHealth.ToString();
                GUI.Label(new Rect(Screen.width / 6 * 5, 0, Screen.width / 6, Screen.height / 4), s, stNormTex);// enemyHealth.ToString);
            }
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
       // Debug.Log(eShState);
        //Debug.Log(Time.time);
        //Debug.Log((action.y + 3) % 6);
       // Debug.Log(1);
        if (action.x == action.y)
        {
            // if ((eShState.x == (action.y + 3) % 6) && (eShState.w < Time.time))
            //{

            //}
            //else
            //{
                if ((eShState.y == (action.y + 3) % 6) && (eShState.w < Time.time))
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
                if ((pShState.y == (action.y + 3) % 6) && (pShState.w < Time.time))
                {
                // Debug.Log(2);
                PlayESwShield();
                }
                else
                {
                    // if (((int)action.x == 5) && ((int)eShState.x))
                    playerHealth -= 1;
                    PlayEHit();
                    Handheld.Vibrate();
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
                go1.active = true;
                menu = true;
                this.gameObject.GetComponent<Camera>().enabled = true;
                this.gameObject.GetComponent<AudioListener>().enabled = true;
                win = false;
                if (level == 1)
                {
                    loseLow++;
                }
                if (level == 2)
                {
                    loseMed++;
                }
                if (level == 3)
                {
                    loseHigh++;
                }
                Save();
                Destroy(main);
            }
            if (enemyHealth < 1)
            {
                go1.active = true;
                fight = false;
                menu = true;
                this.gameObject.GetComponent<Camera>().enabled = true;
                this.gameObject.GetComponent<AudioListener>().enabled = true;
                win = true;
                Save();
                if (level == 1)
                {
                    winsLow++;
                    if (winsLow % 3 == 0)
                    {
                      //  adv = true;
                    }
                }
                if (level == 2)
                {
                    winsMed++;
                    if (winsMed % 3 == 0)
                    {
                       // adv = true;
                    }
                }
                if (level == 3)
                {
                    winsHigh++;
                    if (winsHigh % 3 == 0)
                    {
                      //  adv = true;
                    }
                }
                Destroy(main);
            }
        }
	}
}
