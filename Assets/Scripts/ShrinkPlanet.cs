using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ShrinkPlanet : MonoBehaviour
{
    [Tooltip(" Initial Size Will Be 100 m")]
    public float highScore;
    public Text sizeText;

     bool startScoreAddition;
    // public variables

    [Range(.0f, .05f)]
    public float shrinkSpeed;

    private void Start()
    {
        Invoke(nameof(startScoreProgress),2);
    }

    void startScoreProgress()
    {
        startScoreAddition = true;
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        this.transform.localScale *= 1f - (shrinkSpeed * Time.fixedDeltaTime);
        string str = ConvertToPercentage(transform.localScale.x) + " m";
        if(sizeText)sizeText.text =str.ToString();
        string str2 = "High Score" + ConvertUptoOneDecimal(highScore);
        if(startScoreAddition && GameManager.instance.gameStarted){  highScore +=0.025f; UiManager.GetInstance().highScoreText.text =str2.ToString();}
    }
    float ConvertToPercentage(float value)
    {
        return Mathf.Round(value * 1000f) / 10f; 
    }

   public void CheckHighScore()
    {
        if (highScore > PlayerPrefsManager.Instance.HighScore)
        {
            print("New Score");
            string str2 = "High Score" + ConvertUptoOneDecimal(highScore);
            UiManager.GetInstance().highScoreText.text = str2.ToString();
            PlayerPrefsManager.Instance.HighScore = highScore;
        }
        else
        {
            PlayerPrefsManager.Instance.HighScore = ConvertUptoOneDecimal(highScore) ;
            string str2 = "High Score" + ConvertUptoOneDecimal(highScore);
            UiManager.GetInstance().highScoreText.text = str2.ToString();
        }
    }

   float ConvertUptoOneDecimal(float score)
   {
      
       var val= Math.Floor(score * 100f) / 100f; float f = (float)val;
       return f;
   }

}
