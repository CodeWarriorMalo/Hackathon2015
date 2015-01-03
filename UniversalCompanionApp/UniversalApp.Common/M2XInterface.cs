using System;
using System.Collections.Generic;
using System.Text;
using ATTM2X;
using log4net;
namespace UniversalCompanionApp.Common
{
    public class M2XInterface
    {
        private static ILog _Log =
        private M2XClient _M2XClient;
        public bool ConnectToM2X(string apiKeyToUse)
        {
            bool success = true;
            try
            {
                _M2XClient = new M2XClient(apiKeyToUse);

            }
            catch(Exception ex)
            {

            }
            return success;
        }
    }
}
