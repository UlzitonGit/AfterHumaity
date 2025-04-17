using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] flame;
    [SerializeField] private GameObject flameHitbox;
    private bool isFlameActive = false;

    private void Awake()
    {
        PlayerPrefs.SetInt("canFireAttack", 0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && PlayerPrefs.GetInt("canFireAttack", 0) == 1)
        {
            ActivateFlame();
        }
        else
        {
            DeactivateFlame();
        }
    }

    private void ActivateFlame()
    {
        if (!isFlameActive)
        {
            isFlameActive = true;
            foreach (var flameParticle in flame)
            {
                flameParticle.maxParticles = 2000;
            }
            flameHitbox.SetActive(true);

        }
    }

    private void DeactivateFlame()
    {
        if (isFlameActive)
        {
            isFlameActive = false;
            foreach (var flameParticle in flame)
            {
                flameParticle.maxParticles = 0;
            }
            flameHitbox.SetActive(false);
        }
    }
}