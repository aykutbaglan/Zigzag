using TMPro;
using UnityEngine;

public class HeaderTextColorChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text headerText;
    [SerializeField] private UnityEngine.Color[] colors;
    [SerializeField] private float lerpValue;
    [SerializeField] private float time;
    private int colorIndex = 0;
    private float currentTime;

    private void Update()
    {
        SetColorChangeTime();
        SetHeaderTexSmoothColorChange();
    }
    private void SetColorChangeTime()
    {
        if (currentTime <= 0)
        {
            CheckColorIndexValue();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    private void CheckColorIndexValue()
    {
        colorIndex++;
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
        colors[colorIndex].a = 1; // Textte Vertex Color da opakl���n� 1 yap�yor opakl���n ismi A bu sayede opakl�k giderek azalm�yor ve her Yeni Renkte G�ncellemi� oluyoruz.
    }
    private void SetHeaderTexSmoothColorChange()
    {
        headerText.color = UnityEngine.Color.Lerp(headerText.color, colors[colorIndex],lerpValue * Time.deltaTime);
    }
}