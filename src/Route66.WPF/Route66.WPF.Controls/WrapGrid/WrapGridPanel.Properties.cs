using System.Windows;
using Route66.WPF.Controls.WrapGrid;

namespace Route66.WPF.Controls.WrapGrid;
public partial class WrapGridPanel {
    public const double Maximum = 100;

    public BreakPoints BreakPoints {
        get => (BreakPoints)this.GetValue(BreakPointsProperty);
        set => this.SetValue(BreakPointsProperty, value);
    }

    public static readonly DependencyProperty BreakPointsProperty =
        DependencyProperty.Register("BreakPoints",
                                    typeof(BreakPoints),
                                    typeof(WrapGridPanel),
                                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));

    public bool ShowGridLines {
        get => (bool)this.GetValue(ShowGridLinesProperty);
        set => this.SetValue(ShowGridLinesProperty, value);
    }

    public static readonly DependencyProperty ShowGridLinesProperty =
        DependencyProperty.Register("ShowGridLines", typeof(bool), typeof(WrapGridPanel), new PropertyMetadata(false));

    public static double GetXS(DependencyObject obj)
        => (double)obj.GetValue(XSProperty);

    public static void SetXS(DependencyObject obj, double value)
        => obj.SetValue(XSProperty, value);


    public static readonly DependencyProperty XSProperty =
        DependencyProperty.RegisterAttached("XS",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(Maximum, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetSM(DependencyObject obj)
        => (double)obj.GetValue(SMProperty);

    public static void SetSM(DependencyObject obj, double value)
        => obj.SetValue(SMProperty, value);

    public static readonly DependencyProperty SMProperty =
        DependencyProperty.RegisterAttached("SM",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(Maximum, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetMD(DependencyObject obj)
        => (double)obj.GetValue(MDProperty);

    public static void SetMD(DependencyObject obj, double value)
        => obj.SetValue(MDProperty, value);


    public static readonly DependencyProperty MDProperty =
        DependencyProperty.RegisterAttached("MD",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(Maximum, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetLG(DependencyObject obj)
        => (double)obj.GetValue(LGProperty);

    public static void SetLG(DependencyObject obj, double value)
        => obj.SetValue(LGProperty, value);


    public static readonly DependencyProperty LGProperty =
        DependencyProperty.RegisterAttached("LG",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(Maximum, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double? GetXS_Offset(DependencyObject obj)
        => (double?)obj.GetValue(XS_OffsetProperty);

    public static void SetXS_Offset(DependencyObject obj, double? value)
        => obj.SetValue(XS_OffsetProperty, value);

    public static readonly DependencyProperty XS_OffsetProperty =
        DependencyProperty.RegisterAttached("XS_Offset",
                                            typeof(double?),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double? GetSM_Offset(DependencyObject obj)
        => (double?)obj.GetValue(SM_OffsetProperty);

    public static void SetSM_Offset(DependencyObject obj, double? value)
        => obj.SetValue(SM_OffsetProperty, value);

    public static readonly DependencyProperty SM_OffsetProperty =
        DependencyProperty.RegisterAttached("SM_Offset",
                                            typeof(double?),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double? GetMD_Offset(DependencyObject obj)
        => (double?)obj.GetValue(MD_OffsetProperty);

    public static void SetMD_Offset(DependencyObject obj, double? value)
        => obj.SetValue(MD_OffsetProperty, value);

    public static readonly DependencyProperty MD_OffsetProperty =
        DependencyProperty.RegisterAttached("MD_Offset",
                                            typeof(double?),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double? GetLG_Offset(DependencyObject obj)
        => (double?)obj.GetValue(LG_OffsetProperty);

    public static void SetLG_Offset(DependencyObject obj, double? value)
        => obj.SetValue(LG_OffsetProperty, value);

    public static readonly DependencyProperty LG_OffsetProperty =
        DependencyProperty.RegisterAttached("LG_Offset",
                                            typeof(double?),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetXS_Push(DependencyObject obj)
        => (double)obj.GetValue(XS_PushProperty);

    public static void SetXS_Push(DependencyObject obj, double value)
        => obj.SetValue(XS_PushProperty, value);

    public static readonly DependencyProperty XS_PushProperty =
        DependencyProperty.RegisterAttached("XS_Push",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetSM_Push(DependencyObject obj)
        => (double)obj.GetValue(SM_PushProperty);

    public static void SetSM_Push(DependencyObject obj, double value)
        => obj.SetValue(SM_PushProperty, value);

    public static readonly DependencyProperty SM_PushProperty =
        DependencyProperty.RegisterAttached("SM_Push",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetMD_Push(DependencyObject obj)
        => (double)obj.GetValue(MD_PushProperty);

    public static void SetMD_Push(DependencyObject obj, double value)
        => obj.SetValue(MD_PushProperty, value);

    public static readonly DependencyProperty MD_PushProperty =
        DependencyProperty.RegisterAttached("MD_Push",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetLG_Push(DependencyObject obj)
        => (double)obj.GetValue(LG_PushProperty);

    public static void SetLG_Push(DependencyObject obj, double value)
        => obj.SetValue(LG_PushProperty, value);

    public static readonly DependencyProperty LG_PushProperty =
        DependencyProperty.RegisterAttached("LG_Push",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetXS_Pull(DependencyObject obj)
        => (double)obj.GetValue(XS_PullProperty);

    public static void SetXS_Pull(DependencyObject obj, double value)
        => obj.SetValue(XS_PullProperty, value);

    public static readonly DependencyProperty XS_PullProperty =
        DependencyProperty.RegisterAttached("XS_Pull",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetSM_Pull(DependencyObject obj)
        => (double)obj.GetValue(SM_PullProperty);

    public static void SetSM_Pull(DependencyObject obj, double value)
        => obj.SetValue(SM_PullProperty, value);

    public static readonly DependencyProperty SM_PullProperty =
        DependencyProperty.RegisterAttached("SM_Pull",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetMD_Pull(DependencyObject obj)
        => (double)obj.GetValue(MD_PullProperty);

    public static void SetMD_Pull(DependencyObject obj, double value)
        => obj.SetValue(MD_PullProperty, value);

    public static readonly DependencyProperty MD_PullProperty =
        DependencyProperty.RegisterAttached("MD_Pull",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));

    public static double GetLG_Pull(DependencyObject obj)
        => (double)obj.GetValue(LG_PullProperty);

    public static void SetLG_Pull(DependencyObject obj, double value)
        => obj.SetValue(LG_PullProperty, value);

    public static readonly DependencyProperty LG_PullProperty =
        DependencyProperty.RegisterAttached("LG_Pull",
                                            typeof(double),
                                            typeof(WrapGridPanel),
                                            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
    public static double GetActualOffset(DependencyObject obj)
        => (double)obj.GetValue(ActualOffsetProperty);

    protected static void SetActualOffset(DependencyObject obj, double value)
        => obj.SetValue(ActualOffsetProperty, value);

    public static readonly DependencyProperty ActualOffsetProperty =
        DependencyProperty.RegisterAttached("ActualOffset", typeof(double), typeof(WrapGridPanel), new PropertyMetadata(0d));

    public static int GetActualRow(DependencyObject obj)
            => (int)obj.GetValue(ActualRowProperty);

    protected static void SetActualRow(DependencyObject obj, int value)
        => obj.SetValue(ActualRowProperty, value);

    public static readonly DependencyProperty ActualRowProperty =
        DependencyProperty.RegisterAttached("ActualRow", typeof(int), typeof(WrapGridPanel), new PropertyMetadata(0));
}
