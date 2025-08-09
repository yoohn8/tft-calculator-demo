using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using TFTCalculatorModel;
using TFTCalculator.ViewModels.Helper;
using System.Security.Cryptography.Pkcs;

namespace TFTCalculator.ViewModels
{

    public class CalcViewModel : BaseViewModel
    {
        #region properties1
        private bool canExecute = true;

        string unit_name = "No_Unit";

        string fruit_name = "None";

        string star = "1";

        string item1 = "None";
        string item2 = "None";
        string item3 = "None";

        string aug1 = "None";
        string aug2 = "None";
        string aug3 = "None";

        //string trait1 = "none";
        //string trait2 = "none";
        //string trait3 = "none";
        
        int attack_counter = 0;
        int cast_counter = 0;
        double auto_dps = 0;
        double cast_dps = 0;
        double p_cast_dps = 0;
        double full_dps = 0;
        double true_damage_dps = 0;

        int attack_counter15 = 0;
        int cast_counter15 = 0;
        double auto_dps15 = 0;
        double cast_dps15 = 0;
        double p_cast_dps15 = 0;
        double full_dps15 = 0;
        double true_damage_dps15 = 0;

        double hp = 0;
        double armor = 0;
        double mr = 0;
        double final_ad = 0;
        double final_atks = 0;
        double ap = 0;
        double amp = 0;
        double crit = 0;
        double crit_multi = 0;

        double auto_ad = 0;
        double ad = 0;
        double atks = 0;
        double asi = 0;
        double mana_oh = 0;
        double mana_regen = 0;
        double mana_multi = 0;

        int targets = 0;

        string trait1 = "None";
        string trait2 = "None";
        string trait3 = "None";


        int trait1_value = 0;
        int trait2_value = 0;
        int trait3_value = 0;

        int list_mode = 0;
        int a_list_mode = 0;

        bool comp_enable = false;
        string ce_text = "Comparison OFF";

        bool full_flag = true;
        string mode_text = "Mode: 30 sec";

        bool tank_ilist_check = false;
        bool ad_ilist_check = false;
        bool ap_ilist_check = true;
        bool as_ilist_check = false;

        bool tank_ilist_e = true;
        bool ad_ilist_e = true;
        bool ap_ilist_e = false;
        bool as_ilist_e = true;

        bool silver_list_check = true;
        bool gold_list_check = false;
        bool pris_list_check = false;

        bool silver_list_e = false;
        bool gold_list_e = true;
        bool pris_list_e = true;

        bool ability_crit = false;

        bool first10 = false;
        bool shielded = false;
        bool above50 = false;
        bool hit_tank = false;

        double phys_ehp = 0;
        double magic_ehp = 0;
        double final_phys_dr = 0;
        double final_magic_dr = 0;
        double shield = 0;

        int lilb = 0;
        int item_n = 0;

        int u_list_mode = 3;
        bool u1_list_check = false;
        bool u2_list_check = false;
        bool u3_list_check = false;
        bool u4_list_check = true;
        bool u5_list_check = false;

        bool u1_list_e = true;
        bool u2_list_e = true;
        bool u3_list_e = true;
        bool u4_list_e = false;
        bool u5_list_e = true;


        

        public bool U1_LIST_CHECK { get { return u1_list_check; } set { u1_list_check = value; OnPropertyChanged(); } }
        public bool U2_LIST_CHECK { get { return u2_list_check; } set { u2_list_check = value; OnPropertyChanged(); } }
        public bool U3_LIST_CHECK { get { return u3_list_check; } set { u3_list_check = value; OnPropertyChanged(); } }
        public bool U4_LIST_CHECK { get { return u4_list_check; } set { u4_list_check = value; OnPropertyChanged(); } }
        public bool U5_LIST_CHECK { get { return u5_list_check; } set { u5_list_check = value; OnPropertyChanged(); } }

        public bool U1_LIST_E { get { return u1_list_e; } set { u1_list_e = value; OnPropertyChanged(); } }
        public bool U2_LIST_E { get { return u2_list_e; } set { u2_list_e = value; OnPropertyChanged(); } }
        public bool U3_LIST_E { get { return u3_list_e; } set { u3_list_e = value; OnPropertyChanged(); } }
        public bool U4_LIST_E { get { return u4_list_e; } set { u4_list_e = value; OnPropertyChanged(); } }
        public bool U5_LIST_E { get { return u5_list_e; } set { u5_list_e = value; OnPropertyChanged(); } }

        public int U_LIST_MODE { get { return u_list_mode; } set { u_list_mode = value; OnPropertyChanged(); } }
        public double PHYS_EHP { get { return phys_ehp; } set { phys_ehp = value; OnPropertyChanged(); } }
        public double MAGIC_EHP { get { return magic_ehp; } set { magic_ehp = value; OnPropertyChanged(); } }
        public double FINAL_PHYS_DR { get { return final_phys_dr; } set { final_phys_dr = value; OnPropertyChanged(); } }
        public double FINAL_MAGIC_DR { get { return final_magic_dr; } set { final_magic_dr = value; OnPropertyChanged(); } }
        public double SHIELD { get { return shield; } set { shield = value; OnPropertyChanged(); } }

        
        
