using UnityEngine;

public class PlayerNameSetup : MonoBehaviour
{
    private const string PlayerNameKey = "TripleWin_PlayerName";

    public bool HasName()
    {
        return PlayerPrefs.HasKey(PlayerNameKey) &&
               !string.IsNullOrWhiteSpace(PlayerPrefs.GetString(PlayerNameKey));
    }

    public void SavePlayerName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        PlayerPrefs.SetString(PlayerNameKey, name.Trim());
        PlayerPrefs.Save();
    }

    public string GetPlayerName()
    {
        return PlayerPrefs.GetString(PlayerNameKey, "");
    }
}
