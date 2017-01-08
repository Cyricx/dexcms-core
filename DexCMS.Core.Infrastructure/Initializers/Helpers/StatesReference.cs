using DexCMS.Core.Infrastructure.Contexts;
using System.Linq;

namespace DexCMS.Core.Infrastructure.Initializers.Helpers
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
            IA = context.States.Where(x => x.Abbreviation == "IA").Select(x => x.StateID).Single();
            OH = context.States.Where(x => x.Abbreviation == "OH").Select(x => x.StateID).Single();
            UT = context.States.Where(x => x.Abbreviation == "UT").Select(x => x.StateID).Single();
            TX = context.States.Where(x => x.Abbreviation == "TX").Select(x => x.StateID).Single();
            ID = context.States.Where(x => x.Abbreviation == "ID").Select(x => x.StateID).Single();
            ME = context.States.Where(x => x.Abbreviation == "ME").Select(x => x.StateID).Single();
            NV = context.States.Where(x => x.Abbreviation == "NV").Select(x => x.StateID).Single();
            KS = context.States.Where(x => x.Abbreviation == "KS").Select(x => x.StateID).Single();
            HI = context.States.Where(x => x.Abbreviation == "HI").Select(x => x.StateID).Single();
            AK = context.States.Where(x => x.Abbreviation == "AK").Select(x => x.StateID).Single();
            OR = context.States.Where(x => x.Abbreviation == "OR").Select(x => x.StateID).Single();
            WY = context.States.Where(x => x.Abbreviation == "WY").Select(x => x.StateID).Single();
            VT = context.States.Where(x => x.Abbreviation == "VT").Select(x => x.StateID).Single();
            AZ = context.States.Where(x => x.Abbreviation == "AZ").Select(x => x.StateID).Single();
            AL = context.States.Where(x => x.Abbreviation == "AL").Select(x => x.StateID).Single();
            FL = context.States.Where(x => x.Abbreviation == "FL").Select(x => x.StateID).Single();
            GA = context.States.Where(x => x.Abbreviation == "GA").Select(x => x.StateID).Single();
            MT = context.States.Where(x => x.Abbreviation == "MT").Select(x => x.StateID).Single();
            IN = context.States.Where(x => x.Abbreviation == "IN").Select(x => x.StateID).Single();
            MO = context.States.Where(x => x.Abbreviation == "MO").Select(x => x.StateID).Single();
            MI = context.States.Where(x => x.Abbreviation == "MI").Select(x => x.StateID).Single();
            MD = context.States.Where(x => x.Abbreviation == "MD").Select(x => x.StateID).Single();
            IL = context.States.Where(x => x.Abbreviation == "IL").Select(x => x.StateID).Single();
            NE = context.States.Where(x => x.Abbreviation == "NE").Select(x => x.StateID).Single();
            NY = context.States.Where(x => x.Abbreviation == "NY").Select(x => x.StateID).Single();
            KY = context.States.Where(x => x.Abbreviation == "KY").Select(x => x.StateID).Single();
            AR = context.States.Where(x => x.Abbreviation == "AR").Select(x => x.StateID).Single();
            CO = context.States.Where(x => x.Abbreviation == "CO").Select(x => x.StateID).Single();
            DE = context.States.Where(x => x.Abbreviation == "DE").Select(x => x.StateID).Single();
            VA = context.States.Where(x => x.Abbreviation == "VA").Select(x => x.StateID).Single();
            OK = context.States.Where(x => x.Abbreviation == "OK").Select(x => x.StateID).Single();
            WI = context.States.Where(x => x.Abbreviation == "WI").Select(x => x.StateID).Single();
            TN = context.States.Where(x => x.Abbreviation == "TN").Select(x => x.StateID).Single();
            LA = context.States.Where(x => x.Abbreviation == "LA").Select(x => x.StateID).Single();
            MN = context.States.Where(x => x.Abbreviation == "MN").Select(x => x.StateID).Single();
            NJ = context.States.Where(x => x.Abbreviation == "NJ").Select(x => x.StateID).Single();
            NM = context.States.Where(x => x.Abbreviation == "NM").Select(x => x.StateID).Single();
            CA = context.States.Where(x => x.Abbreviation == "CA").Select(x => x.StateID).Single();
            WA = context.States.Where(x => x.Abbreviation == "WA").Select(x => x.StateID).Single();
            CT = context.States.Where(x => x.Abbreviation == "CT").Select(x => x.StateID).Single();
            MS = context.States.Where(x => x.Abbreviation == "MS").Select(x => x.StateID).Single();
            ND = context.States.Where(x => x.Abbreviation == "ND").Select(x => x.StateID).Single();
            SD = context.States.Where(x => x.Abbreviation == "SD").Select(x => x.StateID).Single();
            PA = context.States.Where(x => x.Abbreviation == "PA").Select(x => x.StateID).Single();
            RI = context.States.Where(x => x.Abbreviation == "RI").Select(x => x.StateID).Single();
            WV = context.States.Where(x => x.Abbreviation == "WV").Select(x => x.StateID).Single();
            MA = context.States.Where(x => x.Abbreviation == "MA").Select(x => x.StateID).Single();
            NH = context.States.Where(x => x.Abbreviation == "NH").Select(x => x.StateID).Single();
            NC = context.States.Where(x => x.Abbreviation == "NC").Select(x => x.StateID).Single();
            SC = context.States.Where(x => x.Abbreviation == "SC").Select(x => x.StateID).Single();
            DC = context.States.Where(x => x.Abbreviation == "DC").Select(x => x.StateID).Single();
        }
    }
}
