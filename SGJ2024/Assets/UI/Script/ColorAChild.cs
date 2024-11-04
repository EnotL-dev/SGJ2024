using UnityEngine;
using UnityEngine.UI;

public class ColorAChild : MonoBehaviour
{
    [Header("��������� ��������� ������������")]
    [SerializeField] private Image parentImage;

    private void Update()
    {
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.b, gameObject.GetComponent<Image>().color.g, parentImage.color.a);
    }
}