        public int ATTACK_COUNTER { get { return attack_counter;} set {attack_counter = value; OnPropertyChanged();} }

        public int CAST_COUNTER { get { return cast_counter; } set { cast_counter = value; OnPropertyChanged(); } }

        public int ATTACK_COUNTER15 { get { return attack_counter15; } set { attack_counter15 = value; OnPropertyChanged(); } }

        public int CAST_COUNTER15 { get { return cast_counter15; } set { cast_counter15 = value; OnPropertyChanged(); } }

        public double AUTO_DPS { get { return auto_dps; } set { auto_dps = value; OnPropertyChanged(); } }
        public double CAST_DPS { get { return cast_dps; } set { cast_dps = value; OnPropertyChanged(); } }
        public double P_CAST_DPS { get { return p_cast_dps; } set { p_cast_dps = value; OnPropertyChanged(); } }
        public double FULL_DPS { get { return full_dps; } set { full_dps = value; OnPropertyChanged(); } }
        public double TRUE_DAMAGE_DPS { get { return true_damage_dps; } set { true_damage_dps = value; OnPropertyChanged(); } }

        public double AUTO_DPS15 { get { return auto_dps15; } set { auto_dps15 = value; OnPropertyChanged(); } }
        public double CAST_DPS15 { get { return cast_dps15; } set { cast_dps15 = value; OnPropertyChanged(); } }
        public double P_CAST_DPS15 { get { return p_cast_dps15; } set { p_cast_dps15 = value; OnPropertyChanged(); } }
        public double FULL_DPS15 { get { return full_dps15; } set { full_dps15 = value; OnPropertyChanged(); } }
        public double TRUE_DAMAGE_DPS15 { get { return true_damage_dps15; } set { true_damage_dps15 = value; OnPropertyChanged(); } }


        //public string TRAIT1 { get { return trait1; } set { trait1 = value; OnPropertyChanged(); } }
        //public string TRAIT2 { get { return trait2; } set { trait2 = value; OnPropertyChanged(); } }
        //public string TRAIT3 { get { return trait3; } set { trait3 = value; OnPropertyChanged(); } }


        public string TRAIT1 { get { return trait1; } set { trait1 = value; OnPropertyChanged(); } }
        public string TRAIT2 { get { return trait2; } set { trait2 = value; OnPropertyChanged(); } }
        public string TRAIT3 { get { return trait3; } set { trait3 = value; OnPropertyChanged(); } }
        public string CE_TEXT { get { return ce_text; } set { ce_text = value; OnPropertyChanged(); } }

        public string MODE_TEXT { get { return mode_text; } set { mode_text = value; OnPropertyChanged(); } }

        public bool TANK_ILIST_CHECK { get { return tank_ilist_check; } set { tank_ilist_check = value; OnPropertyChanged(); } }

        public bool GOLD_LIST_CHECK { get { return gold_list_check; } set { gold_list_check = value; OnPropertyChanged(); } }
        public bool SILVER_LIST_CHECK { get { return silver_list_check; } set { silver_list_check = value; OnPropertyChanged(); } }
        public bool PRIS_LIST_CHECK { get { return pris_list_check; } set { pris_list_check = value; OnPropertyChanged(); } }

        public bool GOLD_LIST_E { get { return gold_list_e; } set { gold_list_e = value; OnPropertyChanged(); } }
        public bool SILVER_LIST_E { get { return silver_list_e; } set { silver_list_e = value; OnPropertyChanged(); } }
        public bool PRIS_LIST_E { get { return pris_list_e; } set { pris_list_e = value; OnPropertyChanged(); } }


        public bool AD_ILIST_CHECK { get { return ad_ilist_check; } set { ad_ilist_check = value; OnPropertyChanged(); } }
        public bool AP_ILIST_CHECK { get { return ap_ilist_check; } set { ap_ilist_check = value; OnPropertyChanged(); } }
        public bool AS_ILIST_CHECK { get { return as_ilist_check; } set { as_ilist_check = value; OnPropertyChanged(); } }
        public bool ABILITY_CRIT { get { return ability_crit; } set { ability_crit = value; OnPropertyChanged(); } }

        public bool TANK_ILIST_E { get { return tank_ilist_e; } set { tank_ilist_e = value; OnPropertyChanged(); } }
        public bool AD_ILIST_E { get { return ad_ilist_e; } set { ad_ilist_e = value; OnPropertyChanged(); } }
        public bool AP_ILIST_E { get { return ap_ilist_e; } set { ap_ilist_e = value; OnPropertyChanged(); } }
        public bool AS_ILIST_E { get { return as_ilist_e; } set { as_ilist_e = value; OnPropertyChanged(); } }
        
        public int LIST_MODE { get { return list_mode; } set { list_mode = value; OnPropertyChanged(); } }
        public int A_LIST_MODE { get { return a_list_mode; } set { a_list_mode = value; OnPropertyChanged(); } }




