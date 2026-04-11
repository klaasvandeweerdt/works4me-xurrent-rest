using System;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class ServiceLevelAgreementClient
    {
        partial class RfcTypeActivityIDsClient
        {
            /// <summary>
            /// Add an <see cref="RfcTypeActivityID"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="rfcTypeActivityIDInput">The rfc type activity identifier input to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeActivityID"/>.</returns>
            public async Task<RfcTypeActivityID> AddAsync(long serviceLevelAgreementId, RfcTypeActivityIDInput rfcTypeActivityIDInput, CancellationToken ct = default)
            {
                return await _client.PostItemAsync<RfcTypeActivityID, RfcTypeActivityIDInput>(serviceLevelAgreementId, "rfc_type_activityIDs", rfcTypeActivityIDInput, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="RfcTypeActivityID"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement to which the rfc type activity identifier input is added.</param>
            /// <param name="rfcTypeActivityIDInput">The rfc type activity identifier input to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeActivityID"/>.</returns>
            public async Task<RfcTypeActivityID> AddAsync(ServiceLevelAgreement serviceLevelAgreement, RfcTypeActivityIDInput rfcTypeActivityIDInput, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, rfcTypeActivityIDInput, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="RfcTypeActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="rfcTypeActivityIDInput">The rfc type activity identifier input to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeActivityID"/>.</returns>
            public async Task<RfcTypeActivityID> UpdateAsync(long serviceLevelAgreementId, RfcTypeActivityIDInput rfcTypeActivityIDInput, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync<RfcTypeActivityID, RfcTypeActivityIDInput>(serviceLevelAgreementId, "rfc_type_activityIDs", rfcTypeActivityIDInput, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="RfcTypeActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which the rfc type activity identifier input is updated.</param>
            /// <param name="rfcTypeActivityIDInput">The rfc type activity identifier input to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeActivityID"/>.</returns>
            public async Task<RfcTypeActivityID> UpdateAsync(ServiceLevelAgreement serviceLevelAgreement, RfcTypeActivityIDInput rfcTypeActivityIDInput, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await UpdateAsync(serviceLevelAgreement.Id, rfcTypeActivityIDInput, ct).ConfigureAwait(false);
            }
        }
    }
}
