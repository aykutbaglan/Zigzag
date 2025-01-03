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
        colors[colorIndex].a = 1; // Textte Vertex Color da opaklýðýný 1 yapýyor opaklýðýn ismi A bu sayede opaklýk giderek azalmýyor ve her Yeni Renkte Güncellemiþ oluyoruz.
    }
    private void SetHeaderTexSmoothColorChange()
    {
        headerText.color = UnityEngine.Color.Lerp(headerText.color, colors[colorIndex],lerpValue * Time.deltaTime);
    }
}