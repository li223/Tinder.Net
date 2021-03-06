﻿using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Tinder Response Object
    /// </summary>
    /// <typeparam name="T">Data Type for the Data Property</typeparam>
    public sealed class TinderResponse<T>
    {
        /// <summary>
        /// Meta Data for request
        /// </summary>
        [JsonProperty("meta")]
        public MetaObject Meta { get; private set; }

        /// <summary>
        /// Data payload
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; private set; }

        /// <summary>
        /// Error payload
        /// </summary>
        [JsonProperty("error")]
        public ErrorObject? Error { get; private set; }
    }
}
