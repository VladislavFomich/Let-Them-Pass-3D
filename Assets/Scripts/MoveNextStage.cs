using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNextStage : Singleton<MoveNextStage>
{
    [SerializeField] private GameObject destination;
    [SerializeField] private GameObject cam;
    [SerializeField] private float camSpeed;
    private const int _distance = 75;
    

    public void Move()
    {
        destination.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z + _distance);
        Vector3 camPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + _distance);
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, camPos, camSpeed * Time.deltaTime);
    }

}