        public double HP { get { return hp; } set { hp = value; OnPropertyChanged(); } }
        //public double HP_MULT { get { return hp_mult; } set { hp_mult = value; OnPropertyChanged(); } }
        public double ARMOR { get { return armor; } set { armor = value; OnPropertyChanged(); } }
        public double MR { get { return mr; } set { mr = value; OnPropertyChanged(); } }
        //public double DR { get { return dr; } set { dr = value; OnPropertyChanged(); } }
        //public double SHIELD { get { return shield; } set { shield = value; OnPropertyChanged(); } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; OnPropertyChanged(); } }
        public double AP { get { return ap; } set { ap = value; OnPropertyChanged(); } }
        public double AD { get { return ad; } set { ad = value; OnPropertyChanged(); } }
        public double CRIT { get { return crit; } set { crit = value; OnPropertyChanged(); } }
        public double CRIT_MULTI { get { return crit_multi; } set { crit_multi = value; OnPropertyChanged(); } }
        public double ATKS { get { return atks; } set { atks = value; OnPropertyChanged(); } }
        public double AMP { get { return amp; } set { amp = value; OnPropertyChanged(); } }
        //public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; OnPropertyChanged(); } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; OnPropertyChanged(); } }

        public double FINAL_AD { get { return final_ad; } set { final_ad = value; OnPropertyChanged(); } }
        public double FINAL_ATKS { get { return final_atks; } set { final_atks = value; OnPropertyChanged(); } }
        public double AUTO_AD { get { return auto_ad; } set { auto_ad = value; OnPropertyChanged(); } }
        public double ASI { get { return asi; } set { asi = value; OnPropertyChanged(); } }
        public double MANA_MULTI { get { return mana_multi; } set { mana_multi = value; OnPropertyChanged(); } }

        

        #endregion


        #region instantiate objects from model
        CalcModel CM = new();
        List_Obj LC = new();
        #endregion


        #region properties with calcs on set

