using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace PsychoMedikApp.Helpers
{
    public static class Helpers
    {
        public async static Task<bool> HandleRequest(this Task serviceMethod)
        {
            try
            {
                await serviceMethod;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}