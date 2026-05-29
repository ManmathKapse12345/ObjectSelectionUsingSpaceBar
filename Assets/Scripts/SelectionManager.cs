using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private const int numberOfObjects = 5;
    private const float speed = 10f;
    public GameObject[] objects = new GameObject[numberOfObjects];
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        Renderer rend = objects[index].GetComponent<Renderer>();
        Material mat = rend.material;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", Color.green * 5.0f);
        Debug.Log(objects[index].name);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (objects[i].name == "Cube")
            {
                objects[i].transform.Rotate((Vector3.right + Vector3.up + Vector3.forward) * Time.deltaTime * speed);
            }
            else if (objects[i].name == "Plane")
            {
                objects[i].transform.Rotate(Vector3.up * Time.deltaTime * speed);
            }
            else
            {
                objects[i].transform.Rotate(Vector3.right * Time.deltaTime * speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Renderer rend = objects[index].GetComponent<Renderer>();
            Material mat = rend.material;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.black);
            index = (index + 1) % numberOfObjects;
            rend = objects[index].GetComponent<Renderer>();
            mat = rend.material;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.green * 5.0f);
            Debug.Log(objects[index].name);
        }

    }
}
