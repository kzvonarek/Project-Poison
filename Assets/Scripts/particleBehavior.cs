using UnityEngine;

public class particleBehavior : MonoBehaviour
{
    [SerializeField] float decayRate;

    void OnParticleCollision(GameObject other)
    {
        // get current scale
        Vector3 currentScale = transform.localScale;

        // calculate new height
        float newHeight = currentScale.y - (decayRate * Time.deltaTime);
        if (newHeight <= 0)
        {
            newHeight = 0;
        }

        // update scale
        transform.localScale = new Vector3(currentScale.x, newHeight, currentScale.z);

        // move object upwards, to make it seem like bottom is not decaying
        float heightDifference = (currentScale.y - newHeight) * 0.5f;
        transform.position += new Vector3(0, -heightDifference, 0);
    }
}
