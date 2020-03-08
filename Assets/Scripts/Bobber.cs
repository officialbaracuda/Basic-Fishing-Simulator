using UnityEngine;

public class Bobber : MonoBehaviour
{
    private Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }
    public void Shake() {
        Vector3 randPos = Random.insideUnitSphere / 2;
        transform.position = Vector3.Lerp(initialPos + randPos, transform.position, 0.9f );
    }
}
