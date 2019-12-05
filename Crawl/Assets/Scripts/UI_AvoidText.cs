using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_AvoidText : MonoBehaviour
{
    float time = 0;
    Player _player;
    void Start()
    {
        _player = LevelManager.Instance.GetPlayer().GetComponent<Player>();
        StartCoroutine(DisableSelf());
    }

    
    IEnumerator DisableSelf()
    {
        while (true)
        {
            if(time >= 0.2f)
            {
                GetComponent<Text>().color = new Color(1, 1, 1, 0);
            }
            yield return null;
        }
    }
    private void Update()
    {
        if (!_player.GetIsPause())
        {
            time += Time.deltaTime;
        }
    }
    public void Avoid()
    {
        time = 0;
        GetComponent<Text>().color = new Color(1, 1, 1, 1);
    }

}
