using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Adam.JSGenerator.Demonstration
{
    public partial class MainForm : Form
    {
        private readonly List<Demonstration> _demonstrations = new List<Demonstration>();
        private Demonstration _currentDemonstation;

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

            _demonstrations.AddRange(demonstrations);

            foreach (var demonstration in _demonstrations.OrderBy(demo => demo.Order))
            {
                string description = demonstration.Description;

                if (!string.IsNullOrEmpty(description))
                {
                    var item = demonstrationList.Items.Add(demonstration.Description);
                    item.Tag = demonstration;
                    item.Group = demonstrationList.Groups[(int) demonstration.Group];
                }
            }
        }

        private void DemonstrationListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Demonstration demonstration = (Demonstration)e.Item.Tag;

            _currentDemonstation = null;
            browser.DocumentText = string.Empty;
            outputBox.Text = string.Empty;

            if (e.IsSelected)
            {
                _currentDemonstation = demonstration;
                browser.DocumentText = demonstration.Explanation;
            }
        }

        private void RunButtonClick(object sender, EventArgs e)
        {
            if (_currentDemonstation != null)
            {
                outputBox.Text = _currentDemonstation.Run().ToString();
            }
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            browser.DocumentText = Explanations.Welcome;
        }
    }
}
