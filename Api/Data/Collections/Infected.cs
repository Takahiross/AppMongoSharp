using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime birthday, string genre, double latitude, double longitude)
        {
            this.Birthday = birthday;
            this.Genre = genre;
            this.Location = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public DateTime Birthday { get; set; }
        public string Genre { get; set; }
        public GeoJson2DGeographicCoordinates Location { get; set; }
    }
}