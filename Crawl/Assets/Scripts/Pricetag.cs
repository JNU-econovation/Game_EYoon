using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pricetag : MonoBehaviour
{
   public int price;
    // Start is called before the first frame update
    void Update()
    {
        GetComponent<Text>().text = price.ToString();
    }
    public void Addprice()
    {
        price += 100;
        
    }

}
