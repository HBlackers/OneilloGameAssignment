

namespace O_neilloGame.Components
{
    /// <summary>
    /// About Page
    /// </summary>
    public partial class ctrAbout : UserControl
    {
        public ctrAbout()
        {
            InitializeComponent();
        }
        /// <summary>
        /// closes the feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Click(object sender, EventArgs e)
        {
            //closes form
            ParentForm.Dispose();
        }
    }
}
