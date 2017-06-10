using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<TrainConnection> FindConnection(string city1, string city2);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Server.ContractType".
    [DataContract]
    public class CompositeType
    {
        List<TrainConnection> listOfConnection = new List<TrainConnection>(new TrainConnection[] {
            new TrainConnection("Warszawa", "Skierniewice", "2017-07-12 12:32", "2017-07-12 13:43"),
            new TrainConnection("Skierniewice", "Lowicz", "2017-07-12 14:16", "2017-07-12 15:19"),
            new TrainConnection("Warszawa", "Skierniewice", "2017-07-12 10:32", "2017-07-12 11:23"),
            new TrainConnection("Skierniewice", "Lowicz", "2017-07-12 13:52", "2017-07-12 14:49"),
            new TrainConnection("Skierniewice", "Lowicz", "2017-07-12 14:12", "2017-07-12 15:18"),
            new TrainConnection("Warszawa", "Skierniewice", "2017-07-12 11:22", "2017-07-12 12:42")
        });
        
        [DataMember]
        public List<TrainConnection> ListOfConnection
        {
            get { return listOfConnection; }
            set { listOfConnection = value; }
        }

    }
}
