using UnityEngine;

public class PenaltyRoundController : MonoBehaviour
{
    [Header("Penalty Settings")]
    public int shotsPerPlayer = 5;

    private int sonyGoals = 0;
    private int peterGoals = 0;

    private int sonyShots = 0;
    private int peterShots = 0;

    public bool MatchFinished { get; private set; }

    public void SonyShot(bool scored)
    {
        if (MatchFinished || sonyShots >= shotsPerPlayer)
            return;

        sonyShots++;

        if (scored)
            sonyGoals++;

        CheckRound();
    }

    public void PeterShot(bool scored)
    {
        if (MatchFinished || peterShots >= shotsPerPlayer)
            return;

        peterShots++;

        if (scored)
            peterGoals++;

        CheckRound();
    }

    private void CheckRound()
    {
        // Toude jwè yo dwe fini 5 tir yo
        if (sonyShots < shotsPerPlayer || peterShots < shotsPerPlayer)
            return;

        if (sonyGoals > peterGoals)
        {
            MatchFinished = true;
            Debug.Log("SONY WINS!");
        }
        else if (peterGoals > sonyGoals)
        {
            MatchFinished = true;
            Debug.Log("PETER WINS!");
        }
        else
        {
            // Egalite: nou antre nan tir desizif
            Debug.Log("DRAW - SUDDEN DEATH!");
        }
    }

    public int GetSonyGoals()
    {
        return sonyGoals;
    }

    public int GetPeterGoals()
    {
        return peterGoals;
    }

    public int GetSonyShots()
    {
        return sonyShots;
    }

    public int GetPeterShots()
    {
        return peterShots;
    }
}