        public int LILB 
        { 
            get { return lilb; } 
            set 
            {
                lilb = value;
                OnPropertyChanged();
                CM.LILB = lilb;
                CM.Combat_Wrapper();
                Data_Helper();
                //CM.Combat_Wrapper(string unit_name, string star, string item1, string item2, string item3, string aug1, string aug2, string aug3, );

            } 
        }
        public int ITEM_N 
        { 
            get { return item_n; }
            set 
            { 
                item_n = value; 
                OnPropertyChanged();
                CM.ITEM_N = item_n;
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }
        public int TRAIT1_VALUE 
        { 
            get { return trait1_value; } 
            set 
            { 
                trait1_value = value; 
                OnPropertyChanged();
                CM.TRAIT1_VALUE = trait1_value;
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }
        public int TRAIT2_VALUE 
        { 
            get { return trait2_value;} 
            set 
            { 
                trait2_value = value; 
                OnPropertyChanged();
                CM.TRAIT2_VALUE = trait2_value;
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }
        public int TRAIT3_VALUE 
        { 
            get { return trait3_value; } 
            set 
            { 
                trait3_value = value; 
                OnPropertyChanged();
                CM.TRAIT3_VALUE = trait3_value;
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }

        public bool FIRST10 
        { 
            get { return first10; } 
            set 
            { 
                first10 = value; 
                OnPropertyChanged();
                CM.FIRST10 = first10;
                CM.Combat_Wrapper();
                Data_Helper();
            }
        }
        public bool SHIELDED 
        { 
            get { return shielded; } 
            set
            { 
                shielded = value; 
                OnPropertyChanged();
                CM.SHIELDED = shielded;
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }
        public bool ABOVE50 
        { 
            get { return above50; } 
            set 
            { 
                above50 = value; 
                OnPropertyChanged();
                CM.ABOVE50= above50;
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }
        public bool HIT_TANK 
        { 
            get { return hit_tank; } 
            set 
            { 
                hit_tank = value; 
                OnPropertyChanged();
                CM.HIT_TANK = hit_tank;
                CM.Combat_Wrapper();
                Data_Helper();
            }
        }

        public int TARGETS 
        {   
            get { return targets; } 
            set 
            {
                targets = value;
                CM.TARGETS = targets; 
                OnPropertyChanged();
                CM.Combat_Wrapper();
                Data_Helper();
                //(ATTACK_COUNTER, CAST_COUNTER, AUTO_DPS, CAST_DPS, P_CAST_DPS, FULL_DPS, TRUE_DAMAGE_DPS,
                //        ATTACK_COUNTER15, CAST_COUNTER15, AUTO_DPS15, CAST_DPS15, P_CAST_DPS15, FULL_DPS15, TRUE_DAMAGE_DPS15
                //        , TRAIT1, TRAIT2, TRAIT3, HP, AUTO_AD, AD, AP, ATKS, ASI, AMP, CRIT, CRIT_MULTI, ARMOR, MR, MANA_OH, MANA_REGEN, MANA_MULTI
                //        , ABILITY_CRIT, PHYS_EHP, MAGIC_EHP, FINAL_PHYS_DR, FINAL_MAGIC_DR, SHIELD)
                //        = CM.Combat_Wrapper(unit_name, star, item1, item2, item3, trait1_value, trait2_value, trait3_value,
                //                            COMP_LIST, COMP_LIST2, COMP_LIST3, comp_enable, full_flag, targets, first10, shielded, above50, hit_tank,
                //                            aug1, aug2, aug3, lilb, item_n);
            } 
        }
        public bool COMP_ENABLE
        {
            get { return comp_enable; }
            set
            {
                comp_enable = value;
                CM.COMP_ENABLE = comp_enable; 
                OnPropertyChanged(); CM.Combat_Wrapper();
                Data_Helper();
            }
        }
        public bool FULL_FLAG 
        { 
            get { return full_flag; } 
            set 
            { 
                full_flag = value;
                CM.FULL_FLAG = full_flag; 
                OnPropertyChanged();
                CM.Combat_Wrapper();
                Data_Helper();
            } 
        }

        public string FRUIT_NAME
        {
            get { return fruit_name; }
            set
            {
                if (value != null)
                {
                    fruit_name = value.ToString();
                    OnPropertyChanged();
                    CM.FRUIT_NAME = fruit_name;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }
            }
        }

        public string UNIT_NAME
        {
            //get { return unit_name; }
            get { return unit_name; }
            set
            {
                if (value != null)
                {
                    unit_name = value.ToString();
                    OnPropertyChanged();
                    CM.UNIT_NAME = unit_name;
                    FRUIT_NAME = "None";
                    CM.FRUIT_NAME = fruit_name;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }
            }
        }

        //public string star = "1";
        public string STAR
        {
            get { return star; }
            set
            {
                star = value.ToString();
                OnPropertyChanged();
                CM.STAR = star;

                CM.Combat_Wrapper();
                Data_Helper();



            }
        }

        //public string item1 = "None";
        public string ITEM1
        {
            get { return item1; }
            set
            {
                if (value != null)
                {
                    item1 = value.ToString();
                    OnPropertyChanged();
                    CM.ITEM1_NAME = item1;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }
                

            }
        }

        //public string item2 = "None";
        public string ITEM2
        {
            get { return item2; }
            set
            {
                if (value != null)
                {
                    item2 = value.ToString();
                    OnPropertyChanged();
                    CM.ITEM2_NAME = item2;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }
                    

            }
        }

        //public string item3 = "None";
        public string ITEM3
        {
            get { return item3; }
            set
            {
                if(value != null)
                {
                    item3 = value.ToString();
                    OnPropertyChanged();
                    CM.ITEM3_NAME = item3;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }
                

            }
        }

        //public string aug1 = "None";

        public string AUG1
        {
            get { return aug1; }
            set
            {
                if (value != null)
                {
                    aug1 = value.ToString();
                    OnPropertyChanged();
                    CM.AUG1_NAME = aug1;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }


            }
        }

       //public string aug2 = "None";

        public string AUG2
        {
            get { return aug2; }
            set
            {
                if (value != null)
                {
                    aug2 = value.ToString();
                    OnPropertyChanged();
                    CM.AUG2_NAME = aug2;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }


            }
        }

        //public string aug3 = "None";

        public string AUG3
        {
            get { return aug3; }
            set
            {
                if (value != null)
                {
                    aug3 = value.ToString();
                    OnPropertyChanged();
                    CM.AUG3_NAME = aug3;
                    CM.Combat_Wrapper();
                    Data_Helper();
                }


            }
        }

        #endregion

        #region list declarations
        public ObservableCollection<string> COMP_LIST { get; }
        public ObservableCollection<string> COMP_LIST2 { get; }
        public ObservableCollection<string> COMP_LIST3 { get; }
        public List<string> STARLIST {get;}
        public List<string> UNITLIST5 {get;}
        public List<string> UNITLIST4 {get;}
        public List<string> UNITLIST3 { get; }
        public List<string> UNITLIST2 { get; }
        public List<string> UNITLIST1 { get; }
        public List<string> ITEMLIST { get; }
        public List<string> ITEMLIST2 { get; }
        public List<string> ITEMLIST3 { get; }
        public List<string> G_AUGLIST { get; }
        public List<string> S_AUGLIST { get; }
        public List<string> P_AUGLIST { get; }
        public List<string> KAT_FLIST { get; }
        public List<string> CAIT_FLIST { get; }
        public List<string> LUCIAN_FLIST { get; }
        public List<string> MALZ_FLIST { get; }
        public List<string> SENNA_FLIST { get; }
        public List<string> AKALI_FLIST { get; }
        public List<string> ASHE_FLIST { get; }
        public List<string> JARVAN_FLIST { get; }
        public List<string> JINX_FLIST { get; }
        public List<string> KSANTE_FLIST { get; }
        public List<string> KARMA_FLIST { get; }
        public List<string> LEONA_FLIST { get; }
        public List<string> POPPY_FLIST { get; }
        public List<string> RYZE_FLIST { get; }
        public List<string> SAMIRA_FLIST { get; }
        public List<string> SETT_FLIST { get; }
        public List<string> VOLI_FLIST { get; }
        public List<string> YUUMI_FLIST { get; }
        #endregion

        // constructor
        public CalcViewModel()
        {
            // intiialize lists
            COMP_LIST = CM.OUT_LIST;
            COMP_LIST2 = CM.OUT_LIST2;
            COMP_LIST3 = CM.OUT_LIST3;

            #region fruit lists
            KAT_FLIST = LC.KAT_FLIST;
            CAIT_FLIST = LC.CAIT_FLIST;
            LUCIAN_FLIST = LC.LUCIAN_FLIST;
            MALZ_FLIST = LC.MALZ_FLIST;
            SENNA_FLIST = LC.SENNA_FLIST;
            AKALI_FLIST = LC.AKALI_FLIST;
            ASHE_FLIST = LC.ASHE_FLIST;
            JARVAN_FLIST = LC.JARVAN_FLIST;
            JINX_FLIST = LC.JINX_FLIST;
            KSANTE_FLIST = LC.KSANTE_FLIST;
            KARMA_FLIST = LC.KARMA_FLIST;
            LEONA_FLIST = LC.LEONA_FLIST;
            POPPY_FLIST = LC.POPPY_FLIST;
            RYZE_FLIST = LC.RYZE_FLIST;
            SAMIRA_FLIST = LC.SAMIRA_FLIST;
            SETT_FLIST = LC.SETT_FLIST;
            VOLI_FLIST = LC.VOLI_FLIST;
            YUUMI_FLIST = LC.YUUMI_FLIST;
            #endregion

            #region augment lists
            G_AUGLIST = LC.G_AUGLIST;
            S_AUGLIST = LC.S_AUGLIST;
            P_AUGLIST = LC.P_AUGLIST;
            #endregion

            #region item lists
            ITEMLIST = LC.ITEMLIST;
            ITEMLIST2 = LC.ITEMLIST2;
            ITEMLIST3 = LC.ITEMLIST3;
            #endregion

            #region unit lists
            STARLIST = LC.STARLIST;
            UNITLIST5 = LC.UNITLIST5;
            UNITLIST4 = LC.UNITLIST4;
            UNITLIST3 = LC.UNITLIST3;
            UNITLIST2 = LC.UNITLIST2;
            UNITLIST1 = LC.UNITLIST1;
            #endregion

            #region commands
            LILB_PLUS = new RelayCommand(Lilb_inc);
            ITEM_N_PLUS = new RelayCommand(Item_n_inc);

            LILB_MINUS = new RelayCommand(Lilb_dec);
            ITEM_N_MINUS = new RelayCommand(Item_n_dec);

            TRAIT1PLUS = new RelayCommand(Trait1_inc);
            TRAIT2PLUS = new RelayCommand(Trait2_inc);
            TRAIT3PLUS = new RelayCommand(Trait3_inc);

            TRAIT1MINUS = new RelayCommand(Trait1_dec);
            TRAIT2MINUS = new RelayCommand(Trait2_dec);
            TRAIT3MINUS = new RelayCommand(Trait3_dec);

            TRAITRESET = new RelayCommand(Trait_reset);
            ITEMRESET = new RelayCommand(Item_reset);
            AUG_RESET = new RelayCommand(Aug_reset);

            TARGETPLUS = new RelayCommand(Target_inc);
            TARGETMINUS = new RelayCommand(Target_dec);

            FIRST10_SET = new RelayCommand(First10_Toggle, param => this.canExecute);
            SHIELDED_SET = new RelayCommand(Shielded_Toggle, param => this.canExecute);
            ABOVE50_SET = new RelayCommand(Above50_Toggle, param => this.canExecute);
            HIT_TANK_SET = new RelayCommand(Hit_Tank_Toggle, param => this.canExecute);

            COMP_E_CHECK = new RelayCommand(Comp_Enable_Toggle, param => this.canExecute);
            COMP_MODE_CHECK = new RelayCommand(Comp_Mode_Toggle, param => this.canExecute);

            TANK_ILIST = new RelayCommand(Tank_IList_Toggle, param => this.canExecute);
            AD_ILIST = new RelayCommand(AD_IList_Toggle, param => this.canExecute);
            AP_ILIST = new RelayCommand(AP_IList_Toggle, param => this.canExecute);

            GOLD_AUG = new RelayCommand(Gold_List_Toggle, param => this.canExecute);
            SILVER_AUG = new RelayCommand(Silver_List_Toggle, param => this.canExecute);
            PRIS_AUG = new RelayCommand(Pris_List_Toggle, param => this.canExecute);

            U1_LIST = new RelayCommand(U1_List_Toggle, param => this.canExecute);
            U2_LIST = new RelayCommand(U2_List_Toggle, param => this.canExecute);
            U3_LIST = new RelayCommand(U3_List_Toggle, param => this.canExecute);
            U4_LIST = new RelayCommand(U4_List_Toggle, param => this.canExecute);
            U5_LIST = new RelayCommand(U5_List_Toggle, param => this.canExecute);

            #endregion
        }

        public void Data_Helper()
        {
            
            TRAIT1 = CM.TRAIT1_NAME;
            TRAIT2 = CM.TRAIT2_NAME;
            TRAIT3 = CM.TRAIT3_NAME;

            FULL_DPS = CM.FULL_DPS;
            ATTACK_COUNTER = CM.ATTACK_COUNTER;
            CAST_COUNTER = CM.CAST_COUNTER;
            AUTO_DPS = CM.AUTO_DPS;
            CAST_DPS = CM.CAST_DPS;
            P_CAST_DPS = CM.P_CAST_DPS;
            TRUE_DAMAGE_DPS = CM.TRUE_DAMAGE_DPS;

            FULL_DPS15 = CM.FULL_DPS15;
            ATTACK_COUNTER15 = CM.ATTACK_COUNTER15;
            CAST_COUNTER15 = CM.CAST_COUNTER15;
            AUTO_DPS15 = CM.AUTO_DPS15;
            CAST_DPS15 = CM.CAST_DPS15;
            P_CAST_DPS15 = CM.P_CAST_DPS15;
            TRUE_DAMAGE_DPS15 = CM.TRUE_DAMAGE_DPS15;

            

            HP = CM.HP;
            ARMOR = CM.ARMOR;
            MR = CM.MR;
            FINAL_ATKS = CM.FINAL_ATKS;
            AP = CM.AP;
            AMP = CM.AMP;
            CRIT = CM.CRIT;
            CRIT_MULTI = CM.CRIT_MULTI;

            AUTO_AD = CM.AUTO_AD;
            AD = CM.AD;
            ASI = CM.ASI;
            MANA_OH = CM.MANA_OH;
            MANA_REGEN = CM.MANA_REGEN;
            MANA_MULTI = CM.MANA_MULTI;

        }

        #region commands

        private ICommand u1_list;
        private ICommand u2_list;
        private ICommand u3_list;
        private ICommand u4_list;
        private ICommand u5_list;

        private ICommand trait1plus;
        private ICommand trait2plus;
        private ICommand trait3plus;

        private ICommand trait1minus;
        private ICommand trait2minus;
        private ICommand trait3minus;

        private ICommand lilb_plus;
        private ICommand item_n_plus;

        private ICommand lilb_minus;
        private ICommand item_n_minus;

        private ICommand traitreset;
        private ICommand itemreset;

        private ICommand targetplus;
        private ICommand targetminus;

        private ICommand comp_e_check;
        private ICommand comp_mode_check;

        private ICommand tank_ilist;
        private ICommand ad_ilist;
        private ICommand ap_ilist;
        private ICommand as_ilist;

        private ICommand gold_aug;
        private ICommand silver_aug;
        private ICommand pris_aug;

        private ICommand aug_reset;

        private ICommand first10_set;
        private ICommand shielded_set;
        private ICommand above50_set;
        private ICommand hit_tank_set;

        public ICommand U1_LIST { get { return u1_list; } set { u1_list = value; } }
        public ICommand U2_LIST { get { return u2_list; } set { u2_list = value; } }
        public ICommand U3_LIST { get { return u3_list; } set { u3_list = value; } }
        public ICommand U4_LIST { get { return u4_list; } set { u4_list = value; } }
        public ICommand U5_LIST { get { return u5_list; } set { u5_list = value; } }
        public ICommand AUG_RESET { get { return aug_reset; } set { aug_reset = value; } }
        public ICommand LILB_PLUS { get { return lilb_plus; } set { lilb_plus = value; } }
        public ICommand LILB_MINUS { get { return lilb_minus; } set { lilb_minus = value; } }

        public ICommand ITEM_N_PLUS { get { return item_n_plus; } set { item_n_plus = value; } }
        public ICommand ITEM_N_MINUS { get { return item_n_minus; } set { item_n_minus = value; } }

        public ICommand GOLD_AUG { get { return gold_aug; } set { gold_aug = value; } }
        public ICommand SILVER_AUG { get { return silver_aug; } set { silver_aug = value; } }
        public ICommand PRIS_AUG { get { return pris_aug; } set { pris_aug = value; } }
        public ICommand TRAIT1PLUS { get { return trait1plus; } set { trait1plus = value; } }
        public ICommand TRAIT2PLUS { get { return trait2plus; } set { trait2plus = value; } }
        public ICommand TRAIT3PLUS { get { return trait3plus; } set { trait3plus = value; } }

        public ICommand TRAIT1MINUS { get { return trait1minus; } set { trait1minus = value; } }
        public ICommand TRAIT2MINUS { get { return trait2minus; } set { trait2minus = value; } }
        public ICommand TRAIT3MINUS { get { return trait3minus; } set { trait3minus = value; } }

        public ICommand TRAITRESET { get { return traitreset; } set { traitreset = value; } }

        public ICommand ITEMRESET { get { return itemreset; } set { itemreset = value; } }

        public ICommand TARGETPLUS { get { return targetplus; } set { targetplus = value; } }
        public ICommand TARGETMINUS { get { return targetminus; } set { targetminus = value; } }
        public ICommand COMP_E_CHECK { get { return comp_e_check; } set { comp_e_check = value; } }
        public ICommand COMP_MODE_CHECK { get { return comp_mode_check; } set { comp_mode_check = value; } }

        public ICommand TANK_ILIST { get { return tank_ilist; } set { tank_ilist = value; } }
        public ICommand AD_ILIST { get { return ad_ilist; } set { ad_ilist = value; } }
        public ICommand AP_ILIST { get { return ap_ilist; } set { ap_ilist = value; } }
        public ICommand AS_ILIST { get { return as_ilist; } set { as_ilist = value; } }

        public ICommand FIRST10_SET { get { return first10_set; } set { first10_set = value; } }
        public ICommand SHIELDED_SET { get { return shielded_set; } set { shielded_set = value; } }
        public ICommand ABOVE50_SET { get { return above50_set; } set { above50_set = value; } }
        public ICommand HIT_TANK_SET { get { return hit_tank_set; } set { hit_tank_set = value; } }



        //public void AS_IList_Toggle(object obj)
        //{
        //    if ((bool)obj)
        //    {
        //        TANK_ILIST_CHECK = false;
        //        AP_ILIST_CHECK = false;
        //        AD_ILIST_CHECK = false;



        //        //AD_ILIST_E = false;
        //        //AP_ILIST_E = false;
        //        //AS_ILIST_E = false;
        //    }
        //    else
        //    {
        //    }

        //}

        //d
        public void Hit_Tank_Toggle(object obj)
        {
            if ((bool)obj)
            {
                HIT_TANK = true;

            }
            else
            {
                HIT_TANK = false;
            } 

        }

        //d
        public void First10_Toggle(object obj)
        {
            if ((bool)obj)
            {
                FIRST10 = true;

            }
            else
            {
                FIRST10 = false;
            }
            


        }

        //d
        public void Shielded_Toggle(object obj)
        {
            if ((bool)obj)
            {
                SHIELDED = true;
            }
            else
            {
                SHIELDED = false;
            } 
                

        }

        //d
        public void Above50_Toggle(object obj)
        {
            if ((bool)obj)
            {
                ABOVE50 = true;

            }
            else
            {
                ABOVE50 = false;

            }


        }

        public void U1_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                U_LIST_MODE = 0;

                U2_LIST_CHECK = false;
                U3_LIST_CHECK = false;
                U4_LIST_CHECK = false;
                U5_LIST_CHECK = false;

                U1_LIST_E = false;
                U2_LIST_E = true;
                U3_LIST_E = true;
                U4_LIST_E = true;
                U5_LIST_E = true;

            }
        }

        public void U2_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                U_LIST_MODE = 1;

                U1_LIST_CHECK = false;
                U3_LIST_CHECK = false;
                U4_LIST_CHECK = false;
                U5_LIST_CHECK = false;

                U1_LIST_E = true;
                U2_LIST_E = false;
                U3_LIST_E = true;
                U4_LIST_E = true;
                U5_LIST_E = true;

            }
        }

        public void U3_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                U_LIST_MODE = 2;

                U1_LIST_CHECK = false;
                U2_LIST_CHECK = false;
                U4_LIST_CHECK = false;
                U5_LIST_CHECK = false;

                U1_LIST_E = true;
                U2_LIST_E = true;
                U3_LIST_E = false;
                U4_LIST_E = true;
                U5_LIST_E = true;

            }
        }

