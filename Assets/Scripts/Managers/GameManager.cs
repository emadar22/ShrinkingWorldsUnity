using System;
using System.Collections;
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
        public List<GameObject> planets = new List<GameObject>();
        public List<AudioSource> allSources = new List<AudioSource>();
        public EventCaller eventOnStart;
       
        [Header("Player Transformation Data")]
        public List<GameObject> planetPrefabs=new List<GameObject>();
        public GameObject currentPlanet;
        public ParticleSystem smokePartilces;
        public GameObject aeroPlane;
        public GameObject cam;
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
        ActivatePlanets();
        instance = this;
        PSceneName = SceneManager.GetActiveScene();
    }

    private GameObject currentPlayerCar;
    private void Start()
    {
       // Time.timeScale = 0;
        InitializeTestingFactors();

        if (playersCars.Count > 0)
        {
            playersCars.ForEach(obj => obj.SetActive(false));
            GameObject obj = playersCars[PlayerPrefsManager.Instance.CurrentSelectedPlayer].gameObject;
            currentPlayerCar = obj; obj.SetActive(true);
        }

        if (eventOnStart._event!=null)
        {
            eventOnStart._event.Invoke();
        }

       
    }

    void ActivatePlanets()
    {
        planets.ForEach(obj=>obj.SetActive(false));
        planets[PlayerPrefsManager.Instance.SelectPlanetNum].SetActive(true);
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

    public bool startLerp;
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
    public List<GameObject> coinsList = new List<GameObject>();
    public void ActivateCoins()
    {
        cois.ForEach(obj=>obj.SetActive(false));
        tempListNum = PlayerPrefsManager.Instance.SelectPlanetNum;
        print(tempListNum+"  Plante Num");
       print(tempListNum+"  "+ cois[tempListNum].transform.GetChild(0).childCount);
        for (int i = 0; i < cois[tempListNum].transform.GetChild(0).childCount-1; i++)
        {
           if( cois[tempListNum].transform.GetChild(0).GetChild(i).gameObject) coinsList.Add( cois[tempListNum].transform.GetChild(0).GetChild(i).gameObject);
        }
     if(cois.Count>0)   cois[tempListNum].SetActive(true);
     else Debug.LogError("Please Assign Coins");
    }

    private FauxGravityAttractor f;
    public FauxGravityAttractor GravityAttracxtor()
    {
        f = FauxGravityAttractor.instance;
        if (!f) f = FindObjectOfType<FauxGravityAttractor>();
        return f;
    }

    public GameObject spawnedPlanet;
    private bool spawned;
    public void SpawnNewPlanet()
    {
        if (currentPlanet)
        {
            if(spawned) return; 
            var id = currentPlanet.GetComponent<ShrinkPlanet>().planetID;
                GameObject obj = Instantiate(planetPrefabs[getCurrentSpawnablePlanet()],
                    new Vector3(currentPlanet.transform.position.x - 15, currentPlanet.transform.position.y,
                        currentPlanet.transform.position.z), currentPlanet.transform.rotation);
                spawnedPlanet = obj;
                obj.SetActive(true);
                spawned = true;

        }
    }


    public void TransformPlanetBodyTo()
    {
      //  EnableDisablePlayerComponents(false);
       // player.GetComponent<Animator>().SetBool(("genericAnim"),true);
        //startPlaneLering();
        StartCoroutine(InitialTransfromation(true));
    }

    void startPlaneLering()
    {
        if (gameObject.TryGetComponent(out testProjectile t))
        {
            t.MoveToTarget(spawnedPlanet.transform);
            currentPlayerCar.SetActive(false);
            aeroPlane.SetActive(true);
            smokePartilces.Play();
            EnableDisablePlayerComponents(false);
        }
    }

    int getCurrentSpawnablePlanet()
    {
        if (PlayerPrefsManager.Instance.SelectPlanetNum < planets.Count)
        {
            PlayerPrefsManager.Instance.SelectPlanetNum += 1;
        }
        else
        {
            PlayerPrefsManager.Instance.SelectPlanetNum += 0;
        }

        return PlayerPrefsManager.Instance.SelectPlanetNum;
    }

    public bool startLookingAt;
    IEnumerator InitialTransfromation(bool isInitial)
    {
        if (isInitial)
        {
            EnableDisablePlayerComponents(false);
            player.transform.GetChild(3).gameObject.SetActive(true); print(player.transform.GetChild(3).gameObject+"  Cam");
           
           smokePartilces.Play();
            currentPlayerCar.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            aeroPlane.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            if (gameObject.TryGetComponent(out testProjectile t))
            {
                t.MoveToTarget(spawnedPlanet.transform);
                EnableDisablePlayerComponents(false);
            }
            cam.GetComponent<CameraFollow>().enabled = false;
            cam.GetComponent<CamFolloTwo>().enabled = true;
            yield return new WaitForSeconds(6);
            smokePartilces.Play();
           // EnableDisablePlayerComponents(true);
            currentPlayerCar.SetActive(true);
            aeroPlane.SetActive(false);
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //spawnedPlanet.AddComponent<FauxGravityAttractor>().gravity = -4;  // -2 standard
            //  spawnedPlanet.GetComponent<FauxGravityAttractor>().enabled = true;

            /*ResetPlanetPosition();
            Destroy((currentPlanet)); currentPlanet = spawnedPlanet;
                                spawnedPlanet.SetActive(true);
                                shrinkPlanet = spawnedPlanet.GetComponent<ShrinkPlanet>();
                                EnableDisablePlayerComponents(true);
                                yield return new WaitForSeconds(1);aeroPlane.SetActive(false);currentPlayerCar.SetActive(true);smokePartilces.Play();
                                UiManager.GetInstance().progressBar.fillAmount = 0;player.GetComponent<BoxCollider>().enabled = true; UiManager.GetInstance().progressJumpToNextBtn.SetActive(false);*/
            // spawnedPlanet = null;
        }
        else
        {
            aeroPlane.SetActive(false);
            EnableDisablePlayerComponents(true);
            yield return new WaitForSeconds(0.9f);
            aeroPlane.SetActive(true);
        }
    }

    void ResetPlanetPosition()
    {
        var pos = player.transform.position;
        player.transform.position = new Vector3(pos.x, pos.y-10, pos.z);
    }
    void enablePlanetComponents()
    {
        spawnedPlanet.GetComponent<ShrinkPlanet>().enabled = true;
    }
   public void EnableDisablePlayerComponents(bool b)
    {
        player.GetComponent<FauxGravityBody>().enabled = b;
        player.GetComponent<PlayerCollision>().enabled = b;
        player.GetComponent<PlayerController>().enabled = b;
        player.GetComponent<Collider>().enabled = b;
    }
    #endregion
}
[Serializable]
public class EventCaller
{
    public UnityEvent _event;
}