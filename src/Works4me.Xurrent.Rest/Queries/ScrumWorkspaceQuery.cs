using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ScrumWorkspace"/> records.
    /// </summary>
    public sealed class ScrumWorkspaceQuery
        : Query<ScrumWorkspaceQuery, ScrumWorkspace.PredefinedFilter, ScrumWorkspace.Field, ScrumWorkspace.FilterField, ScrumWorkspace.OrderField>
    {
    }
}
