using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using MVVMApp.Services;

namespace MVVMApp.Model.DB
{
    public class Model : IModel
    {
        private ILogService _logService;
        private DataProvider _dataProvider;

        public Model(ILogService logService)
        {
            _logService = logService;
            _dataProvider = new DataProvider();
        }

        public List<IEmployee> GetAllEmployees()
        {
            try
            {
                _logService.Log("GetAllEmployees");

                var employees = _dataProvider.GetAll<Employee>();

                Thread.Sleep(2000);

                return employees.ToList<IEmployee>();
            }
            catch (Exception exception)
            {
                _logService.Log(exception.Message);

                return new List<IEmployee>();
            }
        }
    }
}