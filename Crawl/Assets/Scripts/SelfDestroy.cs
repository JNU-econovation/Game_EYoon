using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] int existTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, existTime);
    }


}
