using System.Threading;

namespace WoWLib
{
    public class Pulsator
    {
        /// <summary>
        /// Pulses the object manager. This should be called from an EndScene hook, or some other form of 'OnFrame'
        /// type function. (This class has a built in thread handler to deal with said OnFrame function)
        /// </summary>
        public void Pulse()
        {
            
        }

        /// <summary>
        /// Shuts down the pulsator, and closes the opened process handle.
        /// </summary>
        public static void Shutdown()
        {
        }
    }
}