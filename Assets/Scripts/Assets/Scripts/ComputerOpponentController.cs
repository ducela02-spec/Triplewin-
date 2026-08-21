using UnityEngine;

public class ComputerOpponentController : MonoBehaviour
{
    [Header("Computer Names")]
    public string[] computerNames =
    {
        "Alex",
        "Ryan",
        "Kevin",
        "Lucas",
        "Daniel",
        "Chris",
        "Leo",
        "Marco"
    };

    private string currentOpponent;

    void Start()
    {
        ChooseRandomOpponent();
    }

    public void ChooseRandomOpponent()
    {
        if (computerNames == null || computerNames.Length == 0)
        {
            currentOpponent = "CPU";
            return;
        }

        int randomIndex = Random.Range(0, computerNames.Length);
        currentOpponent = computerNames[randomIndex];
    }

    public string GetOpponentName()
    {
        return currentOpponent;
    }
}
