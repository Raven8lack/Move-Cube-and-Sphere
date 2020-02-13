using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] public GameObject CubeToSpawn;
    [SerializeField] public GameObject SphereToSpawn;
    public ObjectManager ManagerObject;

    private void Start()
    {
        ManagerObject = GameObject.Find("Check").GetComponent<ObjectManager>();
    }

    private void Update()
    {
        ManagerObject.MoveObject();
    }

    public void SpawnCube()
    {
        ManagerObject.Spawn_Cube();
    }

    public void SpawnSphere()
    {
        ManagerObject.Spawn_Sphere();
    }

    public void DeleteObject()
    {
        ManagerObject.Delete();
    }

    public void ChangeColor()
    {
        ManagerObject.ColorCheck();
    }

    public void ChangeSlider(float value) => ManagerObject.Slider(value);
}
