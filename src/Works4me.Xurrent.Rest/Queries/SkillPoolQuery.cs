using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="SkillPool"/> records.
    /// </summary>
    public sealed class SkillPoolQuery
        : Query<SkillPoolQuery, SkillPool.PredefinedFilter, SkillPool.Field, SkillPool.FilterField, SkillPool.OrderField>
    {
    }
}
