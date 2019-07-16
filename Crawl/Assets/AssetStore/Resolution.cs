using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    Camera mainCamera;
    public Camera uiCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        mainCamera.aspect = 640.0f / 1280.0f;
     //   uiCamera.aspect = 640.0f / 1280.0f;
    }
}
