using UnityEngine;
using TMPro;

namespace UI
{
    public class EndManager : MonoBehaviour
    {
        [SerializeField] string endText;
        [SerializeField] GameObject panelBox;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] AudioSource audioSource;
        [SerializeField] EnemyHealth bossHealth;
        [SerializeField] GameObject menu;

        private void Update()
        {
            if (bossHealth?.health == 0)
            {
                menu.SetActive(false);
                audioSource.Stop();
                panelBox.SetActive(true);
                text.text = endText;
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    panelBox.SetActive(false);
                    Time.timeScale = 1;
                    menu.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }

}