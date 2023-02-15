namespace Route66.WPF.Controls.WrapGrid;

public class WrapGridMeasureContext {
    public WrapGridMeasureContext(double maxWidth) {
        // properties
        MaxWidth = maxWidth;
    }

    #region Properties

    public double MaxWidth { get; }

    public int CurrentRow { get; private set; } = 0;

    public int CurrentRowElementsCount { get; private set; } = 0;

    public double CurrentOffset {
        get => currentOffset;
        private set {
            currentOffset = value;

            if (currentOffset < MaxWidth)
                return;

            currentOffset %= MaxWidth;
            IncrementRow();
        }
    }
    private double currentOffset = 0;

    #endregion

    public void NormalizeOffset(double? offset, double shift) {
        // no value
        if (!offset.HasValue)
            offset = CurrentOffset;

        // negative value
        if (offset.Value < 0)
            offset = CurrentOffset;

        // too large to see at all
        offset += shift;
        offset %= MaxWidth;

        // too large to see in current row
        if (offset.Value < CurrentOffset)
            IncrementRow();

        // ok
        CurrentOffset = offset.Value;
    }

    public double NormalizeWidth(double width) {
        // negative value or zero
        if (width <= 0)
            width = MaxWidth;
        // never fit (width > 100%)
        else if (width > MaxWidth)
            width = MaxWidth;

        // fit in current row
        if (CurrentOffset + width <= MaxWidth)
            return width;

        // shift to next row
        IncrementRow();
        // ok
        return width;
    }

    /// <summary>
    /// Normalize push or pull
    /// </summary>
    public double NormalizeShift(double shift) {
        // negative value or zero
        if (shift < 0)
            return 0;

        // never fit (shift > 100%)
        if (shift > MaxWidth)
            return MaxWidth;

        // ok
        return shift;
    }

    public void AddElement(double width) {
        CurrentRowElementsCount++;
        CurrentOffset += width;
    }

    private bool IncrementRow() {
        if (CurrentRowElementsCount <= 0)
            return false;

        CurrentRow++;
        CurrentOffset = 0;
        CurrentRowElementsCount = 0;
        return true;
    }
}
