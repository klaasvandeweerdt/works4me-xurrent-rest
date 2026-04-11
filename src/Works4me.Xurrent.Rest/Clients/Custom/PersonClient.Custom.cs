using System;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class PersonClient
    {
        /// <summary>
        /// Retrieves a collection of <see cref="Person"/> records with roles in this account using the specified query.
        /// </summary>
        /// <param name="query">The query that defines which people to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Person"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Person>> GetPeopleWithRolesAsync(PersonQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Person>(query, "all_with_roles", ct).ConfigureAwait(false);
        }

        partial class PermissionsClient
        {
            /// <summary>
            /// Adds a <see cref="Permission"/> to the specified person.
            /// </summary>
            /// <param name="personId">The identifier of the person for which the permission is added.</param>
            /// <param name="permission">The permission to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The added <see cref="Permission"/> record.</returns>
            public async Task<Permission> AddAsync(long personId, Permission permission, CancellationToken ct = default)
            {
                if (permission is null)
                    throw new ArgumentNullException(nameof(permission));

                if (permission.Account is null || permission.Account.Id is null)
                    throw new ArgumentException(nameof(permission.Account));

                return await _client.PostItemAsync(personId, $"permissions/{permission.Account.Id}", permission, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Adds a <see cref="Permission"/> to the specified person.
            /// </summary>
            /// <param name="person">The person to which the permission is added.</param>
            /// <param name="permission">The permission to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The added <see cref="Permission"/> record.</returns>
            public async Task<Permission> AddAsync(Person person, Permission permission, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (permission is null)
                    throw new ArgumentNullException(nameof(permission));

                if (permission.Account is null || permission.Account.Id is null)
                    throw new ArgumentException(nameof(permission.Account));

                return await AddAsync(person.Id, permission, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Updates a <see cref="Permission"/> of the specified person, overwriting all existing permissions for the specified account.
            /// </summary>
            /// <param name="personId">The unique identifier of the person.</param>
            /// <param name="permission">The permission to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The updated <see cref="Permission"/> record.</returns>
            public async Task<Permission> UpdateAsync(long personId, Permission permission, CancellationToken ct = default)
            {
                if (permission is null)
                    throw new ArgumentNullException(nameof(permission));

                if (permission.Account is null || permission.Account.Id is null)
                    throw new ArgumentException(nameof(permission.Account));

                return await _client.PatchItemAsync(personId, $"permissions/{permission.Account.Id}", permission, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Updates a <see cref="Permission"/> of the specified person, overwriting all existing permissions for the specified account.
            /// </summary>
            /// <param name="person">The person for which to update the permission.</param>
            /// <param name="permission">The permission to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The updated <see cref="Permission"/> record.</returns>
            public async Task<Permission> UpdateAsync(Person person, Permission permission, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await UpdateAsync(person.Id, permission, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes the <see cref="Permission"/> of the specified person.
            /// </summary>
            /// <param name="personId">The identifier of the person for which to revoke the permissions.</param>
            /// <param name="permission">The permission to revoke.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAsync(long personId, Permission permission, CancellationToken ct = default)
            {
                if (permission is null)
                    throw new ArgumentNullException(nameof(permission));

                if (permission.Account is null || permission.Account.Id is null)
                    throw new ArgumentException(nameof(permission.Account));

                return await _client.DeleteItemAsync(personId, $"permissions/{permission.Account.Id}", permission, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes the <see cref="Permission"/> of the specified person.
            /// </summary>
            /// <param name="person">The person for which to revoke the permissions.</param>
            /// <param name="permission">The permission to revoke.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAsync(Person person, Permission permission, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAsync(person.Id, permission, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes all permissions in a specific account for the specified person.
            /// </summary>
            /// <param name="personId">The unique identifier of the person.</param>
            /// <param name="accountId">The identifier of the account in which to revoke the permissions.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAllAsync(long personId, string accountId, CancellationToken ct = default)
            {
                if (accountId is null)
                    throw new ArgumentNullException(nameof(accountId));

                return await _client.DeleteAllItemsAsync(personId, $"permissions/{accountId}", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes all permissions in a specific account for the specified person.
            /// </summary>
            /// <param name="personId">The identifier of the person for which to revoke the permissions.</param>
            /// <param name="account">The account in which to revoke the permissions.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAllAsync(long personId, Account account, CancellationToken ct = default)
            {
                if (account is null || account.Id is null)
                    throw new ArgumentNullException(nameof(account));

                return await DeleteAllAsync(personId, account.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes all permissions in a specific account for the specified person.
            /// </summary>
            /// <param name="person">The person for which to revoke the permissions.</param>
            /// <param name="accountId">The identifier of the account in which to revoke the permissions.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAllAsync(Person person, string accountId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAllAsync(person.Id, accountId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes all permissions in a specific account for the specified person.
            /// </summary>
            /// <param name="person">The person for which to revoke the permissions.</param>
            /// <param name="account">The account in which to revoke the permissions.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAllAsync(Person person, Account account, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (account is null || account.Id is null)
                    throw new ArgumentNullException(nameof(account));

                return await DeleteAllAsync(person.Id, account.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes all permissions in all accounts for the specified person.
            /// </summary>
            /// <param name="personId">The unique identifier of the person.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAllAsync(long personId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(personId, "permissions", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Revokes all permissions in all accounts for the specified person.
            /// </summary>
            /// <param name="person">The person for which to remove the permissions.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the deletion succeeds.</returns>
            public async Task<bool> DeleteAllAsync(Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAllAsync(person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Retrieves a collection of <see cref="Permission"/> records of the specified person for the specified account using the provided query.
            /// </summary>
            /// <param name="personId">The unique identifier of the person.</param>
            /// <param name="accountId">The identifier of the account for which permissions are retrieved.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Permission"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Permission>> GetAsync(long personId, string accountId, PermissionQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Permission>(personId, $"permissions/{accountId}", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Retrieves a collection of <see cref="Permission"/> records of the specified person for the specified account using the provided query.
            /// </summary>
            /// <param name="person">The person for which to retrieve permissions.</param>
            /// <param name="accountId">The identifier of the account for which permissions are retrieved.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Permission"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Permission>> GetAsync(Person person, string accountId, PermissionQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, accountId, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Retrieves a collection of <see cref="Permission"/> records of the specified person for the specified account using the provided query.
            /// </summary>
            /// <param name="personId">The unique identifier of the person.</param>
            /// <param name="account">The account for which permissions are retrieved.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Permission"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Permission>> GetAsync(long personId, Account account, PermissionQuery query, CancellationToken ct = default)
            {
                if (account is null || account.Id is null)
                    throw new ArgumentNullException(nameof(account));

                return await _client.GetListAsync<Permission>(personId, $"permissions/{account.Id}", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Retrieves a collection of <see cref="Permission"/> records of the specified person for the specified account using the provided query.
            /// </summary>
            /// <param name="person">The person for which to retrieve permissions.</param>
            /// <param name="account">The account for which permissions are retrieved.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Permission"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Permission>> GetAsync(Person person, Account account, PermissionQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (account is null || account.Id is null)
                    throw new ArgumentNullException(nameof(account));

                return await GetAsync(person.Id, account.Id, query, ct).ConfigureAwait(false);
            }
        }
    }
}
