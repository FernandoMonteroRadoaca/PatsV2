[System.Serializable]
public class PlayerData 
{
    public float love;
    public float hunger;
    public int money;
    

    public PlayerData(LoveBar player)
    {
        love = player.actualLove;
        hunger = player.actualHunger;
    }
}
