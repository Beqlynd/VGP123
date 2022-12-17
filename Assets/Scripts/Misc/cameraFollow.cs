using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Player;

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
        Vector3 cameraPosition;

        cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(Player.transform.position.x, minXClamp, maxXclamp);
        cameraPosition.y = Mathf.Clamp(Player.transform.position.y, minYClamp, maxYClamp);

        transform.position = cameraPosition;
    }
}
