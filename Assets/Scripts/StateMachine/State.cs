using UnityEngine;
public abstract class State : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;

    public virtual void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
    public virtual void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}