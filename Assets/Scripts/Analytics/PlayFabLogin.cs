using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    private string userEmail,userPassword,userName;
    public GameObject userLoginPanel;
    
    public int playerHighScore;
    public void Start()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId)){
            PlayFabSettings.TitleId = "E0C0B"; // Please change this value to your own titleId from PlayFab Game Manager
        }

        /*var req = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(req,OnLoginSuccess,OnLoginFailure);*/
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL"); 
            userPassword = PlayerPrefs.GetString("PASSWORD"); 
            var request = new LoginWithEmailAddressRequest  { Email = userEmail, Password = userPassword };
                    PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
     
       
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");userLoginPanel.SetActive(false);
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        userLoginPanel.SetActive(false);
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = userName }, OnDisplayName, OnLoginMobileFailure);
        GetStats();
        userLoginPanel.SetActive(false);
    }
    private void OnLoginMobileFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    void OnDisplayName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName + " is your new display name");
    }
    void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }
    void OnGetStats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            switch(eachStat.StatisticName)
            {
                case "highscore":
                    playerHighScore = eachStat.Value;
                    break;
                default: break;
            }
        }
    } 
    
    private void OnLoginFailure(PlayFabError error)
    {
        var registerUsr = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword,Username =userName};
        PlayFabClientAPI.RegisterPlayFabUser(registerUsr,OnRegisterSuccess,OnRegisterFailure);
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    public void GetUserEmailId(string emalId)
    {
        userEmail = emalId;
    }

    public void GetUserPassword(string password)
    {
        userPassword = password;
    }
 public void GetUserName(string _name)
    {
        userName = name;
    }

    public void OnLoginClick()
    {
        var req = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(req,OnLoginSuccess,OnLoginFailure);
    }

    #region Leaderboard

    public void GetLeaderboard()
    {
        var raqLeaderboard = new GetLeaderboardRequest
            { StartPosition = 0, StatisticName = "highscore", MaxResultsCount = 20 };
        PlayFabClientAPI.GetLeaderboard(raqLeaderboard,OnGetLeaderBoard,OnErrorLeaderBoard);
    }

    void OnGetLeaderBoard(GetLeaderboardResult result)
    {
        Debug.Log(result.Leaderboard[0].StatValue);
        foreach (PlayerLeaderboardEntry player in result.Leaderboard)
        {
            Debug.Log(player.DisplayName+" : "+player.StatValue);
        }
    }

    void OnErrorLeaderBoard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
    #endregion
}