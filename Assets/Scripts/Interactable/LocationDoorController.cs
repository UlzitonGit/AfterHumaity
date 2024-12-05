using TMPro;
using UnityEngine;

public class LocationDoorController : MonoBehaviour
{
   private int keys = 5;
   private int collectedKeys = 0;
   public TextMeshProUGUI progressText;
   public GameObject door;
   public GameObject lockedMessage;
   public float messageDisplayTime = 3f;
   private float messageHideTime;
   private bool isPlayerNearby;

   private void Start()
   {
      UpdateProgressText();
      if (lockedMessage != null)
      {
         lockedMessage.SetActive(false);
      }
   }

   private void Update()
   {
      if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
      {
         if (collectedKeys >= keys)
         {
            OpenDoor();
         }
         else
         {
            ShowLockedMessage();
         }
      }

      if (Time.time >= messageHideTime)
      {
         lockedMessage.SetActive(false);
      }
   }

   private void ShowLockedMessage()
   {
      if (lockedMessage != null)
      {
         lockedMessage.SetActive(true);
      }
      messageHideTime = Time.time + messageDisplayTime;
   }

   private void OpenDoor()
   {
      door.SetActive(false);
   }

   public void CollectKeys()
   {
      collectedKeys++;
      UpdateProgressText();
   }

   private void UpdateProgressText()
   {
      progressText.text = $"Keys: {collectedKeys}/{keys}";
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
      {
         isPlayerNearby = true;
      }
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
      {
         isPlayerNearby = false;
      }
   }
}