using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    protected Image inventory;

    private void Start()
    {
        inventory = GetComponent<Image>();
    }
}
