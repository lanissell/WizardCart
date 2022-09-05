using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.2f;

    private static readonly int Rotation = Shader.PropertyToID("_Rotation");

    private void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat(Rotation, rotationSpeed * Time.time);
    }
}
