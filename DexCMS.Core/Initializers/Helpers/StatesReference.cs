using DexCMS.Core.Contexts;
using System.Linq;

namespace DexCMS.Core.Initializers.Helpers
{
    public class StatesReference
    {

        public int IA { get; set; }
        public int OH { get; set; }
        public int UT { get; set; }
        public int TX { get; set; }
        public int ID { get; set; }
        public int ME { get; set; }
        public int NV { get; set; }
        public int KS { get; set; }
        public int HI { get; set; }
        public int AK { get; set; }
        public int OR { get; set; }
        public int WY { get; set; }
        public int VT { get; set; }
        public int AZ { get; set; }
        public int AL { get; set; }
        public int FL { get; set; }
        public int GA { get; set; }
        public int MT { get; set; }
        public int IN { get; set; }
        public int MO { get; set; }
        public int MI { get; set; }
        public int MD { get; set; }
        public int IL { get; set; }
        public int NE { get; set; }
        public int NY { get; set; }
        public int KY { get; set; }
        public int AR { get; set; }
        public int CO { get; set; }
        public int DE { get; set; }
        public int VA { get; set; }
        public int OK { get; set; }
        public int WI { get; set; }
        public int TN { get; set; }
        public int LA { get; set; }
        public int MN { get; set; }
        public int NJ { get; set; }
        public int NM { get; set; }
        public int CA { get; set; }
        public int WA { get; set; }
        public int CT { get; set; }
        public int MS { get; set; }
        public int ND { get; set; }
        public int SD { get; set; }
        public int PA { get; set; }
        public int RI { get; set; }
        public int WV { get; set; }
        public int MA { get; set; }
        public int NH { get; set; }
        public int NC { get; set; }
        public int SC { get; set; }
        public int DC { get; set; }

