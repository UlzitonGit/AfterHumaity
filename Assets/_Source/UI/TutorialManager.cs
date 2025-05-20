using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

namespace UI
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] List<string> tutorialList = new List<string>();
        int panelNum = 0;
        [SerializeField] GameObject panelBox;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] AudioSource audioSource;

        bool isShowing = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                audioSource.Stop();
                panelBox.SetActive(true);
                isShowing = true;
                Time.timeScale = 0;
                Panels();
            }
        }

        void Update()
        {
            if (isShowing == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    panelNum++;
                    Panels();
                }
            }
        }

        void Panels()
        {
            if (panelNum < tutorialList.Count)
            {
                text.text = tutorialList[panelNum];
            }
            else
            {
                panelNum = 0;
                panelBox.SetActive(false);
                Time.timeScale = 1;
                Destroy(gameObject);
            }
        }
    }

}