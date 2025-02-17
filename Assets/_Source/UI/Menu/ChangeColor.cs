using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color selectColor;
    [SerializeField] Image image;
    private void Start()
    {
        image.color = defaultColor;
    }
    public void Selected()
    {
        image.color = selectColor;
    }
    public void Deselected()
    {
        image.color = defaultColor;
    }
}
