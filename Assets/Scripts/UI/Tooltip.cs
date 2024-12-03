using UnityEngine;

public class Tooltip : MonoBehaviour
{
   public GameObject tooltip;

   private float autoHideTime = 5f;

   private float hidetimer;

   void Start()
   {
      if (tooltip != null)
      {
         tooltip.SetActive(false);
      }
   }

   void toogletooltip()
   {
      if (tooltip != null)
      {
         tooltip.SetActive(true);
         hidetimer = Time.time + autoHideTime;
      }
   }
   
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.H))
      { 
         toogletooltip();
         Debug.Log("Hint showed");
      }

      if (tooltip.activeSelf && Time.time >= hidetimer)
      {
         HideTooltip();
      }
   }

   void HideTooltip()
   {
      if (tooltip != null)
      {
         tooltip.SetActive(false);
      }
   }
   
}
