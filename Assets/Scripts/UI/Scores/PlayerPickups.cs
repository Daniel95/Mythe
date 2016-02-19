using UnityEngine;
using UnityEngine.UI;

public class PlayerPickups : ScoreBase {

    private int pickups;

    protected override void Count()
    {
        base.Count();
        if (Random.Range(0, 0.99f) < 0.01f)
        {
            incrementPickups();
        }
    }

    public int Pickups {
        get { return pickups; }
    }

    public void incrementPickups() {
        pickups++;
        UpdateTextField();
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
