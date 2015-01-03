using System;
using System.Collections.Generic;
using System.Text;
using ATTM2X;

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

                _AccelXStream = _M2XDevice.Stream("accel_x");
                _AccelYStream = _M2XDevice.Stream("accel_y");
                _AccelZStream = _M2XDevice.Stream("accel_z");
 //               _LatStream = _M2XDevice.Stream("lat");
//                _LngStream = _M2XDevice.Stream("lng");
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
