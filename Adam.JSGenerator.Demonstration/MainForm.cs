using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Adam.JSGenerator.Demonstration
{
    public partial class MainForm : Form
    {
        private readonly List<Demonstration> _Demonstrations = new List<Demonstration>();
        private Demonstration _CurrentDemonstation;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            browser.Navigate("about:blank");
            
            LoadDemonstrations();
        }

        private void LoadDemonstrations()
        {
            Type baseType = typeof (Demonstration);
            var demonstrations = from type in Assembly.GetExecutingAssembly().GetTypes()
                                 where baseType.IsAssignableFrom(type) && !type.Equals(baseType)
                                 select (Demonstration)Activator.CreateInstance(type);

            this._Demonstrations.AddRange(demonstrations);

            foreach (var demonstration in this._Demonstrations.OrderBy(demo => demo.Order))
            {
                var item = demonstrationList.Items.Add(demonstration.Description);
                item.Tag = demonstration;
                item.Group = demonstrationList.Groups[(int)demonstration.Group];
            }
        }

        private void DemonstrationListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Demonstration demonstration = (Demonstration)e.Item.Tag;

            this._CurrentDemonstation = null;
            this.browser.DocumentText = string.Empty;
            this.outputBox.Text = string.Empty;

            if (e.IsSelected)
            {
                this._CurrentDemonstation = demonstration;
                browser.DocumentText = demonstration.Explanation;
            }
        }

        private void RunButtonClick(object sender, EventArgs e)
        {
            if (this._CurrentDemonstation != null)
            {
                outputBox.Text = this._CurrentDemonstation.Run().ToString();
            }
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            browser.DocumentText = Explanations.Welcome;
        }
    }
}
