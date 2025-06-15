using UnityEngine;
using TMPro;

namespace UI
{
    public class NoteManager : MonoBehaviour
    {
        [SerializeField] string noteText;
        [SerializeField] GameObject panelBox;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] AudioSource audioSource;
        [SerializeField] PlayerSoundController paperSource;
        [SerializeField] GameObject menu;

        bool isShowing = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                menu.SetActive(false);
                audioSource.Stop();
                paperSource.PlayPaperSound();
                panelBox.SetActive(true);
                isShowing = true;
                text.text = noteText;
                Time.timeScale = 0;
            }
        }

        void Update()
        {
            if (isShowing == true)
            {
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