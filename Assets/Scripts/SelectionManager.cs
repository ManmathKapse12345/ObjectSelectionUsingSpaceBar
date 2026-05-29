using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SelectionManager : MonoBehaviour
{
    private const int numberOfObjects = 5;
    public Canvas canv;
    private TMP_Text label;
    private const float speed = 10f;
    public GameObject[] objects = new GameObject[numberOfObjects];
    private Vector3[] labelPosition = new Vector3[]
    {
        new Vector3(-8.64f,-2.42f,-1.57f),
        new Vector3(-5.48f,-2.42f,-1.57f),
        new Vector3(-2.3f,-2.42f,-1.57f),
        new Vector3(1.37f,-2.42f,-1.57f),
        new Vector3(7f,-2.42f,-1.57f)
    };
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        label = canv.GetComponentInChildren<TMP_Text>();
        index = 0;
        Renderer rend = objects[index].GetComponent<Renderer>();
        Material mat = rend.material;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", Color.green * 5.0f);
        Debug.Log(objects[index].name);
        canv.transform.position = labelPosition[index];
        label.text = objects[index].name;
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
                objects[i].transform.Rotate(Vector3.left * Time.deltaTime * speed);
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
            canv.transform.position = labelPosition[index];
            label.text = objects[index].name;
        }

    }
}
