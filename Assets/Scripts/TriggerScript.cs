using UnityEngine;

public class Triger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnergyScript.MaxEnergy += 100;
        EnergyScript.MaxEnergy = Mathf.Clamp(EnergyScript.MaxEnergy, 0, 100);
        Destroy(gameObject);
    }
}
