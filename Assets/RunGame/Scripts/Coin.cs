public class Coin : Item
{
    public override void Action() => GameSystem.Instance.Coin++;
}