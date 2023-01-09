using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titles_generator : MonoBehaviour
{
    public GameObject standard_pref;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                init_hex(get_hex_location(i, k));
            }
        }
    }





    // Update is called once per frame
    void Update()
    {

    }

    void init_hex(point_2D p)
    {
        GameObject pref = Instantiate(standard_pref, new Vector3(p.x_f, p.y_f, p.z_f), Quaternion.identity);
        pref.GetComponent<title>().x = p.x;
    }

    point_2D get_hex_location(int x , int y)
    {
        point_2D hex_pos= new point_2D(); 
        hex_pos.x_f = x * 0.2498f;
        hex_pos.y_f = (y * 0.289626f) + (0.144813f * x);

        return hex_pos;
    }


}

struct point_2D { 

    public float x_f;
    public float y_f;
    public float z_f;

    public int x;
    public int y;
    public int z;

    point_2D(float x, float y)
    {
        this.x_f = x;
        this.y_f = y;
        this.z_f = 0;

        this.x = 0;
        this.y = 0;
        this.z = 0;
    }
}

