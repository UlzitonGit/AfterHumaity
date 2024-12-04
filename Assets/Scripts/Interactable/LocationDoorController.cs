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
   
   private bool IsPlayerNearby = false;

   void Start()
   {
      UpdateProgressText();

      if (lockedMessage != null)
      {
         lockedMessage.SetActive(false);
      }
   }

   void Update()
   {
      if (IsPlayerNearby && Input.GetKeyDown(KeyCode.E))
      {
         if (collectedKeys >= keys)
         {
            OpenDoor();
         }
         else
         {
            Debug.Log("Not enough keys to open");
            ShowLockedMessage();
         }
      }
      
      if (IsPlayerNearby && Time.time >= messageHideTime)
      {
         lockedMessage.SetActive(false);
      }
   }

   void OpenDoor()
   {
      if (door != null)
      {
         door.SetActive(false);
      }
   }

   void ShowLockedMessage()
   {
      if(lockedMessage != null) lockedMessage.SetActive(true);
      messageHideTime = Time.time + messageDisplayTime;
   }

   public void CollectKeys()
   {
      collectedKeys++;
      UpdateProgressText();

      if (collectedKeys > keys)
      {
         collectedKeys = keys;
      }
   }

   void UpdateProgressText()
   {
      if (progressText != null)
      {
         int remainingKeys = collectedKeys - keys;
         progressText.text = $"Keys left : {remainingKeys}";
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         IsPlayerNearby = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         IsPlayerNearby = false;
      }
   }
}
