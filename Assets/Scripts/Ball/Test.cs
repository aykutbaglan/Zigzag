using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public int showValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        showValue = utopianTree(5);
    }
    public int utopianTree(int n)
    {

        int height = 1;

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {

                height = height * 2;
            }
            else
            {
                height = height + 1;
            }

        }

        return height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
