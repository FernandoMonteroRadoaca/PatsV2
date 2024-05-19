[System.Serializable]
public class PlayerData 
{
    public float love;
    public float hunger;
    public int money;
    

    public PlayerData(LoveBar player, UIShopManager uIShop)
    {
        love = player.actualLove;
        hunger = player.actualHunger;
        money = uIShop.totalMoney;
    }
}
