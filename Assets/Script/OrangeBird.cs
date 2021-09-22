using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBird : Bird
{
    public override void OnTap()
    {
        Big();
    }

    public void Big()
    {
        float newScale = Mathf.Lerp(1, 3, 1);
        transform.localScale = new Vector3(newScale, newScale, 1);
        //transform.localScale += new Vector3(2.0f, 2.0f, 0f);
    }
}
