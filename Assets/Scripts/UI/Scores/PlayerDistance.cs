using UnityEngine;

public class PlayerDistance : ScoreBase {

    [SerializeField]
    private GameSpeed gameSpeed;

    private int distance;

    protected override void Count()
    {
        base.Count();
        distance = Mathf.RoundToInt(distance + GameSpeed.Speed);
        UpdateTextField();
    }

    protected override void UpdateTextField()
    {
        base.UpdateTextField();
        textField.text = standardText + distance;
    }

    public override void ResetValue()
    {
        distance = 0;
        base.ResetValue();
    }

    public int Distance {
        get { return distance; }
    }
}
