using System.Collections;
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
 [Header("Progress Bar Area")]
  public Image progressBar;
  public GameObject progressJumpToNextBtn;
  [Header("Public References")] public GameObject coinPrefab;
  public Transform coinTargetInitial,coinTargetFinal;
  public Text sizeText;

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
  
  
  #region Bar Filling Mechanism

  public void UpdateBarFilling()
  {
   if(progressBar.fillAmount<1 && progressBar) StartCoroutine(fillBar());
  }

  IEnumerator fillBar()
  {
  
    float minFillAmount = progressBar.fillAmount;
    float maxFillAmount = progressBar.fillAmount + 0.2f;
    float elapsedTime=0;
    float timeToProgress = 2f;
    while (elapsedTime<timeToProgress)
    {
      elapsedTime += Time.deltaTime;
      progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, maxFillAmount, elapsedTime / timeToProgress);
      yield return null;
    }
    progressBar.fillAmount = maxFillAmount; print("Progress Bar Filling "+maxFillAmount);
   progressJumpToNextBtn.SetActive(progressBar.fillAmount>0.99f);
   if (progressBar.fillAmount == 1)
   {
     GameManager.instance.SpawnNewPlanet();
     
   }
    
  }

  #endregion

  #endregion
}
