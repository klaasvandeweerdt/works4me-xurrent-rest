// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The constructed HttpMessageHandler chain is passed to HttpClient with disposeHandler: true. HttpClient takes ownership and disposes all handlers automatically. Manual disposal is not required.", Scope = "member", Target = "~M:Works4me.Xurrent.Rest.XurrentClient.#ctor(Works4me.Xurrent.Rest.AuthenticationTokenCollection,System.String,System.String,Microsoft.Extensions.Logging.ILogger{Works4me.Xurrent.Rest.XurrentClient})")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the MultipartFormDataContent instance will cascade and dispose all added HttpContent instances (every StringContent and the StreamContent), so no objects are left undisposed.", Scope = "member", Target = "~M:Works4me.Xurrent.Rest.XurrentHttpClient.UploadAttachmentAsync(System.IO.Stream,System.String,System.String,Works4me.Xurrent.Rest.AttachmentStorage,System.TimeSpan,System.Threading.CancellationToken)~System.Threading.Tasks.Task{Works4me.Xurrent.Rest.AttachmentUploadResponse}")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the MultipartFormDataContent instance will cascade and dispose all added HttpContent instances (every StringContent and the StreamContent), so no objects are left undisposed.", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.XurrentHttpClient")]

[assembly: SuppressMessage("Performance", "CA1812:Internal class is apparently never instantiated", Justification = "Instantiated via reflection by System.Text.Json", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.Serialization.XurrentObjectConverter`1")]
[assembly: SuppressMessage("Performance", "CA1812:Internal class is apparently never instantiated", Justification = "Instantiated via reflection by System.Text.Json", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.Serialization.XurrentEnumNullableConverter`1")]
[assembly: SuppressMessage("Performance", "CA1812:Internal class is apparently never instantiated", Justification = "Instantiated via reflection by System.Text.Json", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.AuthenticationOAuth2Response")]
[assembly: SuppressMessage("Performance", "CA1812:Internal class is apparently never instantiated", Justification = "Instantiated via reflection by System.Text.Json", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.AttachmentUploadParameters")]
[assembly: SuppressMessage("Performance", "CA1812:Internal class is apparently never instantiated", Justification = "Instantiated via reflection.", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.XurrentEventsClient")]

[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "This is Xurrent entity name.", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.CustomCollection")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "This is Xurrent entity name.", Scope = "type", Target = "~T:Works4me.Xurrent.Rest.Permission")]

