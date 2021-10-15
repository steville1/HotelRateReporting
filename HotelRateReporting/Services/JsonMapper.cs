using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelRateReporting.Common
{
    public class JsonMapper
    {
        public string fileName { get; set; }

        public JsonMapper(string name)
        {
            fileName = name;
        }

        public T Deserialize<T>(T entity)
        {
            
           using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + fileName))           
            {
                string json = r.ReadToEnd();
                var type = entity.GetType();
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
