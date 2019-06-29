using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassObject : MonoBehaviour
{        
    private void OnBecameVisible()
    {
        HazardManager.Instance.windows.Add(gameObject);           
    }
    private void OnBecameInvisible()
    {
        HazardManager.Instance.windows.Remove(gameObject);
    }
}
