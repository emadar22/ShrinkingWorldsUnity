using UnityEngine;

public class PlayerPrefsManager
{
    private static PlayerPrefsManager instance;

    private PlayerPrefsManager()
    {
        // Ensure that the instance is created only once
        if (instance != null)
        {
            Debug.LogWarning("Tried to instantiate multiple PlayerPrefsManagers.");
            return;
        }
        instance = this;
    }

    public static PlayerPrefsManager Instance
    {
        get
        {
            // Create the instance if it doesn't exist
            if (instance == null)
            {
                new PlayerPrefsManager();
            }
            return instance;
        }
    }

    public float SfxVolume
    {
        get { return PlayerPrefs.GetFloat("sfxVolume"); }
        set{PlayerPrefs.SetFloat("sfxVolume",value);}
    }
    public float HighScore
    {
        get { return PlayerPrefs.GetFloat("highScore"); }
        set{PlayerPrefs.SetFloat("highScore",value);}
    }

    public int UpdateCash
    {
        get { return PlayerPrefs.GetInt("cash");} set{PlayerPrefs.SetInt("cash",value);}
    }
public int SelectPlanetNum
    {
        get { return PlayerPrefs.GetInt("planetNum");} set{PlayerPrefs.SetInt("planetNum",value);}
    }

    public int CurrentSelectedPlayer
    {
        get { return PlayerPrefs.GetInt("selectedPlayer"); }
        set{PlayerPrefs.SetInt("selectedPlayer",value);}
    }

    /*public string UserEmail()
    {
        get { return PlayerPrefs.GetString("userEmail"); }
        set{PlayerPrefs.SetString("selectedPlayer",string);}
    }*/
    // Add other PlayerPrefs-related methods as needed...
}