using UnityEngine;
using UnityEngine.UI;

public class PlayerPickups : ScoreBase {

    private int pickups;

    public int Pickups {
        get { return pickups; }
    }

    protected override void ChangeValue(int _value)
    {
        pickups++;
        base.ChangeValue(_value);
    }

    protected override void UpdateTextField()
    {
        base.UpdateTextField();
        textField.text = standardText + pickups;
    }

    public override void ResetValue()
    {
        pickups = 0;
        base.ResetValue();
    }
}
