namespace Magic
{
    using System;

    public static class SHijack
    {
        public static CONTEXT org_context { get; set; }
        private static byte[] orgOpcodes { get; set; }

        /// <summary>
        /// Hijacks or "Hooks" a function so you can use it to run code in a codecave ;)
        /// </summary>
        /// <param name="wow">BlackMagic instance to use</param>
        /// <param name="lpAdress">Pointer to the function you want to hijack</param>
        /// <param name="codeCave">Pointer to the codecave</param>
        public static void HijackFunction(BlackMagic wow, uint lpAdress, uint codeCave)
        {
            if (wow.OpenProcessAndThread(wow.ProcessId))
            {
                //Store the original opcodes
                orgOpcodes = wow.ReadBytes(lpAdress, 6);

                //Suspend the thread so we can write the jump safeley and store the context
                wow.SuspendThread();
                org_context = SThread.GetThreadContext(wow.ThreadHandle, CONTEXT_FLAGS.CONTEXT_ALL);

                //Write the jump
                wow.Asm.Clear();
                wow.Asm.AddLine("jmp {0}", codeCave);
                wow.Asm.Inject(lpAdress);
                
                Console.WriteLine("Hook inserted!");
                
                //resume the thread and when it fires let it jump to the codecave
                wow.ResumeThread();
            }
        }

        /// <summary>
        /// Resores a hijacked function into it's previous state
        /// </summary>
        /// <param name="dwProcessId">ProcessId of the target process</param>
        /// <param name="lpAdress">Pointer to the function you want to restore</param>
        /// <param name="codeCave">Pointer to the codecave</param>
        public static void RestoreHijackedFunction(int dwProcessId, uint lpAdress, uint codeCave)
        {
            BlackMagic wow = new BlackMagic(dwProcessId);
            if (wow.OpenProcessAndThread(wow.ProcessId))
            {
                wow.WriteBytes(lpAdress, orgOpcodes);

                //Set the CONTEXT back
                wow.SuspendThread();
                SThread.SetThreadContext(wow.ThreadHandle, org_context);
                wow.ResumeThread();

                //free the codecave
                wow.FreeMemory(codeCave);

                Console.WriteLine("Hook removed!");
            }
        }


        /// <summary>
        /// Hijacks a thread to execute code in a codecave
        /// </summary>
        /// <param name="ProcessId">Proces Id</param>
        /// <param name="dwThreadId">Thread Id</param>
        /// <param name="CodeCave">Pointer to a codecave</param>
        public static void HijackThreadRunCode(int ProcessId, int dwThreadId, uint CodeCave)
        {
            //Obtain a handle to the thread
            IntPtr hThread = SThread.OpenThread(dwThreadId);

            //Suspend the thread so the context wont change while we obtain it
            SThread.SuspendThread(hThread);

            //Get the original context so we can restore it later
            org_context = SThread.GetThreadContext(hThread, CONTEXT_FLAGS.CONTEXT_ALL);

            //Change the EIP so it points to the codecave
            CONTEXT MyContext = org_context;
            MyContext.Eip = CodeCave;
            SThread.SetThreadContext(hThread, MyContext);

            //Resume the thread again and let the code run
            SThread.ResumeThread(hThread);
        }

        public static void HijackThreadRestore(int dwThreadId)
        {
            //Obtain a handle to the thread
            IntPtr hThread = SThread.OpenThread(dwThreadId);

            //Suspend it so we can restore the context
            SThread.SuspendThread(hThread);

            //Restore the original context
            SThread.SetThreadContext(hThread, org_context);

            //Resume it and hopefully the process wont crash :)
            SThread.ResumeThread(hThread);
        }
    }
}
