using UnityEngine;

public class Bobber : MonoBehaviour
{
    public void Shake() {
        Vector3 randPos = Random.insideUnitSphere / 2;
        transform.position = Vector3.Lerp(transform.position + randPos, transform.position, 0.9f );
    }
}
