using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.stencyl.io.mbs;

namespace haxe_mbs_translate.src.mbs.io
{
    public class MbsVersionControl
    {
        private List<MbsTypedefSet> knownTypedefSets;
        private List<int> validMbsVersions;

        public static MbsVersionControl ALLCURRENTVERSIONS;

        static MbsVersionControl()
        {
            ALLCURRENTVERSIONS = new MbsVersionControl();
            ALLCURRENTVERSIONS.addTypedefSet(TypedefsHistory.basicTypes);
            ALLCURRENTVERSIONS.addTypedefSet(TypedefsHistory.mbs_validation);
            ALLCURRENTVERSIONS.addTypedefSet(TypedefsHistory.unused_GameModel);
            ALLCURRENTVERSIONS.addTypedefSet(TypedefsHistory.disposeImages);
            ALLCURRENTVERSIONS.addTypedefSet(TypedefsHistory.in_layer_actors);
            ALLCURRENTVERSIONS.addTypedefSet(TypedefsHistory.remove_scene_format);

            ALLCURRENTVERSIONS.addMbsVersion(1);
            ALLCURRENTVERSIONS.addMbsVersion(2);


            DADISH = (1, -2033963926);
            DADISH2 = (1, -2033963926);
            CATBIRD = (1, -2033963926);
            LATESTVERSION = (2, -1349349184);
        }


        /// <summary>
        /// (version number, typedef hash)
        /// </summary>
        public static (int, int) DADISH;
        /// <summary>
        /// (version number, typedef hash)
        /// </summary>
        public static (int, int) DADISH2;
        /// <summary>
        /// (version number, typedef hash)
        /// </summary>
        public static (int, int) CATBIRD;
        /// <summary>
        /// (version number, typedef hash)
        /// </summary>
        public static (int, int) LATESTVERSION;





        public MbsVersionControl()
        {
            validMbsVersions = new List<int>();
            knownTypedefSets = new List<MbsTypedefSet>();
        }

        public void addTypedefSet(MbsTypedefSet typeDefSet)
        {
            knownTypedefSets.Add(typeDefSet);
        }
        public void addMbsVersion(int mbsVersion)
        {
            validMbsVersions.Add(mbsVersion);
        }

        public bool isKnownHash(int typedefSetHash)
        {
            return knownTypedefSets.Any(i => i.getHash() == typedefSetHash);
        }
        public bool isValidMbsVersion(int mbsVersion)
        {
            return validMbsVersions.Contains(mbsVersion);
        }

        public MbsTypedefSet getTypedefSet(int typedefSetHash)
        {
            if (!isKnownHash(typedefSetHash)) throw new Exception($"No known typedefs match the hashcode {typedefSetHash}");

            else return knownTypedefSets.Find(i => i.getHash() == typedefSetHash);
        }
    }
}
