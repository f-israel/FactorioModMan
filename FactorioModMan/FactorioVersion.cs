using System;

namespace FactorioModMan
{
    internal class FactorioVersion
    {
        public int Build { get; set; }
        public bool IsSteam { get; set; }
        public string Arch { get; set; }
        public Version Version { get; set; }
        public string MapInputVersion { get; set; }
        public string MapOutputVersion { get; set; }
        public int BinaryVersion { get; set; }

        public string GetVersionString() => $"Version: {Version} (Build: {Build}, {Arch}, {(IsSteam ? "steam" : "non-steam")})";
    }
}