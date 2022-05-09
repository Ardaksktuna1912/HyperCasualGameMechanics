using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform _balltrans;
    private Vector3 _offset;

    [SerializeField]private float _lerptime;
    private void Start()
    {
        _offset = transform.position - _balltrans.position;
    }

    private void LateUpdate()
    {
        Vector3 newpos = Vector3.Lerp(transform.position,_balltrans.position+_offset,_lerptime*Time.deltaTime);
        transform.position = newpos;
    }
}