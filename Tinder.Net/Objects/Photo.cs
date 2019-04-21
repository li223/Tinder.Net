using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Photo Object
    /// </summary>
    public struct Photo
    {
        /// <summary>
        /// Photo Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }
       
        /// <summary>
        /// Crop Info
        /// </summary>
        [JsonProperty("crop_info")]
        public CropInfo CropInfo { get; private set; }

        /// <summary>
        /// Image Url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("fbId")]
        public string FbId { get; private set; }

        /// <summary>
        /// The Processed Files
        /// </summary>
        [JsonProperty("processedFiles")]
        public IEnumerable<ProcessedFile> ProcessedFiles { get; private set; }
    }
}