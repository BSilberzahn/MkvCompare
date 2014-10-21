using System;

namespace cordova.context
{
    public class CallBackContext
    {
        public CallBackContext(ScriptManager scriptManager, String transactionId)
        {
            this.scriptManager = scriptManager;
            this.transactionId = transactionId;
        }

        private ScriptManager scriptManager { get; set; }
        private String transactionId { get; set; }

        public void success(String passedString)
        {
            if (scriptManager != null)
                scriptManager.callSuccessCallback(passedString, transactionId);
        }

        public void successJSON(String passedJSON)
        {
            if (scriptManager != null)
                scriptManager.callSuccessCallbackJSON(passedJSON, transactionId);
        }

        public void fail(String passedString)
        {
            if (scriptManager != null)
                scriptManager.callFailCallback(passedString, transactionId);
        }

        public void failJSON(String passedJSON)
        {
            if (scriptManager != null)
                scriptManager.callFailCallbackJSON(passedJSON, transactionId);
        }

        /*public void doNothingAndRelease()
        {
            if (this.scriptManager != null)
                this.scriptManager.releaseSema();
        }*/
    }
}