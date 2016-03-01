using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    // Use this for initialization
    public GameObject main;

    private Vector4 pSwState;
    private Vector4 pShState;
    private Vector4 eSwState;
    private Vector4 eShState;
    private bool pSw;
    private bool pSh;
    private bool eSw;
    private bool eSh;

    private int enemyHealth;
    private int playerHealth;

    private bool menu;
    private bool fight;

    public GameObject mainPref;

    public void Fight()
    {
        pSwState = new Vector4(4, 4, 0, 0);
        pShState = new Vector4(1, 1, 0, 0);
        eSwState = new Vector4(4, 4, 0, 0);
        eShState = new Vector4(1, 1, 0, 0);
        main = GameObject.Instantiate(mainPref);
        this.gameObject.GetComponent<Camera>().enabled = false;
        fight = !fight;
        enemyHealth = 10;
        playerHealth = 10;
    }
    
	void Start () {
        menu = true;
	}

    void OnGUI()
    {
        if (menu)
        {
            if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "Start"))
            {
                menu = false;
                Fight();
                main.SendMessage("Fight", this.gameObject);

            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Exit"))
            {
                Application.Quit();
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
        if (action.x == action.y)
        {
           // if ((eShState.x == (action.y + 3) % 6) && (eShState.w < Time.time))
            //{

            //}
            //else
            //{
                if ((eShState.y == (action.y + 3) % 6) && (eShState.w > Time.time))
                {

                }
                else
                {
                   // if (((int)action.x == 5) && ((int)eShState.x))
                    enemyHealth -= 1;
                }
            //}
        }
    }

    void DoPShAction(Vector4 action)
    {
        if (action.x == action.y)
        {
            if (action.x == 0) {//(((int)pShState.x == 0) && ((int)pShState.y == 0)){
                enemyHealth -= 1;
                Debug.Log(0);
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
                    Debug.Log(2);
                }
                else
                {
                    // if (((int)action.x == 5) && ((int)eShState.x))
                    playerHealth -= 1;
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
                playerHealth -= 1;
            }
        }
    }
    // Update is called once per frame
    void Update () {
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
                Destroy(main);
            }
            if (enemyHealth < 1)
            {
                fight = false;
                menu = true;
                this.gameObject.GetComponent<Camera>().enabled = true;
                Destroy(main);
            }
        }
	}
}
