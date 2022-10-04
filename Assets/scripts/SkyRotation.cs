using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 1.2f;

    private static readonly int Rotation = Shader.PropertyToID("_Rotation");

    private void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat(Rotation, _rotationSpeed * Time.time);
    }
}
