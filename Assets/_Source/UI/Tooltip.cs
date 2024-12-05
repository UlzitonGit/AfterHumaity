using UnityEngine;

public class Tooltip : MonoBehaviour
{
   [SerializeField] private GameObject tooltip;
   [SerializeField] private float autoHideTime = 5f;

   private float hideTimer;

   void Start()
   {
      tooltip?.SetActive(false);
   }

   void ToggleTooltip()
   {
      if (tooltip != null)
      {
         tooltip.SetActive(true);
         hideTimer = Time.time + autoHideTime;
         Debug.Log("Hint showed");
      }
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.H))
      {
         ToggleTooltip();
      }

      if (tooltip != null && tooltip.activeSelf && Time.time >= hideTimer)
      {
         HideTooltip();
      }
   }

   void HideTooltip()
   {
      tooltip?.SetActive(false);
   }
}