using BusSeatsReservation.Data.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using BusSeatsReservation.Models.SQL.Models;

namespace BusSeatsReservation.Commands.Utils
{
    public class DataParser
    {
        public static void LoadInitialData(EfUnitOfWork unitOfWork)
        {
            string path = @"..\..\Data\buses_input.json";
            string json = File.ReadAllText(path);

            JObject allSearch = JObject.Parse(json);

            IList<JToken> destinationResults = allSearch["Destinations"].Children().ToList();
            IList<JToken> busResults = allSearch["Buses"].Children().ToList();
            IList<JToken> userResults = allSearch["Users"].Children().ToList();

            Console.WriteLine("Load initial DESTINATION data ...");

            foreach (JToken result in destinationResults)
            {
                Destination destinationToAdd = result.ToObject<Destination>();
                unitOfWork.DestinationRepository.Add(destinationToAdd);
            }

            Console.WriteLine("Load initial BUS data ...");

            foreach (JToken result in busResults)
            {
                Bus busToAdd = result.ToObject<Bus>();
                unitOfWork.BusRepository.Add(busToAdd);
            }

            Console.WriteLine("Load initial USER data ...");

            foreach (JToken result in userResults)
            {
                User userToAdd = result.ToObject<User>();
                unitOfWork.UserRepository.Add(userToAdd);
            }

            unitOfWork.Commit();
        }
    }
}