        public void U4_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                U_LIST_MODE = 3;

                U1_LIST_CHECK = false;
                U2_LIST_CHECK = false;
                U3_LIST_CHECK = false;
                U5_LIST_CHECK = false;

                U1_LIST_E = true;
                U2_LIST_E = true;
                U3_LIST_E = true;
                U4_LIST_E = false;
                U5_LIST_E = true;

            }
        }

        public void U5_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                U_LIST_MODE = 4;

                U1_LIST_CHECK = false;
                U2_LIST_CHECK = false;
                U3_LIST_CHECK = false;
                U4_LIST_CHECK = false;

                U1_LIST_E = true;
                U2_LIST_E = true;
                U3_LIST_E = true;
                U4_LIST_E = true;
                U5_LIST_E = false;

            }
        }

        public void AP_IList_Toggle(object obj)
        {
            if ((bool)obj)
            {
                TANK_ILIST_CHECK = false;
                AD_ILIST_CHECK = false;
                AS_ILIST_CHECK = false;

                //ITEMLIST[1] = "Archangels";
                //ITEMLIST[2] = "Deathcap";
                //ITEMLIST[3] = "JeweledGauntlet";
                //ITEMLIST[4] = "VoidStaff";
                //ITEMLIST[5] = "Rageblade";
                //ITEMLIST[6] = "BlueBuff";
                //ITEMLIST[7] = "Nashor";
                //ITEMLIST[8] = "StrikersFlail";
                //ITEMLIST[9] = "AdaptiveBack";
                //ITEMLIST[10] = "Morello";
                //ITEMLIST[11] = "Gunblade";
                //ITEMLIST[12] = "Redbuff";

                LIST_MODE = 0;
                AP_ILIST_E = false;
                AD_ILIST_E = true;
                TANK_ILIST_E = true;

            }
        }

        public void Silver_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                GOLD_LIST_CHECK = false;
                PRIS_LIST_CHECK = false;

                A_LIST_MODE = 0;

                SILVER_LIST_E = false;
                GOLD_LIST_E = true;
                PRIS_LIST_E = true;
            }
            else
            {
            }

        }

        public void Gold_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                SILVER_LIST_CHECK = false;
                PRIS_LIST_CHECK = false;

                A_LIST_MODE = 1;

                SILVER_LIST_E = true;
                GOLD_LIST_E = false;
                PRIS_LIST_E = true;
            }
            else
            {
            }

        }

        public void Pris_List_Toggle(object obj)
        {
            if ((bool)obj)
            {
                SILVER_LIST_CHECK = false;
                GOLD_LIST_CHECK = false;

                A_LIST_MODE = 2;

                SILVER_LIST_E = true;
                GOLD_LIST_E = true;
                PRIS_LIST_E = false;
            }
            else
            {
            }

        }

        public void AD_IList_Toggle(object obj)
        {
            if ((bool)obj)
            {
                TANK_ILIST_CHECK = false;
                AP_ILIST_CHECK = false;
                AS_ILIST_CHECK = false;

                LIST_MODE = 1;
                AP_ILIST_E = true;
                AD_ILIST_E = false;
                TANK_ILIST_E = true;
            }
            else
            {
            }

        }
        public void Tank_IList_Toggle(object obj)
        {
            if ((bool)obj)
            {
                AD_ILIST_CHECK = false;
                AP_ILIST_CHECK = false;
                AS_ILIST_CHECK = false;

                //ITEMLIST[1] = "Warmogs";
                //ITEMLIST[2] = "SpiritVisage";
                //ITEMLIST[3] = "Bramble";
                //ITEMLIST[4] = "DragonClaw";
                //ITEMLIST[5] = "ProtectorsVow";
                //ITEMLIST[6] = "SteadfastHeart";
                //ITEMLIST[7] = "Crownguard";
                //ITEMLIST[8] = "Stoneplate";
                //ITEMLIST[9] = "AdaptiveFront";
                //ITEMLIST[10] = "Spark";
                //ITEMLIST[11] = "EvenShroud";
                //ITEMLIST[12] = "Sunfire";

                LIST_MODE = 2;
                AP_ILIST_E = true;
                AD_ILIST_E = true;
                TANK_ILIST_E = false;
            }
            else
            {
            }

        }

        public void Comp_Mode_Toggle(object obj)
        {
            if ((bool)obj)
            {

                FULL_FLAG = false;
                MODE_TEXT = "Mode: 15 sec";
            }
            else
            {
                FULL_FLAG = true;
                MODE_TEXT = "Mode: 30 sec";
            }

        }
        public void Comp_Enable_Toggle(object obj)
        {
            if ((bool)obj)
            {
                
                COMP_ENABLE = true;
                CE_TEXT = "Comparison ON";
            }
            else
            {
                COMP_ENABLE = false;
                CE_TEXT = "Comparison OFF";
            }
               
        }

        public void Trait_reset(object obj)
        {
            
            TRAIT1_VALUE = 0;
            TRAIT2_VALUE = 0;
            TRAIT3_VALUE = 0;

        }

        public void Item_reset(object obj)
        {

            ITEM1 = "None";
            ITEM2 = "None";
            ITEM3 = "None";

        }

        public void Aug_reset(object obj)
        {

            AUG1 = "None";
            AUG2 = "None";
            AUG3 = "None";

        }

        public void Lilb_inc(object obj)
        {
            if (lilb < 6)
            {
                LILB += 1;
            }

        }

        public void Lilb_dec(object obj)
        {
            if (lilb > 0)
            {
                LILB -= 1;

            }

        }

        public void Item_n_inc(object obj)
        {
            if (item_n < 19)
            {
                ITEM_N += 1;
            }

        }

        public void Item_n_dec(object obj)
        {
            if (item_n > 0)
            {
                ITEM_N -= 1;
            }

        }

        public void Target_inc(object obj)
        {
            if (TARGETS < 5)
            {
                TARGETS += 1;

                
            }

        }

        public void Target_dec(object obj)
        {
            if (TARGETS > 0)
            {
                TARGETS -= 1;

            }



        }

        public void Trait1_inc(object obj)
        {
            if (trait1_value < 10)
            {
                TRAIT1_VALUE += 1;

            }


            
        }

        public void Trait2_inc(object obj)
        {
            if (trait2_value < 10)
            {
                TRAIT2_VALUE += 1;

            }


            
        }

        public void Trait3_inc(object obj)
        {
            if(trait3_value < 10)
            {
                TRAIT3_VALUE += 1;

            }

            
        }

        public void Trait1_dec(object obj)
        {
            if(trait1_value > 0)
            {
                TRAIT1_VALUE -= 1;

            }

            
        }

        public void Trait2_dec(object obj)
        {
            if (trait2_value > 0)
            {
                TRAIT2_VALUE -= 1;

            }
            
        }

        public void Trait3_dec(object obj)
        {
            if (trait3_value > 0)
            {
                TRAIT3_VALUE -= 1;

            }
            
        }


        #endregion 



    }

}
