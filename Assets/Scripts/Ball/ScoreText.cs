using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText;
    public RectTransform scoreTransfrom;
    public TMP_Text highScoreText;
    public TMP_Text crystalText;
    public int score = 0;
    public int highScore;
    public int crystalScore = 0;
    public GameObject crystalTextGo;
    private Tween textTween;
    private Tween crystalTextTween;
    private Vector3 initialcrystalTextTransform;

    void Start()
    {
        initialcrystalTextTransform = crystalText.rectTransform.position;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = "HighScore:" + highScore;
    }
    internal void UpdateScore(int v)
    {
        textTween.Kill(true);
        score += v;
        scoreText.text = "Score: " + score;
        textTween = TextTween();
    }
    public void CrystalScore()
    {
        crystalText.text = "+" + crystalScore.ToString();
    }
    private Tween TextTween()
    {
        return scoreText.rectTransform.DOPunchScale(new Vector3(0f, 0.2f, 0f), 0.3f);
    }
    public Tween CrystalTween()
    {
        crystalTextGo.SetActive(true);
        crystalText.rectTransform.localScale = Vector3.one;
        crystalText.rectTransform.position = initialcrystalTextTransform;

        crystalTextTween.Kill(true);
        return crystalText.rectTransform.DOMove(scoreTransfrom.position, 0.5f).OnComplete(() =>
        {
            crystalText.rectTransform.DOScale(0f, 0.5f).OnComplete(() =>
            {
                crystalTextGo.SetActive(false);
            });
        });
    }
}