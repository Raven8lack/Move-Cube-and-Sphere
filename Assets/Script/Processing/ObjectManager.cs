using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManager : MonoBehaviour
{
    public ObjectController Controller;
    public ObjectView SelectedObject;

    private void Start()
    {
        Controller = GameObject.Find("ObjectManager").GetComponent<ObjectController>();
        SelectedObject = GetComponent<ObjectView>();
    }

    public void MoveObject()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit))
            {
                var hitObject = hit.collider.GetComponent<ObjectView>();
                if(hitObject != null)
                {
                    SelectedObject = hitObject;
                }
                else
                {
                    SelectedObject = null;
                }
            }
            else
            {
                SelectedObject = null;
            }
        }

        if(SelectedObject != null)
        {
            if(Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out var hit))
                {
                    var pos = new Vector3(0f, 1f);
                    pos.z = hit.point.z;
                    pos.x = hit.point.x;
                    SelectedObject.transform.position = pos;
                }
            }
        }
    }

    public void Spawn_Cube()
    {
        SelectedObject = Instantiate(Controller.CubeToSpawn).GetComponent<ObjectView>();
    }

    public void Spawn_Sphere()
    {
        SelectedObject = Instantiate(Controller.SphereToSpawn).GetComponent<ObjectView>();
    }

    public void Delete()
    {
        if(SelectedObject == null)
        {
            return;
        }

        Destroy(SelectedObject.gameObject);
    }

    public void ColorCheck()
    {
        if(SelectedObject == null)
        {
            return;
        }

        SelectedObject.Color = SelectedObject.Color == Color.white ? Color.yellow : Color.white;
    }

    public void Slider(float Value)
    {
        if(SelectedObject != null)
        {
            if(SelectedObject.gameObject == GameObject.Find("Sphere(Clone)"))
            {
                SelectedObject.SliderCheck(Value);
            }
            else
            {
                return;
            }
        }
    }
}
