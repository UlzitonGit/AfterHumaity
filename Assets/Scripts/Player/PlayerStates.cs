using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] GameObject humanState;
    [SerializeField] GameObject substanceState;
    [SerializeField] Vector2 colliderOffsetHum;
    [SerializeField] Vector2 colliderScaleHum;
    [SerializeField] Vector2 colliderOffsetSub;
    [SerializeField] Vector2 colliderScaleSub;
    [SerializeField] CapsuleCollider2D capsuleCollider;
    PlayerMovement playerMove;
    bool isHuman = true;
    bool canSwithch = true;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q) && canSwithch == true)
        {
            ChangeState();
        }
    }
    private void ChangeState()
    {
        print("1");
        if (canSwithch == false) return;
        if(isHuman == true)
        {
            humanState.SetActive(false);
            substanceState.SetActive(true);
            capsuleCollider.size = colliderScaleSub;
            capsuleCollider.offset = colliderOffsetSub;
            playerMove.moveSpeed = playerMove.moveSpeed / 1.5f;
            playerMove.jumpForce = playerMove.jumpForce / 1.5f;
            isHuman = false;
            print("2");
            StartCoroutine(ReloadSwitching());
        }
        else if (isHuman == false)
        {
            humanState.SetActive(true);
            substanceState.SetActive(false);
            capsuleCollider.size = colliderScaleHum;
            capsuleCollider.offset = colliderOffsetHum;
            playerMove.moveSpeed = playerMove.moveSpeed * 1.5f;
            playerMove.jumpForce = playerMove.jumpForce * 1.5f;
            isHuman =true;
            print("3");
            StartCoroutine(ReloadSwitching());
        }
      
    }
    IEnumerator ReloadSwitching()
    {
        canSwithch = false;
        yield return new WaitForSeconds(0.5f);
        canSwithch = true;
    }
}
