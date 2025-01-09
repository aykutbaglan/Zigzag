using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
    [SerializeField] private float endYValue;
    [SerializeField] private GroundSpawnController groundSpawnController;
    [SerializeField] private Rigidbody rb;
    private int groundDirection;

    void Update()
    {
        CheckGroundVerticalPosition();
    }
    private void CheckGroundVerticalPosition()
    {
        if (transform.position.y <= endYValue)
        {
            SetRigidBodyValues();
            SetGroundNewPosition();
        }
    }
    private void SetGroundNewPosition()
    {
        groundDirection = Random.Range(0, 2);

        if (groundDirection == 0 || groundSpawnController.isHackActive)
        {
            transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x - 1f, groundSpawnController.lastGroundObject.transform.position.y, groundSpawnController.lastGroundObject.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x, groundSpawnController.lastGroundObject.transform.position.y, groundSpawnController.lastGroundObject.transform.position.z + 1f);
        }
        groundSpawnController.lastGroundObject = gameObject;
        groundSpawnController.TryPlaceCrystal(gameObject);

    }
    private void SetRigidBodyValues()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}