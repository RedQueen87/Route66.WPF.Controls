using Route66.WPF.Controls.WrapGrid;

namespace Route66.WPF.Controls.Test.WrapGrid;

public class WrapGridMeasureContextTest {
    /// <summary>
    /// Test two elements with summary width (1200) smaller than max width (1600).
    /// Takes one row.
    /// <code>
    ///   600   600  400
    /// +-----+-----+---+
    /// |xxxxx|xxxxx|   |
    /// +-----+-----+---+
    /// </code>
    /// </summary>
    [Test]
    public void Measure_LG_FitOneLine_Test() {
        const double expectedOffset = 1200;
        const double expectedRow = 0;

        // initial width is 1600 (1200 + 400)
        var context = new WrapGridMeasureContext(BreakPoints.MD_LG_Default + 400);
        var uiElements = new Element[] {
            new(null, 600, 0, 0),
            new(null, 600, 0, 0),
        };

        foreach (var element in uiElements) {
            var (offset, width, push, pull) = element;
            // normalize properties
            push = context.NormalizeShift(push);
            pull = context.NormalizeShift(pull);
            context.NormalizeOffset(offset, push - pull);
            width = context.NormalizeWidth(width);

            context.AddElement(width);
        }

        var actualOffset = context.CurrentOffset;
        var actualRow = context.CurrentRow;
        Assert.Multiple(() => {
            Assert.That(actualOffset, Is.EqualTo(expectedOffset));
            Assert.That(actualRow, Is.EqualTo(expectedRow));
        });
    }

    /// <summary>
    /// Test two elements with summary width (1700) greater than max width (1600).
    /// Takes two rows because second element is to large to fit first row.
    /// <code>
    ///      1200      700
    /// +------------+----+
    /// |xxxxxxxxxxxx|    |
    /// +------------+----+
    /// |xxxxx|           |
    /// +-----+-----------+
    ///   500
    /// </code>
    /// </summary>
    [Test]
    public void Measure_LG_NotFitOneLine_Auto_Test() {
        const double expectedOffset = 500;
        const double expectedRow = 1;

        // initial width is 1600 (1200 + 400)
        var context = new WrapGridMeasureContext(BreakPoints.MD_LG_Default + 400);
        var uiElements = new Element[] {
            new(null, 1200, 0, 0),
            new(null, 500, 0, 0),
        };

        foreach (var element in uiElements) {
            var (offset, width, push, pull) = element;
            // normalize properties
            push = context.NormalizeShift(push);
            pull = context.NormalizeShift(pull);
            context.NormalizeOffset(offset, push - pull);
            width = context.NormalizeWidth(width);

            context.AddElement(width);
        }

        var actualOffset = context.CurrentOffset;
        var actualRow = context.CurrentRow;
        Assert.Multiple(() => {
            Assert.That(actualOffset, Is.EqualTo(expectedOffset));
            Assert.That(actualRow, Is.EqualTo(expectedRow));
        });
    }

    /// <summary>
    /// Test two elements with summary width (1000) smaller than max width (1600).
    /// Takes two rows because second element offset force to change row.
    /// <code>
    ///   500      700
    /// +-----+-----------+
    /// |xxxxx|           |
    /// +-----+-----------+
    /// |xxxxx|           |
    /// +-----+-----------+
    /// </code>
    /// </summary>
    [Test]
    public void Measure_LG_FitTwoLines_Offset_Test() {
        const double expectedOffset = 500;
        const double expectedRow = 1;

        // initial width is 1600 (1200 + 400)
        var context = new WrapGridMeasureContext(BreakPoints.MD_LG_Default + 400);
        var uiElements = new Element[] {
            new(null, 500, 0, 0),
            new(0, 500, 0, 0),
        };

        foreach (var element in uiElements) {
            var (offset, width, push, pull) = element;
            // normalize properties
            push = context.NormalizeShift(push);
            pull = context.NormalizeShift(pull);
            context.NormalizeOffset(offset, push - pull);
            width = context.NormalizeWidth(width);

            context.AddElement(width);
        }

        var actualOffset = context.CurrentOffset;
        var actualRow = context.CurrentRow;
        Assert.Multiple(() => {
            Assert.That(actualOffset, Is.EqualTo(expectedOffset));
            Assert.That(actualRow, Is.EqualTo(expectedRow));
        });
    }
}

record Element(double? Offset, double Width, double Push, double Pull);