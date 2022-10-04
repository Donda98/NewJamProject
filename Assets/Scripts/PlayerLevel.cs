using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int playerLVL;
    [SerializeField] private GameObject[] componentsLVL0;
    [SerializeField] private GameObject[] componentsLVL1;
    [SerializeField] private GameObject[] componentsLVL2;
    [SerializeField] private GameObject[] componentsLVL3;
    [SerializeField] private GameObject occhiBase;

    private void Start()
    {
        UpdateSkin();
    }
    [ContextMenu("UpdateSkin")]
    public void UpdateSkin()
    {
        playerLVL = GameManager.Instance.playerLVL;
        for (int i = 0; i <= playerLVL; i++)
        {
            switch (i)
            {
                case 0:
                    //naked GUY
                    print("livello0");
                    break;
                case 1:
                    foreach (GameObject componente in componentsLVL0)
                    {
                        componente.SetActive(false);
                    }
                    foreach (GameObject componente in componentsLVL1)
                    {
                        componente.SetActive(true);
                    }
                    print("livello1");
                    break;

                case 2:
                  
                    foreach (GameObject componente in componentsLVL2)
                    {
                        componente.SetActive(true);
                    }
                    print("livello2");
                    break;

                case 3:
                    foreach (GameObject componente in componentsLVL3)
                    {
                        componente.SetActive(true);
                    }
                    occhiBase.SetActive(false);
                    print("livello3");
                    break;
                default:
                    foreach (GameObject componente in componentsLVL3)
                    {
                        componente.SetActive(true);
                    }
                    occhiBase.SetActive(false);
                    break;
            }
        }
    }
    public void lvlUP()
    {
        playerLVL++;
        GameManager.Instance.playerLVL = playerLVL;
        UpdateSkin();
    }
}
