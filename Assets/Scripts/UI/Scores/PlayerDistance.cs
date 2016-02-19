using UnityEngine;

public class PlayerDistance : ScoreBase {

    private float distanceValue;

    private int distanceInt;

    protected override void Count()
    {
        base.Count();
        distanceInt = Mathf.RoundToInt(distanceValue += 2 * Time.deltaTime);
        UpdateTextField();
    }

    protected override void UpdateTextField()
    {
        base.UpdateTextField();
        textField.text = standardText + distanceInt;
    }

    public override void ResetValue()
    {
        distanceValue = 0;
        base.ResetValue();
    }

    public int Distance {
        get { return distanceInt; }
    }
}
