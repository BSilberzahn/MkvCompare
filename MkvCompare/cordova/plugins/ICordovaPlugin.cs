using System;

namespace cordova.plugins
{
    public interface ICordovaPlugin
    {
        Boolean execute(String action, String args);
    }
}