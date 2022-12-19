using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float minXClamp;
    public float maxXclamp;
    public float minYClamp;
    public float maxYClamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance.playerInstance)
        {

            Vector3 cameraPosition;

            cameraPosition = transform.position;
            cameraPosition.x = Mathf.Clamp(GameManager.instance.playerInstance.transform.position.x, minXClamp, maxXclamp);
            cameraPosition.y = Mathf.Clamp(GameManager.instance.playerInstance.transform.position.y, minYClamp, maxYClamp);

            transform.position = cameraPosition;
        }
    }
}
