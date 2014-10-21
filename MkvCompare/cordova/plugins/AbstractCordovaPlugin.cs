using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using cordova.context;

namespace cordova.plugins
{
    public abstract class AbstractCordovaPlugin
    {
        private String action;
        private String[] args;
        private CallBackContext callBackContext;
        private BackgroundWorker pluginWorker;
        protected abstract void doExecute(String action, String[] args, CallBackContext callBackContext);

        public void launchPlugin(String action, String[] args, CallBackContext callBackContext)
        {
            ScriptManager.debugCordova("[P3] Launching action : " + action);
            this.action = action;
            this.args = args;
            this.callBackContext = callBackContext;
            try
            {
                    pluginWorker = new BackgroundWorker();
                    pluginWorker.DoWork += backgroundWorker_doWork;
                    pluginWorker.RunWorkerCompleted +=
                        backgroundWorker_runWorkerCompleted;
                    pluginWorker.RunWorkerAsync();
            }
            catch (WebException ex)
            {
                handleException(ex);
            }
            catch (Exception ex)
            {
                handleException(ex);
            }
        }


        private void backgroundWorker_doWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                doExecute(action, args, callBackContext);
            }
            catch (WebException ex)
            {
                handleException(ex);
            }
            catch (Exception ex)
            {
                handleException(ex);
            }
        }

        private void backgroundWorker_runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            }
            catch (WebException ex)
            {
                handleException(ex);
            }
            catch (Exception ex)
            {
                handleException(ex);
            }
        }

        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public void handleException(Exception ex)
        {
            var jsonObject = new JObject();

            //TODO ERROR

            callBackContext.failJSON(jsonObject.ToString());
        }

        public void handleException(WebException ex)
        {
            var jsonObject = new JObject();
            
            //TODO ERROR

            callBackContext.failJSON(jsonObject.ToString());
        }
    }
}