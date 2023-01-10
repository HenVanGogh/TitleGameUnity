using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titles_generator : MonoBehaviour
{
    public List<title> titles = new List<title>();
    public title[,] cordinat_titles = new title[21, 21];

    public GameObject standard_pref;
    // Start is called before the first frame update
    void Start()
    {
        generate_hex_playfield();



    }

    void generate_hex_playfield()
    {
        for (int i = -10; i <= 10; i++)
        {
            for (int k = -10; k <= 10; k++)
            {
                if ((-10 < i && i < 10) && (-10 < k && k < 10) && (-10 < i + k && i + k < 10))
                {
                    titles.Add(init_hex(get_hex_location(i, k)));
                }


            }
        }
    }





    // Update is called once per frame
    void Update()
    {

    }

    void add_title(point_2D p , title t)
    {
        int x_mod = 10;
        int y_mod = 10;
        t.array_x = p.x + x_mod;
        t.array_y = p.y + y_mod;
        cordinat_titles[t.array_x, t.array_y] = t;
        

    }

    title init_hex(point_2D p)
    {
        GameObject pref = Instantiate(standard_pref, new Vector3(p.x_f, p.y_f, (p.x_f * 0.00001f) + (p.y_f * 0.00001f)), Quaternion.identity);
        title t = pref.GetComponent<title>();
        t.x = p.x;
        t.y = p.y;
        t.z = p.x + p.y;
        add_title(p, t);
        return t;
    }

    point_2D get_hex_location(int x , int y)
    {
        point_2D hex_pos= new point_2D(); 
        hex_pos.x_f = x * 0.2498f;
        hex_pos.y_f = (y * 0.289626f) + (0.144813f * x);

        hex_pos.y = y;
        hex_pos.x = x;

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

