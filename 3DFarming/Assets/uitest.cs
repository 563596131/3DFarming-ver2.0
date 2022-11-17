using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uitest : MonoBehaviour
{
    public Click3D click3D;
    // Start is called before the first frame update
    void Start()
    {
        click3D.AddClickEvent(OnClick3D);
    }

    private void OnClick3D(Click3D btn)
    {
        gameObject.SetActive(true);
    }
}
