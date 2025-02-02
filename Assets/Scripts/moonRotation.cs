using Unity.VisualScripting;
using UnityEngine;

public class moonRotation : MonoBehaviour
{
    [SerializeField] float smooth;
    [SerializeField] float tiltSpeed;
    private float currTilt;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        currTilt += input * tiltSpeed * Time.deltaTime;

        // rotate moon by converting angles into a quaternion
        Quaternion target = Quaternion.Euler(0, 0, currTilt);

        // dampen towards target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
