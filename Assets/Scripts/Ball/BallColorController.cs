using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorController : MonoBehaviour
{
    [SerializeField] private Material ballMaterial; // Material rengi deðiþtirilecek
    [SerializeField] protected Color[] colors; // renklerin tutulacaðý dizi
    [SerializeField] private float lerpValue; // renk geçiþinin hýzýný belirler.
    [SerializeField] private float time; // iki renk arasýnda geçiþ yapýlmadan önce beklenilecek süre.
    private int colorIndex = 0; // aktif olarak hangi renk in olacaðýný belirleyen index
    private float currenTime; //geçerli zamaný takip eder time sýfýrlandýðýnda bir sonra ki renk e geçilir.

    private void Update()
    {
        SetColorChangeTime();
        SetBallMaterialColorChange();
    }
    private void SetColorChangeTime() // bu method bir renk deðiþim zamanlayýcýsý olarak çalýþýr
    {
        if (currenTime <= 0)
        {
            CheckColorIndexValue();
            currenTime = time;
        }
        else
        {
            currenTime -= Time.deltaTime;
        }
    }
    private void CheckColorIndexValue() // Renk Indexini arttýrýr Index aþýldýysa baþa dönülür.
    {
        colorIndex++;
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }
    private void SetBallMaterialColorChange() // Bu Method Mevcut renkten hedef renk e yumuþak geçiþ yapmasýný saðlar
    {
        ballMaterial.color = Color.Lerp(ballMaterial.color, colors[colorIndex], lerpValue * Time.deltaTime);
    }

}
