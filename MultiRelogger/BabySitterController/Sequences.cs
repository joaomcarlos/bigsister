namespace BigSister
{
    static partial class BSController
    {
        public static void SequencialStartAll()
        {
            for (int i = 0; i < GetAllBabySitters().Count; i++)
            {
                if (!GetAllBabySitters()[i].Watching)
                    GetAllBabySitters()[i].BabySit();
            }
        }
        public static void KillAllBabySitters()
        {
            foreach (BabySitter s in BSController.GetAllBabySitters())
            {
                s.KillBabySitter();
            }
        }
    }
}
