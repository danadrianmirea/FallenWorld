using System;

[Serializable]
public class Experience : StorageForValue
{
    private static float everyLevel = 0.2f;
    private int _bank;

    public Action OnLeveLUp;
    internal int LeveL { get; private set; }

    public override void Initialize()
    {
        base.Initialize();

        _bar.Initialize(this);
        _bar.UpdateFillAmountAndText();
        LeveL = 1;
    }

    public override void AddToCurrent(float value)
    {
        base.AddToCurrent(value);

        if (IsFull)
        {
            LeveL++;
            _bank = (int)(current - total);
            current = 0f;
            total += total * everyLevel;
            AddToCurrent(_bank);
            OnLeveLUp?.Invoke();
        }

        _bar.UpdateFillAmountAndText();
    }

    public void LoadSavedLevel(int level)
    {
        LeveL = level;
    }
}