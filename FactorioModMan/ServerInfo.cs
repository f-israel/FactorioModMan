using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorioModMan
{
    public class ServerInfo
    {
        public static byte[] ServerRequest =
        {
            0x10, 0x01, 0x7d, 0x66, 0x00, 0x00, 0x0c, 0x00, 0x1d, 0x00, 0x0b, 0x46,
            0x11, 0x00, 0x00, 0x00, 0x31, 0x30, 0x2e, 0x31, 0x30, 0x2e, 0x38, 0x2e, 0x31, 0x30, 0x33, 0x3a, 0x33, 0x34,
            0x31, 0x39, 0x37, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x62, 0x61, 0x73, 0x65, 0x00, 0x00, 0x0c,
            0x00, 0x1d, 0x00, 0x26, 0x10
        };

        public List<ServerModInfo> ActiveMods = new List<ServerModInfo>();
        public Version Version;
        public bool Success { get; private set; }


        public bool ParseNetworkPacket(byte[] rawResult)
        {
            ActiveMods.Clear();
            try
            {
                rawResult.Takeout(9, out rawResult);
                    //TODO: skip first 9 bytes... don't know what they are. if anyone knows please give me feedback.

                //don't know better... do checks which should work
                if (Encoding.ASCII.GetString(rawResult.Takeout(0x28, out rawResult)) ==
                    "Active mods configuration doesn't match.")
                {
                    rawResult.Takeout(1, out rawResult);
                        //this one seems to be always 0x0F... could be a marker, but for now just skip

                    //now the version (minor+major+revision+build each 2 byte (uint16) => 8 bytes total)
                    Version = _convertVersion(rawResult.Takeout(8, out rawResult));
                    //next byte(s?) should be count of active mods (without "base" mod) //TODO: check if count is 2 or 4 byte
                    int numMods = BitConverter.ToUInt16(rawResult.Takeout(2, out rawResult), 0); //for parsing we need
                    //int numMods = BitConverter.ToUInt32(_takeout(rawResult, 4, out rawResult));

                    rawResult.Takeout(2, out rawResult); //TODO: figure out what this is, 2 byte, maybe just a marker

                    for (int i = 0; i < numMods; i++)
                    {
                        //TODO: do checkin in this loop
                        int modNameLength = BitConverter.ToUInt16(rawResult.Takeout(2, out rawResult), 0);
                            //length of following mod name, 2 byte
                        byte[] unknownBytesCache = rawResult.Takeout(2, out rawResult);
                            //TODO: check if always 0x00 0x00? maybe marker?
                        string modName = Encoding.ASCII.GetString(rawResult.Takeout(modNameLength, out rawResult));
                        Version modVersion = _convertVersion(rawResult.Takeout(6, out rawResult));
                        ActiveMods.Add(new ServerModInfo(modName, modVersion));
                    }
                }
                Success = true;
                return true;
            }
            catch
            {
                Success = false;
                return false;
            }
        }

        private Version _convertVersion(IEnumerable<byte> inputBytes)
        {
            if (inputBytes.Count() != 8 && inputBytes.Count() != 6)
                throw new Exception("Parameter should be exact 8 bytes");
            int minor, major, revision, build;
            major = BitConverter.ToUInt16(inputBytes.Skip(0).Take(2).ToArray(), 0);
            minor = BitConverter.ToUInt16(inputBytes.Skip(2).Take(2).ToArray(), 0);

            revision = BitConverter.ToUInt16(inputBytes.Skip(4).Take(2).ToArray(), 0);

            if (inputBytes.Count() == 8)
            {
                build = BitConverter.ToUInt16(inputBytes.Skip(6).Take(2).ToArray(), 0);
            }
            else
            {
                build = 0;
            }
            return new Version(major, minor, revision, build);
        }

        public struct ServerModInfo
        {
            public ServerModInfo(string name, Version version)
            {
                this.Name = name;
                this.Version = version;
            }

            public string Name;

            public Version Version;
                //mods don't have a build - it's always set to 0, this way it's possible to use build-in operators

            public override string ToString()
            {
                return Name + " " + Version.ToString(3);
            }
        }
    }
}