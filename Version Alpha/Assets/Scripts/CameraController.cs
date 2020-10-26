using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject aim;
  public float timeOffset;
  public Vector3 posOffset;

  private Vector3 velocity;

  void Update()
  {
      transform.position = Vector3.SmoothDamp(transform.position, aim.transform.position + posOffset, ref velocity, timeOffset);
  }
}
