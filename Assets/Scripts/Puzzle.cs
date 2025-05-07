using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject[] peices;
    public Transform limit1;
    public Transform limit2;
    public BoxCollider2D boxCollider2D;
    public bool placed;
    public PuzzleManager puzzleManager;

    void Start()
    {
        Shuffle();
        boxCollider2D = GetComponent<BoxCollider2D>();
        placed=false;
    }


    void Update()
    {
        
    }

    public void Shuffle()
    {
        transform.position = new Vector2(Random.Range(limit1.position.x, limit2.position.x), Random.Range(limit1.position.y, limit2.position.y));
    }

    /*
    private void OnMouseDown()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseWorldPos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos2D, Vector2.zero);
        if (hit.collider != null)
        {
            if(hit.collider.gameObject==this.gameObject)
            {
                //Debug.Log("Hit: " + hit.collider.name);
            }
        }
    }
    /**/

    public void OnMouseDrag()
    {
        //Debug.Log("drag");
        if(placed) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            //Debug.Log("Objet placé au bon endroit !");
        if (other.gameObject.tag == this.tag)
        {
            transform.position = other.transform.position;
            boxCollider2D.enabled = false;
            this.placed=true;
            puzzleManager.placed++;
        }
    }
}
