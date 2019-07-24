using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blood : Singleton<Blood>
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
