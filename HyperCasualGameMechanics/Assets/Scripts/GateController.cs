using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    [SerializeField] private TMP_Text _TmpTextGateNumb;

    [SerializeField]
    private enum GateType
    {
        PosGate,
        Neggate
    }

    [SerializeField] private GateType _gatetype;
    [SerializeField] private int _gatenumber;

    private void Start()
    {
        GateUpdate();
    }

    public int GetGateNumber()
    {
        return _gatenumber;
    }
    private void GateUpdate()
    {
        switch (_gatetype)
        {
            case GateType.PosGate:_gatenumber = Random.Range(1, 10);
                _TmpTextGateNumb.text = _gatenumber.ToString();
                    break;
            case GateType.Neggate:
                _gatenumber = Random.Range(-10, -1);
                _TmpTextGateNumb.text = _gatenumber.ToString();
                break;
        }

    }
}
