using UnityEngine;

public class GroundSpawnController : MonoBehaviour
{
    public GameObject lastGroundObject;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject crystalPrefab;
    private GameObject newGroundObject;

    private Vector3 lastCrystalPosition = Vector3.positiveInfinity;
    private float minCrystalDistance = 4f;

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
        if (Random.Range(0, 2) == 0) // buradan 0 veya 1 değeri döner 0 olursa zemin sola yerleştirilir 1 olursa zemin ileri yerleştirilir.
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x - 1f, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z), Quaternion.identity);
            lastGroundObject = newGroundObject;
            TryPlaceCrystal(newGroundObject);
        }
        else
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z +1f), Quaternion.identity);
            lastGroundObject = newGroundObject;
        }
    }
    private void TryPlaceCrystal(GameObject groundObject)
    {
        if (Random.Range(0, 14) == 0) //Burada %14 İhtimalle kristal oluşturuyorum.
        {
            Vector3 crystalPosition = newGroundObject.transform.position + new Vector3(0, 0.55f, 0);
        if (Vector3.Distance(crystalPosition,lastCrystalPosition) >= minCrystalDistance)
        {
            GameObject newCrystal = Instantiate(crystalPrefab, crystalPosition, Quaternion.identity);
            lastCrystalPosition = crystalPosition;
        }
        }
    }
}