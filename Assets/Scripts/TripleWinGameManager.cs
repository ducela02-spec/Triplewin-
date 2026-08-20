using UnityEngine;

public class TripleWinGameManager : MonoBehaviour
{
    public int shotsPerPlayer = 5;

    private int playerGoals = 0;
    private int opponentGoals = 0;

    public void PlayerScored()
    {
        playerGoals++;
        Debug.Log("Player Goal! " + playerGoals + "/" + shotsPerPlayer);
    }

    public void OpponentScored()
    {
        opponentGoals++;
        Debug.Log("Opponent Goal! " + opponentGoals + "/" + shotsPerPlayer);
    }

    public string GetWinner()
    {
        if (playerGoals > opponentGoals)
            return "PLAYER WINS";

        if (opponentGoals > playerGoals)
            return "OPPONENT WINS";

        return "DRAW";
    }
}
