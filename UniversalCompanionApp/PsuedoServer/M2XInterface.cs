using System;
using System.Collections.Generic;
using System.Text;
using ATTM2X;
using System.Data.SqlClient;

using System.Reflection;
namespace PsuedoServer
{
    public class M2XInterface
    {
        private M2XClient _M2XClient;
        private M2XDevice _M2XDevice;
        private M2XStream _AccelXStream;
        private M2XStream _AccelYStream;
        private M2XStream _AccelZStream;
        private M2XStream _LatStream;
        private M2XStream _LngStream;
        public bool InitializeM2X(string apiKeyToUse, string deviceIdToGet)
        {
            bool success = true;
            try
            {
                _M2XClient = new M2XClient(apiKeyToUse);
                _M2XDevice = _M2XClient.Device(deviceIdToGet);

                _M2XDevice.Details();
                string a1 = string.Format("device.Details: {0}", _M2XClient.LastResponse.Status);
                string a2 = string.Format("status: {0}", _M2XClient.LastResponse.Json.status);
                string a3 = string.Format("description: {0}", _M2XClient.LastResponse.Json.description);


                DateTime now = DateTime.Now;
                string dateFormatter = "yyyy-MM-ddTHH:mm:ss.ffffffZ";
                var m2xFilter = new { start = now.AddMinutes(-5).ToString(dateFormatter), end = now.ToString(dateFormatter), limit = 100 };
                
                _AccelXStream = _M2XDevice.Stream("accel-x");
                var x_vals = _AccelXStream.Values(m2xFilter);
                var jx_vals = x_vals.Json.values;
                _AccelYStream = _M2XDevice.Stream("accel-y");
                var y_vals = _AccelYStream.Values(m2xFilter);
                var jy_vals = y_vals.Json.values;
                _AccelZStream = _M2XDevice.Stream("accel-z");
                var z_vals = _AccelZStream.Values(m2xFilter);
                var jz_vals = z_vals.Json.values;

                SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder();
                //csBuilder.DataSource = "i2ym1ip5n8.database.windows.net,1433";
                csBuilder.DataSource = "wrj8boouxc.database.windows.net,1433";
                csBuilder.InitialCatalog = "WachterData";
                csBuilder.UserID = "Hackathon";
                csBuilder.Password = "Hacking2104";
                SqlConnection conn = new SqlConnection(csBuilder.ConnectionString);
                conn.Open();

                // with lat and lng
                //string dataFormatter = "INSERT INTO [dbo].[RawData] ([Id], [AccelX], [AccelY], [AccelZ], [GeoLat], [GeoLng], [DataTime]) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Max(ID) from RawData";
                int maxId = 0;
                try
                {
                    maxId = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {

                }
                int new_id = maxId + 1;

                // without lat and lng
                string dataFormatter = "INSERT INTO [dbo].[RawData] ([AccelX], [AccelY], [AccelZ], [GeoLat], [GeoLng], [TimeStamp]) VALUES ({0}, {1}, {2}, {3}, {4}, '{5}')";
                string insertStatement = string.Empty;
                float x; float y; float z; float lat; float lng;
                for (int i = 0; i < jx_vals.Count; i++)
                {
                    new_id += i;
                    x = (float)jx_vals[i].value;
                    y = (float)jy_vals[i].value;
                    z = (float)jz_vals[i].value;
                    lat = 0;
                    lng = 0;
                
                    string timestamp = jx_vals[i].timestamp;
                    insertStatement = string.Format(dataFormatter, x, y, z, lat, lng, timestamp);
                    cmd.CommandText = insertStatement;
                    cmd.ExecuteNonQuery();
                }

            }
            catch(Exception ex)
            {
                string eeee = ex.Message;
                string a = "b";
            }
            return success;
        }
    }
}
