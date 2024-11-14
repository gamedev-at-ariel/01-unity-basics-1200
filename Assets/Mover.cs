using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Horizontal speed of object, in meters per second")]
    float speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Starting");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Updating");
        GetComponent<Transform>().position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
