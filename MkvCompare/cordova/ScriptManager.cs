using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using CefSharp.WinForms;
using MkvCompare;
using MkvCompare.cordova.plugins.imp;
using Newtonsoft;
using Newtonsoft.Json;
using cordova.context;

namespace cordova
{
    [ComVisible(true)]
    public class ScriptManager
    {
        public static readonly String MKV_MODULE = "MKV";

        private readonly WebView web_view;
        private MainWindow window;

        public ScriptManager(MainWindow window, WebView web_view)
        {
            this.window = window;
            this.web_view = web_view;
        }

        public void debugjs(String message)
        {
            //TODO
        }

        public void debugcordovajs(String message)
        {
            //TODO
        }

        public static void debugCordova(String message)
        {
            //TODO
        }

        public void invokefunc(String plugin, String action, String jsonedArgs, String success, String fail,
                               String transactionId)
        {
            String[] realArray = JsonConvert.DeserializeObject < String[] > (jsonedArgs);
            var callBackContext = new CallBackContext(this, transactionId);

            debugCordova("[P2] Invoke Plugin : " + plugin + " | action : " + action + " | args : " + jsonedArgs +
                         " | transactionId : " + transactionId);

            if (plugin.Equals(MKV_MODULE))
            {
                var enrolmentPluginImpl = new MkvPluginImpl();
                enrolmentPluginImpl.launchPlugin(action, realArray, callBackContext);
            }
        }

        public void InvokeScript(String name, params object[] args)
        {
            String paramStr = "";
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (!(args[i] is String))
                    paramStr += "\"" + args[i] + "\",";
                else
                {
                    paramStr += args[i] + ",";
                }
            }
            if (args.Length > 0)
                paramStr += args[args.Length - 1];
            debugCordova("[P5] Call Javascript : " + name + "(" + paramStr + ")");
            web_view.ExecuteScript(name + "(" + paramStr + ")");
        }

        public void callSuccessCallback(String passedString, String transactionId)
        {
            if (passedString == null)
                passedString = "-1";
            debugCordova("[P4] Executing callback success | args : " + passedString + " | tId : " + transactionId);

            InvokeScript("cordova.executeCallbackSuccess", transactionId, passedString);
        }

        public void callSuccessCallbackJSON(String passedObject, String transactionId)
        {
            debugCordova("[P4] Executing callback success JSON | args : " + passedObject + " | tId : " + transactionId);

            InvokeScript("cordova.executeCallbackSuccessJSON", transactionId, passedObject);
        }

        public void callFailCallback(String passedString, String transactionId)
        {
            if (passedString == null)
                passedString = "-1";
            debugCordova("[P4] Executing callback fail | args : " + passedString + " | tId : " + transactionId);

            InvokeScript("cordova.executeCallbackFail", transactionId, passedString);
        }

        public void callFailCallbackJSON(String passedObject, String transactionId)
        {
            debugCordova("[P4] Executing callback fail JSON | args : " + passedObject + " | tId : " + transactionId);

            InvokeScript("cordova.executeCallbackFailJSON", transactionId, passedObject);
        }

        public void showNotificationSSLCert()
        {
            debugCordova("[P4] Executing showNotification");
            InvokeScript("cordova.showNotificationSSLCert");
        }

        public String getlanguage()
        {
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            if (currentCulture.IsNeutralCulture)
            {
                return currentCulture.TwoLetterISOLanguageName;
            }
            else
            {
                return currentCulture.Parent.TwoLetterISOLanguageName;
            }
        }
    }
}