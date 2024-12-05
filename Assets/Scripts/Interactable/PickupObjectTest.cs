using UnityEngine;

public class PickupObjectTest : MonoBehaviour
{
    void Update()
    {
        if (IsPlayerInTrigger() && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }

    private bool IsPlayerInTrigger()
    {
        return Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Player"));
    }
}