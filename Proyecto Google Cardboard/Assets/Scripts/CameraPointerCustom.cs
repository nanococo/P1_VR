using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerCustom : MonoBehaviour
{
    private const float _maxDistance = 15;
    private GameObject _gazedAtObject = null;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("CustomOnPointerExit", SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject?.SendMessage("CustomOnPointerEnter", SendMessageOptions.DontRequireReceiver);
                UnityEngine.Debug.Log(_gazedAtObject.name);
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("CustomOnPointerExit", SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }
        
        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            UnityEngine.Debug.Log("touch");
            _gazedAtObject?.SendMessage("CustomOnPointerClick", SendMessageOptions.DontRequireReceiver);
        }
    }
}
