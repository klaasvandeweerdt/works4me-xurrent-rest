using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="TimesheetSetting"/> records.
    /// </summary>
    public sealed class TimesheetSettingQuery
        : Query<TimesheetSettingQuery, TimesheetSetting.PredefinedFilter, TimesheetSetting.Field, TimesheetSetting.FilterField, TimesheetSetting.OrderField>
    {
    }
}
