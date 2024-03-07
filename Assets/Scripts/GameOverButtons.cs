using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverButtons : MonoBehaviour
{
    // private variables
    private AudioSource audioSource;
    public ButtonType btnType;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
       btn.onClick.AddListener(OnClickBtn);
    }


    public void OnClickBtn()
    {
        switch (btnType)
        {
            case ButtonType.Pause:
                Time.timeScale = 0; 
                  SoundManager.GetInstance().PlaySfxSound("buttonclick1");
                break;
            case ButtonType.Resume:
               SoundManager.GetInstance().PlaySfxSound("buttonclick1");
                Time.timeScale = 1;
                break;
            case ButtonType.Menu:
               SoundManager.GetInstance().PlaySfxSound("buttonclick1");
                SceneManager.LoadScene(0);
                break;
            case ButtonType.Restart:
               SoundManager.GetInstance().PlaySfxSound("buttonclick1");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case ButtonType.Quit:
                SoundManager.GetInstance().PlaySfxSound("buttonclick1");
                Application.Quit();
                break;
            default:
                Debug.Log("Assign Btn Enums"); return;
        }
    }
    /*public void onClick() {
        switch (this.gameObject.name)
        { 
            case "Retry":
                audioSource.Play(); print(this.gameObject.name);
                print(" In Retry Btn");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "QuitButton": print(this.gameObject.name);
                audioSource.Play();
                Application.Quit();
                break;
            case "Pause": print(this.gameObject.name);
                Time.timeScale = 0;
                break;
            case "Resume": print(this.gameObject.name);
                Time.timeScale = 1;
                break;
            case "Menu": print(this.gameObject.name);
               print("In Menu Click Button");
                SceneManager.LoadScene(0);
                break;
            default:print(this.gameObject.name);
                return;
        }
    }*/
}
[SerializeField]
public enum ButtonType
{
    Pause,Resume,Menu,Restart,Quit
}