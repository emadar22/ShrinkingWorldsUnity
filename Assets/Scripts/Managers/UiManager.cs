using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiManager :Singleton<UiManager>
{
  #region variables
//[Header("Public Objects")]

  [Header("Panels And Texts")] public Text highScoreText;
  public Text coinsText;
  public GameObject gameFailPanel,gamePlayPanel;
  [Header("Public References")] public GameObject coinPrefab;
  public Transform coinTargetInitial,coinTargetFinal;

  #endregion

  #region Runtime

  #region Unity Built In Events

  void Start()
  {
    UpdateCash(0);
    Time.timeScale = 1;
  }
  

  #endregion

  #region Generic Methods
  public void UpdateCash(int val)
  {
    PlayerPrefsManager.Instance.UpdateCash += val;
    coinsText.text = PlayerPrefsManager.Instance.UpdateCash.ToString();
  }
  

  #endregion

  #region Pause Fail And Complete Functionality

  public void LevelComplete()
  {
    print("Level Completed");
  }

  public void LevelFail()
  {
    gameFailPanel.SetActive(true);
    gamePlayPanel.SetActive(false);
    GameManager.instance.shrinkPlanet.CheckHighScore();
    
    GameManager.instance.shrinkPlanet.enabled = false;
    GameManager.instance.mateorSpawner.gameObject.SetActive(false);
    GameManager.GetInstance().allSources.ForEach(obj=>obj.Stop());
    SoundManager.GetInstance().PlaySfxSound("fail");GameManager.instance.gameStarted = false;
    Time.timeScale = 0.00001f;
  }

  public void SpawnCoin()
  {
   coinPrefab.SetActive(true);
   coinPrefab.transform.position = coinTargetInitial.transform.position;
    coinPrefab.transform.DOMove(coinTargetFinal.position, 0.5f).OnComplete((delegate { coinPrefab.SetActive(false);
      UpdateCash(1);
    }));
  }
  public void LevelPause()
  {
    
  }

  public void ClickGamePlay()
  {
    Time.timeScale = 1;
  }
  

  #endregion

  #endregion
}
