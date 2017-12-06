using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour {

    public GameObject bladeTrailPrefab;

    public float minSlicingVelocity = 0.001f;

    Rigidbody2D bladeRB;
    Camera mainCamera;
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;
    Vector2 previousPosition;

    bool isSlicing = false;
    
    // Use this for initialization
	void Start ()
    {
        bladeRB = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }

        if(isSlicing)
        {
            UpdateSlice();
        }
	}

    void StartSlicing()
    {
        isSlicing = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopSlicing()
    {
        isSlicing = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2.0f);
        circleCollider.enabled = false;

    }

    void UpdateSlice()
    {
        Vector2 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        bladeRB.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minSlicingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPosition = newPosition;
    }
}
