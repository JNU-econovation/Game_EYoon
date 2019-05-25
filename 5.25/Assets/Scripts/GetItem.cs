using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetItem : MonoBehaviour
{
    Text hp;
    int temp;
    Image playerHp;
    private void OnTriggerEnter2D(Collider2D collider)
    {

    }

    void Bullet(GameObject gameObject)
    {
        temp = gameObject.GetComponent<UI>().temp + 3;
        gameObject.GetComponent<UI>().NOBullet.text = temp.ToString();
        Destroy(gameObject);
    }
    void Heal(GameObject gameObject)
    {
        temp = int.Parse(gameObject.GetComponent<UI>().HPValue.text) + 20;
        gameObject.GetComponent<UI>().HPValue.text = temp.ToString();
        gameObject.GetComponent<Health>().HP.fillAmount = (float)temp / 100;
        Destroy(gameObject);
    }
}
