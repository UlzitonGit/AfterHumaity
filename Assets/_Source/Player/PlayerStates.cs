using System.Collections;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] private GameObject humanState;
    [SerializeField] private GameObject substanceState;
    [SerializeField] private Vector2 colliderOffsetHum;
    [SerializeField] private Vector2 colliderScaleHum;
    [SerializeField] private Vector2 colliderOffsetSub;
    [SerializeField] private Vector2 colliderScaleSub;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    private PlayerMovement playerMove;
    private bool isHuman = true;
    private bool canSwitch = true;

    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canSwitch)
        {
            ChangeState();
        }
    }

    private void ChangeState()
    {
        if (!canSwitch) return;

        canSwitch = false;

        if (isHuman)
        {
            SwitchToSubstanceState();
        }
        else
        {
            SwitchToHumanState();
        }

        StartCoroutine(ReloadSwitching());
    }

    private void SwitchToSubstanceState()
    {
        humanState.SetActive(false);
        substanceState.SetActive(true);
        capsuleCollider.size = colliderScaleSub;
        capsuleCollider.offset = colliderOffsetSub;
        playerMove.moveSpeed /= 1.5f;
        playerMove.jumpForce /= 1.5f;
        isHuman = false;
    }

    private void SwitchToHumanState()
    {
        humanState.SetActive(true);
        substanceState.SetActive(false);
        capsuleCollider.size = colliderScaleHum;
        capsuleCollider.offset = colliderOffsetHum;
        playerMove.moveSpeed *= 1.5f;
        playerMove.jumpForce *= 1.5f;
        isHuman = true;
    }

    private IEnumerator ReloadSwitching()
    {
        yield return new WaitForSeconds(0.5f);
        canSwitch = true;
    }
}