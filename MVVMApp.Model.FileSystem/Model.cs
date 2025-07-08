using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using Newtonsoft.Json;

namespace MVVMApp.Model.FileSystem
{
    public class Model : IModel
    {
        public List<IEmployee> GetAllEmployees()
        {
            try
            {
                Data data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(@"data.json"));

                Thread.Sleep(3000);

                return data.Employees.ToList<IEmployee>();
            }
            catch (JsonException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);

                return new List<IEmployee>();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);

                return new List<IEmployee>();
            }
        }
    }
}