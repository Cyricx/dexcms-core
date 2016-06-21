using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace DexCMS.Core.Infrastructure.Globals.Initializers
{
    class StateInitializer
    {
        public static void Run(IDexCMSCoreContext context)
        {
            int usa = context.Countries.Where(x => x.Name == "United States").Select(x => x.CountryID).Single();

            var states = new List<State>
            {
                new State { CountryID = usa, Abbreviation = "IA", Name = "Iowa"},
                new State { CountryID = usa, Abbreviation = "OH", Name = "Ohio"},
                new State { CountryID = usa, Abbreviation = "UT", Name = "Utah"},
                new State { CountryID = usa, Abbreviation = "TX", Name = "Texas"},
                new State { CountryID = usa, Abbreviation = "ID", Name = "Idaho"},
                new State { CountryID = usa, Abbreviation = "ME", Name = "Maine"},
                new State { CountryID = usa, Abbreviation = "NV", Name = "Nevada"},
                new State { CountryID = usa, Abbreviation = "KS", Name = "Kansas"},
                new State { CountryID = usa, Abbreviation = "HI", Name = "Hawaii"},
                new State { CountryID = usa, Abbreviation = "AK", Name = "Alaska"},
                new State { CountryID = usa, Abbreviation = "OR", Name = "Oregon"},
                new State { CountryID = usa, Abbreviation = "WY", Name = "Wyoming"},
                new State { CountryID = usa, Abbreviation = "VT", Name = "Vermont"},
                new State { CountryID = usa, Abbreviation = "AZ", Name = "Arizona"},
                new State { CountryID = usa, Abbreviation = "AL", Name = "Alabama"},
                new State { CountryID = usa, Abbreviation = "FL", Name = "Florida"},
                new State { CountryID = usa, Abbreviation = "GA", Name = "Georgia"},
                new State { CountryID = usa, Abbreviation = "MT", Name = "Montana"},
                new State { CountryID = usa, Abbreviation = "IN", Name = "Indiana"},
                new State { CountryID = usa, Abbreviation = "MO", Name = "Missouri"},
                new State { CountryID = usa, Abbreviation = "MI", Name = "Michigan"},
                new State { CountryID = usa, Abbreviation = "MD", Name = "Maryland"},
                new State { CountryID = usa, Abbreviation = "IL", Name = "Illinois"},
                new State { CountryID = usa, Abbreviation = "NE", Name = "Nebraska"},
                new State { CountryID = usa, Abbreviation = "NY", Name = "New York"},
                new State { CountryID = usa, Abbreviation = "KY", Name = "Kentucky"},
                new State { CountryID = usa, Abbreviation = "AR", Name = "Arkansas"},
                new State { CountryID = usa, Abbreviation = "CO", Name = "Colorado"},
                new State { CountryID = usa, Abbreviation = "DE", Name = "Delaware"},
                new State { CountryID = usa, Abbreviation = "VA", Name = "Virginia"},
                new State { CountryID = usa, Abbreviation = "OK", Name = "Oklahoma"},
                new State { CountryID = usa, Abbreviation = "WI", Name = "Wisconsin"},
                new State { CountryID = usa, Abbreviation = "TN", Name = "Tennessee"},
                new State { CountryID = usa, Abbreviation = "LA", Name = "Louisiana"},
                new State { CountryID = usa, Abbreviation = "MN", Name = "Minnesota"},
                new State { CountryID = usa, Abbreviation = "NJ", Name = "New Jersey"},
                new State { CountryID = usa, Abbreviation = "NM", Name = "New Mexico"},
                new State { CountryID = usa, Abbreviation = "CA", Name = "California"},
                new State { CountryID = usa, Abbreviation = "WA", Name = "Washington"},
                new State { CountryID = usa, Abbreviation = "CT", Name = "Connecticut"},
                new State { CountryID = usa, Abbreviation = "MS", Name = "Mississippi"},
                new State { CountryID = usa, Abbreviation = "ND", Name = "North Dakota"},
                new State { CountryID = usa, Abbreviation = "SD", Name = "South Dakota"},
                new State { CountryID = usa, Abbreviation = "PA", Name = "Pennsylvania"},
                new State { CountryID = usa, Abbreviation = "RI", Name = "Rhode Island"},
                new State { CountryID = usa, Abbreviation = "WV", Name = "West Virginia"},
                new State { CountryID = usa, Abbreviation = "MA", Name = "Massachusetts"},
                new State { CountryID = usa, Abbreviation = "NH", Name = "New Hampshire"},
                new State { CountryID = usa, Abbreviation = "NC", Name = "North Carolina"},
                new State { CountryID = usa, Abbreviation = "SC", Name = "South Carolina"},
                new State { CountryID = usa, Abbreviation = "DC", Name = "District of Columbia"},
            };
            states.ForEach(x => context.States.Add(x));
            context.SaveChanges();
        }
    }
}
