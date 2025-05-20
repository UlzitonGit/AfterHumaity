using UnityEngine;

public class BossZone : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject door;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossZone")
        {
            boss.gameObject.SetActive(true);
            door.gameObject.SetActive(true);
        }
    }
}
