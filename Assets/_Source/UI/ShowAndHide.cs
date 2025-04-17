using System.Collections;
using UnityEngine;

public class ShowAndHide : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime(3));
    }

    private void OnDisable()
    {
        StopCoroutine(DestroyAfterTime(3));
    }
    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
