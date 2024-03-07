using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public Text messageText,playerPriceText;
    public Button buyButton;
    public Button selectButton;
    public Button leftButton;
    public Button rightButton;

    public int[] playerPrices;
    public GameObject[] players;
    public int currentSelectedPlayerIndex = 0;

    private void Start()
    {
        UpdateUI();
        ActivatePlayerCar(currentSelectedPlayerIndex);
        PlayerPrefs.SetInt("playerpurchased" + 0, 1);
    }

    private void UpdateUI()
    {
        MenuUiManager.GetInstance().UpdateCash(0);

        buyButton.interactable = !checkPlayerPurchasedStatus(currentSelectedPlayerIndex) && PlayerPrefsManager.Instance.UpdateCash >= playerPrices[currentSelectedPlayerIndex];
        buyButton.gameObject.SetActive(!checkPlayerPurchasedStatus(currentSelectedPlayerIndex)); 
        selectButton.interactable =checkPlayerPurchasedStatus(currentSelectedPlayerIndex);
        selectButton.gameObject.SetActive(checkPlayerPurchasedStatus(currentSelectedPlayerIndex));
        playerPriceText.gameObject.SetActive(!checkPlayerPurchasedStatus(currentSelectedPlayerIndex));
        if(!checkPlayerPurchasedStatus(currentSelectedPlayerIndex))
        {
            string str = "Player Price Is: " + playerPrices[currentSelectedPlayerIndex];
            playerPriceText.text = str;
        }
        
        messageText.text = "";
    }

    public void OnBuyButtonClick()
    {
        if (PlayerPrefsManager.Instance.UpdateCash >= playerPrices[currentSelectedPlayerIndex])
        {
            MenuUiManager.GetInstance().UpdateCash(-playerPrices[currentSelectedPlayerIndex]);
            PlayerPrefs.SetInt("playerpurchased" + currentSelectedPlayerIndex.ToString(), 1); // Save purchased player
            UpdateUI();
        }
        else
        {
            messageText.text = "Not enough money!";
        }
    }

    bool checkPlayerPurchasedStatus(int currentPlayer)
    {
        return Convert.ToBoolean( PlayerPrefs.GetInt("playerpurchased" + currentPlayer));
    }
    public void OnSelectButtonClick()
    {
        PlayerPrefsManager.Instance.CurrentSelectedPlayer = currentSelectedPlayerIndex;
        SceneManager.LoadScene(1);
    }

    public void OnLeftButtonClick()
    {
        currentSelectedPlayerIndex--;
        if (currentSelectedPlayerIndex < 0)
            currentSelectedPlayerIndex = players.Length - 1;
        ActivatePlayerCar(currentSelectedPlayerIndex);
        UpdateUI();
    }
    
    public void OnRightButtonClick()
    {
        currentSelectedPlayerIndex++;
        if (currentSelectedPlayerIndex >= players.Length)
            currentSelectedPlayerIndex = 0; ActivatePlayerCar(currentSelectedPlayerIndex);
        UpdateUI();
    }

    void ActivatePlayerCar(int index)
    {
        foreach (var player in players)
        {
            player.SetActive(false);
        }
        players[index].SetActive(true);
    }
}

