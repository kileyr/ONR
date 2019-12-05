using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ONR
{
    public class Batch
    {
        public string batch_name;
        public string date_added;
        public int batch_id;
        public Batch(string name, string date_added)
        {
            this.batch_name = name;
            this.date_added = date_added;
            this.batch_id = 0; //TEMP 
        }
    }

    public class WaterJet
    {
        public Batch batch;
        public int psi;
        public WaterJet(Batch batch, int psi)
        {
            this.batch = batch;
            this.psi = psi;
        }
    }

    public class PanelFouling
    {
        public string panel_id;
        public PanelFouling(string id)
        {
            this.panel_id = id;
        }
    }

    public class FoulingDataEntry
    {
        public string panel_id;
        public Batch batch;
        public FoulingDataEntry(string id, Batch batch)
        {
            this.panel_id = id;
            this.batch = batch;
        }
    }

    public class PanelPush
    {
        public string panel_id;
        public PanelPush(string id)
        {
            this.panel_id = id;
        }
    }

    public class PushDataEntry
    {
        public string panel_id;
        public Batch batch;
        public PushDataEntry(string id, Batch batch)
        {
            this.panel_id = id;
            this.batch = batch;
        }
    }

    public class PanelWJ
    {
        public string panel_id;
        public PanelWJ(string id)
        {
            this.panel_id = id;
        }
    }

    public class WJDataEntry
    {
        public string panel_id;
        public Batch batch;
        public int psi;
        public WJDataEntry(string id, Batch batch, int psi)
        {
            this.panel_id = id;
            this.batch = batch;
            this.psi = psi;
        }

        public void next_psi()
        {
            if (this.psi < 120)
            {
                this.psi += 40;
            }
            else if (this.psi == 120)
            {
                this.psi = 180;
            }
            else if (this.psi == 180)
            {
                this.psi = 240;
            }
        }
    }
}