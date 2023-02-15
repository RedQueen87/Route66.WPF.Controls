using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Route66.WPF.Controls.WrapGrid;

public class BreakPointsTypeConverter : TypeConverter {
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string);

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) {
        var text = (string)value;
        var list = text
            .Split(',')
            .Select(o => o.Trim())
            .Select(o => double.Parse(o) as double?)
            .ToArray();

        return new BreakPoints {
            XS_SM = list.ElementAtOrDefault(0) ?? BreakPoints.XS_SM_Default,
            SM_MD = list.ElementAtOrDefault(1) ?? BreakPoints.SM_MD_Default,
            MD_LG = list.ElementAtOrDefault(2) ?? BreakPoints.MD_LG_Default
        };
    }
}
