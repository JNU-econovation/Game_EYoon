using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Hazard
{
    public GameObject steam;
    public bool isFIreOff = false;
    public override void Function(GameObject window)
    {
        transform.position = new Vector3(window.transform.position.x, window.transform.position.y - 10.0f, window.transform.position.z);
        LevelManager.Instance.fireList.Add(gameObject);
    }

    private void OnDestroy()
    {
        GameObject temp = Instantiate(steam);
        temp.transform.position = gameObject.transform.position;
    }
    
}
