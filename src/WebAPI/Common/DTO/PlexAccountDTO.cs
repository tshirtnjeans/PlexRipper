﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlexRipper.WebAPI.Common.DTO
{
    public class PlexAccountDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("isValidated")]
        public bool IsValidated { get; set; }

        [JsonProperty("validatedAt")]
        public DateTime ValidatedAt { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("hasPassword")]
        public bool HasPassword { get; set; }

        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [JsonProperty("authentication_token")]
        public string AuthenticationToken { get; set; }

        [JsonProperty("forumId")]
        public object ForumId { get; set; }

        [JsonProperty("plexServers")]
        public List<PlexServerDTO> PlexServers { get; set; }
    }
}
