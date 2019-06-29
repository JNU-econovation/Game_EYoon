using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] Sprite soldOut;
    public GameObject shop;
    public GameObject mainmenu;
  public void Gamestart()
    {
        SceneManager.LoadScene("Project");
    }
    public void Returntomainmenu()
    {
        mainmenu.SetActive(true);
        shop.SetActive(false);
    }
    public void Gotoshop()
    {
        mainmenu.SetActive(false);
        shop.SetActive(true);
    }
    public void Soldout(GameObject button)
    {
        button.GetComponent<Image>().sprite = soldOut;
    }
    public void DeleteButton(GameObject button)
    {
        button.SetActive(false);
    }
}
