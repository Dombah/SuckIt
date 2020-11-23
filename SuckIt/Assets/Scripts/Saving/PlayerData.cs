using Game.Core;
[System.Serializable]
public class PlayerData
{
    #region Data Variables
    bool is_Alive;
    float score_Points;
    #endregion

    public PlayerData (Core core)
    {
        is_Alive = core.isAlive;
        score_Points = core.score_Points;
    }

}
