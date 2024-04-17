using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiManager : Singleton<MenuUiManager>
{
 #region Variables
 public Text coinsText;
 public int addMoneyOnStart;


 #endregion

 #region Unity Events

 void Start()
 {
  
  UpdateCash(addMoneyOnStart);
  Time.timeScale = 1;
 }

 public void SelectWorld(int num)
 {
  UpdatePlanetNum(num);
  if(num==3){SceneManager.LoadScene(2);}
  else
  {
   SceneManager.LoadScene(1);
  }
 }
 void UpdatePlanetNum(int num)
 {
  PlayerPrefsManager.Instance.SelectPlanetNum = num;
 }
 #endregion

 #region Custom Methods

 public void UpdateCash(int val)
 {
  PlayerPrefsManager.Instance.UpdateCash += val;
  coinsText.text = PlayerPrefsManager.Instance.UpdateCash.ToString();
 }

 public void ExitGame()
 {
  print(" Exited");
  Application.Quit();
 }
 #endregion


}
