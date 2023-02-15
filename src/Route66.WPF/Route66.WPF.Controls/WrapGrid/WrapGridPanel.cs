using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Route66.WPF.Controls.WrapGrid;

public partial class WrapGridPanel : Panel {
    private static readonly Pen yellowPen = new Pen(Brushes.Yellow, 1);
    private static readonly Pen bluePen = new Pen(Brushes.Blue, 1) {
        DashStyle = new DashStyle(new double[] { 6, 6 }, 0)
    };
    private readonly IList<double> columnOffsets = new List<double>();

    public WrapGridPanel() {
        // properties
        this.BreakPoints = new BreakPoints();
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo) {
        base.OnRenderSizeChanged(sizeInfo);
        this.InvalidateMeasure();
    }

    protected override Size MeasureOverride(Size availableSize) {
        var totalSize = new Size();
        if (this.ActualWidth <= 0)
            return totalSize;

        if (this.Children.Count <= 0)
            return totalSize;

        var context = new WrapGridMeasureContext(this.ActualWidth);

        foreach (UIElement child in this.Children) {
            if (child == null)
                continue;

            if (child.Visibility == Visibility.Collapsed)
                continue;

            // collect properties
            var push = this.GetPush(child, context.MaxWidth);
            var pull = this.GetPull(child, context.MaxWidth);
            var offset = this.GetOffset(child, context.MaxWidth);
            var width = this.GetWidth(child, context.MaxWidth);

            // normalize properties
            push = context.NormalizeShift(push);
            pull = context.NormalizeShift(pull);
            context.NormalizeOffset(offset, push - pull);
            width = context.NormalizeWidth(width);

            WrapGridPanel.SetActualOffset(child, context.CurrentOffset);
            WrapGridPanel.SetActualRow(child, context.CurrentRow);

            context.AddElement(width);

            var size = new Size(width, double.PositiveInfinity);
            child.Measure(size);
        }

        var rowGroups = this.Children
            .OfType<UIElement>()
            .GroupBy(obj => WrapGridPanel.GetActualRow(obj))
            .ToArray();

        totalSize.Width = rowGroups.Max(rows => rows.Sum(o => o.DesiredSize.Width));
        totalSize.Height = rowGroups.Sum(rows => rows.Max(o => o.DesiredSize.Height));
        return totalSize;
    }

    protected override Size ArrangeOverride(Size finalSize) {
        this.columnOffsets.Clear();
        if (this.Children.Count == 0)
            return base.ArrangeOverride(finalSize);

        var rowGroups = this.Children
            .OfType<UIElement>()
            .GroupBy(obj => WrapGridPanel.GetActualRow(obj))
            .ToArray();

        var location = new Point();
        foreach (var rowGroup in rowGroups) {
            var rowHeight = rowGroup.Max(o => o.DesiredSize.Height);

            foreach (var element in rowGroup) {
                location.X = WrapGridPanel.GetActualOffset(element);
                var width = this.GetWidth(element, finalSize.Width);
                var size = new Size(width, rowHeight);
                var rect = new Rect(location, size);

                element.Arrange(rect);
            }

            location.Y += rowHeight;
        }
        return base.ArrangeOverride(finalSize);
    }

    protected override void OnRender(DrawingContext dc) {
        base.OnRender(dc);
        this.RenderGridLines(dc);
    }

    protected double? GetOffset(UIElement element, double availableWidth) {
        // default: availableWidth < 768
        if (availableWidth < this.BreakPoints.XS_SM)
            return getOffsetXS();

        // default: availableWidth < 992
        if (availableWidth < this.BreakPoints.SM_MD)
            return getOffsetSM();

        // default: availableWidth < 1200
        if (availableWidth < this.BreakPoints.MD_LG)
            return getOffsetMD();

        // default: availableWidth >= 1200
        return getOffsetLG();
        // locals
        double? getOffsetXS()
            => getOffset(WrapGridPanel.GetXS_Offset, () => null);

        double? getOffsetSM()
            => getOffset(WrapGridPanel.GetSM_Offset, getOffsetXS);

        double? getOffsetMD()
            => getOffset(WrapGridPanel.GetMD_Offset, getOffsetSM);

        double? getOffsetLG()
            => getOffset(WrapGridPanel.GetLG_Offset, getOffsetMD);

        double? getOffset(Func<DependencyObject, double?> getOffsetFor, Func<double?> getOffsetDowngrade)
            => GetCascadeWidth(element, availableWidth, getOffsetFor, getOffsetDowngrade);
    }

