using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject attackZone;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAttack == true)
        {
            StartCoroutine(Attacking());
        }
    }
    IEnumerator Attacking()
    {
        canAttack = false;
        attackZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackZone.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }

}
