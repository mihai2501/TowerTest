using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectionAndPlacement : MonoBehaviour
{
    private CircleCollider2D towerCollider1;
    public GameObject theTowerPrefab;
    public Transform towerCentralPosition;
    public static bool towerIsPlaced=false;
    public GameObject visibleRange;
    
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        towerCollider1 = hit.collider.GetComponent<CircleCollider2D>();

        Debug.Log("Collider actions active : " + hit.collider);

        if (hit.collider == towerCollider1)
        {
            if (towerCentralPosition.childCount > 0)
            {
                DestroyImmediate(towerCentralPosition.GetChild(0).gameObject);
                Instantiate(theTowerPrefab, towerCentralPosition);
                towerIsPlaced = true;
                
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Instantiate(theTowerPrefab, towerCentralPosition);
                towerIsPlaced = true;

                transform.parent.gameObject.SetActive(false);
            }
            


            
        }
        
    }

    //IEnumerator TowerRange()
    //{
    //    visibleRange.SetActive(true);
    //    yield return new WaitForSeconds(2f);
    //    visibleRange.SetActive(false);
    //}
}
