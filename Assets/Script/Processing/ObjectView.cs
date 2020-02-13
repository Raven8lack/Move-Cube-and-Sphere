using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView : MonoBehaviour
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

    public void SliderCheck(float NewValue)
    {
        Vector3 pos = GetComponent<Renderer>().transform.localScale;
        pos.x = NewValue;
        pos.y = NewValue;
        pos.z = NewValue;
        GetComponent<Renderer>().transform.localScale = pos;
    }
}
