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

        bool isShowing = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isShowing = true;
                Time.timeScale = 0;
                Panels();
            }
        }

        void Update()
        {
            if (isShowing == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
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
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
        }
    }

}