using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Modelo {
    internal class Pokemon {
        [JsonPropertyName("species")]
        public EspeciePokemon? Species { get; set; }
        [JsonPropertyName("stats")]
        public List<StatusPokemon>? StatusPokemon { get; set; }
    }

    internal class EspeciePokemon {
        [JsonPropertyName("name")]
        public string? Nome { get; set; }
    }

    internal class StatusPokemon {
        [JsonPropertyName("base_stat")]
        public int StatusBase { get; set; }
        [JsonPropertyName("stat")]
        public StatusInfo? Stat { get; set; }
    }

    internal class StatusInfo {
        [JsonPropertyName ("name")]
        public string? Name { get; set; }
    }
}
