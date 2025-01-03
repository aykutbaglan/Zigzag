using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField][Range(0,3)] private float lerpValue;
    private Vector3 offset;
    private Vector3 newPosition;

    void Start()
    {
        offset = transform.position - ballTransform.position;
    }
    void LateUpdate()
    {
        SetCameraSmoothFollow();
    }
    private void SetCameraSmoothFollow()
    {
        newPosition = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpValue + Time.deltaTime);
        transform.position = newPosition;
    }
}