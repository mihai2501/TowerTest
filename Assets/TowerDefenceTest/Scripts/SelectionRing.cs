using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRing : MonoBehaviour
{

    private int clickedGround = -1;
    private Collider2D groundCollider;
    

    private void Start()
    {
        groundCollider = gameObject.GetComponent<Collider2D>();
        

    }
    private void OnMouseDown()
    {


         RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        
        

        Debug.Log("Collider on Tower : " + hit[0].collider);
        if (hit[0].collider == groundCollider)
        {
            clickedGround *= -1;
            if (clickedGround == 1 )
            {
                
                hit[0].collider.transform.GetChild(3).gameObject.SetActive(true);

            }
            if (clickedGround == -1)
            {
                hit[0].collider.transform.GetChild(3).gameObject.SetActive(false);


            }
            return;
        }
        
    }

}
