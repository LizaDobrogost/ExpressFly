﻿namespace DataAccessLayer.Models
{
    public class AirportEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}