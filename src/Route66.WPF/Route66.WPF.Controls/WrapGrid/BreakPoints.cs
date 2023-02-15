using System.ComponentModel;
using System.Windows;

namespace Route66.WPF.Controls.WrapGrid;

[TypeConverter(typeof(BreakPointsTypeConverter))]
public class BreakPoints : DependencyObject {
    public const double XS_SM_Default = 768d;
    public const double SM_MD_Default = 992d;
    public const double MD_LG_Default = 1200d;

    public BreakPoints() { }

    public double XS_SM {
        get => (double)GetValue(XS_SMProperty);
        set => SetValue(XS_SMProperty, value);
    }

    public static readonly DependencyProperty XS_SMProperty =
        DependencyProperty.Register("XS_SM", typeof(double), typeof(BreakPoints), new PropertyMetadata(XS_SM_Default));

    public double SM_MD {
        get => (double)GetValue(SM_MDProperty);
        set => SetValue(SM_MDProperty, value);
    }

    public static readonly DependencyProperty SM_MDProperty =
        DependencyProperty.Register("SM_MD", typeof(double), typeof(BreakPoints), new PropertyMetadata(SM_MD_Default));

    public double MD_LG {
        get => (double)GetValue(MD_LGProperty);
        set => SetValue(MD_LGProperty, value);
    }

    public static readonly DependencyProperty MD_LGProperty =
        DependencyProperty.Register("MD_LG", typeof(double), typeof(BreakPoints), new PropertyMetadata(MD_LG_Default));
}
