using UnityEngine;
using TMPro;

public class Billboard : MonoBehaviour
{
    Transform mainCameraTransform;
    [SerializeField] TMP_Text text;

    void Start()
    {
        // Get a reference to the main camera's transform
        mainCameraTransform=Camera.main.transform;
    }

    void Update()
    {
        // Make the text face the camera
        transform.LookAt(transform.position+mainCameraTransform.rotation*Vector3.forward ,
                         mainCameraTransform.rotation*Vector3.up);
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

}
