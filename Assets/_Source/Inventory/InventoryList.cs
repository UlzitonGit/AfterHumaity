public class InventoryList
{
    int BoxPiece = 0;
    int Box = 0;
    int Potion = 0;

    public void AddItem(string name)
    {
        switch (name)
        {
            case "BoxPiece":
                BoxPiece++;
                break;
            case "Box":
                Box++;
                break;
            case "Potion":
                Potion++;
                break;
            default: break;
        }
    }

    public void RemoveItem(string name, int num)
    {
        switch (name)
        {
            case "BoxPiece":
                BoxPiece = BoxPiece - num;
                break;
            case "Box":
                Box = Box - num;
                break;
            case "Potion":
                Potion = Potion - num;
                break;
            default: break;
        }
    }

    public int GetItem(string name)
    {
        switch (name)
        {
            case "BoxPiece":
                return BoxPiece;
            case "Box":
                return Box;
            case "Potion":
                return Potion;
            default:
                return 0;
        }
    }
}
