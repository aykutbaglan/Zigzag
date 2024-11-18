using UnityEngine;

public class GroundSpawnController : MonoBehaviour
{
    public GameObject lastGroundObject;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject crystalPrefab;
    private GameObject newGroundObject;

    void Start()
    {
        GenerateRandomNewGrounds();
    }
    public void GenerateRandomNewGrounds()
    {
        for (int i = 0; i < 75; i++)
        {
            CreateNewGround();
        }
    }
    private void CreateNewGround()
    {
       

        if (Random.Range(0, 2) == 0)
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x - 1f, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z), Quaternion.identity);
            lastGroundObject = newGroundObject;
            if (Random.Range(0, 14) == 0)
            {
                Vector3 crystalPosition = newGroundObject.transform.position + new Vector3(0,0.55f,0);
                GameObject newCrystal = Instantiate(crystalPrefab, crystalPosition,Quaternion.identity);
            }
        }
        else
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z +1f), Quaternion.identity);
            lastGroundObject = newGroundObject;
        }
    }
}