using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    static public List<GameObject> ObjectsList = new List<GameObject>();

    public GameObject myGameObjectToSpawn;
    public PlacementManager myPlacementManager;

    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
    }

    void InitializeComponents()
    {
        myPlacementManager = FindObjectOfType<PlacementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTouchInput();
    }

    void CheckForTouchInput()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject newGameObject = Instantiate(myGameObjectToSpawn,
                                            myPlacementManager.transform.position,
                                            GetSpawnRotation());
        ObjectsList.Add(newGameObject);
    }

    Quaternion GetSpawnRotation()
    {
        return myPlacementManager.transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}
