using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNextStage : Singleton<MoveNextStage>
{
    [SerializeField] private GameObject destination;
    [SerializeField] private GameObject cam;
    [SerializeField] private float camSpeed;
    [SerializeField] private DrawPath drawPath;
    private const int _distance = 75;
    private bool moveCam;
    Vector3 newCamPos;

    private void Update()
    {
        if (moveCam)
        {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, newCamPos, camSpeed * Time.deltaTime);
            if(cam.transform.localPosition == newCamPos)
                moveCam = false;

        }
    }

    public void Move()
    {
        destination.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z + _distance);
         newCamPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + _distance);
        CheckPath.Instance.UpdateCheckPath();
        moveCam = true;
    }

}
