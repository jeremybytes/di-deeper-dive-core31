﻿using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace PersonReader.Service
{
    public class ServiceReader : IPersonReader
    {
        WebClient client;
        string baseUri;

        public ServiceReader(ServiceReaderUri baseUri)
        {
            client = new WebClient();
            this.baseUri = baseUri.ServiceUriString;
        }

        public IReadOnlyCollection<Person> GetPeople()
        {
            var address = $"{baseUri}/people";
            string reply = client.DownloadString(address);
            return JsonConvert.DeserializeObject<IReadOnlyCollection<Person>>(reply);
        }

        public Person GetPerson(int id)
        {
            var address = $"{baseUri}/people/{id}";
            string reply = client.DownloadString(address);
            return JsonConvert.DeserializeObject<Person>(reply);
        }
    }
}