        public StatesReference(IDexCMSCoreContext context)
        {
            IA = context.States.Where(x => x.Abbreviation == "IA").Select(x => x.StateID).SingleOrDefault();
            OH = context.States.Where(x => x.Abbreviation == "OH").Select(x => x.StateID).SingleOrDefault();
            UT = context.States.Where(x => x.Abbreviation == "UT").Select(x => x.StateID).SingleOrDefault();
            TX = context.States.Where(x => x.Abbreviation == "TX").Select(x => x.StateID).SingleOrDefault();
            ID = context.States.Where(x => x.Abbreviation == "ID").Select(x => x.StateID).SingleOrDefault();
            ME = context.States.Where(x => x.Abbreviation == "ME").Select(x => x.StateID).SingleOrDefault();
            NV = context.States.Where(x => x.Abbreviation == "NV").Select(x => x.StateID).SingleOrDefault();
            KS = context.States.Where(x => x.Abbreviation == "KS").Select(x => x.StateID).SingleOrDefault();
            HI = context.States.Where(x => x.Abbreviation == "HI").Select(x => x.StateID).SingleOrDefault();
            AK = context.States.Where(x => x.Abbreviation == "AK").Select(x => x.StateID).SingleOrDefault();
            OR = context.States.Where(x => x.Abbreviation == "OR").Select(x => x.StateID).SingleOrDefault();
            WY = context.States.Where(x => x.Abbreviation == "WY").Select(x => x.StateID).SingleOrDefault();
            VT = context.States.Where(x => x.Abbreviation == "VT").Select(x => x.StateID).SingleOrDefault();
            AZ = context.States.Where(x => x.Abbreviation == "AZ").Select(x => x.StateID).SingleOrDefault();
            AL = context.States.Where(x => x.Abbreviation == "AL").Select(x => x.StateID).SingleOrDefault();
            FL = context.States.Where(x => x.Abbreviation == "FL").Select(x => x.StateID).SingleOrDefault();
            GA = context.States.Where(x => x.Abbreviation == "GA").Select(x => x.StateID).SingleOrDefault();
            MT = context.States.Where(x => x.Abbreviation == "MT").Select(x => x.StateID).SingleOrDefault();
            IN = context.States.Where(x => x.Abbreviation == "IN").Select(x => x.StateID).SingleOrDefault();
            MO = context.States.Where(x => x.Abbreviation == "MO").Select(x => x.StateID).SingleOrDefault();
            MI = context.States.Where(x => x.Abbreviation == "MI").Select(x => x.StateID).SingleOrDefault();
            MD = context.States.Where(x => x.Abbreviation == "MD").Select(x => x.StateID).SingleOrDefault();
            IL = context.States.Where(x => x.Abbreviation == "IL").Select(x => x.StateID).SingleOrDefault();
            NE = context.States.Where(x => x.Abbreviation == "NE").Select(x => x.StateID).SingleOrDefault();
            NY = context.States.Where(x => x.Abbreviation == "NY").Select(x => x.StateID).SingleOrDefault();
            KY = context.States.Where(x => x.Abbreviation == "KY").Select(x => x.StateID).SingleOrDefault();
            AR = context.States.Where(x => x.Abbreviation == "AR").Select(x => x.StateID).SingleOrDefault();
            CO = context.States.Where(x => x.Abbreviation == "CO").Select(x => x.StateID).SingleOrDefault();
            DE = context.States.Where(x => x.Abbreviation == "DE").Select(x => x.StateID).SingleOrDefault();
            VA = context.States.Where(x => x.Abbreviation == "VA").Select(x => x.StateID).SingleOrDefault();
            OK = context.States.Where(x => x.Abbreviation == "OK").Select(x => x.StateID).SingleOrDefault();
            WI = context.States.Where(x => x.Abbreviation == "WI").Select(x => x.StateID).SingleOrDefault();
            TN = context.States.Where(x => x.Abbreviation == "TN").Select(x => x.StateID).SingleOrDefault();
            LA = context.States.Where(x => x.Abbreviation == "LA").Select(x => x.StateID).SingleOrDefault();
            MN = context.States.Where(x => x.Abbreviation == "MN").Select(x => x.StateID).SingleOrDefault();
            NJ = context.States.Where(x => x.Abbreviation == "NJ").Select(x => x.StateID).SingleOrDefault();
            NM = context.States.Where(x => x.Abbreviation == "NM").Select(x => x.StateID).SingleOrDefault();
            CA = context.States.Where(x => x.Abbreviation == "CA").Select(x => x.StateID).SingleOrDefault();
            WA = context.States.Where(x => x.Abbreviation == "WA").Select(x => x.StateID).SingleOrDefault();
            CT = context.States.Where(x => x.Abbreviation == "CT").Select(x => x.StateID).SingleOrDefault();
            MS = context.States.Where(x => x.Abbreviation == "MS").Select(x => x.StateID).SingleOrDefault();
            ND = context.States.Where(x => x.Abbreviation == "ND").Select(x => x.StateID).SingleOrDefault();
            SD = context.States.Where(x => x.Abbreviation == "SD").Select(x => x.StateID).SingleOrDefault();
            PA = context.States.Where(x => x.Abbreviation == "PA").Select(x => x.StateID).SingleOrDefault();
            RI = context.States.Where(x => x.Abbreviation == "RI").Select(x => x.StateID).SingleOrDefault();
            WV = context.States.Where(x => x.Abbreviation == "WV").Select(x => x.StateID).SingleOrDefault();
            MA = context.States.Where(x => x.Abbreviation == "MA").Select(x => x.StateID).SingleOrDefault();
            NH = context.States.Where(x => x.Abbreviation == "NH").Select(x => x.StateID).SingleOrDefault();
            NC = context.States.Where(x => x.Abbreviation == "NC").Select(x => x.StateID).SingleOrDefault();
            SC = context.States.Where(x => x.Abbreviation == "SC").Select(x => x.StateID).SingleOrDefault();
            DC = context.States.Where(x => x.Abbreviation == "DC").Select(x => x.StateID).SingleOrDefault();
        }
    }
}
