using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Exodus.Version.Checker.Compare.Cryptography;
using System.ComponentModel;

namespace Exodus.Version.Checker.Compare.Objects
{
    public class GameFile
    {
        [JsonProperty]
        public virtual string Name { get; private set; }
        [JsonProperty]
        public virtual long Size { get; private set; }
        [JsonProperty]
        public virtual string MD5 { get; private set; }
        [JsonProperty]
        public virtual string Version { get; private set; }
        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public virtual bool IsSame { get; set; } = true;

        public GameFile() { }
        public GameFile(string FullName)
        {
            FileInfo FileInfo = new FileInfo(FullName);
            this.Name = FileInfo.Name;
            this.Size = FileInfo.Length;

            if(FullName.EndsWith(".dll") || FullName.EndsWith(".exe"))
            {
                Version = FileVersionInfo.GetVersionInfo(FullName).FileVersion;
            }

            MD5 = MD5Crypto.GetMD5(FullName);
        }

        public static string Serialize(GameFile e)
        {
            return JsonConvert.SerializeObject(e, Formatting.Indented);
        }
        public static string SerializeArray(GameFile[] e)
        {
            return JsonConvert.SerializeObject(e, Formatting.Indented);
        }
        public static GameFile Deserialize(string e)
        {
            return JsonConvert.DeserializeObject<GameFile>(e);
        }
        public static GameFile[] DeserializeArray(string e)
        {
            return JsonConvert.DeserializeObject<GameFile[]>(e);
        }
    }
}
