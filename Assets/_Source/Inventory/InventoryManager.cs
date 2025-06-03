using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] TMP_Text boxPiecesNum;
    [SerializeField] TMP_Text boxNum;
    [SerializeField] TMP_Text potionNum;
    InventoryList inventoryList = new InventoryList();
    [SerializeField] int boxPiecesNeeded = 3;
    [SerializeField] GameObject boxPreset;
    [SerializeField] PlayerSoundController soundController;

    private void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("piece"))
        {
            soundController.ItemSound();
            Destroy(collision.gameObject);
            inventoryList.AddItem("BoxPiece");
            UpdateText();
        }
        if (collision.CompareTag("Potion"))
        {
            soundController.ItemSound();
            Destroy(collision.gameObject);
            inventoryList.AddItem("Potion");
            UpdateText();
        }
    }

    void UpdateText()
    {
        boxPiecesNum.text = "" + inventoryList.GetItem("BoxPiece");
        boxNum.text = "" + inventoryList.GetItem("Box");
        potionNum.text = "" + inventoryList.GetItem("Potion");
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
    public void TryPlaceBox()
    {
        if (inventoryList.GetItem("Box") >= 1)
        {
            inventoryList.RemoveItem("Box", 1);
            Debug.Log("Crafted");
            Instantiate(boxPreset, transform.position, Quaternion.identity);
            UpdateText() ;
        }
    }

    public void TryUsePotion()
    {
        if (inventoryList.GetItem("Potion") >= 1)
        {
            soundController.DrinkSound();
            inventoryList.RemoveItem("Potion", 1);
            gameObject.GetComponent<PlayerHealth>().currentHealth += 20;
            gameObject.GetComponent<PlayerHealth>().UpdateBar();
            UpdateText();
        }
    }
}
