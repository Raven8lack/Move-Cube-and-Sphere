using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectManagerold : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    public ObjectViewold SelectedObject;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit))
            {
                var hitObject = hit.collider.GetComponent<ObjectViewold>();
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

    public void SpawnObject()
    {
        SelectedObject = Instantiate(objectToSpawn).GetComponent<ObjectViewold>();
    }

    public void DeleteObject()
    {
        if(SelectedObject == null)
        {
            return;
        }

        Destroy(SelectedObject.gameObject);
    }

    public void ChangeColor()
    {
        if(SelectedObject == null)
        {
            return;
        }

        SelectedObject.Color = SelectedObject.Color == Color.white ? Color.yellow : Color.white;
    }


    public void Slider_Changed(float newValue)
    {
        Vector3 pos = SelectedObject.transform.localScale;
        pos.x = newValue;
        pos.y = newValue;
        pos.z = newValue;
        SelectedObject.transform.localScale = pos;       
    }
}
