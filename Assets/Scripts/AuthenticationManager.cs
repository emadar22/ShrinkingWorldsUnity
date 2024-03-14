using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class AuthenticationManager : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;

    private string scoreKey = "Score";
    private string coinsKey = "Coins";
    private string levelKey = "Level";

    public void Register()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
        {
            Username = username,
            Password = password
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registration successful!";
        InitializePlayerData();
    }

    void OnRegisterFailure(PlayFabError error)
    {
        messageText.text = "Registration failed: " + error.ErrorMessage;
    }

    public void Login()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password
        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Login successful!";
        LoadPlayerData();
    }

    void OnLoginFailure(PlayFabError error)
    {
        messageText.text = "Login failed: " + error.ErrorMessage;
    }

    public void RecoverPassword()
    {
        string username = usernameInput.text;

        SendAccountRecoveryEmailRequest request = new SendAccountRecoveryEmailRequest
        {
            Email = username,
            TitleId = PlayFabSettings.TitleId
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverPasswordSuccess, OnRecoverPasswordFailure);
    }

    void OnRecoverPasswordSuccess(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password recovery email sent successfully!";
    }

    void OnRecoverPasswordFailure(PlayFabError error)
    {
        messageText.text = "Password recovery failed: " + error.ErrorMessage;
    }

    void InitializePlayerData()
    {
        UpdatePlayerStats(0, 100, 1); // Initialize with 0 score, 100 coins, and level 1
    }

    void UpdatePlayerStats(int score, int coins, int level)
    {
        UpdateUserDataRequest request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { scoreKey, score.ToString() },
                { coinsKey, coins.ToString() },
                { levelKey, level.ToString() }
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnUpdatePlayerStatsSuccess, OnUpdatePlayerStatsFailure);
    }

    void OnUpdatePlayerStatsSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player stats updated successfully!");
    }

    void OnUpdatePlayerStatsFailure(PlayFabError error)
    {
        Debug.LogError("Failed to update player stats: " + error.ErrorMessage);
    }

    void LoadPlayerData()
    {
        GetUserDataRequest request = new GetUserDataRequest();

        PlayFabClientAPI.GetUserData(request, OnLoadPlayerDataSuccess, OnLoadPlayerDataFailure);
    }

    void OnLoadPlayerDataSuccess(GetUserDataResult result)
    {
        if (result.Data.TryGetValue(coinsKey, out UserDataRecord coinsRecord))
        {
            int coins = int.Parse(coinsRecord.Value);
            Debug.Log("Coins: " + coins);
        }

        if (result.Data.TryGetValue(levelKey, out UserDataRecord levelRecord))
        {
            int level = int.Parse(levelRecord.Value);
            Debug.Log("Level: " + level);
        }

        if (result.Data.TryGetValue(scoreKey, out UserDataRecord scoreRecord))
        {
            int score = int.Parse(scoreRecord.Value);
            Debug.Log("Score: " + score);
        }
    }

    void OnLoadPlayerDataFailure(PlayFabError error)
    {
        Debug.Log("Load player data error: " + error.ErrorMessage);
    }
}
