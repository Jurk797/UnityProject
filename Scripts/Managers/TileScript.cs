using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private bool isEmpty = true;

    public bool IsEmpty
    {
        get
        {
            return isEmpty;
        }

        set
        {
            isEmpty = value;
        }
    }
}
