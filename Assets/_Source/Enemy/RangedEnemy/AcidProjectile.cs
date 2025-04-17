using System.Collections;
using UnityEngine;

public class AcidProjectile : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime(5));
    }

    public void SetDirection(Vector2 dir, float spd)
    {
        direction = dir;
        speed = spd;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
            if (Physics2D.OverlapPoint(transform.position, layerMask))
            {
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}