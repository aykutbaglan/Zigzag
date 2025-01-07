using UnityEngine;

public class GroundSpawnController : MonoBehaviour
{
    public GameObject lastGroundObject;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject crystalPrefab;
    private GameObject newGroundObject;

    private Vector3 lastCrystalPosition = Vector3.positiveInfinity;
    private float minCrystalDistance = 4f;

    [SerializeField] public bool isHackActive = false;
    void Start()
    {
        GenerateRandomNewGrounds();
    }
    public void GenerateRandomNewGrounds()
    {
        for (int i = 0; i < 95; i++)
        {
            CreateNewGround();
        }
    }
    private void CreateNewGround()
    {
        Vector3 spawnPos = lastGroundObject.transform.position;
        if (Random.Range(0, 2) == 0 || isHackActive) // buradan 0 veya 1 deðeri döner 0 olursa zemin sola yerleþtirilir 1 olursa zemin ileri yerleþtirilir.
        {
            spawnPos += new Vector3(-1, 0, 0);
        }
        else
        {
            spawnPos += new Vector3(0, 0, 1);
        }
        newGroundObject = Instantiate(groundPrefab, spawnPos, Quaternion.identity);

        newGroundObject.transform.SetParent(this.transform); 

        lastGroundObject = newGroundObject;
        TryPlaceCrystal(newGroundObject);
    }


    private void TryPlaceCrystal(GameObject groundObject)
    {
        if (Random.Range(0, 14) == 0) //Burada %14 Ýhtimalle kristal oluþturuyorum.
        {
            Vector3 crystalPosition = newGroundObject.transform.position + new Vector3(0, 0.55f, 0);
        if (Vector3.Distance(crystalPosition,lastCrystalPosition) >= minCrystalDistance)
        {
            GameObject newCrystal = Instantiate(crystalPrefab, crystalPosition, Quaternion.identity);

                newCrystal.transform.SetParent(this.transform);

            lastCrystalPosition = crystalPosition;
        }
        }
    }
}