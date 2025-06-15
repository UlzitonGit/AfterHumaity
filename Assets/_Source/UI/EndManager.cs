using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
    }

}