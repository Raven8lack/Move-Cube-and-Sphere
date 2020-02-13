using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectViewold : MonoBehaviour
{

    private Color _color;

    public Color Color
    {
        set
        {
            _color = value;
            UpdateView();
        }
        get
        {
            return _color;
        }
    }

    public void UpdateView()
    {
        GetComponent<Renderer>().material.color = Color;
    }
}
