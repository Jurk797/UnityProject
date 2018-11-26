using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePrefab : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color bad = new Color(1, 0, 0, 0.4f);
    private Color good = new Color(0, 1, 0, 0.4f);
    public bool isEmpty = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {
            ChangeColor(bad);
            isEmpty = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ChangeColor(bad);
        isEmpty = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeColor(good);
        isEmpty = true;
    }

}
