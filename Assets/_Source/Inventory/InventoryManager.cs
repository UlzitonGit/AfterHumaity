using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] TMP_Text boxPiecesNum;
    [SerializeField] TMP_Text boxNum;
    InventoryList inventoryList = new InventoryList();
    [SerializeField] int boxPiecesNeeded = 3;

    private void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("piece"))
        {
            Destroy(collision.gameObject);
            inventoryList.AddItem("BoxPiece");
            UpdateText();
        }
    }

    void UpdateText()
    {
        boxPiecesNum.text = "" + inventoryList.GetItem("BoxPiece");
        boxNum.text = "" + inventoryList.GetItem("Box");
    }

    public void TryCraftBox()
    {
        if (inventoryList.GetItem("BoxPiece") >= boxPiecesNeeded)
        {
            inventoryList.RemoveItem("BoxPiece", boxPiecesNeeded);
            inventoryList.AddItem("Box");
            Debug.Log("Crafted " + inventoryList.GetItem("Box"));
        }
        else
        {
            Debug.Log("Not enough pieces!");
        }
        UpdateText();
    }
}
