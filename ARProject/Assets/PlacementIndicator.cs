/*
 * Code taken from https://www.youtube.com/watch?v=Ml2UakwRxjk&t=532s
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour

    
{
    public GameObject positionIndicator;
    private ARRaycastManager origin;
    private Pose position;
    private bool positionIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        origin = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
        updatePositionIndicator();
    }

    private void updatePositionIndicator()
    {
        throw new NotImplementedException();
    }

    private void updatePosition()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        origin.Raycast(screenCenter, hits, TrackableType.Planes);

        positionIsValid = hits.Count > 0;
        if (positionIsValid)
        {
            positionIndicator.SetActive(true);
            positionIndicator.transform.SetPositionAndRotation(position.position, position.rotation);
        }
        else
        {
            positionIndicator.SetActive(false);
        }

    }
}
