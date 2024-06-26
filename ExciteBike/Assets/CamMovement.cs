using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform lookAt;
    public Vector3 offset = new Vector3(0, 5.0f, -10.0f);

   
    void Start() 
    {
        transform.position = lookAt.position + offset;
    }
    private void LateUpdate() 
    {  
        Vector3 desiredPosition = lookAt.position + offset;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }

}
