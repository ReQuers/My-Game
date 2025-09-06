using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform pivot;
    private Vector3 offset = new Vector3(0, 5, -10);
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = pivot.position + pivot.TransformDirection(offset);
        transform.LookAt(pivot.position);
    }
}
