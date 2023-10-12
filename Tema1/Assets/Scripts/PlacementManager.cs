using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlacementManager : MonoBehaviour

{
    public ARRaycastManager aRRaycastManager;
    public GameObject myGameObject;

    // Start is called before the first frame update
    void Start()
    {
        InitializeARComponents();
    }

    void Update()
    {
        PerformARRaycast();
    }

    void InitializeARComponents()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        myGameObject = transform.GetChild(0).gameObject;
        myGameObject.SetActive(false);
    }

    // Update is called once per frame
    void PerformARRaycast()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),
                            hits,
                            TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!IsMyObjectActive())
            {
                SetMyObjectActive(true);
            }
        }
    }

    bool IsMyObjectActive()
    {
        return myGameObject.activeInHierarchy;
    }

    void SetMyObjectActive(bool isActive)
    {
        myGameObject.SetActive(isActive);
    }

}
