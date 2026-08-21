using UnityEngine;

public class PlayerRoleController : MonoBehaviour
{
    public enum PlayerRole
    {
        Shooter,
        Goalkeeper
    }

    [Header("Player")]
    public PlayerRole currentRole = PlayerRole.Shooter;

    [Header("Equipment")]
    public GameObject normalKit;
    public GameObject goalkeeperKit;
    public GameObject goalkeeperGloves;

    void Start()
    {
        ApplyRole();
    }

    public void SetRole(PlayerRole newRole)
    {
        currentRole = newRole;
        ApplyRole();
    }

    private void ApplyRole()
    {
        bool isGoalkeeper = currentRole == PlayerRole.Goalkeeper;

        if (normalKit != null)
            normalKit.SetActive(!isGoalkeeper);

        if (goalkeeperKit != null)
            goalkeeperKit.SetActive(isGoalkeeper);

        if (goalkeeperGloves != null)
            goalkeeperGloves.SetActive(isGoalkeeper);
    }

    public void BecomeShooter()
    {
        SetRole(PlayerRole.Shooter);
    }

    public void BecomeGoalkeeper()
    {
        SetRole(PlayerRole.Goalkeeper);
    }
}
