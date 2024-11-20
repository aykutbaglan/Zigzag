using UnityEngine;

public class BallInputController : MonoBehaviour
{
    [HideInInspector] public Vector3 ballDirection;
    private bool isGoingForward = false;
    void Start()
    {
        
        if (Random.Range(0, 2) == 0)
        {
            ballDirection = Vector3.forward;
            isGoingForward = true;
        }
        else
        {
            ballDirection = Vector3.left;
            isGoingForward = false;
        }
    }
    void Update()
    {
        HandleBallInputs();
    }
    private void HandleBallInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeBallDirection();
            Debug.Log("týký");
        }
    }
    private void ChangeBallDirection()
    {
       if (!isGoingForward)
       {
           ballDirection = Vector3.forward;
            isGoingForward = true;
       }
       else
       {
           ballDirection = Vector3.left;
            isGoingForward = false;
       }
    }
}