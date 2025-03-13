using System.Collections;
using TMPro;
using UnityEngine;

public class BacktrackTimer : MonoBehaviour
{

    public void Timer (int num, TMP_Text text)
    {
        while (num >= 0)
        {
            Debug.Log("ok");
            text.text = num.ToString();
            num--;
            StartCoroutine(Wfs());
        }
    }

    IEnumerator Wfs()
    {
        yield return new WaitForSeconds(1);
    }
}
