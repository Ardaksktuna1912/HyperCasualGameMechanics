using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _Horizontalspeed;
    [SerializeField] private float _Movespeed;
    public float horizontalXLimit;
    float _horizontal;
    float newx;
    [SerializeField] private TMP_Text _Ballcountext;
    [SerializeField] private List<GameObject> _list = new List<GameObject>();
    [SerializeField] private int _gatenumber;
    [SerializeField] private GameObject _Ballpre;

    [SerializeField] private int _targetcount;
    void Start()
    {

    }


    void Update()
    {
        Forward();
        Move();
        IUpdate();

    }

    public void Move()
    {
        if (Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            _horizontal = 0;
        }
        newx = transform.position.x + _horizontal * _Horizontalspeed * Time.deltaTime;
        newx = Mathf.Clamp(newx, -horizontalXLimit, horizontalXLimit);

        transform.position = new Vector3(newx, transform.position.y, transform.position.z);
    }
    public void Forward()
    {
        transform.Translate(Vector3.forward * _Movespeed * Time.deltaTime);
    }

    public void IUpdate()
    {
        _Ballcountext.text = (_list.Count - 1).ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stack"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, _list[_list.Count - 1].transform.localPosition.z - 1f);
            _list.Add(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Gate"))
        {
            _gatenumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            _targetcount = _list.Count + _gatenumber;
            if (_gatenumber > 0)
            {
                Toplacogalttoplari();
            }
            else if(_gatenumber<0)
            {
                RemoveAzalt();
            }
        }

        


    }
    private void Toplacogalttoplari()
    {
        for (int i = 0; i < _gatenumber; i++)
        {
            GameObject newball = Instantiate(_Ballpre);
            newball.transform.SetParent(transform);
            newball.GetComponent<SphereCollider>().enabled = false;
            newball.gameObject.transform.localPosition = new Vector3(0f, 0f, _list[_list.Count - 1].transform.localPosition.z - 1f);
            _list.Add(newball);
        }
    }
    private void RemoveAzalt()
    {
        for (int j = _list.Count-1; j >= _targetcount; j--)
        {
            _list[j].SetActive(false);
            _list.RemoveAt(j);
        }
    }
}
