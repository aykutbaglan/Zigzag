using System.Collections;
using UnityEngine;

public class GroundFallController : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public IEnumerator SetRigidBodyValues()
    {
        yield return new WaitForSeconds(0.75f);
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}