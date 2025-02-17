public class InventoryList
{
    int BoxPiece = 0;
    int Box = 0;

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
            default:
                return 0;
        }
    }
}
