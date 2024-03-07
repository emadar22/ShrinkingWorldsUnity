using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    // public variables
    public static GameManager instance;

    #region Vaiables

       [Header("Public Objects")]
        public GameObject createrPrefab;

        public List<GameObject> playersCars = new List<GameObject>();


        [Space] [Header("Public Scripts")] public ShrinkPlanet shrinkPlanet;
        public MeterorSpawner mateorSpawner;
        public GameObject player;

        public bool SetGameTestingVariables,gameStarted;
        [Header("Lists")] public List<GameObject> cois = new List<GameObject>();
        public List<AudioSource> allSources = new List<AudioSource>();
        public EventCaller eventOnStart;

        #endregion
    
    

    public string SceneName {
        get {
            return this.PSceneName.name;
        }
    }

    // private variables
    private Scene PSceneName;

    private void Awake() 
    {
        instance = this;
        PSceneName = SceneManager.GetActiveScene();
    }

    private void Start()
    {
       // Time.timeScale = 0;
        InitializeTestingFactors();

        if (playersCars.Count > 0)
        {
            playersCars.ForEach(obj => obj.SetActive(false));
            playersCars[PlayerPrefsManager.Instance.CurrentSelectedPlayer].SetActive(true);
        }

        if (eventOnStart._event!=null)
        {
            eventOnStart._event.Invoke();
        }

       
    }


    void Update()
    {
        foreach (var obj in coinsList)
        {
            if (obj!=null)
            {
                obj.transform.LookAt(player.transform);
            }
        }
    }
    #region Initialization

    void InitializeTestingFactors()
    {
        if (SetGameTestingVariables)
        {
            PlayerPrefsManager.Instance.SfxVolume = 1;
        }
        ActivateCoins();
    }

    #endregion
    public void ChangeTimeScale(float t)
    {
        Time.timeScale = t;
    }

    #region Coins Managment Scetion

    private int tempListNum;
    private List<GameObject> coinsList = new List<GameObject>();
    public void ActivateCoins()
    {
        cois.ForEach(obj=>obj.SetActive(false));
        tempListNum = Random.Range(0, cois.Count - 1);
       print(tempListNum+"  "+ cois[tempListNum].transform.childCount);
        for (int i = 0; i < cois[tempListNum].transform.childCount-1; i++)
        {
           if( cois[tempListNum].transform.GetChild(i).gameObject) coinsList.Add( cois[tempListNum].transform.GetChild(i).gameObject);
        }
     if(cois.Count>0)   cois[tempListNum].SetActive(true);
     else Debug.LogError("Please Assign Coins");
    }
    

    #endregion
}
[Serializable]
public class EventCaller
{
    public UnityEvent _event;
}