using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour
{
    public hex_pos hex;
    public Node node;


    public int array_x = 0;
    public int array_y = 0;

    // Start is called before the first frame update
    void Start()
    {
        node = GetComponent<Node>();
    }

}
