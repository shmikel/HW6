using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW6.DTO
{
    public class MainData
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        [JsonProperty("features")]
        public Feature[] Features { get; set; }
    }

    public class Properties
    {
        [JsonProperty("ResponseMetaData")]
        public ResponseMetaData ResponseMetaData { get; set; }
    }
    public class ResponseMetaData
    {
        [JsonProperty("SearchRequest")]
        public SearchRequest SearchRequest { get; set; }
        [JsonProperty("SearchResponse")]
        public SearchResponse SearchResponse { get; set; }
    }
    public class SearchResponse 
    {
        [JsonProperty("found")]
        public int Found { get; set; }
        [JsonProperty("display")]
        public string Display { get; set; }
    }
    public class SearchRequest 
    {
        [JsonProperty("request")]
        public string Request { get; set; }
        [JsonProperty("results")]
        public int Results { get; set; }
    }

    public class Feature
    {
        [JsonProperty("properties")]
        public CompanyProperties Properties { get; set; }
    }
    public class CompanyProperties
    {
        [JsonProperty("CompanyMetaData")]
        public CompanyMetaData CompanyMetaData { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class CompanyMetaData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("Phones")]
        public Phone[] Phones { get; set; }
        [JsonProperty("Hours")]
        public Hours Hours { get; set; }
        [JsonProperty("Links")]
        public Link[] Links { get; set; }
    }
    public class Link
    {
        [JsonProperty("aref")]
        public string Aref { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
    }
    public class Hours
    {
        [JsonProperty("Availabilities")]
        public Availability[] Availabilities { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class Availability
    {
        [JsonProperty("Everyday")]
        public bool Everyday { get; set; }
        [JsonProperty("TwentyFourHours")]
        public bool TwentyFourHours { get; set; }
        [JsonProperty("Intervals")]
        public Interval[] Intervals { get; set; }
    } 
    public class Interval
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
    }
    public class Phone
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("formatted")]
        public string Formatted { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
///////
