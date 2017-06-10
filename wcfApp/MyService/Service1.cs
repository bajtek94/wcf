using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public List<TrainConnection> FindConnection(string city1, string city2)
        {
            List<TrainConnection> foundList = new List<TrainConnection>();
            CompositeType composite = new CompositeType();
            bool firstCityExist = false;
            bool secondCityExist = false;
            foreach(TrainConnection connection in composite.ListOfConnection)
            {
                if(city1 == connection.City1 || city1 == connection.City2)
                {
                    firstCityExist = true;
                }
                if (city2 == connection.City1 || city2 == connection.City2)
                {
                    secondCityExist = true;
                }
            }
            if(firstCityExist == false || secondCityExist == false)
            {
                throw new Exception("City doesn't exist.");
            }
            foreach(TrainConnection connection in composite.ListOfConnection)
            {
                if (connection.City1 == city1)
                {
                    // Punkt startowy znaleziony
                    if(connection.City2 == city2)
                    {
                        // Połączenie bezpośrednie
                        if(foundList.Count == 0)
                        {
                            foundList.Add(connection);
                        }
                        else
                        {
                            if(foundList[0].StartTime > connection.StartTime)
                            {
                                foundList.Clear();
                                foundList.Add(connection);
                            }
                        }
                    }
                    else
                    {
                        foreach(TrainConnection conn in composite.ListOfConnection)
                        {
                            if(connection.City2 == conn.City1 && conn.StartTime > connection.EndTime)
                            {
                                // Znaleziono przesiadkę?
                                if(conn.City2 == city2)
                                {
                                    //Połączenie z przesiadką
                                    if (foundList.Count == 0)
                                    {
                                        foundList.Add(connection);
                                        foundList.Add(conn);
                                    }
                                    else
                                    {
                                        if (foundList[0].StartTime > connection.StartTime && foundList.Count == 1)
                                        {
                                            foundList.Clear();
                                            foundList.Add(connection);
                                            foundList.Add(conn);
                                        }
                                        else if(foundList[0].StartTime > connection.StartTime && foundList.Count > 1 && foundList[1].StartTime > conn.StartTime)
                                        {
                                            foundList.Clear();
                                            foundList.Add(connection);
                                            foundList.Add(conn);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return foundList;
        }
        
    }
}
