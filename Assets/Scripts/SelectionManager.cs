using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    const int numberOfObjects = 5;
    public GameObject[] objects = new GameObject[numberOfObjects];
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        Renderer rend = objects[index].GetComponent<Renderer>();
        Material mat = rend.material;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor",Color.green*5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
