using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwarInverted
    }

    [SerializeField]private Mode mode;
    // Update is called once per frame
    void Update()
    {
        switch(mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                transform.LookAt(transform.position-Camera.main.transform.position+transform.position);
                break;
            case Mode.CameraForward:
                transform.forward= Camera.main.transform.forward;
                break;
            case Mode.CameraForwarInverted:
                transform.LookAt(Camera.main.transform);
                break;
            default:
                break;
        }
        
    }
}
