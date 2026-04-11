using System;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class ServiceOfferingClient
    {
        partial class RfcTypeRatesClient
        {
            /// <summary>
            /// Add an <see cref="RfcTypeRate"/> to a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="rfcTypeRate">The rfc type rate identifier input to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeRate"/>.</returns>
            public async Task<RfcTypeRate> AddAsync(long serviceOfferingId, RfcTypeRateInput rfcTypeRate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync<RfcTypeRate, RfcTypeRateInput>(serviceOfferingId, "rfc_type_rates", rfcTypeRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="RfcTypeRate"/> to a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering to which the rfc type rate identifier input is added.</param>
            /// <param name="rfcTypeRate">The rfc type rate identifier input to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeRate"/>.</returns>
            public async Task<RfcTypeRate> AddAsync(ServiceOffering serviceOffering, RfcTypeRateInput rfcTypeRate, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await AddAsync(serviceOffering.Id, rfcTypeRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="RfcTypeRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="rfcTypeRate">The rfc type rate identifier input to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeRate"/>.</returns>
            public async Task<RfcTypeRate> UpdateAsync(long serviceOfferingId, RfcTypeRateInput rfcTypeRate, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync<RfcTypeRate, RfcTypeRateInput>(serviceOfferingId, "rfc_type_rates", rfcTypeRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="RfcTypeRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering to which the rfc type rate identifier input is added.</param>
            /// <param name="rfcTypeRate">The rfc type rate identifier input to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="RfcTypeRate"/>.</returns>
            public async Task<RfcTypeRate> UpdateAsync(ServiceOffering serviceOffering, RfcTypeRateInput rfcTypeRate, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await UpdateAsync(serviceOffering.Id, rfcTypeRate, ct).ConfigureAwait(false);
            }
        }
    }
}
