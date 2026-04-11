using System;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Queries.Custom;

namespace Works4me.Xurrent.Rest
{
    partial class AccountClient
    {
        /// <summary>
        /// Retrieves all available usage statements for the current account.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only collection with all usage statements.</returns>
        public async Task<ReadOnlyKeyedDataCollection<UsageStatement>> GetUsageStatementsAsync(CancellationToken ct = default)
        {
            return await GetListAsync<UsageStatement>(new UsageStatementQuery().SelectAll(), "usage_statements", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a specific usage statement by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the usage statement.
        /// </param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only collection with all usage statements.</returns>
        public async Task<ReadOnlyKeyedDataCollection<UsageStatement>> GetUsageStatementsAsync(long id, CancellationToken ct = default)
        {
            return await GetListAsync<UsageStatement>(new UsageStatementQuery().SelectAll(), $"usage_statements/{id}", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves usage statements for a specific year and month.
        /// </summary>
        /// <param name="year">The calendar year of the usage statements.</param>
        /// <param name="month">The calendar month of the usage statements (1–12).</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only collection with all usage statements.</returns>
        public async Task<ReadOnlyKeyedDataCollection<UsageStatement>> GetUsageStatementsAsync(int year, int month, CancellationToken ct = default)
        {
            DateTime utcNow = DateTime.UtcNow;

            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), month, "The month must be between 1 and 12.");

            if (year < 2010)
                throw new ArgumentOutOfRangeException(nameof(year), year, "The specified year predates ITRP, was never 4me, and certainly not Xurrent.");

            if (year > utcNow.Year)
                throw new ArgumentOutOfRangeException(nameof(year), year, "The year cannot be greater than the current year.");

            if (year == utcNow.Year && month > utcNow.Month)
                throw new ArgumentOutOfRangeException(nameof(month), month, "The month cannot be greater than the current month of the current year.");

            return await GetListAsync<UsageStatement>(new UsageStatementQuery().SelectAll(), $"usage_statements/?year={year}&month={month}", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all billable users for the current account.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only collection with all billable users.</returns>
        public async Task<ReadOnlyKeyedDataCollection<BillableUser>> GetBillableUsersAsync(CancellationToken ct = default)
        {
            return await GetListAsync<BillableUser>(new BillableUserQuery().SelectAll(), "billable_users", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all billable users for a specific year and month.
        /// </summary>
        /// <param name="year">The calendar year of the usage statements.</param>
        /// <param name="month">The calendar month of the usage statements (1–12).</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only collection with all billable users.</returns>

        public async Task<ReadOnlyKeyedDataCollection<BillableUser>> GetBillableUsersAsync(int year, int month, CancellationToken ct = default)
        {
            DateTime utcNow = DateTime.UtcNow;

            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), month, "The month must be between 1 and 12.");

            if (year < 2010)
                throw new ArgumentOutOfRangeException(nameof(year), year, "The specified year predates ITRP, was never 4me, and certainly not Xurrent.");

            if (year > utcNow.Year)
                throw new ArgumentOutOfRangeException(nameof(year), year, "The year cannot be greater than the current year.");

            if (year == utcNow.Year && month > utcNow.Month)
                throw new ArgumentOutOfRangeException(nameof(month), month, "The month cannot be greater than the current month of the current year.");

            return await GetListAsync<BillableUser>(new BillableUserQuery().SelectAll(), $"billable_users/?year={year}&month={month}", ct).ConfigureAwait(false);
        }

    }
}
