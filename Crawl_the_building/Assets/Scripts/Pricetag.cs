using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pricetag : MonoBehaviour
{
   [SerializeField] Stuffprice stuffprice;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = stuffprice.price.ToString();
    }

}
