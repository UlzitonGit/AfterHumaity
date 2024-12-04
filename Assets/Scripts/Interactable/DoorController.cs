using UnityEngine;


public class DoorController : MonoBehaviour
{
    private bool hasKey = false;
    
    public GameObject door;

    public GameObject NoKeyMessage;
    
    public float messageDisplayTime = 3f;
    
    private bool IsPlayerNearby = false;
    
    private float messageHideTime = 0f;

    private void Start()
    {
        if (NoKeyMessage != null)
        {
            NoKeyMessage.SetActive(false);
        }
    }

    void Update()
    {
        if (IsPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (hasKey)
            {
                OpenDoor();
            }

            else
            {
                ShowNoKeymessage();
            }
        }
    }

    void ShowNoKeymessage()
    {
        NoKeyMessage.SetActive(true);
        messageHideTime = Time.time + messageDisplayTime;
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.SetActive(false);
        }
    }

    public void CollectKey()
    {
        hasKey = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerNearby = false;
        }
    }
}
