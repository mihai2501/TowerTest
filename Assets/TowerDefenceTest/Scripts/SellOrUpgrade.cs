using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellOrUpgrade : MonoBehaviour
{
    

    private int clickedTower = -1;
    
    private void OnMouseDown()
    {
        clickedTower *= -1;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log("Collider on Tower : " +hit.collider);
        if (TowerSelectionAndPlacement.towerIsPlaced)
        {
            if (clickedTower == 1)
            {
                hit.collider.transform.GetChild(2).gameObject.SetActive(true);
                hit.collider.transform.GetChild(1).gameObject.SetActive(true);


            }
            if (clickedTower == -1)
            {
                hit.collider.transform.GetChild(2).gameObject.SetActive(false);
                hit.collider.transform.GetChild(1).gameObject.SetActive(false);

            }
            
        }
    }
   
}
