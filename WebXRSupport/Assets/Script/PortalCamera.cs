using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform left_eye;
    public Transform right_eye;
    public Transform portal;
    public Transform otherPortal;

    public bool neg;

    void Start()
    {
        
    }

  
    void LateUpdate()
    {
        
        Vector3 playerOffsetFromPrtal = (left_eye.position + right_eye.position) / 2 - otherPortal.position; //note that I'm not sure if this works...
        
        if(!neg)
            transform.position = portal.position + playerOffsetFromPrtal;
        else
            transform.position = new Vector3(portal.position.x, -portal.position.y, portal.position.z) - new Vector3(playerOffsetFromPrtal.x, -playerOffsetFromPrtal.y, playerOffsetFromPrtal.z);
        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCamDir = portalRotDiff * left_eye.forward;

        transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);


     /*   Matrix4x4 m = portal.localToWorldMatrix * otherPortal.localToWorldMatrix * player_cam.localToWorldMatrix;

        portal_cam.SetPositionAndRotation(m.GetColumn(3), m.rotation);*/

    }
}
