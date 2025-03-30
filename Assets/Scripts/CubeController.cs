using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class CubeController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveAmount = 1f;
    [SerializeField] private float rotateAmount = 30f;
    [SerializeField] private float actionDuration = 0.5f;
    
    [Header("AR Settings")]
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private float distanceFromCamera = 1.0f;
    
    private Camera arCamera;
    
    private void Start()
    {
        if (xrOrigin == null) xrOrigin = FindObjectOfType<XROrigin>();
        if (xrOrigin != null) arCamera = xrOrigin.Camera;
        SetCubePositionInView();
    }
    
    // Method to position cube in AR space using XROrigin
    private void SetCubePositionInView()
    {
        if (arCamera != null)
        {
            transform.position = arCamera.transform.position + 
                                 arCamera.transform.forward * distanceFromCamera;
        }
    }

    public void MoveCubeUp()
    {
        Debug.Log("moveu");
        transform.position += Vector3.up * moveAmount;
    }

    public void MoveCubeDown()
    {
        Debug.Log("moved");
        transform.position += Vector3.down * moveAmount;
    }

    public void RotateX()
    {
        Debug.Log("rotx");
        transform.Rotate(Vector3.right, rotateAmount);
    }

    public void RotateY()
    {
        Debug.Log("roty");
        transform.Rotate(Vector3.up, rotateAmount);
    }

    public void RotateZ()
    {
       Debug.Log("rotz");
       transform.Rotate(Vector3.forward, rotateAmount);
    }
}