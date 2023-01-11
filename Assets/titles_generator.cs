using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titles_generator : MonoBehaviour
{
    public List<title> titles = new List<title>();
    public title[,] cordinat_titles = new title[21, 21];
    public Node title_node;

    int x_mod = 10;
    int y_mod = 10;

    List<hex_pos> Directions = new List<hex_pos>();

    

    public GameObject standard_pref;
    // Start is called before the first frame update
    void Start()
    {
        Directions.Add(new hex_pos(1, 0, 0));
        Directions.Add(new hex_pos(-1, 0, 0));
        Directions.Add(new hex_pos(0, 1, 0));
        Directions.Add(new hex_pos(0, -1, 0));
        Directions.Add(new hex_pos(0, 0, 1));
        Directions.Add(new hex_pos(0, 0, -1));
        generate_hex_playfield(10 , 10 , 10);
        title_node = GetComponent<Node>();
    }

    void generate_hex_playfield(int hex_size_x , int hex_size_y , int hex_size_z)
    {
        for (int i = -hex_size_x; i <= hex_size_x; i++)
        {
            for (int k = -hex_size_y; k <= hex_size_y; k++)
            {
                if ((-hex_size_x < i && i < hex_size_x) && (-hex_size_y < k && k < hex_size_y) && (-hex_size_z < i + k && i + k < hex_size_z))
                {
                    titles t = init_hex(get_hex_location(i, k));
                    foreach (hex_pos d in Directions)
                    {
                        hex_pos target_title_location = t.hex + d;
                        title target_title = get_title(target_title_location);
                        if (target_title != null)
                        {
                            target_title.node.m_Connections.Add(target_title.node);
                        }
                    }
                    titles.Add(t);
                }


            }
        }
    }

    void generete_connections()
    {
        foreach (title t in titles) { 
            foreach(hex_pos d in Directions)
            {
                hex_pos target_title_location = t.hex + d;
                title target_title = get_title(target_title_location);
                target_title.node.m_Connections.Add(target_title.node);

            }
            
        }

    }

    title get_title(int x , int y)
    {
        try
        {
            return cordinat_titles[x + x_mod, y + y_mod];
        }
        catch(IndexOutOfRangeException e)
        {
            return null;
        }
    }

    title get_title(hex_pos h)
    {
        try
        {
            return cordinat_titles[h.x + x_mod, h.y + y_mod];
        }
        catch (IndexOutOfRangeException e)
        {
            return null;
        }
    }





    // Update is called once per frame
    void Update()
    {

    }

    void add_title(point_2D p , title t)
    {
        
        t.array_x = p.x + x_mod;
        t.array_y = p.y + y_mod;
        cordinat_titles[t.array_x, t.array_y] = t;
        

    }

    title init_hex(point_2D p)
    {
        GameObject pref = Instantiate(standard_pref, new Vector3(p.x_f, p.y_f, (p.x_f * 0.00001f) + (p.y_f * 0.00001f)), Quaternion.identity);
        title t = pref.GetComponent<title>();
        t.hex.x = p.x;
        t.hex.y = p.y;
        t.hex.z = p.x + p.y;
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

public struct hex_pos
{
    public int x;
    public int y;
    public int z;

    public hex_pos(int x,int y, int z)
    {
        this.x = x;     
        this.y = y;
        this.z = z;
    }

    public static hex_pos operator +(hex_pos h1, hex_pos h2)
    {
        return new hex_pos(h1.x + h2.x,h1.y + h2.y,h1.z + h2.z);
    }

    public static hex_pos operator -(hex_pos h1, hex_pos h2)
    {
        return new hex_pos(h1.x - h2.x, h1.y - h2.y, h1.z - h2.z);
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

