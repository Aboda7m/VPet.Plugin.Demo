
using VPet_Simulator.Windows.Interface;

namespace VPet.MutiPlayer.EatBean
{
    /// <summary>
    /// �Զ�2 ���ûع�!
    /// </summary>
    public class EatBean : MainPlugin
    {

        public int TransIndex = 1000;
        /// <summary>
        /// ��������
        /// </summary>
        public List<TransData> TransData = new List<TransData>();

        public EatBean(IMainWindow mainwin) : base(mainwin)
        {
            MW.MutiPlayerHandle += MW_MutiPlayerHandle;
        }
        IMPWindows IMPW;
        private void MW_MutiPlayerHandle(IMPWindows windows)
        {
            //��������Ԥ������
            IMPW = windows;

        }

        public override string PluginName => "EatBean";
    }

}
