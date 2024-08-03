using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpawnner : MonoBehaviour
{
    //public GameObject[][] vertex;
    public GameObject vertexobject;

    public uint length;
    public uint width;
    public uint gap;

    public uint o_length;
    public uint o_width;
    public uint o_gap;

    List<GameObject> vertexList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        length = 1;
        width = 2;
        gap = 1;

        //limiting length width and gap values
        length = (uint)Mathf.Clamp((int)length, 1, Mathf.Infinity);
        width = (uint)Mathf.Clamp((int)width, 1, Mathf.Infinity);
        gap = (uint)Mathf.Clamp((int)gap, 1, Mathf.Infinity);

        vertexGenerator();

        o_length = length;
        o_width = width;
        o_gap = gap;
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        //limiting length width and gap values
        length = (uint)Mathf.Clamp((int)length, 1, Mathf.Infinity);
        width = (uint)Mathf.Clamp((int)width, 1, Mathf.Infinity );
        gap = (uint)Mathf.Clamp((int)gap, 1, Mathf.Infinity);

        if(length != o_length || width != o_width || gap!=o_gap)
        {
            //resize();
            vertexGenerator();
            o_length = length;
            o_width = width;
            o_gap = gap;
        }        

    }

    
    void vertexGenerator()
    {
        //delete previous vertecies
        foreach (GameObject vertex in vertexList) 
        {
            vertex.GetComponent<vertexController>().selfDestruct();
        }

        //clear list
        vertexList.Clear();

        //add new vertecies to the list
        for (uint i = 0; i < length; i += gap)
        {
            for (uint j = 0; j < width; j += gap) 
            {
                //spawn new vertecies
                GameObject newvertex = Instantiate(vertexobject, new Vector3(0, i, j), Quaternion.identity);
                newvertex.GetComponent<vertexController>().gap = gap;
                newvertex.GetComponent<vertexController>().Connect();
                //update list
                vertexList.Add(newvertex);

            }
        }

    }
}
