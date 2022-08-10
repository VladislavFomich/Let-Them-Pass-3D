using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSetting : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
