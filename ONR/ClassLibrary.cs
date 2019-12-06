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
        public Barnacle barnacle;
        public Molluscs molluscs;
        public Tubeworms tubeworms;
        public Bryozoans bryozoans;
        public Hydroids hydroids;
        public Anenomes anenomes;
        public Tunicates tunicates;
        public Amphipods amphipods;
        public Sponges sponges;
        public Aglae aglae;
        public UnknownSoft unknownsoft;
        public Incipient incipient;
        public Biofilm biofilm;
        public FoulingDataEntry(string id, Batch batch, Barnacle b, Molluscs m, Tubeworms t, Bryozoans by, Hydroids h,
            Anenomes a, Tunicates tn, Amphipods amp, Sponges sp, Aglae ag, UnknownSoft us, Incipient i, Biofilm bf)
        {
            this.panel_id = id;
            this.batch = batch;
            this.barnacle = b;
            this.molluscs = m;
            this.tubeworms = t;
            this.bryozoans = by;
            this.hydroids = h;
            this.anenomes = a;
            this.tunicates = tn;
            this.amphipods = amp;
            this.sponges = sp;
            this.aglae = ag;
            this.unknownsoft = us;
            this.incipient = i;
            this.biofilm = bf;
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

    // Organism classes 
    public class Barnacle
    {
        public string barn_perc;
        public string barn_size;
        public string barn_num;
        public Barnacle()
        {
            this.barn_perc = "";
            this.barn_size = "";
            this.barn_num = "";
        }
    }

    public class Molluscs
    {
        public string mol_perc;
        public Molluscs()
        {
            this.mol_perc = "";
        }
    }

    public class Tubeworms
    {
        public string psed_perc;
        public string pcal_perc;
        public Tubeworms()
        {
            this.psed_perc = "";
            this.pcal_perc = "";
        }
    }

    public class Bryozoans
    {
        public string eb;
        public string wsp;
        public string br;
        public Bryozoans()
        {
            this.eb = "";
            this.wsp = "";
            this.br = "";
        }
    }

    public class Hydroids
    {
        public string cn;
        public Hydroids()
        {
            this.cn = "";
        }
    }

    public class Anenomes
    {
        public string cn;
        public Anenomes()
        {
            this.cn = "";
        }
    }

    public class Tunicates
    {
        public string ct;
        public string pcal;
        public Tunicates()
        {
            this.ct = "";
            this.pcal = "";
        }
    }

    public class Amphipods
    {
        public string cor;
        public Amphipods()
        {
            this.cor = "";
        }
    }

    public class Sponges
    {
        public string sp;
        public Sponges()
        {
            this.sp = "";
        }
    }

    public class Aglae
    {
        public string type;
        public string pcal;
        public Aglae()
        {
            this.type = "";
            this.pcal = "";
        }
    }

    public class UnknownSoft
    {
        public string us_perc;
        public UnknownSoft()
        {
            this.us_perc = "";
        }
    }

    public class Incipient
    {
        public string IF;
        public Incipient()
        {
            this.IF = "";
        }
    }

    public class Biofilm
    {
        public string si_perc;
        public Biofilm()
        {
            this.si_perc = "";
        }
    }
}