using UnityEngine;

public class PlayerProfileController : MonoBehaviour
{
    public string playerName;

    private const string PlayerNameKey = "TripleWin_PlayerName";

    void Awake()
    {
        LoadPlayerName();
    }

    public bool HasPlayerName()
    {
        return !string.IsNullOrWhiteSpace(playerName);
    }

    public void SetPlayerName(string newName)
    {
        newName = newName.Trim();

        if (string.IsNullOrWhiteSpace(newName))
            return;

        playerName = newName;
        PlayerPrefs.SetString(PlayerNameKey, playerName);
        PlayerPrefs.Save();
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    private void LoadPlayerName()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            playerName = PlayerPrefs.GetString(PlayerNameKey);
        }
        else
        {
            playerName = "";
        }
    }

    public void ChangePlayerName(string newName)
    {
        SetPlayerName(newName);
    }
}