    /// <summary>
    /// Gets column span based on available width
    /// </summary>
    protected double GetWidth(UIElement element, double availableWidth) {
        // default: availableWidth < 768
        if (availableWidth < this.BreakPoints.XS_SM)
            return getSpanXS();

        // default: availableWidth < 992
        if (availableWidth < this.BreakPoints.SM_MD)
            return getSpanSM();

        // default: availableWidth < 1200
        if (availableWidth < this.BreakPoints.MD_LG)
            return getSpanMD();

        // default: availableWidth >= 1200
        return getSpanLG();
        // locals
        double getSpanXS()
            => getSpan(WrapGridPanel.GetXS, () => availableWidth);

        double getSpanSM()
            => getSpan(WrapGridPanel.GetSM, getSpanXS);

        double getSpanMD()
            => getSpan(WrapGridPanel.GetMD, getSpanSM);

        double getSpanLG()
            => getSpan(WrapGridPanel.GetLG, getSpanMD);

        double getSpan(Func<DependencyObject, double> getSpanFor, Func<double> getSpanDowngrade)
            => GetCascadeWidth(element, availableWidth, getSpanFor, getSpanDowngrade);
    }

    protected double GetPush(UIElement element, double availableWidth) {
        // default: availableWidth < 768
        if (availableWidth < this.BreakPoints.XS_SM)
            return getPushXS();

        // default: availableWidth < 992
        if (availableWidth < this.BreakPoints.SM_MD)
            return getPushSM();

        // default: availableWidth < 1200
        if (availableWidth < this.BreakPoints.MD_LG)
            return getPushMD();

        // default: availableWidth >= 1200
        return getPushLG();
        // locals
        double getPushXS()
            => getPush(WrapGridPanel.GetXS_Push, () => 0);

        double getPushSM()
            => getPush(WrapGridPanel.GetSM_Push, getPushXS);

        double getPushMD()
            => getPush(WrapGridPanel.GetMD_Push, getPushSM);

        double getPushLG()
            => getPush(WrapGridPanel.GetLG_Push, getPushMD);

        double getPush(Func<DependencyObject, double> getPushFor, Func<double> getPushDowngrade)
            => GetCascadeWidth(element, availableWidth, getPushFor, getPushDowngrade);
    }

    protected double GetPull(UIElement element, double availableWidth) {
        // default: availableWidth < 768
        if (availableWidth < this.BreakPoints.XS_SM)
            return getPullXS();

        // default: availableWidth < 992
        if (availableWidth < this.BreakPoints.SM_MD)
            return getPullSM();

        // default: availableWidth < 1200
        if (availableWidth < this.BreakPoints.MD_LG)
            return getPullMD();

        // default: availableWidth >= 1200
        return getPullLG();
        // locals
        double getPullXS()
            => getPull(WrapGridPanel.GetXS_Pull, () => 0);

        double getPullSM()
            => getPull(WrapGridPanel.GetSM_Pull, getPullXS);

        double getPullMD()
            => getPull(WrapGridPanel.GetMD_Pull, getPullSM);

        double getPullLG()
            => getPull(WrapGridPanel.GetLG_Pull, getPullMD);

        double getPull(Func<DependencyObject, double> getPullFor, Func<double> getPullDowngrade)
            => GetCascadeWidth(element, availableWidth, getPullFor, getPullDowngrade);
    }

    private static double GetCascadeWidth(
        DependencyObject element, double availableWidth,
        Func<DependencyObject, double> getWidthFor, Func<double> getWidthDowngrade) {
        // percent
        var width = getWidthFor(element);
        // dpi
        width = CalculateWidth(availableWidth, width);
        if (width > 0 && width <= availableWidth)
            return width;

        // default
        return getWidthDowngrade();
    }

    private static double? GetCascadeWidth(
        DependencyObject element, double availableWidth,
        Func<DependencyObject, double?> getWidthFor, Func<double?> getWidthDowngrade) {
        // percent
        var width = getWidthFor(element);
        if (!width.HasValue)
            // default
            return getWidthDowngrade();

        // dpi
        width = CalculateWidth(availableWidth, width.Value);
        if (width >= 0 && width <= availableWidth)
            return width;

        // default
        return getWidthDowngrade();
    }

    private static double CalculateWidth(double availableWidth, double percentage)
        => availableWidth * percentage / Maximum;

    private void RenderGridLines(DrawingContext dc) {
        if (!this.ShowGridLines)
            return;

        foreach (var offset in columnOffsets) {
            if (offset == 0)
                continue;

            var topPoint = new Point(offset, 0);
            var bottomPoint = new Point(offset, this.ActualHeight);
            dc.DrawLine(WrapGridPanel.yellowPen, topPoint, bottomPoint);
            dc.DrawLine(WrapGridPanel.bluePen, topPoint, bottomPoint);
        }
    }
}
