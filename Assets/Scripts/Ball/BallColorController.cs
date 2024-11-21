using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorController : MonoBehaviour
{
    [SerializeField] private Material ballMaterial; // Material rengi de�i�tirilecek
    [SerializeField] protected Color[] colors; // renklerin tutulaca�� dizi
    [SerializeField] private float lerpValue; // renk ge�i�inin h�z�n� belirler.
    [SerializeField] private float time; // iki renk aras�nda ge�i� yap�lmadan �nce beklenilecek s�re.
    private int colorIndex = 0; // aktif olarak hangi renk in olaca��n� belirleyen index
    private float currenTime; //ge�erli zaman� takip eder time s�f�rland���nda bir sonra ki renk e ge�ilir.

    private void Update()
    {
        SetColorChangeTime();
        SetBallMaterialColorChange();
    }
    private void SetColorChangeTime() // bu method bir renk de�i�im zamanlay�c�s� olarak �al���r
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
    private void CheckColorIndexValue() // Renk Indexini artt�r�r Index a��ld�ysa ba�a d�n�l�r.
    {
        colorIndex++;
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }
    private void SetBallMaterialColorChange() // Bu Method Mevcut renkten hedef renk e yumu�ak ge�i� yapmas�n� sa�lar
    {
        ballMaterial.color = Color.Lerp(ballMaterial.color, colors[colorIndex], lerpValue * Time.deltaTime);
    }

}
