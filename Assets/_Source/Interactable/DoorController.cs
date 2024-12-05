using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    private static bool hasKey;
    public GameObject door;
    public GameObject noKeyMessage;
    public float messageDisplayTime = 3f;
    private bool isPlayerNearby;

    private void Start()
    {
        if (noKeyMessage != null)
        {
            noKeyMessage.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (hasKey)
            {
                OpenDoor();
            }
            else
            {
                ShowNoKeyMessage();
            }
        }
    }

    private void ShowNoKeyMessage()
    {
        noKeyMessage.SetActive(true);
        StartCoroutine(Wfs());
    }

    private IEnumerator Wfs()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        noKeyMessage.SetActive(false);
    }

    private void OpenDoor()
    {
        door.SetActive(false);
    }

    public void CollectKey()
    {
        hasKey = true;
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