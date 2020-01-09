using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy_DamageText : MonoBehaviour
{
    Vector3 vector = Vector3.zero;
    public float moveSpeed;
    public float alphaSpeed;
    public float lifeTime;
    TextMeshPro damageText;
    Player _player;
    Color alpha;
    public float damage;
    void Start()
    {
        damageText = GetComponent<TextMeshPro>();
        _player = LevelManager.Instance.GetPlayer().GetComponent<Player>();
        alpha = damageText.color;
        damageText.text = ((int)damage).ToString();
        Invoke("DestroyObject", lifeTime);
    }


    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        damageText.color = alpha;

    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
