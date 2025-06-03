using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] AudioSource walkSource;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip missSound;
    [SerializeField] AudioClip enemySound;
    [SerializeField] AudioClip paperSound;
    [SerializeField] AudioClip chestSound;
    [SerializeField] AudioClip itemSound;
    [SerializeField] AudioClip drinkSound;
    [SerializeField] AttackTrigger trigger;
    private AudioSource audioSource;
    private bool wasGrounded;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemySound()
    {
        if (enemySound != null)
        {
            audioSource.PlayOneShot(enemySound);
        }
    }

    public void PlayWalkSound()
    {
        if (walkSound != null)
        {
            walkSource.PlayOneShot(walkSound);
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    public void PlayAttackSound()
    {
        if (trigger.hit && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        else if (!trigger.hit && missSound != null)
        {
            audioSource.PlayOneShot(missSound);
        }
    }

    public void PlayPaperSound()
    {
        if (paperSound != null)
        {
            audioSource.PlayOneShot(paperSound);
        }
    }

    public void PlayChestSound()
    {
        if (chestSound != null)
        {
            audioSource.PlayOneShot(chestSound);
        }
    }
    public void ItemSound()
    {
        if (itemSound != null)
        {
            audioSource.PlayOneShot(itemSound);
        }
    }
    public void DrinkSound()
    {
        if (drinkSound != null)
        {
            audioSource.PlayOneShot(drinkSound);
        }
    }

    public void UpdateMovementSounds(bool isMoving, bool isGrounded)
    {
        if (isMoving && isGrounded && !walkSource.isPlaying)
        {
            PlayWalkSound();
        }
        if (!isMoving || !isGrounded)
        {
            walkSource.Stop();
        }

        wasGrounded = isGrounded;
    }
}