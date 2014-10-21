using cordova.context;
using cordova.plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvCompare.cordova.plugins.imp
{
    public class MkvPluginImpl : AbstractCordovaPlugin
    {
        public static readonly String TEST = "TEST";

        protected override void doExecute(String action, String[] args, CallBackContext callbackContext)
        {
            if (TEST.Equals(action))
            {
                test(callbackContext);
            }
        }

        private void test(CallBackContext callbackContext)
        {
            Application.Exit();

            callbackContext.success(null);
        }
    }
}
