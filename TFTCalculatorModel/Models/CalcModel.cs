using System;
using System.Buffers.Text;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


/// To do list
/// 
/// implement rest of 4 costs
/// 
/// implement after cast mana events
/// star guardian and water lotus
/// 
/// implement stoneplate effect
/// 
/// implement power ups
/// 
/// work on ui
/// 
/// change crit_flag to be a bool
/// rename crit_flag2 in combat methods
///

namespace TFTCalculatorModel
{
    public class CalcModel : INotifyPropertyChanged
    {
        bool comp_enable = false;
        bool full_flag = true;
        int targets = 0;

        string unit_name = "No_Unit";
        string star = "1";

        string item1_name = "None";
        string item2_name = "None";
        string item3_name = "None";

        string aug1_name = "None";
        string aug2_name = "None";
        string aug3_name = "None";

        string trait1_name = "None";
        string trait2_name = "None";
        string trait3_name = "None";

        double trait1_value = 0;
        double trait2_value = 0;
        double trait3_value = 0;

        string fruit_name = "None";

        //bool ascend_flag = false;
        int lilb = 0;
        int item_n = 0;

        bool first10 = false;
        bool shielded = false;
        bool above50 = false;
        bool hit_tank = false;

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
        double final_atks = 0;
        double ap = 0;
        double amp = 0;
        double crit = 0;
        double crit_multi = 0;

        double auto_ad = 0;
        double ad = 0;
        double asi = 0;
        double mana_oh = 0;
        double mana_regen = 0;
        double mana_multi = 0;

        public double HP { get { return hp; } set { hp = value; OnPropertyChanged(); } }
        public double ARMOR { get { return armor; } set { armor = value; OnPropertyChanged(); } }
        public double MR { get { return mr; } set { mr = value; OnPropertyChanged(); } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; OnPropertyChanged(); } }
        public double AP { get { return ap; } set { ap = value; OnPropertyChanged(); } }
        public double AD { get { return ad; } set { ad = value; OnPropertyChanged(); } }
        public double CRIT { get { return crit; } set { crit = value; OnPropertyChanged(); } }
        public double CRIT_MULTI { get { return crit_multi; } set { crit_multi = value; OnPropertyChanged(); } }
        public double AMP { get { return amp; } set { amp = value; OnPropertyChanged(); } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; OnPropertyChanged(); } }

        public double FINAL_ATKS { get { return final_atks; } set { final_atks = value; OnPropertyChanged(); } }
        public double AUTO_AD { get { return auto_ad; } set { auto_ad = value; OnPropertyChanged(); } }
        public double ASI { get { return asi; } set { asi = value; OnPropertyChanged(); } }
        public double MANA_MULTI { get { return mana_multi; } set { mana_multi = value; OnPropertyChanged(); } }

        public int ATTACK_COUNTER { get { return attack_counter; } set { attack_counter = value; OnPropertyChanged(); } }

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

        public bool FIRST10 { get { return first10; } set { first10 = value; } }
        public bool SHIELDED { get { return shielded; } set { shielded = value; } }
        public bool ABOVE50 { get { return above50; } set { above50 = value; } }
        public bool HIT_TANK { get { return hit_tank; } set { hit_tank = value; } }
        public string TRAIT1_NAME { get { return trait1_name; } set { trait1_name = value; OnPropertyChanged(); } }
        public string TRAIT2_NAME { get { return trait2_name; } set { trait2_name = value; OnPropertyChanged(); } }
        public string TRAIT3_NAME { get { return trait3_name; } set { trait3_name = value; OnPropertyChanged(); } }

        public string FRUIT_NAME { get { return fruit_name; } set { fruit_name = value; } }
        public string UNIT_NAME { get { return unit_name; } set { unit_name = value; } }
        public string STAR { get { return star; } set { star = value; } }

        public string ITEM1_NAME { get { return item1_name; } set { item1_name = value; } }
        public string ITEM2_NAME { get { return item2_name; } set { item2_name = value; } }
        public string ITEM3_NAME { get { return item3_name; } set { item3_name = value; } }

        public string AUG1_NAME { get { return aug1_name; } set { aug1_name = value; } }
        public string AUG2_NAME { get { return aug2_name; } set { aug2_name = value; } }
        public string AUG3_NAME { get { return aug3_name; } set { aug3_name = value; } }

        public double TRAIT1_VALUE { get { return trait1_value; } set { trait1_value = value; } }
        public double TRAIT2_VALUE { get { return trait2_value; } set { trait2_value = value; } }
        public double TRAIT3_VALUE { get { return trait3_value; } set { trait3_value = value; } }

        public int LILB { get { return lilb; } set { lilb = value; } }
        public int ITEM_N { get { return item_n; } set { item_n = value; } }
        //public bool ASCEND_FLAG { get { return ascend_flag; } set { ascend_flag = value; } }
        public bool COMP_ENABLE { get { return comp_enable; } set { comp_enable = value; } }
        public bool FULL_FLAG { get { return full_flag; } set { full_flag = value; } }

        public int TARGETS { get { return targets; } set { targets = value; } }

        public static ObservableCollection<string> out_list = new()
        {
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-"
        };

        public ObservableCollection<string> OUT_LIST { get { return out_list; } }

        public static ObservableCollection<string> out_list2 = new()
        {
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-"
        };
        public ObservableCollection<string> OUT_LIST2 { get { return out_list2; } }

        public static ObservableCollection<string> out_list3 = new()
        {
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            "-",  "-",  "-",  "-",  "-",  "-",  "-"
        };
        public ObservableCollection<string> OUT_LIST3 { get { return out_list3; } }

        #region methods
        //public (int, int, double, double, double, double, double, int, int, double, double, double, double, double,
        //        string, string, string,
        //        double, double, double, double, double, double, double,
        //        double, double, double, double, double, double, double,
        //        bool, double, double, double, double, double
        //        )
        public void Combat_Wrapper()
            //(string unit, string star, string item1, string item2, string item3, int trait1_value, int trait2_value, int trait3_value,
            //           ObservableCollection<string> outlist, ObservableCollection<string> outlist2, ObservableCollection<string> outlist3, 
            //           bool comp_enable, bool full_flag, int targets, bool first10, bool shielded, bool above50, bool hit_tank, string aug1, 
            //           string aug2, string aug3, int lilb, int item_n)
        {
            // instantiate objects here
            // combat wrapper takes in string as inputs

            Post_Combat_Stats pobj = new();
            Unit_Holder uobj = new();
            Item_Holder iobj1 = new();
            Item_Holder iobj2 = new();
            Item_Holder iobj3 = new();
            Aug_Holder aobj1 = new();
            Aug_Holder aobj2 = new();
            Aug_Holder aobj3 = new();
            Trait_Holder tobj1 = new();
            Trait_Holder tobj2 = new();
            Trait_Holder tobj3 = new();
            Fruit_Holder fobj = new();

            uobj.UNIT_NAME = UNIT_NAME;
            uobj.STAR = STAR;

            iobj1.ITEM_NAME = ITEM1_NAME;
            iobj2.ITEM_NAME = ITEM2_NAME;
            iobj3.ITEM_NAME = ITEM3_NAME;

            aobj1.AUG_NAME = AUG1_NAME;
            aobj2.AUG_NAME = AUG2_NAME;
            aobj3.AUG_NAME = AUG3_NAME;

            tobj1.TRAIT_VALUE = TRAIT1_VALUE;
            tobj2.TRAIT_VALUE = TRAIT2_VALUE;
            tobj3.TRAIT_VALUE = TRAIT3_VALUE;

            fobj.FRUIT_NAME = FRUIT_NAME;

            aobj1.LILB = LILB;
            aobj2.LILB = LILB;
            aobj3.LILB = LILB;

            aobj1.ITEM_N = ITEM_N;
            aobj2.ITEM_N = ITEM_N;
            aobj3.ITEM_N = ITEM_N;

            

            tobj1.FIRST10 = FIRST10;
            tobj2.FIRST10 = FIRST10;
            tobj3.FIRST10 = FIRST10;

            tobj1.SHIELDED = SHIELDED;
            tobj2.SHIELDED = SHIELDED;
            tobj3.SHIELDED = SHIELDED;

            tobj1.ABOVE50 = ABOVE50;
            tobj2.ABOVE50 = ABOVE50;
            tobj3.ABOVE50 = ABOVE50;

            iobj1.ABOVE50 = ABOVE50;
            iobj2.ABOVE50 = ABOVE50;
            iobj3.ABOVE50 = ABOVE50;

            iobj1.HIT_TANK = HIT_TANK;
            iobj2.HIT_TANK = HIT_TANK;
            iobj3.HIT_TANK = HIT_TANK;


            Unit_Stat_Setter(uobj);

            Item_Stat_Setter(iobj1);
            Item_Stat_Setter(iobj2);
            Item_Stat_Setter(iobj3);

            Trait_Stat_Setter(tobj1, uobj.TRAIT1);
            Trait_Stat_Setter(tobj2, uobj.TRAIT2);
            Trait_Stat_Setter(tobj3, uobj.TRAIT3);

            Aug_Stat_Setter(aobj1, uobj);
            Aug_Stat_Setter(aobj2, uobj);
            Aug_Stat_Setter(aobj3, uobj);

            Fruit_Stat_Setter(fobj);

            

            Combat_Setter(uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, pobj);

            Combat_Method(pobj);

            // sort item list here
            if (comp_enable)
            {
                Sort_Item_List(uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, pobj);
            }

            // set output data here

            TRAIT1_NAME = uobj.TRAIT1;
            TRAIT2_NAME = uobj.TRAIT2;
            TRAIT3_NAME = uobj.TRAIT3;

            FULL_DPS = pobj.FULL_DPS;
            ATTACK_COUNTER = pobj.ATTACK_COUNTER;
            CAST_COUNTER = pobj.CAST_COUNTER;
            AUTO_DPS = pobj.AUTO_DPS;
            CAST_DPS = pobj.CAST_DPS;
            P_CAST_DPS = pobj.P_CAST_DPS;
            TRUE_DAMAGE_DPS = pobj.TRUE_DAMAGE_DPS;

            FULL_DPS15 = pobj.FULL_DPS15;
            ATTACK_COUNTER15 = pobj.ATTACK_COUNTER15;
            CAST_COUNTER15 = pobj.CAST_COUNTER15;
            AUTO_DPS15 = pobj.AUTO_DPS15;
            CAST_DPS15 = pobj.CAST_DPS15;
            P_CAST_DPS15 = pobj.P_CAST_DPS15;
            TRUE_DAMAGE_DPS15 = pobj.TRUE_DAMAGE_DPS15;

            HP = pobj.HP;
            ARMOR = pobj.ARMOR;
            MR = pobj.MR;
            FINAL_ATKS = pobj.FINAL_ATKS;
            AP = pobj.AP;
            AMP = pobj.AMP;
            CRIT = pobj.CRIT;
            CRIT_MULTI = pobj.CRIT_MULTI;

            AUTO_AD = pobj.AUTO_AD;
            AD = pobj.AD;
            ASI = pobj.ASI;
            MANA_OH = pobj.MANA_OH;
            MANA_REGEN = pobj.MANA_REGEN;
            MANA_MULTI = pobj.MANA_MULT;

            //Sort_Item_List(uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, unit, star, tobj1, tobj2, tobj3,
            //               full_flag,
            //               full_dps, full_dps15,
            //               comp_enable,
            //               outlist, outlist2, outlist3,
            //               hit_tank, above50, targets);



            //return (attack_counter, cast_counter, auto_dps, cast_dps, p_cast_dps, full_dps, true_damage_dps,
            //    attack_counter15, cast_counter15, auto_dps15, cast_dps15, p_cast_dps15, full_dps15, true_damage_dps15,
            //    trait1, trait2, trait3,
            //    hp, auto_ad, ad, ap, atks, asi, amp, crit, crit_multi, armor, mr, mana_oh, mana_regen, mana_multi,
            //    ability_crit, phys_EHP, magic_EHP, final_phys_dr, final_magic_dr, shield
            //    );
        }

        public (int, int, double, double, double, double, double, int, int, double, double, double, double, double,
                double, double, double, double, double, double, double, double, double, double, double,
                double, double, double, double, double, double, double, double
                )
        FightSim(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                 Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3, string star, string unit, 
                 Trait_Holder trait1, Trait_Holder trait2, Trait_Holder trait3, int targets)
        {
            double base_ad = uobj.AD;

            double base_atks = uobj.ATKS;

            double atks = 0;

            double auto_ad = 0;

            double auto_dps = 0;

            double cast_dps = 0;

            double phys_cast_dps = 0;

            double full_dps = 0;

            double auto_dps15 = 0;

            double cast_dps15 = 0;

            double phys_cast_dps15 = 0;

            int attack_counter = 0;

            int cast_counter = 0;

            int attack_counter15 = 0;

            int cast_counter15 = 0;

            double full_dps15 = 0;

            double true_damage_dps = 0;

            double true_damage_dps15 = 0;

            double inc_ad = 0;
            double ap = 0;
            double crit = 0;
            double crit_multi = 0;
            double asi = 0;
            double amp = 0;
            double omnivamp = 0;
            double mana_hit = 0;
            double crit_flag = 0;
            double mana_regen = 0;

            double phys_EHP = 0;
            double magic_EHP = 0;

            double final_hp = 0;

            double armor_dr = 0;

            double mr_dr = 0;

            double final_phys_dr = 0;

            double final_magic_dr = 0;

            double armor = 0;

            double mr = 0;
            double shield = 0;




            


            //disp.AUTO_DPS = auto_dps;
            //disp.CAST_DPS = cast_dps;
            //disp.P_CAST_DPS = phys_cast_dps;
            //disp.TRUE_DAMAGE_DPS = true_damage_dps;
            //disp.FINAL_DPS = full_dps;
            //disp.ATTACK_COUNTER = attack_counter;
            //disp.CAST_COUNTER = cast_counter;

            //disp.AUTO_DPS15 = auto_dps15;
            //disp.CAST_DPS15 = cast_dps15;
            //disp.P_CAST_DPS15 = phys_cast_dps15;
            //disp.FINAL_DPS15 = full_dps15;
            //disp.ATTACK_COUNTER15 = attack_counter15;
            //disp.CAST_COUNTER15 = cast_counter15;
            //disp.TRUE_DAMAGE_DPS15 = true_damage_dps15;


            // stats outputs
            //stats.AD = inc_ad;
            //stats.FINAL_AD = base_ad * (1 + inc_ad);
            //stats.AP = ap;
            //stats.CRIT = crit;
            //stats.CRIT_MULTI = crit_multi;
            //stats.ATKS = asi;
            //stats.D_AMP = amp;
            //stats.OMNIVAMP = omnivamp;
            //stats.MANA_OH = mana_hit;
            //stats.FINAL_ATKS = base_atks * (1 + asi);
            //stats.CRIT_FLAG = crit_flag;
            //stats.MANA_REGEN = mana_regen;
            //stats.HP = final_hp;
            //stats.ARMOR = armor;
            //stats.MR = mr;
            //stats.MANA_REGEN = mana_regen;

            //stats.PHYS_EHP = phys_EHP;
            //stats.MAGIC_EHP = magic_EHP;
            //stats.FINAL_PHYS_DR = final_phys_dr;
            //stats.FINAL_MAGIC_DR = final_magic_dr;






            return (attack_counter, cast_counter, auto_dps, cast_dps, phys_cast_dps, full_dps, true_damage_dps,
                    attack_counter15, cast_counter15, auto_dps15, cast_dps15, phys_cast_dps15, full_dps15, true_damage_dps15,
                    auto_ad, inc_ad, atks, asi, ap, crit, crit_multi, mana_hit, mana_regen, amp, crit_flag,
                    phys_EHP, magic_EHP, final_hp, final_phys_dr, final_magic_dr, armor, mr, shield
                    );

        }

        //private static (double, double, double, double, double, int, int, double, double, double,
        //                double, double, int, int, double, double, double, double, double, double,
        //                double, double, double, double, double)
        public void 
        Combat_Method(Post_Combat_Stats final)
        {
            #region old code
            //double base_atks = uobj.ATKS;
            //double max_mana = uobj.MAX_MANA;
            //double base_ad = uobj.AD;
            //double mana_counter = uobj.MANA_COUNT;

            //double titans_flag = item1.TITANS_FLAG + item2.TITANS_FLAG + item3.TITANS_FLAG;
            //bool ascend_flag = aug1.ASCEND_FLAG || aug2.ASCEND_FLAG || aug3.ASCEND_FLAG;
            ////int targets = traits.TARGETS;
            //double potential = trait1.POTENTIAL + trait2.POTENTIAL + trait3.POTENTIAL;
            //bool m_flag = trait1.M_FLAG | trait2.M_FLAG | trait3.M_FLAG;

            //double asi = item1.ATKS + item2.ATKS + item3.ATKS + aug1.ATKS + aug2.ATKS + aug3.ATKS + trait1.ATKS + trait2.ATKS + trait3.ATKS;
            //double mana_regen = uobj.MANA_REGEN + item1.MANA_REGEN + item2.MANA_REGEN + item3.MANA_REGEN +
            //       aug1.MANA_REGEN + aug2.MANA_REGEN + aug3.MANA_REGEN + trait1.MANA_REGEN + trait2.MANA_REGEN + trait3.MANA_REGEN;

            //double mana_hit = uobj.MANA_OH + item1.MANA_OH + item2.MANA_OH + item3.MANA_OH + trait1.MANA_OH + trait2.MANA_OH + trait3.MANA_OH;

            //double mana_mult = item1.MANA_MULT + item2.MANA_MULT + item3.MANA_MULT;

            //if (mana_mult > 0)
            //{
            //    mana_hit = mana_hit * (1 + (.15 * mana_mult));
            //    mana_regen = mana_regen * (1 + (.15 * mana_mult));
            //}


            //double crit = uobj.CRIT + item1.CRIT + item2.CRIT + item3.CRIT + aug1.CRIT + aug2.CRIT + aug3.CRIT + trait1.CRIT + trait2.CRIT + trait3.CRIT;
            //double over_crit = 0;
            //if (crit > 1)
            //{
            //    over_crit = crit - 1;
            //    crit = 1;
            //}


            //// uobj.CRIT + + aug1.CRIT + aug2.CRIT + aug3.CRIT; item1.CRIT + item2.CRIT + 
            //double ie_flag = item1.IE_FLAG + item2.IE_FLAG + item3.IE_FLAG;

            //double over_cm = over_crit / 2;
            //double ie_cm = 0;
            //double crit_flag2 = aug1.CRIT_FLAG + aug2.CRIT_FLAG + aug3.CRIT_FLAG + trait1.CRIT_FLAG + trait2.CRIT_FLAG + trait3.CRIT_FLAG;

            //if (crit_flag2 > 1)
            //{
            //    ie_cm = ie_flag * .1;
            //}
            //else if (ie_flag > 0)
            //{
            //    ie_cm = (ie_flag - 1) * .1;
            //}


            //double crit_multi = ie_cm + over_cm + uobj.CRIT_MULTI + trait1.CRIT_MULT + trait2.CRIT_MULT + trait3.CRIT_MULT;

            //double crit_flag = ie_flag + crit_flag2; // change this to a bool eventually

            //double amp = item1.D_AMP + item2.D_AMP + item3.D_AMP + aug1.D_AMP + aug2.D_AMP + aug3.D_AMP + trait1.D_AMP + trait2.D_AMP + trait3.D_AMP;
            //double inc_ad = item1.AD + item2.AD + item3.AD + aug1.AD + aug2.AD + aug3.AD + trait1.AD + trait2.AD + trait3.AD;
            //double ap = item1.AP + item2.AP + item3.AP + aug1.AP + aug2.AP + aug3.AP + trait1.AP + trait2.AP + trait3.AP;

            //double rb_flag = item1.RB_FLAG + item2.RB_FLAG + item3.RB_FLAG;
            ////double rb_flag = 0;
            //double kraken_flag = item1.KRAKEN_FLAG + item2.KRAKEN_FLAG + item3.KRAKEN_FLAG;
            //double aa_flag = item1.AA_FLAG + item2.AA_FLAG + item3.AA_FLAG;

            //bool jinx_flag = false;
            ////double trait1 = traits.TRAIT1_VALUE;
            ////double trait2 = traits.TRAIT2_VALUE;
            ////double trait3 = traits.TRAIT3_VALUE;

            //double nashors_flag = item1.NASHORS_FLAG + item2.NASHORS_FLAG + item3.NASHORS_FLAG;
            //double nashors_tracker = 0;
            //bool nashors_e = false;

            //double qss_flag = item1.QSS_FLAG + item2.QSS_FLAG + item3.QSS_FLAG;
            //double gs_flag = item1.GS_FLAG + item2.GS_FLAG + item3.GS_FLAG;

            //bool sf_t = false;
            //bool sf_flag = trait1.SF_FLAG || trait2.SF_FLAG || trait3.SF_FLAG;
            //double sf_t_v = trait1.SF_T_V + trait2.SF_T_V + trait3.SF_T_V;
            //double sf_ad = trait1.SF_AD + trait2.SF_AD + trait3.SF_AD;

            //bool duelist_flag = trait1.DUELIST_FLAG | trait2.DUELIST_FLAG | trait3.DUELIST_FLAG;
            //double duelist_asi = trait1.D_ATKS + trait2.D_ATKS + trait3.D_ATKS;
            //double duelist_cap = trait1.D_CAP + trait1.D_CAP + trait1.D_CAP;
            //double duelist_track = 0;

            //double execute = trait1.EXECUTE + trait2.EXECUTE + trait3.EXECUTE;

            ////if (uobj.TRAIT2 == "Soul Fighter")
            ////{
            ////    sf_flag = traits.TRAIT2_VALUE;
            ////}

            ///*
            //double trait1 = disp.TRAIT1_VALUE;
            //double trait2 = disp.TRAIT2_VALUE;
            //double trait3 = disp.TRAIT3_VALUE;
            //*/

            //double sunder = item1.SUNDER + item2.SUNDER + item3.SUNDER;
            //double shred = item1.SHRED + item2.SHRED + item3.SHRED;
            //double omnivamp = uobj.OMNIVAMP + item1.OMNIVAMP + item2.OMNIVAMP + item3.OMNIVAMP + aug1.OMNIVAMP + aug2.OMNIVAMP + aug3.OMNIVAMP
            //                  + trait1.OMNIVAMP + trait2.OMNIVAMP + trait3.OMNIVAMP;

            //double true_damage = 0;
            //double true_damage_dps = 0;
            //double true_damage_tracker = 0;
            //double true_damage_dps15 = 0;

            ////double mana_counter15 = 0;


            //int ashe_counter = 0;
            //double voli_passive = 0;
            //double voli_atks = 0;

            //double spell_start = 0;

            //double j_track = 0; // track jinx's ability attack speed increase

            //double d_dtrack = 0; // track duelist attack speed increase

            //double atk_time = Attack_Time_calc(base_atks, asi); // in1 is base attack speed



            //double attack_checker = atk_time;

            //double time_s = 0;

            //double time_e = atk_time;

            //int attack_counter = 0;

            //int cast_counter = 0;

            //double cast_time = 0;

            //bool cast_flag = false;

            //int i = 0;

            //int rb_counter = 0;

            //double cast_damage_tracker = 0;

            //double phys_cast_damage_tracker = 0;

            //double auto_damage_tracker = 0;

            //double cast_damage = 0;

            //double p_cast_damage = 0;

            //double auto_damage = 0;

            //bool attack_flag = false;

            //double auto_dps = 0;

            //double cast_dps = 0;

            //double phys_cast_dps = 0;

            //double full_dps = 0;

            //double auto_dps15 = 0;

            //double cast_dps15 = 0;

            //double phys_cast_dps15 = 0;

            //int attack_counter15 = 0;

            //int cast_counter15 = 0;

            //double full_dps15 = 0;

            //double final_inc_ad = 0;

            //double final_atks = 0;

            //double final_ad = 0;

            //int break_counter = 0;

            //double armor_dr = 0;

            //double mr_dr = 0;

            //double tsf = 0;
            //double tef = 0;


            //bool half_flag = false;

            //bool aa_check = false;

            //double voli_tracker = 0;
            #endregion

            switch (final.UNIT_NAME) // resolve unit specific
            {
                case "No_Unit":
                    break;

                case "Jinx":
                    while (final.TIME_S < 30)
                    {

                        //(time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap,
                        //    half_flag, sf_t, nashors_tracker, nashors_e)
                        //    = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                        //                   rb_flag, kraken_flag, aa_flag, duelist_flag, true, break_counter, ap, half_flag, qss_flag, sf_flag, sf_ad, sf_t, nashors_flag, nashors_tracker, nashors_e);
                        Attack_event(final);

                        if (final.ATTACK_FLAG)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }
                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }


                        if (final.CAST_FLAG)
                        {

                            //(time_s, time_e, cast_counter, ap, asi, half_flag, inc_ad, sf_t, nashors_tracker, nashors_e) =
                            //    Base_Cast_event(time_s, time_e, cast_counter, atk_time, aa_flag, ap, rb_flag, asi, base_atks, 1,
                            //                    half_flag, qss_flag, sf_flag, sf_ad, inc_ad, sf_t, nashors_flag, nashors_tracker, nashors_e);
                            //p_cast_damage = Jinx_Spell_Damage_Calc(crit, crit_multi, inc_ad, amp, crit_flag, star);
                            Base_Cast_event(final);
                            Jinx_Spell_Damage_Calc(final);
                            final.PHYS_CAST_DAMAGE_TRACKER += final.P_CAST_DAMAGE;

                            //if (nashors_e && (time_e - nashors_tracker < 5))
                            //{
                            //    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                            //}
                            //else nashors_e = false;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                    }

                    break;

                case "Karma":
                    while (final.TIME_S < 30)
                    {
                        // attack event
                        //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                        //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase
                        Attack_event(final);

                        if (final.ATTACK_FLAG)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG) 
                            {
                                final.AMP += .6; 
                            }

                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            
                            Base_Cast_event(final);
                            Karma_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE;

                            //if (nashors_e && (time_e - nashors_tracker < 5))
                            //{
                            //    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                            //}
                            //else nashors_e = false;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;
                case "Ryze":

                    //base_atks
                    while (final.TIME_S < 30)
                    {

                        Attack_event(final);

                        if (final.ATTACK_FLAG)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            
                            Base_Cast_event(final);
                            Ryze_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE;

                            //if (nashors_e && (time_e - nashors_tracker < 5))
                            //{
                            //    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                            //}
                            //else nashors_e = false;
                        }



                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;
                case "Yuumi":

                    //base_atks
                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Yuumi_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE;
                            final.TRUE_DAMAGE_TRACKER += final.TRUE_DAMAGE;

                            //if (nashors_e && (time_e - nashors_tracker < 5))
                            //{
                            //    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                            //}
                            //else nashors_e = false;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;
                case "Ashe":

                    //base_atks
                    while (final.TIME_S < 30) // implement ashes spell lasting 8 auto attacks
                    {
                        Ashe_Attack_event(final);

                        if (final.ATTACK_FLAG)
                        {

                            // calc auto damage here
                            Auto_Damage_Calc(final);
                            //attack_counter += 1;
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                            //if (nashors_e && (time_e - nashors_tracker < 5))
                            //{
                            //    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                            //}
                            //else nashors_e = false;


                            if (final.CAST_FLAG)
                            {
                                if (final.NASHORS_FLAG > 0 && final.NASHORS_E)
                                {
                                    final.NASHORS_TRACKER = 0;
                                }
                                else if (final.NASHORS_FLAG > 0 && !final.NASHORS_E)
                                {
                                    final.NASHORS_E = true;
                                    final.NASHORS_TRACKER = 0;
                                    final.ASI += (.3 * final.NASHORS_FLAG);
                                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                                }
                                Ashe_Spell_Damage_Calc(final);
                                final.PHYS_CAST_DAMAGE_TRACKER += final.P_CAST_DAMAGE;


                            }
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }


                    }
                    break;
                case "Samira":
                    
                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            if (final.STYLE < 5)
                            {
                                final.CAST_TIME = .5;
                            }
                            else
                            {
                                final.CAST_TIME = 3;
                            }

                            Base_Cast_event(final);
                            Samira_Spell_Damage_Calc(final);

                            if (final.STYLE < 5)
                            {
                                final.STYLE += 1;
                            }
                            else
                            {
                                final.STYLE = 0;
                            }

                            final.PHYS_CAST_DAMAGE_TRACKER += final.P_CAST_DAMAGE;

                            if (final.SF_T)
                            {
                                final.TRUE_DAMAGE_TRACKER += final.SF_T_V * final.P_CAST_DAMAGE;
                            }
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;
                case "Jarvan":
                    break;
                case "Ksante":
                    break;
                case "Leona":
                    break;
                case "Poppy":
                    break;
                case "Sett":
                    break;
                case "Volibear":

                    //base_atks
                    while (final.TIME_S < 30) // implement ashes spell lasting 8 auto attacks
                    {
                        Voli_Attack_event(final);
                        
                        if (final.ATTACK_FLAG)
                        {
                            // calc auto damage here
                            Auto_Damage_Calc(final);
                            //attack_counter += 1;

                            if ((final.ATTACK_COUNTER % 4) == 0)
                            {
                                Voli_Spell_Damage_Calc(final);
                            }

                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE + final.P_CAST_DAMAGE;


                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.TITANS_FLAG > 0)
                            {
                                final.AD += .5 * final.TITANS_FLAG;
                                final.AP += .5 * final.TITANS_FLAG;
                            }
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;
                case "Akali":

                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.TITANS_FLAG > 0)
                            {
                                final.AD += .5 * final.TITANS_FLAG;
                                final.AP += .5 * final.TITANS_FLAG;
                                //armor += 15 * titans_flag;
                                //mr += 15 * titans_flag;
                            }
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Akali_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE * (1 + final.EXECUTE);

                            //if (nashors_e && (time_e - nashors_tracker < 5))
                            //{
                            //    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                            //}
                            //else nashors_e = false;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.TITANS_FLAG > 0)
                            {
                                final.AD += .5 * final.TITANS_FLAG;
                                final.AP += .5 * final.TITANS_FLAG;
                                //armor += 15 * titans_flag;
                                //mr += 15 * titans_flag;
                            }
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;

                case "Katarina":

                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.TITANS_FLAG > 0)
                            {
                                final.AD += .5 * final.TITANS_FLAG;
                                final.AP += .5 * final.TITANS_FLAG;
                                //armor += 15 * titans_flag;
                                //mr += 15 * titans_flag;
                            }
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Kat_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.TITANS_FLAG > 0)
                            {
                                final.AD += .5 * final.TITANS_FLAG;
                                final.AP += .5 * final.TITANS_FLAG;
                                //armor += 15 * titans_flag;
                                //mr += 15 * titans_flag;
                            }
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;

                case "Malzahar":

                    while (final.TIME_S < 30)
                    {
                        // attack event

                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Malzahar_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }



                    }
                    break;
                case "Caitlyn":
                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Caitlyn_Spell_Damage_Calc(final);
                            final.PHYS_CAST_DAMAGE_TRACKER += final.P_CAST_DAMAGE;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                    }
                    break;

                case "Senna":
                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Senna_Spell_Damage_Calc(final);
                            final.PHYS_CAST_DAMAGE_TRACKER += final.P_CAST_DAMAGE;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                    }
                    break;

                case "Lucian":
                    while (final.TIME_S < 30)
                    {
                        Attack_event(final);

                        if (final.ATTACK_FLAG == true)
                        {
                            Auto_Damage_Calc(final);
                            final.AUTO_DAMAGE_TRACKER += final.AUTO_DAMAGE;

                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                        if (final.CAST_FLAG)
                        {
                            Base_Cast_event(final);
                            Lucian_Spell_Damage_Calc(final);
                            final.CAST_DAMAGE_TRACKER += final.CAST_DAMAGE;
                        }

                        if (final.HALF_FLAG)
                        {
                            if (final.ASCEND_FLAG)
                            {
                                final.AMP += .6;
                            }
                            final.AUTO_DPS15 = final.AUTO_DAMAGE_TRACKER / 15;
                            final.P_CAST_DPS15 = final.PHYS_CAST_DAMAGE_TRACKER / 15;
                            final.CAST_DPS15 = final.CAST_DAMAGE_TRACKER / 15;
                            final.ATTACK_COUNTER15 = final.ATTACK_COUNTER;
                            final.CAST_COUNTER15 = final.CAST_COUNTER;
                        }

                    }
                    break;

                default:
                    break;
            }


            double dummy_armor = 100;
            double dummy_mr = 100;

            double dummy_armor_dr = 0;
            double dummy_mr_dr = 0;

            if (final.SUNDER > 0)
            {
                dummy_armor = 70;
            }
            if (final.SHRED > 0)
            {
                dummy_mr = 70;
            }


            dummy_armor_dr = Armor_DR_calc(dummy_armor);

            dummy_mr_dr = Magic_DR_calc(dummy_mr);

            // disp outputs

            final.AUTO_DPS = final.AUTO_DAMAGE_TRACKER / 30;
            final.P_CAST_DPS = final.PHYS_CAST_DAMAGE_TRACKER / 30;
            final.CAST_DPS = final.CAST_DAMAGE_TRACKER / 30;
            final.TRUE_DAMAGE_DPS = final.TRUE_DAMAGE_TRACKER / 30;

            final.AUTO_DPS = final.AUTO_DPS - (final.AUTO_DPS * dummy_armor_dr);
            final.P_CAST_DPS = final.P_CAST_DPS - (final.P_CAST_DPS * dummy_armor_dr);
            final.CAST_DPS = final.CAST_DPS - (final.CAST_DPS * dummy_mr_dr);

            final.AUTO_DPS15 = final.AUTO_DPS15 - (final.AUTO_DPS15 * dummy_armor_dr);
            final.P_CAST_DPS15 = final.P_CAST_DPS15 - (final.P_CAST_DPS15 * dummy_armor_dr);
            final.CAST_DPS15 = final.CAST_DPS15 - (final.CAST_DPS15 * dummy_mr_dr);

            final.FULL_DPS = final.AUTO_DPS + final.P_CAST_DPS + final.CAST_DPS + final.TRUE_DAMAGE_DPS;
            final.FULL_DPS15 = final.AUTO_DPS15 + final.P_CAST_DPS15 + final.CAST_DPS15 + final.TRUE_DAMAGE_DPS15;

            final.FINAL_ATKS = final.BASE_ATKS * (1 + final.ASI);
            final.AUTO_AD = final.BASE_AD* (1 + final.AD);

            //final_ad = ase_ad * (1 + inc_ad);



            //return (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
            //        auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
            //        inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen, amp
            //        );
        }

        // TANK STATS

        private static (double, double, double, double, double, double, double, double)
        EHP_calc(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                 Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3, Trait_Holder trait1,
                 Trait_Holder trait2, Trait_Holder trait3
                 )
        /// inputs to add
        /// stoneplate, bastion first 10 sec, shielded for protectors, above below 50% hp for jugg
        ///


        {

            double base_hp = uobj.HP;
            double hp = item1.HP + item2.HP + item3.HP + aug1.HP + aug2.HP + aug3.HP + trait1.HP + trait2.HP + trait3.HP;
            double hp_mult = item1.HP_MULT + item2.HP_MULT + item3.HP_MULT + aug1.HP_MULT + aug2.HP_MULT + aug3.HP_MULT + trait1.HP_MULT + trait2.HP_MULT + trait3.HP_MULT;
            double armor = uobj.ARMOR + item1.ARMOR + item2.ARMOR + item3.ARMOR + aug1.ARMOR + aug2.ARMOR + aug3.ARMOR + trait1.ARMOR + trait2.ARMOR + trait3.ARMOR;
            double mr = uobj.MR + item1.MR + item2.MR + item3.MR + aug1.MR + aug2.MR + aug3.MR + trait1.MR + trait2.MR + trait3.MR;
            double item1_dr = item1.DR;
            double item2_dr = item2.DR;
            double item3_dr = item3.DR;
            double trait1_dr = trait1.DR;
            double trait2_dr = trait2.DR;
            double trait3_dr = trait3.DR;
            double shield = item1.SHIELD + item2.SHIELD + item3.SHIELD + aug1.SHIELD + aug2.SHIELD + aug3.SHIELD + trait1.SHIELD + trait2.SHIELD + trait3.SHIELD;

            double phys_EHP;
            double magic_EHP;

            double final_hp = HP_calc(base_hp, hp, hp_mult);

            double total_pool = final_hp + shield;

            double armor_dr = Armor_DR_calc(armor);

            double mr_dr = Magic_DR_calc(mr);

            double final_phys_dr = DR_calc(armor_dr, item1_dr, item2_dr, item3_dr, trait1_dr, trait2_dr, trait3_dr);

            double final_magic_dr = DR_calc(mr_dr, item1_dr, item2_dr, item3_dr, trait1_dr, trait2_dr, trait3_dr);

            phys_EHP = total_pool / (1 - final_phys_dr);

            magic_EHP = total_pool / (1 - final_magic_dr);


            return (phys_EHP, magic_EHP, final_hp, final_phys_dr, final_magic_dr, armor, mr, shield);
        }

        private static double Armor_DR_calc(double in1)
        {
            double h = 1;
            double out1;
            double h1 = 100;
            //return in1 + (in1 * in2) + (in1 * in2 * in3) + (in1 * in2 * in3 * in4);
            //return in1 + (in1 * in2) + (in1 * in3) + (in1 * in4);
            out1 = h - (h1 / (h1 + in1));
            //return h1 - h2 - h3 - h4;
            return out1;
        }
        private static double Magic_DR_calc(double in1)
        {
            double h = 1;
            double out1;
            double h1 = 100;
            //return in1 + (in1 * in2) + (in1 * in2 * in3) + (in1 * in2 * in3 * in4);
            //return in1 + (in1 * in2) + (in1 * in3) + (in1 * in4);
            out1 = h - (h1 / (h1 + in1));
            //return h1 - h2 - h3 - h4;
            return out1;
        }

        // in1 = unit base hp, in2 = combine item hp, in3 = combined hp mult
        private static double HP_calc(double in1, double in2, double in3)
        {
            double out1;
            //return in1 + (in1 * in2) + (in1 * in2 * in3) + (in1 * in2 * in3 * in4);
            //return in1 + (in1 * in2) + (in1 * in3) + (in1 * in4);
            out1 = (in1 + in2) * (1 + in3);
            //return h1 - h2 - h3 - h4;
            return out1;
        }

        // dr sources: items 3x, resistance, traits, ability
        // add more when they come up later like fruits
        private static double DR_calc(double in1, double in2, double in3, double in4, double in5, double in6, double in7)
        {
            double h = 1;
            double h1 = 0;
            double h2 = 0;
            double h3 = 0;
            double h4 = 0;
            double h5 = 0;
            double h6 = 0;
            double h7 = 0;
            
            h1 = h - (h * in1);
            h2 = h1 - (h1 * in2);
            h3 = h2 - (h2 * in3);
            h4 = h3 - (h3 * in4);
            h5 = h4 - (h4 * in5);
            h6 = h5 - (h5 * in6);
            h7 = h6 - (h6 * in7);

            return h - h7;
        }


        // ATTACK EVENTS
        private static double Fruit_Timed_effects(double ts, double te, string timed_fruit, double mana_regen)
        {
            // super genius 1.5
            // critical threat 3
            // power font 3
            int counter = 0;
            double tsf = Math.Floor(ts);
            double tef = Math.Floor(te);

            switch (timed_fruit)
            {
                case "Power Font":
                    if ((tsf < 3) && (tef >= 3))
                    {
                        counter += 1;
                    }

                    if ((tsf < 6) && (tef >= 6))
                    {
                        counter += 1;
                    }

                    if ((tsf < 9) && (tef >= 9))
                    {
                        counter += 1;
                    }

                    if ((tsf < 12) && (tef >= 12))
                    {
                        counter += 1;
                    }

                    if ((tsf < 15) && (tef >= 15))
                    {
                        counter += 1;
                    }

                    if ((tsf < 18) && (tef >= 18))
                    {
                        counter += 1;
                    }

                    if ((tsf < 21) && (tef >= 21))
                    {
                        counter += 1;
                    }

                    if ((tsf < 24) && (tef >= 24))
                    {
                        counter += 1;
                    }

                    if ((tsf < 27) && (tef >= 27))
                    {
                        counter += 1;
                    }

                    break;

                case "Critical Threat":
                    break;

                case "Super Genius":
                    break;
                default: break;

                    
            }
            return counter;



        }

        private static void OH_effects()
        {
            /// List of on hit effects
            /// kraken, jinx, duelist
            /// flicker


        }

        //private static (double, double, bool, double, double, double, double, int, int, double, double, int, bool, double, bool, bool, double, bool)
        //Attack_event(double time_s, double time_e, double atk_time, double base_a, double mana_r, double max_mana, double mana_counter,
        //             double mana_oh, double j_track, double asi, int attack_counter, int rb_counter, double ad,
        //             double rb_flag, double kraken_flag, double aa_flag, bool duelist_flag, bool jinx_flag, int break_counter, double ap,
        //             bool half_flag, double qss_flag, bool sf_flag, double sf_ad, bool sf_t,
        //             double nashors_flag, double nashors_tracker, bool nashors_e
        //)
        public void Attack_event(Post_Combat_Stats final)
        {

            double tsf = Math.Floor(final.TIME_S);
            double tef = Math.Floor(final.TIME_E);


            double loop_amount = tef - tsf;


            double j_cap = .6 * (1 + final.AP);

            //bool cast_flag = false;

            //bool attack_flag = false;

            //mana_counter += mana_oh;

            double mana_r2 = final.MANA_REGEN / 2;

            double r_counter = 0;
            bool aa_check = false;
            int qss_check = 0;
            int sf_check = 0;


            // timed events

            // rage blade
            if (final.RB_FLAG > 0)
            {
                for (int i = 0; i < loop_amount; i++)
                {
                    final.ASI += .07 * final.RB_FLAG;
                    //rb_counter += 1;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            // nashors
            if (final.NASHORS_E)
            {
                if ((final.NASHORS_TRACKER + loop_amount) < 5)
                {
                    final.NASHORS_TRACKER += loop_amount;
                }
                else
                {
                    final.NASHORS_E = false;
                    final.ASI -= .3 * final.NASHORS_FLAG;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }


            // qss

            if (final.QSS_FLAG > 0)
            {
                qss_check = QSS_Counter(final.TIME_S, final.TIME_E);
                if (qss_check > 0)
                {
                    final.ASI += .03 * final.QSS_FLAG * qss_check;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            // aa

            if (final.AA_FLAG > 0)
            {
                aa_check = AA_Counter(final.TIME_S, final.TIME_E);
                if (aa_check)
                {
                    final.AP += .3 * final.AA_FLAG;
                }
            }

            // sf 
            if (final.SF_FLAG)
            {
                (sf_check) = SF_Counter(final);
                if (sf_check > 0)
                {
                    final.AD += final.SF_AD * sf_check;
                    final.AP += final.SF_AD * sf_check;
                }
            }

            // half flag @15
            if ((tsf < 15) && (tef >= 15))
            {

                final.HALF_FLAG = true;
            }
            else final.HALF_FLAG = false;



            // on hit effects


            if (final.JINX_FLAG && final.ATTACK_COUNTER <10) // jinx atk speed per auto
            {
                //j_track += .06 * (1 + ap);
                final.ASI += .06 * (1 + final.AP);
                final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
            }

            if (final.KRAKEN_FLAG > 0)
            {
                final.AD += .03 * final.KRAKEN_FLAG;
            }


            // mana events
            r_counter = Mana_Regen_Counter(final.TIME_S, final.TIME_E);

            final.MANA_COUNTER += mana_r2 * r_counter;
            if (final.MANA_COUNTER >= final.MAX_MANA)
            {
                final.CAST_FLAG = true;
                final.MANA_COUNTER = final.MANA_OH;
            }
            else
            {
                final.MANA_COUNTER += final.MANA_OH;
                if (final.MANA_COUNTER >= final.MAX_MANA)
                {
                    final.CAST_FLAG = true;
                    final.MANA_COUNTER -= final.MAX_MANA;
                }
            }

            // recalc for next event

            final.TIME_S = final.TIME_E;
            final.TIME_E = final.TIME_E + final.ATK_TIME;

            final.ATTACK_FLAG = true;


            final.ATTACK_COUNTER += 1;





            //return (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, ad, break_counter, attack_flag, ap,
            //        half_flag, sf_t, nashors_tracker, nashors_e);
        }

        //private static (double, double, bool, double, double, double, int, int, double, double, bool, double, bool, int, bool, int, double, bool)
        //    Ashe_Attack_event(double time_s, double time_e, double atk_time, double base_a, double mana_r, double max_mana, double mana_counter,
        //                      double mana_oh, double asi, int attack_counter, int rb_counter, double ad,
        //                      double rb_flag, double kraken_flag, double aa_flag, double ap,
        //                      bool half_flag, int cast_counter, bool cast_flag, int ashe_counter, bool duelist_flag, double duelist_asi, double qss_flag,
        //                      double nashors_flag, double nashors_tracker, bool nashors_e
        //    )
        private void Ashe_Attack_event(Post_Combat_Stats final)
        {

            double tsf = Math.Floor(final.TIME_S);
            double tef = Math.Floor(final.TIME_E);


            double loop_amount = tef - tsf;



            //mana_counter += mana_oh;

            double mana_r2 = final.MANA_REGEN / 2;

            double r_counter = 0;

            bool aa_check = false;

            int qss_check = 0;



            r_counter = Mana_Regen_Counter(final.TIME_S, final.TIME_E);

            if (final.CAST_FLAG && ((final.ASHE_COUNTER) == 8))
            {
                final.CAST_FLAG = false;
                final.ASHE_COUNTER = 0;

            }





            // timed events

            // rage blade
            if (final.RB_FLAG > 0)
            {
                for (int i = 0; i < loop_amount; i++)
                {
                    final.ASI += .07 * final.RB_FLAG;
                    //rb_counter += 1;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            // nashors
            if (final.NASHORS_E)
            {
                if ((final.NASHORS_TRACKER + loop_amount) < 5)
                {
                    final.NASHORS_TRACKER += loop_amount;
                }
                else
                {
                    final.NASHORS_E = false;
                    final.ASI -= .3 * final.NASHORS_FLAG;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }


            // qss

            if (final.QSS_FLAG > 0)
            {
                qss_check = QSS_Counter(final.TIME_S, final.TIME_E);
                if (qss_check > 0)
                {
                    final.ASI += .03 * final.QSS_FLAG * qss_check;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            // aa

            if (final.AA_FLAG > 0)
            {
                aa_check = AA_Counter(final.TIME_S, final.TIME_E);
                if (aa_check)
                {
                    final.AP += .3 * final.AA_FLAG;
                }
            }

            // half

            if ((tsf < 15) && (tef >= 15))
            {

                final.HALF_FLAG = true;
            }
            else final.HALF_FLAG = false;




            // on hit events

            if (final.KRAKEN_FLAG > 0)
            {
                final.AD += .03 * final.KRAKEN_FLAG;
            }

            if (final.DUELIST_FLAG && (final.ATTACK_COUNTER < 12))
            {
                final.ASI += final.DUELIST_ASI;
                final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
            }


            if (final.CAST_FLAG) // mana lock during spell
            {

                final.ASHE_COUNTER += 1;

            }
            else
            {
                //final.MANA_COUNTER += (mana_r2 * r_counter) + final.MANA_OH;

                final.MANA_COUNTER += mana_r2 * r_counter;
                if (final.MANA_COUNTER >= final.MAX_MANA)
                {
                    final.CAST_FLAG = true;
                    final.MANA_COUNTER = final.MANA_OH;
                    final.CAST_COUNTER += 1;
                }
                else
                {
                    final.MANA_COUNTER += final.MANA_OH;
                    if (final.MANA_COUNTER >= final.MAX_MANA)
                    {
                        final.CAST_FLAG = true;
                        final.MANA_COUNTER -= final.MAX_MANA;
                        final.CAST_COUNTER += 1;
                    }
                }
            }

            //if (final.MANA_COUNTER >= final.MAX_MANA)
            //{
            //    final.CAST_FLAG = true;
            //    final.MANA_COUNTER -= final.MAX_MANA; // OVERFLOW MANA
            //    final.CAST_COUNTER += 1;
            //}






            final.TIME_S = final.TIME_E;
            final.TIME_E = final.TIME_E + final.ATK_TIME;
            final.ATTACK_COUNTER += 1;
            final.ATTACK_FLAG = true;





            //return (time_s, time_e, cast_flag, mana_counter, asi, atk_time, attack_counter, rb_counter, mana_counter, ad, attack_flag, ap,
              //      half_flag, cast_counter, cast_flag, ashe_counter, nashors_tracker, nashors_e);
        }

        //private static (double, double, bool, double, double, double, int, int, double, double, bool, double, bool, int, bool, double, double, double, double)
        //    Voli_Attack_event(double time_s, double time_e, double atk_time, double base_a, double mana_r, double max_mana, double mana_counter,
        //                      double mana_oh, double asi, int attack_counter, int rb_counter, double ad,
        //                      double rb_flag, double kraken_flag, double aa_flag, double ap,
        //                      bool half_flag, int cast_counter, bool cast_flag, double spell_start, double voli_atks, double qss_flag, double voli_tracker,
        //                      double nashors_flag
        //    )
        private void Voli_Attack_event(Post_Combat_Stats final)
        {

            double tsf = Math.Floor(final.TIME_S);
            double tef = Math.Floor(final.TIME_E);


            double loop_amount = tef - tsf;




            bool attack_flag = false;

            //mana_counter += mana_oh;

            double mana_r2 = final.MANA_REGEN / 2;

            double r_counter = 0;

            bool aa_check = false;
            int qss_check = 0;



            r_counter = Mana_Regen_Counter(final.TIME_S, final.TIME_E);

            // timed events

            // rage blade
            if (final.RB_FLAG > 0)
            {
                for (int i = 0; i < loop_amount; i++)
                {
                    final.ASI += .07 * final.RB_FLAG;
                    //rb_counter += 1;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            // nashors
            if (final.NASHORS_E)
            {
                if ((final.NASHORS_TRACKER + loop_amount) < 5)
                {
                    final.NASHORS_TRACKER += loop_amount;
                }
                else
                {
                    final.NASHORS_E = false;
                    final.ASI -= .3 * final.NASHORS_FLAG;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }


            // qss

            if (final.QSS_FLAG > 0)
            {
                qss_check = QSS_Counter(final.TIME_S, final.TIME_E);
                if (qss_check > 0)
                {
                    final.ASI += .03 * final.QSS_FLAG * qss_check;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            // aa

            if (final.AA_FLAG > 0)
            {
                aa_check = AA_Counter(final.TIME_S, final.TIME_E);
                if (aa_check)
                {
                    final.AP += .3 * final.AA_FLAG;
                }
            }

            // half

            if ((tsf < 15) && (tef >= 15))
            {

                final.HALF_FLAG = true;
            }
            else final.HALF_FLAG = false;


            // on hit events

            if (final.KRAKEN_FLAG > 0)
            {
                final.AD += .03 * final.KRAKEN_FLAG;
            }



            if (final.CAST_FLAG) // mana lock
            {
                if ((final.VOLI_TRACKER + loop_amount) < 5)
                {
                    final.VOLI_TRACKER += loop_amount;

                }
                else //5 seconds after spell started (syncs with nashors)
                {
                    final.CAST_FLAG = false;
                    final.ASI -= .99;

                    if (final.NASHORS_FLAG > 0)
                    {
                        final.ASI -= .3 * final.NASHORS_FLAG;
                    }

                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);


                }
            }
            else
            {
                //final.MANA_COUNTER += (mana_r2 * r_counter) + final.MANA_OH;
                final.MANA_COUNTER += mana_r2 * r_counter;
                if (final.MANA_COUNTER >= final.MAX_MANA)
                {
                    final.CAST_FLAG = true;
                    final.MANA_COUNTER = final.MANA_OH;
                    final.CAST_COUNTER += 1;

                    final.ASI += .99;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                    final.VOLI_TRACKER = 0;
                    //spell_start = time_e;

                    if (final.NASHORS_FLAG > 0)
                    {
                        final.ASI += (.3 * final.NASHORS_FLAG);
                        final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                    }
                }
                else
                {
                    final.MANA_COUNTER += final.MANA_OH;
                    if (final.MANA_COUNTER >= final.MAX_MANA)
                    {
                        final.CAST_FLAG = true;
                        final.MANA_COUNTER -= final.MAX_MANA;
                        final.CAST_COUNTER += 1;

                        final.ASI += .99;
                        final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                        final.VOLI_TRACKER = 0;
                        //spell_start = time_e;

                        if (final.NASHORS_FLAG > 0)
                        {
                            final.ASI += (.3 * final.NASHORS_FLAG);
                            final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                        }
                    }
                }
            }

            //if (final.MANA_COUNTER >= final.MAX_MANA)
            //{

            //    final.MANA_COUNTER -= final.MAX_MANA; // OVERFLOW MANA

            //    final.CAST_COUNTER += 1;

            //    final.CAST_FLAG = true;

            //    final.ASI += .99;
            //    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
            //    final.VOLI_TRACKER = 0;
            //    //spell_start = time_e;

            //    if (final.NASHORS_FLAG > 0)
            //    {
            //        final.ASI += (.3 * final.NASHORS_FLAG);
            //        final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
            //    }

            //}
            final.TIME_S = final.TIME_E;
            final.TIME_E = final.TIME_E + final.ATK_TIME;
            final.ATTACK_COUNTER += 1;
            final.ATTACK_FLAG = true;





            //return (time_s, time_e, cast_flag, mana_counter, asi, atk_time, attack_counter, rb_counter, mana_counter, ad, attack_flag, ap,
                    //half_flag, cast_counter, cast_flag, spell_start, voli_atks, voli_tracker, nashors_flag);
        }

        private static double Mana_Regen_Counter(double ts, double te)
        {
            int r_counter = 0;
            //int rb_counter = 0;
            //int aa_counter = 0;
            double tsf = Math.Floor(ts);
            //double tef = Math.Floor(te);

            double m1 = tsf + .5;

            double o1 = tsf + 1;

            double o2 = tsf + 1.5;

            double o3 = tsf + 2;

            double o4 = tsf + 2.5;


            if ((m1 > ts) && (m1 <= te))
            {
                r_counter += 1;
            }

            if ((o1 > ts) && (o1 <= te))
            {
                r_counter += 1;
            }

            if ((o2 > ts) && (o2 <= te))
            {
                r_counter += 1;
            }

            if ((o3 > ts) && (o3 <= te))
            {
                r_counter += 1;
            }

            if ((o4 > ts) && (o4 <= te))
            {
                r_counter += 1;
            }




            return r_counter;


        }

        private static int SF_Counter(Post_Combat_Stats final)
        {
            int sf_counter = 0;
            //int rb_counter = 0;
            //int qss_counter = 0;
            double tsf = Math.Floor(final.TIME_S);
            double tef = Math.Floor(final.TIME_E);



            if ((tsf < 1) && (tef >= 1))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 2) && (tef >= 2))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 3) && (tef >= 3))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 4) && (tef >= 4))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 5) && (tef >= 5))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 6) && (tef >= 6))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 7) && (tef >= 7))
            {
                sf_counter += 1;
                final.SF_T = false;
            }

            if ((tsf < 8) && (tef >= 8))
            {
                sf_counter += 1;
                final.SF_T = true;
            }

            return sf_counter;

        }

        private static int QSS_Counter(double ts, double te)
        {
            int qss_counter = 0;
            double tsf = Math.Floor(ts);
            double tef = Math.Floor(te);



            if ((tsf < 2) && (tef >= 2))
            {
                qss_counter += 1;
            }

            if ((tsf < 4) && (tef >= 4))
            {
                qss_counter += 1;
            }

            if ((tsf < 6) && (tef >= 6))
            {
                qss_counter += 1;
            }

            if ((tsf < 8) && (tef >= 8))
            {
                qss_counter += 1;
            }

            if ((tsf < 10) && (tef >= 10))
            {
                qss_counter += 1;
            }

            if ((tsf < 12) && (tef >= 12))
            {
                qss_counter += 1;
            }

            if ((tsf < 14) && (tef >= 14))
            {
                qss_counter += 1;
            }

            if ((tsf < 16) && (tef >= 16))
            {
                qss_counter += 1;
            }

            if ((tsf < 18) && (tef >= 18))
            {
                qss_counter += 1;
            }
            return qss_counter;


        }
        private static bool AA_Counter(double ts, double te)
        {
            bool aa_counter = false;
            //int rb_counter = 0;
            //int aa_counter = 0;
            double tsf = Math.Floor(ts);
            double tef = Math.Floor(te);



            if ((tsf < 5) && (tef >= 5))
            {
                aa_counter = true;
            }

            if ((tsf < 10) && (tef >= 10))
            {
                aa_counter = true;
            }

            if ((tsf < 15) && (tef >= 15))
            {
                aa_counter = true;
            }

            if ((tsf < 20) && (tef >= 20))
            {
                aa_counter = true;
            }

            if ((tsf < 25) && (tef >= 25))
            {
                aa_counter = true;
            }

            if ((tsf < 30) && (tef >= 30))
            {
                aa_counter = true;
            }




            return aa_counter;


        }

        //private static (double, double, int, double, double, bool, double, bool, double, bool)
        //    Base_Cast_event(double time_s, double time_e, int cast_counter,
        //                    double atk_time, double aa_flag, double ap, double rb_flag, double asi, double base_a, double cast_time,
        //                    bool half_flag, double qss_flag, bool sf_flag, double sf_ad, double ad, bool sf_t,
        //                    double nashors_flag, double nashors_tracker, bool nashors_e
        //                   )
        private void Base_Cast_event(Post_Combat_Stats final)
        {

            //double cast_time = 1;

            double time_s_floor = 0;
            double time_e_floor = 0;

            double loop_amount = 0;
            bool aa_check = false;
            int qss_check = 0;
            int sf_check = 0;

            //time_s = time_s;
            final.TIME_E = final.TIME_S + final.CAST_TIME;


            time_s_floor = Math.Floor(final.TIME_S);

            time_e_floor = Math.Floor(final.TIME_E);

            loop_amount = time_e_floor - time_s_floor;


            // timed events
            // rage blade
            if (final.RB_FLAG > 0)
            {
                for (int i = 0; i < loop_amount; i++)
                {
                    final.ASI += .07 * final.RB_FLAG;
                    //rb_counter += 1;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            if (final.NASHORS_FLAG > 0 && final.NASHORS_E)
            {

                final.NASHORS_TRACKER = final.CAST_TIME;
            }
            else if (final.NASHORS_FLAG > 0 && !final.NASHORS_E)
            {
                final.NASHORS_E = true;
                final.NASHORS_TRACKER = final.CAST_TIME;
                final.ASI += (.3 * final.NASHORS_FLAG);
                final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
            }




            if (final.SF_FLAG)
            {
                sf_check = SF_Counter(final);
                if (sf_check > 0)
                {
                    final.AD += final.SF_AD * sf_check;
                    final.AP += final.SF_AD * sf_check;
                }
            }

            if (final.QSS_FLAG > 0)
            {
                qss_check = QSS_Counter(final.TIME_S, final.TIME_E);
                if (qss_check > 0)
                {
                    final.ASI += .03 * final.QSS_FLAG * qss_check;
                    final.ATK_TIME = Attack_Time_calc(final.BASE_ATKS, final.ASI);
                }
            }

            if (final.AA_FLAG > 0)
            {
                aa_check = AA_Counter(final.BASE_ATKS, final.ASI);
                if (aa_check)
                {
                    final.AP += .3 * final.AA_FLAG;
                }
            }

            if ((time_s_floor < 15) && (time_e_floor >= 15))
            {

                final.HALF_FLAG = true;
            }
            else final.HALF_FLAG = false;

            final.TIME_S = final.TIME_E;
            final.TIME_E = final.TIME_S + final.ATK_TIME;

            final.CAST_COUNTER += 1;
            final.CAST_FLAG = false;

            //return (time_s, time_e, cast_counter, ap, asi, half_flag, ad, sf_t, nashors_tracker, nashors_e);
        }
        private static double Attack_Time_calc(double in1, double in2)
        {
            // in1 base attack speed, in2 increased attack speed
            // output = time for 1 attack in seconds

            double out1;

            if (in1 == 0)
            {
                out1 = 0;
            }
            else out1 = 1 / (in1 * (1 + in2));
            return out1;


        }

        private void Auto_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1 + (final.CRIT * final.CRIT_MULTI);

            final.AUTO_DAMAGE = final.BASE_AD * (1 + final.AD) * final_crit * (1 + final.AMP);

        }

        // SPELL DAMAGE CALCS

        private void Jinx_Spell_Damage_Calc(Post_Combat_Stats final)
        { // passive attack speed and cap handled in attack event
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 520;
                    base_damage2 = 200;
                    break;
                case "2":
                    base_damage = 750;
                    base_damage2 = 300;
                    break;
                case "3":
                    base_damage = 3600;
                    base_damage2 = 900;
                    break;
                default: break;
            }

            final.P_CAST_DAMAGE = (base_damage + base_damage2) * (1 + final.AD) * final_crit * (1 + final.AMP);

        }
        private void Samira_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;
            double ap_base_damage = 0;
            double mode = 1;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            if (final.STYLE < 5)
            {
                ap_base_damage = 0;
                switch (final.STAR)
                {
                    case "1":
                        base_damage = 90;
                        break;
                    case "2":
                        base_damage = 135;
                        break;
                    case "3":
                        base_damage = 650;
                        break;
                    default: break;
                }
            }
            else
            {
                mode = targets + 1;
                switch (final.STAR)
                {
                    case "1":
                        base_damage = 280;
                        ap_base_damage = 50;
                        break;
                    case "2":
                        base_damage = 420;
                        ap_base_damage = 75;
                        break;
                    case "3":
                        base_damage = 2200;
                        ap_base_damage = 225;
                        break;
                    default: break;
                }
            }


            final.P_CAST_DAMAGE = (((base_damage * (1 + final.AD)) + (ap_base_damage * (1 + final.AP))) * final_crit * (1 + final.AMP) * mode);

        }

        private void Yuumi_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;

            double page_counter = 10 + (5 * final.CAST_COUNTER);

            double pot_page_counter = page_counter / 5;

            double final_damage = 0;

            int true_damage_i = 0;

            double true_damage_f = 0;


            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 28;
                    break;
                case "2":
                    base_damage = 42;
                    break;
                case "3":
                    base_damage = 150;
                    break;
                default: break;
            }

            final_damage = base_damage * (1 + final.AP);

            //true_damage_i = 

            //return (final_damage * page_counter * final_crit * (1 + amp), final_damage * pot_page_counter * potential * .32 * final_crit * (1 + amp));
            //return (final_damage * page_counter * final_crit * (1 + final.AMP), final_damage * pot_page_counter * final.POTENTIAL * .32 * final_crit * (1 + final.AMP));
            
            final.CAST_DAMAGE = final_damage * page_counter * final_crit * (1 + final.AMP);
            final.TRUE_DAMAGE = final_damage * pot_page_counter * final.POTENTIAL * .32 * final_crit * (1 + final.AMP);
        }

        private void Ksante_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 1.2;
                    break;
                case "2":
                    base_damage = 1.8;
                    break;
                case "3":
                    base_damage = 8;
                    break;
                default: break;
            }

            final.P_CAST_DAMAGE = (final.ARMOR + final.MR) * base_damage * final_crit * (1 + final.AMP);

        }

        private void Allout_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 350;
                    break;
                case "2":
                    base_damage = 525;
                    break;
                case "3":
                    base_damage = 3000;
                    break;
                default: break;
            }

            final.P_CAST_DAMAGE = base_damage * (1 + final.AD) * final_crit * (1 + final.AMP);

        }

        private void Ashe_Spell_Damage_Calc(Post_Combat_Stats final)
        { // the spell lasts for 8 auto attacks, 0 cast time
            double final_crit = 1;
            double base_damage = 0;
            double ap_base_damage = 0;
            double base_final = 0;
            double ap_base_final = 0;
            double arrows = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 13;
                    ap_base_damage = 1;
                    break;
                case "2":
                    base_damage = 19;
                    ap_base_damage = 2;
                    break;
                case "3":
                    base_damage = 90;
                    ap_base_damage = 10;
                    break;
                default: break;
            }

            base_final = base_damage * (1 + final.AD);
            ap_base_final = ap_base_damage * (1 + final.AP);
            arrows = 8 + Math.Floor(final.ASI * 100 / 34.5);

            final.P_CAST_DAMAGE =  (base_final + ap_base_final) * arrows * final_crit * (1 + final.AMP);

        }

        private void Voli_Spell_Damage_Calc(Post_Combat_Stats final)

        { // omni and asi is built into voli attack event
            double final_crit = 1;

            double base_damage = 0;

            
            final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            

            switch (final.STAR)
            {
                case "1":
                    base_damage = 90;
                    break;
                case "2":
                    base_damage = 135;
                    break;
                case "3":
                    base_damage = 500;
                    break;
                default: break;
            }



            final.P_CAST_DAMAGE = base_damage * final_crit * (1 + final.AMP) * (1 + final.AD);

        }

        private void Ryze_Spell_Damage_Calc(Post_Combat_Stats final)
        { // targets are # of units hit around the target, single target scenario targets = 0
          // maybe make a single target dps output later
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;
            double wave_damage = 0;
            double total_wave_damage = 0;
            double total_base2_damage = 0;
            double total_base_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    if (final.M_FLAG)
                    {
                        base_damage = 750;
                        wave_damage = 50;
                    }
                    base_damage = 720;
                    base_damage2 = 110;
                    break;
                case "2":
                    if (final.M_FLAG)
                    {
                        base_damage = 1125;
                        wave_damage = 75;
                    }
                    base_damage = 1080;
                    base_damage2 = 165;
                    break;
                case "3":
                    if (final.M_FLAG)
                    {
                        wave_damage = 250;
                    }
                    base_damage = 6000;
                    base_damage2 = 550;
                    break;
                default: break;
            }
            if (targets > 0)
            {
                total_wave_damage = wave_damage * 6 ;

                total_base2_damage = base_damage2 * targets;

            }

            total_base_damage = base_damage;

            final.CAST_DAMAGE =  (total_base_damage + total_wave_damage + total_base2_damage) * (1 + final.AP) * final_crit * (1 + final.AMP);

        }

        private void Karma_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;


            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 1125;
                    break;
                case "2":
                    base_damage = 1700;
                    break;
                case "3":
                    base_damage = 6500;
                    break;
                default: break;
            }

            final.CAST_DAMAGE = base_damage * (1 + final.AP) * final_crit * (1 + final.AMP);

        }

        private void Jarvan_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;


            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 100;
                    break;
                case "2":
                    base_damage = 150;
                    break;
                case "3":
                    base_damage = 2000;
                    break;
                default: break;
            }

            final.CAST_DAMAGE = base_damage * (1 + final.AP) * final_crit * (1 + final.AMP);

        }

        private void Akali_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 80;
                    base_damage2 = 70;
                    break;
                case "2":
                    base_damage = 120;
                    base_damage2 = 105;
                    break;
                case "3":
                    base_damage = 1000;
                    base_damage2 = 1000;
                    break;
                default: break;
            }

            final.CAST_DAMAGE = (base_damage2 * targets * (1 + final.AP) * final_crit * (1 + final.AMP)) + (base_damage * (1 + final.AP) * final_crit * (1 + final.AMP)) * final.CAST_COUNTER;

        }

        private void Poppy_Spell_Damage_Calc(Post_Combat_Stats final)
        { // targets are # of units hit around the target, single target scenario targets = 0
          // maybe make a single target dps output later
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;

            double primary = 0;
            double secondary = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 200;
                    base_damage2 = 60;
                    break;
                case "2":
                    base_damage = 300;
                    base_damage2 = 90;
                    break;
                case "3":
                    base_damage = 2000;
                    base_damage2 = 600;
                    break;
                default: break;
            }

            primary = ((base_damage * (1 + final.AD)) + (final.HP * .1));
            secondary = (((base_damage2 * (1 + final.AD)) + (final.HP * .05)) * targets);



            final.P_CAST_DAMAGE = (primary + secondary) * final_crit * (1 + final.AMP);

        }

        private void Sett_Spell_Damage_Calc(Post_Combat_Stats final)
        { // targets are # of units hit around the target, single target scenario targets = 0
          // maybe make a single target dps output later
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;
            double base_damage3 = 0;

            double primary = 0;
            double secondary = 0;
            double tertiary = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 140;
                    base_damage2 = 120;
                    base_damage3 = 10;
                    break;
                case "2":
                    base_damage = 210;
                    base_damage2 = 180;
                    base_damage3 = 15;
                    break;
                case "3":
                    base_damage = 2000;
                    base_damage2 = 750;
                    base_damage3 = 50;
                    break;
                default: break;
            }

            primary = base_damage * (1 + final.AD);
            secondary = (((base_damage2 * (1 + final.AD)) + (final.HP * .04) + (base_damage3)) + (base_damage3 + (15 * final.HEALING / 100)));
            tertiary = (((base_damage2 * (1 + final.AD)) + (final.HP * .04)) * targets);

            final.P_CAST_DAMAGE = (primary + secondary + tertiary) * final_crit * (1 + final.AMP);

        }

        private void Leona_Spell_Damage_Calc(Post_Combat_Stats final)
        { // targets are # of units hit around the target, single target scenario targets = 0
          // maybe make a single target dps output later
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;

            double primary = 0;
            double secondary = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = (final.ARMOR + final.MR) * .50;
                    base_damage2 = (final.ARMOR + final.MR) * .25;
                    break;
                case "2":
                    base_damage = (final.ARMOR + final.MR) * .75;
                    base_damage2 = (final.ARMOR + final.MR) * .40;
                    break;
                case "3":
                    base_damage = (final.ARMOR + final.MR) * 500;
                    base_damage2 = (final.ARMOR + final.MR) * 200;
                    break;
                default: break;
            }

            final.CAST_DAMAGE = (base_damage + base_damage2) * final_crit * (1 + final.AMP);

        }

        private void Kat_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;
            double final_damage = 0;
            double pot_damage = .13 * final.POTENTIAL;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 140;
                    break;
                case "2":
                    base_damage = 210;
                    break;
                case "3":
                    base_damage = 325;
                    break;
                default: break;
            }

            base_damage2 = pot_damage * base_damage;
            final_damage = base_damage + base_damage2;

            //true_damage_i = 

            //return (final_damage * page_counter * final_crit * (1 + amp), final_damage * pot_page_counter * potential * .32 * final_crit * (1 + amp));
            final.CAST_DAMAGE = final_damage * (1 + final.AP) * final_crit * (1 + final.AMP) * (targets + 1);

        }

        private void Malzahar_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 545;
                    break;
                case "2":
                    base_damage = 820;
                    break;
                case "3":
                    base_damage = 1390;
                    break;
                default: break;
            }

            final.CAST_DAMAGE = base_damage * (1 + final.AP) * final_crit * (1 + final.AMP);

        }

        private void Caitlyn_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;
            double ap_damage = 0;
            double final_damage = 0;
            double pot_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 350;
                    ap_damage = 30;
                    pot_damage = 95;
                    break;
                case "2":
                    base_damage = 525;
                    ap_damage = 45;
                    pot_damage = 145;
                    break;
                case "3":
                    base_damage = 840;
                    ap_damage = 70;
                    pot_damage = 240;
                    break;
                default: break;
            }

            final_damage = (base_damage * (1 + final.AD)) + (ap_damage * (1 + final.AP)) + (pot_damage * final.POTENTIAL * (1 + final.AD));

            final.P_CAST_DAMAGE = final_damage * final_crit * (1 + final.AMP);

        }

        private void Senna_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;
            double base_damage2 = 0;
            double ap_damage = 0;
            double final_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 385;
                    ap_damage = 35;
                    break;
                case "2":
                    base_damage = 525;
                    ap_damage = 55;
                    break;
                case "3":
                    base_damage = 870;
                    ap_damage = 85;
                    break;
                default: break;
            }

            final_damage = (base_damage * (1 + final.AD)) + (ap_damage * (1 + final.AP));
            base_damage2 = final_damage * .22 * targets;

            final.P_CAST_DAMAGE = (final_damage + base_damage2) * final_crit * (1 + final.AMP);

        }

        private void Lucian_Spell_Damage_Calc(Post_Combat_Stats final)
        {
            double final_crit = 1;
            double base_damage = 0;

            if (final.CRIT_FLAG)
            {
                final_crit = 1 + (final.CRIT * final.CRIT_MULTI);
            }

            switch (final.STAR)
            {
                case "1":
                    base_damage = 85;
                    break;
                case "2":
                    base_damage = 130;
                    break;
                case "3":
                    base_damage = 200;
                    break;
                default: break;
            }

            final.CAST_DAMAGE = base_damage * 4 * (1 + final.AP) * final_crit * (1 + final.AMP);

        }

        private static (double, double, double, double, double, double, double, double)

        // trait related
        Starguardian(double sg_count, int rell, int syndra, int xayah, int ahri, int neeko, int jinx, int poppy, int seraphine)
        {
            double scalar = 1 + (sg_count * .1); // change .1 to actual multiplier

            double shield = rell * 200 * scalar;

            double ap = syndra * 100 * scalar;

            double on_hit = xayah * 10 * scalar;

            double mana_gain = ahri * 10 * scalar;

            double sh_power = neeko * 10 * scalar;

            double atks = jinx * 10 * scalar;

            double stats = seraphine * 10 * scalar;

            double emblem = 0;



            return (shield, ap, on_hit, mana_gain, sh_power, atks, stats, emblem);
        }

        // COMPARE METHODS

        //public void
        //Sort_Item_List(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
        //                Aug_Holder Aug1_Slot, Aug_Holder Aug2_Slot, Aug_Holder Aug3_Slot,
        //                string unit, string star, Trait_Holder trait1, Trait_Holder trait2, Trait_Holder trait3,
        //                bool full, double outside_full_dps, double outside_full_dps15,
        //                bool enable, bool hit_tank, bool above50, int targets
        //)
        public void Sort_Item_List(Unit_Holder uobj, Item_Holder iobj1, Item_Holder iobj2, Item_Holder iobj3, Aug_Holder aobj1, Aug_Holder aobj2, Aug_Holder aobj3,
                       Trait_Holder tobj1, Trait_Holder tobj2, Trait_Holder tobj3, Fruit_Holder fobj, Post_Combat_Stats final)
        {
            #region item dps objects
            Item_DPS_Obj None_o = new(); None_o.ITEM_NAME = "None           ";
            Item_DPS_Obj Deathblade_o = new(); Deathblade_o.ITEM_NAME = "Deathblade     ";
            Item_DPS_Obj Giantslayer_o = new(); Giantslayer_o.ITEM_NAME = "Giantslayer    ";
            Item_DPS_Obj Gunblade_o = new(); Gunblade_o.ITEM_NAME = "Gunblade       ";
            Item_DPS_Obj Shojin_o = new(); Shojin_o.ITEM_NAME = "Shojin         ";
            Item_DPS_Obj EdgeOfNight_o = new(); EdgeOfNight_o.ITEM_NAME = "EdgeOfNight    ";
            Item_DPS_Obj BloodThirster_o = new(); BloodThirster_o.ITEM_NAME = "BloodThirster  ";
            Item_DPS_Obj Steraks_o = new(); Steraks_o.ITEM_NAME = "Steraks        ";
            Item_DPS_Obj InfinityEdge_o = new(); InfinityEdge_o.ITEM_NAME = "InfinityEdge   ";
            Item_DPS_Obj Redbuff_o = new(); Redbuff_o.ITEM_NAME = "Redbuff        ";
            Item_DPS_Obj Rageblade_o = new(); Rageblade_o.ITEM_NAME = "Rageblade      ";
            Item_DPS_Obj VoidStaff_o = new(); VoidStaff_o.ITEM_NAME = "VoidStaff       ";
            Item_DPS_Obj Titans_o = new(); Titans_o.ITEM_NAME = "Titans         ";
            Item_DPS_Obj Kraken_o = new(); Kraken_o.ITEM_NAME = "Kraken         ";
            Item_DPS_Obj Nashor_o = new(); Nashor_o.ITEM_NAME = "Nashor         ";
            Item_DPS_Obj LastWhisper_o = new(); LastWhisper_o.ITEM_NAME = "LastWhisper    ";
            Item_DPS_Obj DeathCap_o = new(); DeathCap_o.ITEM_NAME = "DeathCap       ";
            Item_DPS_Obj Archangels_o = new(); Archangels_o.ITEM_NAME = "Archangels     ";
            Item_DPS_Obj Morello_o = new(); Morello_o.ITEM_NAME = "Morello        ";
            Item_DPS_Obj JeweledGauntlet_o = new(); JeweledGauntlet_o.ITEM_NAME = "JeweledGauntlet";
            Item_DPS_Obj HandOfJustice_o = new(); HandOfJustice_o.ITEM_NAME = "HandOfJustice  ";
            Item_DPS_Obj BlueBuff_o = new(); BlueBuff_o.ITEM_NAME = "BlueBuff       ";
            Item_DPS_Obj QuickSilver_o = new(); QuickSilver_o.ITEM_NAME = "QuickSilver    ";
            Item_DPS_Obj StrikersFlail_o = new(); StrikersFlail_o.ITEM_NAME = "StrikersFlail  ";
            Item_DPS_Obj Warmogs_o = new(); Warmogs_o.ITEM_NAME = "Warmogs        ";
            Item_DPS_Obj Sunfire_o = new(); Sunfire_o.ITEM_NAME = "Sunfire        ";
            Item_DPS_Obj SpiritVisage_o = new(); SpiritVisage_o.ITEM_NAME = "SpiritVisage   ";
            Item_DPS_Obj EvenShroud_o = new(); EvenShroud_o.ITEM_NAME = "EvenShroud     ";
            Item_DPS_Obj Spark_o = new(); Spark_o.ITEM_NAME = "Spark          ";
            Item_DPS_Obj AdaptiveFront_o = new(); AdaptiveFront_o.ITEM_NAME = "AdaptiveFront  ";
            Item_DPS_Obj Stoneplate_o = new(); Stoneplate_o.ITEM_NAME = "Stoneplate     ";
            Item_DPS_Obj DragonClaw_o = new(); DragonClaw_o.ITEM_NAME = "DragonClaw     ";
            Item_DPS_Obj Bramble_o = new(); Bramble_o.ITEM_NAME = "Bramble        ";
            Item_DPS_Obj ProtectorsVow_o = new(); ProtectorsVow_o.ITEM_NAME = "ProtectorsVow  ";
            Item_DPS_Obj Crownguard_o = new(); Crownguard_o.ITEM_NAME = "Crownguard     ";
            Item_DPS_Obj SteadfastHeart_o = new(); SteadfastHeart_o.ITEM_NAME = "SteadfastHeart ";
            Item_DPS_Obj AdaptiveBack_o = new(); AdaptiveBack_o.ITEM_NAME = "AdaptiveBack   ";
            #endregion

            

            List<Item_Holder> list_int = Create_Item_List();

            for (int i = 0; i < 37; i++)
            {
                Item_Stat_Setter(list_int[i]);
            }

            List<Item_DPS_Obj> item_list = new()
            {
                None_o,
                Deathblade_o,
                Giantslayer_o,
                Gunblade_o,
                Shojin_o,
                EdgeOfNight_o,
                BloodThirster_o,
                Steraks_o,
                InfinityEdge_o,
                Redbuff_o,
                Rageblade_o,
                VoidStaff_o,
                Titans_o,
                Kraken_o,
                Nashor_o,
                LastWhisper_o,
                DeathCap_o,
                Archangels_o,
                Morello_o,
                JeweledGauntlet_o,
                HandOfJustice_o,
                BlueBuff_o,
                QuickSilver_o,
                StrikersFlail_o,
                Warmogs_o,
                Sunfire_o,
                SpiritVisage_o,
                EvenShroud_o,
                Spark_o,
                AdaptiveFront_o,
                Stoneplate_o,
                DragonClaw_o,
                Bramble_o,
                ProtectorsVow_o,
                Crownguard_o,
                SteadfastHeart_o,
                AdaptiveBack_o
            };

            List<Item_DPS_Obj> DPS_list = new();
            List<Item_DPS_Obj> DPS_list2 = new();
            List<Item_DPS_Obj> DPS_list3 = new();

            //List<string> out_list = new() 
            //{
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-"
            //};
            //List<string> out_list2 = new() 
            //{
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-"
            //    };
            //List<string> out_list3 = new() 
            //{
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",  "-",
            //        "-",  "-",  "-",  "-",  "-",  "-",  "-"
            //    };
            
            if (comp_enable)
            {
                DPS_list = Item_DPS_Compare_Calc(1, list_int, item_list, uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, final);
                Combine_List(DPS_list, out_list);

                DPS_list2 = Item_DPS_Compare_Calc(2, list_int, item_list, uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, final);
                Combine_List(DPS_list2, out_list2);

                DPS_list3 = Item_DPS_Compare_Calc(3, list_int, item_list, uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, final);
                Combine_List(DPS_list3, out_list3);


                //DPS_list = Item_DPS_Compare_Calc(uobj, item1, item2, item3, Aug1_Slot, Aug2_Slot, Aug3_Slot, unit, star, 1, full, outside_full_dps, outside_full_dps15, trait1, trait2, trait3, item_list, list_int, targets);

                //Combine_List(DPS_list, out_list);

                //DPS_list2 = Item_DPS_Compare_Calc(uobj, item1, item2, item3, Aug1_Slot, Aug2_Slot, Aug3_Slot, unit, star, 2, full, outside_full_dps, outside_full_dps15, trait1, trait2, trait3, item_list, list_int, targets);

                //Combine_List(DPS_list2, out_list2);

                //DPS_list3 = Item_DPS_Compare_Calc(uobj, item1, item2, item3, Aug1_Slot, Aug2_Slot, Aug3_Slot, unit, star, 3, full, outside_full_dps, outside_full_dps15, trait1, trait2, trait3, item_list, list_int, targets);

                //Combine_List(DPS_list3, out_list3);

            }
            else
            {
                for (int i = 0; i < 37; i++)
                {
                    out_list[i] = "-";
                    out_list2[i] = "-";
                    out_list3[i] = "-";
                }

            }

            //return item_list;
            //return (out_list, out_list2, out_list3);
        }

        public List<Item_DPS_Obj> 
            Item_DPS_Compare_Calc(int slot, List<Item_Holder> list_int, List<Item_DPS_Obj>item_list,
                                  Unit_Holder uobj, Item_Holder iobj1, Item_Holder iobj2, Item_Holder iobj3, Aug_Holder aobj1, 
                                  Aug_Holder aobj2, Aug_Holder aobj3, Trait_Holder tobj1, Trait_Holder tobj2, Trait_Holder tobj3, 
                                  Fruit_Holder fobj, Post_Combat_Stats final)
        //Item_DPS_Compare_Calc(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
        //                Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3,
        //                string unit, string star, int slot, bool full, double outside_full_dps, double outside_full_dps15,
        //                Trait_Holder trait1, Trait_Holder trait2, Trait_Holder trait3, List<Item_DPS_Obj> item_list, List<Item_Holder> list_int, int targets
        //)
        {
           


            /*
            double auto_dps = 0;
            double cast_dps = 0;
            double p_cast_dps = 0;
            double final_dps = 0;
            double attack_counter = 0;
            double cast_counter = 0;
            double break_counter = 0;
            double ad = 0;
            double atks = 0;
            double final_atks = 0;
            double d_amp = 0;
            double crit = 0;
            double final_ad = 0;
            double crit_flag = 0;
            double ap = 0;
            */

            //Post_Combat_Stats slot1 = new();
            //Post_Combat_Stats slot2 = new();
            //Post_Combat_Stats slot3 = new();


            

            

            //(DPS_Display1.AUTO_DPS, DPS_Display1.CAST_DPS, DPS_Display1.FINAL_DPS, DPS_Display1.ATTACK_COUNTER, DPS_Display1.CAST_COUNTER, DPS_Display1.BREAK_COUNTER,
            //  DPS_Display1.AD, DPS_Display1.ATKS, DPS_Display1.FINAL_ATKS, DPS_Display1.D_AMP, DPS_Display1.CRIT, DPS_Display1.FINAL_AD, DPS_Display1.CRIT_FLAG
            // , DPS_Display1.AP, DPS_Display1.P_CAST_DPS
            //  ) =

            //CopyProperties(item_list2[34],Item_Blank);

            //Combat_Setter(uobj, empty, iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, slot1);

            //Combat_Setter(uobj, iobj1, empty, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, slot2);

            //Combat_Setter(uobj, iobj1, iobj2, empty, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, slot3);
            switch (slot)
            {

                case 1:
                    /*
                    (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                            auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                            inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap,
                            crit_flag) =
                            Combat_Method(uobj, item1, item2, item3, aug1, aug2, aug3, star, unit);
                    //list_int[0]
                    item_list[0].ITEM_DPS = item2.AD;
                    */

                    for (int i = 0; i < 37; i++)
                    {
                        //(auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                        //auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                        //inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen, amp) =
                        //Combat_Method(uobj, list_int[i], item2, item3, aug1, aug2, aug3, star, unit, trait1, trait2, trait3, targets);
                        Post_Combat_Stats slot1 = new();
                        Combat_Setter(uobj, list_int[i], iobj2, iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, slot1);
                        Combat_Method(slot1);

                        if (full_flag)
                        {
                            item_list[i].ITEM_DPS = Resolve_DPS_Change(final.FULL_DPS, slot1.FULL_DPS);
                        }
                        else
                        {
                            item_list[i].ITEM_DPS = Resolve_DPS_Change(final.FULL_DPS15, slot1.FULL_DPS15);
                        }


                    }

                    break;


                case 2:
                    for (int i = 0; i < 37; i++)
                    {
                        Post_Combat_Stats slot2 = new();
                        Combat_Setter(uobj, iobj1, list_int[i], iobj3, aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, slot2);
                        Combat_Method(slot2);

                        if (full_flag)
                        {
                            item_list[i].ITEM_DPS = Resolve_DPS_Change(final.FULL_DPS, slot2.FULL_DPS);
                        }
                        else
                        {
                            item_list[i].ITEM_DPS = Resolve_DPS_Change(final.FULL_DPS15, slot2.FULL_DPS15);
                        }


                    }

                    break;
                case 3:
                    for (int i = 0; i < 37; i++)
                    {
                        Post_Combat_Stats slot3 = new();
                        Combat_Setter(uobj, iobj1, iobj2, list_int[i], aobj1, aobj2, aobj3, tobj1, tobj2, tobj3, fobj, slot3);
                        Combat_Method(slot3);

                        if (full_flag)
                        {
                            item_list[i].ITEM_DPS = Resolve_DPS_Change(final.FULL_DPS, slot3.FULL_DPS);
                        }
                        else
                        {
                            item_list[i].ITEM_DPS = Resolve_DPS_Change(final.FULL_DPS15, slot3.FULL_DPS15);
                        }


                    }
                    break;





                default: break;
            }

            item_list = item_list.OrderBy(o => o.ITEM_DPS).ToList();

            item_list.Reverse();

            return item_list;
        }

        private static double Resolve_DPS_Change(double real_value, double comp_value)
        {
            double diff = 0;

            if (real_value == 0)
            {
                diff = 99;
            }
            else
            {
                if (comp_value > real_value)
                {
                    diff = ((comp_value - real_value) / real_value) * 100;
                    //out1 = " +" + diff.ToString() + "%";

                    //diff = 3;
                }
                else if (comp_value < real_value)
                {
                    diff = ((comp_value - real_value) / real_value) * 100;
                    //out1 = " " + diff.ToString() + "%";
                }
                else
                {
                    //out1 = " no change";
                    diff = 0;
                }

            }

            return diff;
        }

        private static void Combine_List(List<Item_DPS_Obj> list1, ObservableCollection<string> out_list)
        {

            //List<string> out_list = new()
            //{
            //    "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
            //    "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
            //    "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
            //    "0",  "0",  "0",  "0",  "0",  "0",  "0"
            //};
            for (int i = 0; i < 37; i++)
            {
                if (list1[i].ITEM_DPS > 0)
                {
                    out_list[i] = list1[i].ITEM_NAME + " +" + Math.Round(list1[i].ITEM_DPS, 2).ToString() + "%";
                }
                else
                {
                    out_list[i] = list1[i].ITEM_NAME + " " + Math.Round(list1[i].ITEM_DPS, 2).ToString() + "%";
                }

            }

            //list1[0] = list1[0] + "test";

            //return out_list;
        }

        private static void Aug_Stat_Setter(Aug_Holder aobj, Unit_Holder uobj)
        {
            switch (aobj.AUG_NAME)
            {
                case "None":
                    break;

                case "PairOfFours":
                    if (uobj.COST == 4)
                    {
                        aobj.HP = 374;
                        aobj.ATKS = .24;
                    }
                    
                    break;
                case "BestFriends2":
                    aobj.ARMOR = 20;
                    aobj.ATKS = .15;
                    break;
                case "LittleBuddies":
                    if (uobj.COST == 4 || uobj.COST == 5)
                    {
                        aobj.HP = aobj.LILB * 55;
                        aobj.ATKS = aobj.LILB * .06;
                    }
                    
                    break;
                case "MacesWill":
                    aobj.CRIT = .2;
                    aobj.ATKS = .06;
                    break;
                case "Preparation2":
                    aobj.AD = .12;
                    aobj.AP = .12;
                    aobj.HP = 180;
                    break;
                case "ScoreboardScrapper":
                    // assumes 14 rounds activated
                    aobj.AD = .28;
                    aobj.AP = .28;
                    aobj.HP_MULT = .1;

                    break;
                case "BackUpDancers":
                    aobj.ATKS = .105;
                    break;
                case "BlazingSoul2":
                    aobj.ATKS = .2;
                    aobj.AP = .2;
                    break;
                case "GlassCannon2":
                    aobj.D_AMP = .2;
                    break;
                case "CyberImplants2":
                    aobj.HP = 120;
                    aobj.AD = .2;
                    break;
                case "CyberUplink2":
                    aobj.HP = 120;
                    aobj.MANA_REGEN = 2;
                    break;
                case "ItemCollector2":
                    aobj.HP = 20 + (aobj.ITEM_N * 5);
                    aobj.AD = aobj.ITEM_N * .01;
                    aobj.AP = aobj.ITEM_N * .01;

                    break;
                case "KnowYourEnemy":
                    // simplified to 15% for now
                    aobj.MORE_MULT = .15;
                    break;
                case "PumpingUp2":
                    // simplified to 30% attack speed for now
                    aobj.ATKS = .3;
                    break;
                case "SpearsWill":
                    aobj.AD = .1;
                    break;
                case "WaterLotus":
                    aobj.CRIT_FLAG = 1;
                    aobj.WATER_LOTUS = true;
                    break;
                case "Ascension":
                    aobj.ASCEND_FLAG = true;
                    break;
                default: break;
            }
        }

        private static void Item_Stat_Setter(Item_Holder iobj)
        {
            switch (iobj.ITEM_NAME)
            {
                case "None":
                    break;
                case "Deathblade":
                    iobj.AD = .55;
                    iobj.D_AMP = .1;
                    break;
                case "Giantslayer":
                    iobj.AP = .2;
                    iobj.AD = .2;
                    iobj.ATKS = .2;
                    if (iobj.HIT_TANK)
                    {
                        iobj.D_AMP = .25;
                    }
                    else iobj.D_AMP = .1;

                    iobj.GS_FLAG = 1;
                    break;
                case "Gunblade":
                    iobj.MANA_REGEN = 1;
                    iobj.AP = .2;
                    iobj.AD = .2;
                    iobj.OMNIVAMP = .18;
                    break;
                case "Shojin":
                    iobj.MANA_REGEN = 1;
                    iobj.AP = .15;
                    iobj.AD = .15;
                    iobj.MANA_OH = 5;
                    break;
                case "EdgeOfNight":
                    iobj.AP = .1;
                    iobj.AD = .1;
                    iobj.ATKS = .15;
                    break;
                case "BloodThirster":
                    iobj.ARMOR = 20;
                    iobj.MR = 20;
                    iobj.DR = 0;
                    iobj.SHIELD = .25;
                    iobj.AP = .15;
                    iobj.AD = .15;
                    iobj.OMNIVAMP = .2;
                    break;
                case "Steraks":
                    iobj.HP = 300;
                    iobj.SHIELD = .5;
                    iobj.AD = .4;
                    break;
                case "InfinityEdge":
                    iobj.AD = .35;
                    iobj.CRIT = .35;
                    iobj.IE_FLAG = 1;
                    break;
                case "Redbuff":
                    iobj.ATKS = .4;
                    iobj.D_AMP = .06;
                    iobj.ANTIHEAL = 1;
                    break;
                case "Rageblade":
                    iobj.AP = .1;
                    iobj.ATKS = .1;
                    iobj.RB_FLAG = 1;
                    break;
                case "VoidStaff":
                    iobj.AP = .35;
                    iobj.MANA_REGEN = 1;
                    iobj.ATKS = .15;
                    iobj.SHRED = 1;
                    break;
                case "Titans":
                    iobj.TITANS_FLAG = 1;
                    iobj.ATKS = .1;
                    // set max stack for armor mr only
                    // ad ap updates in combat method
                    iobj.ARMOR = 35;
                    iobj.ARMOR = 15;
                    //if (titans_max && )
                    //{
                    //    iobj.AD = .5;
                    //    iobj.AP = .5;
                    //    iobj.ARMOR = 35;
                    //    iobj.MR = 15;
                    //}
                    //else
                    //{
                    //    iobj.ARMOR = 20;
                    //}

                    break;
                case "Kraken":
                    iobj.MR = 20;
                    iobj.AD = .15;
                    iobj.ATKS = .1;
                    iobj.KRAKEN_FLAG = 1;
                    break;
                case "Nashor":
                    iobj.HP = 150;
                    iobj.MANA_REGEN = 2;
                    iobj.AP = .2;
                    iobj.ATKS = .1;
                    iobj.NASHORS_FLAG = 1;
                    break;
                case "LastWhisper":
                    iobj.AD = .15;
                    iobj.CRIT = .2;
                    iobj.ATKS = .2;
                    iobj.SUNDER = 1;
                    break;
                case "Deathcap":
                    iobj.AP = .5;
                    iobj.D_AMP = .15;
                    break;
                case "Archangels":
                    iobj.MANA_REGEN = 1;
                    iobj.AP = .2;
                    iobj.AA_FLAG = 1;
                    break;
                case "Morello":
                    iobj.HP = 150;
                    iobj.MANA_REGEN = 1;
                    iobj.AP = .2;
                    iobj.ANTIHEAL = 1;
                    break;
                case "JeweledGauntlet":
                    iobj.AP = .35;
                    iobj.CRIT = .35;
                    iobj.IE_FLAG = 1;
                    break;
                case "HandOfJustice":
                    iobj.MANA_REGEN = 1;
                    iobj.CRIT = .2;

                    if (iobj.ABOVE50)
                    {
                        iobj.AP = .3;
                        iobj.AD = .3;
                        iobj.OMNIVAMP = .12;
                    }
                    else
                    {
                        iobj.AP = .15;
                        iobj.AD = .15;
                        iobj.OMNIVAMP = .24;
                    }
                    break;
                case "BlueBuff":
                    iobj.MANA_REGEN = 5;
                    iobj.AP = .15;
                    iobj.AD = .15;
                    break;
                case "QuickSilver":
                    iobj.MR = 20;
                    iobj.CRIT = .2;
                    iobj.ATKS = .3;
                    iobj.QSS_FLAG = 1;
                    break;
                case "StrikersFlail":
                    iobj.HP = 150;
                    iobj.CRIT = .2;
                    iobj.ATKS = .2;
                    iobj.D_AMP = .3;
                    break;
                case "Warmogs":
                    iobj.HP = 600;
                    iobj.HP_MULT = .12;
                    break;
                case "Sunfire":
                    iobj.HP = 150;
                    iobj.ARMOR = 20;
                    iobj.ANTIHEAL = 1;
                    break;
                case "SpiritVisage":
                    iobj.HP = 300;
                    iobj.DR = .1;
                    iobj.MANA_REGEN = 1;
                    break;
                case "EvenShroud":
                    iobj.HP = 150;
                    iobj.ARMOR = 20;
                    iobj.MR = 40;
                    iobj.SUNDER = 1;
                    break;
                case "Spark":
                    iobj.HP = 150;
                    iobj.MR = 25;
                    iobj.AP = .15;
                    iobj.SHRED = 1;
                    break;
                case "AdaptiveFront":
                    iobj.ARMOR = 35;
                    iobj.MR = 55;
                    iobj.MANA_REGEN = 2;
                    break;
                case "AdaptiveBack":
                    iobj.MR = 20;
                    iobj.MANA_REGEN = 2;
                    iobj.AP = .15;
                    iobj.AD = .15;
                    iobj.MANA_MULT = .15;
                    break;
                case "Stoneplate":
                    iobj.HP = 100;
                    iobj.ARMOR = 25;
                    iobj.MR = 25;
                    break;
                case "DragonClaw":
                    iobj.HP_MULT = .09;
                    iobj.MR = 75;
                    break;
                case "Bramble":
                    iobj.HP_MULT = .07;
                    iobj.ARMOR = 65;
                    iobj.AUTO_DR = .08;
                    break;
                case "ProtectorsVow":
                    iobj.ARMOR = 25;
                    iobj.MR = 25;
                    iobj.SHIELD = .4;
                    iobj.MANA_REGEN = 1;
                    break;
                case "Crownguard":
                    iobj.HP = 100;
                    iobj.ARMOR = 20;
                    iobj.SHIELD = .25;
                    iobj.AP = .45;
                    break;
                case "SteadfastHeart":
                    iobj.HP = 250;
                    iobj.ARMOR = 20;
                    iobj.DR = .14;
                    iobj.CRIT = .2;
                    break;
                default: break;
            }
        }

        private static void Unit_Stat_Setter(Unit_Holder uobj)
        {
          
            switch (uobj.UNIT_NAME)
            {
                case "No_Unit":

                    break;

                case "Jinx":
                    uobj.TRAIT1 = "Sniper";
                    uobj.TRAIT2 = "Starguardian";
                    uobj.MAX_MANA = 80;
                    uobj.ARMOR = 35;
                    uobj.MR = 35;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.MANA_COUNT = 10;
                    uobj.ATKS = .75;
                    uobj.COST = 4;
                    uobj.CAST_TIME = 1;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 850;
                            uobj.AD = 70;
                            break;
                        case "2":
                            uobj.HP = 1530;
                            uobj.AD = 105;
                            break;
                        case "3":
                            uobj.HP = 2754;
                            uobj.AD = 158;
                            break;

                        default: break;
                    }
                    break;

                case "Karma":
                    uobj.TRAIT1 = "Mighty Mech";
                    uobj.TRAIT2 = "Sorcerer";
                    uobj.MAX_MANA = 70;
                    uobj.ARMOR = 35;
                    uobj.MR = 35;
                    uobj.ATKS = .75;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.COST = 4;
                    uobj.CAST_TIME = .5;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 850;
                            uobj.AD = 40;


                            break;
                        case "2":
                            uobj.HP = 1530;
                            uobj.AD = 60;
                            break;
                        case "3":
                            uobj.HP = 2754;
                            uobj.AD = 90;
                            break;

                        default: break;
                    }
                    break;
                case "Ryze":
                    uobj.TRAIT1 = "Executioner";
                    uobj.TRAIT2 = "Strategist_B";
                    uobj.TRAIT3 = "Mentor";
                    uobj.MAX_MANA = 60;
                    uobj.ARMOR = 35;
                    uobj.MR = 35;
                    uobj.ATKS = .8;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.MANA_COUNT = 10;
                    uobj.COST = 4;
                    uobj.CAST_TIME = 3;
                    switch (uobj.STAR)
                    {

                        case "1":
                            uobj.HP = 850;
                            uobj.AD = 50;


                            break;
                        case "2":
                            uobj.HP = 1530;
                            uobj.AD = 75;

                            break;
                        case "3":
                            uobj.HP = 2754;
                            uobj.AD = 113;
                            break;

                        default: break;
                    }
                    break;
                case "Yuumi":
                    uobj.TRAIT1 = "Prodigy";
                    uobj.TRAIT2 = "Battle Academia";
                    uobj.MAX_MANA = 40;
                    uobj.ARMOR = 35;
                    uobj.MR = 35;
                    uobj.ATKS = .75;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.COST = 4;
                    uobj.CAST_TIME = 2;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 850;
                            uobj.AD = 40;


                            break;
                        case "2":
                            uobj.HP = 1530;
                            uobj.AD = 60;
                            break;
                        case "3":
                            uobj.HP = 2754;
                            uobj.AD = 90;
                            break;

                        default: break;
                    }
                    break;
                case "Ashe":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "Crystal Gambit";
                    uobj.TRAIT2 = "Duelist";
                    uobj.ATKS = .8; 
                    uobj.MANA_OH = 10;
                    uobj.MAX_MANA = 80; 
                    uobj.ARMOR = 35; 
                    uobj.MR = 35;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 850; 
                            uobj.AD = 60;
                            
                            break;
                        case "2":
                            uobj.HP = 1530; 
                            uobj.AD = 90;
                            
                            break;
                        case "3":
                            uobj.HP = 2754;
                            uobj.AD = 135;
                            break;

                        default: break;
                    }
                    break;
                case "Samira":
                    uobj.COST = 4;
                    uobj.ATKS = .75; 
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.TRAIT1 = "Edgelord"; 
                    uobj.TRAIT2 = "Soul Fighter";
                    uobj.MAX_MANA = 15; 
                    uobj.ARMOR = 45; 
                    uobj.MR = 45;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 850; 
                            uobj.AD = 50;
                            
                            break;
                        case "2":
                            uobj.HP = 1530; 
                            uobj.AD = 75;
                            
                            break;
                        case "3":
                            uobj.HP = 2754;
                            uobj.AD = 113;
                            break;

                        default: break;
                    }
                    break;
                case "Jarvan":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "Mighty Mech"; 
                    uobj.TRAIT2 = "Strategist_F";
                    uobj.ATKS = .65;
                    uobj.MANA_OH = 5; 
                    uobj.MANA_COUNT = 45;
                    uobj.MAX_MANA = 150;
                    uobj.ARMOR = 60; 
                    uobj.MR = 60;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1100; 
                            uobj.AD = 60;
                            
                            
                            break;
                        case "2":
                            uobj.HP = 1980; 
                            uobj.AD = 90;
                            
                            break;
                        case "3":
                            uobj.HP = 3564;
                            uobj.AD = 135;
                            break;

                        default: break;
                    }
                    break;
                case "Ksante":
                    uobj.COST = 4;
                    uobj.ATKS = .7; 
                    uobj.MANA_OH = 5;
                    uobj.MANA_COUNT = 30;
                    uobj.TRAIT1 = "Protector"; 
                    uobj.TRAIT2 = "Wraith";
                    uobj.MAX_MANA = 90;
                    uobj.ARMOR = 60; 
                    uobj.MR = 60;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1000; 
                            uobj.AD = 60;
                            
                            break;
                        case "2":
                            uobj.HP = 1800;  
                            uobj.AD = 90;
                            
                            break;
                        case "3":
                            uobj.HP = 3240;
                            uobj.AD = 135;
                            break;

                        default: break;
                    }
                    break;
                case "Leona":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "Bastion";
                    uobj.TRAIT2 = "Battle Academia";
                    uobj.ATKS = .6;
                    uobj.MANA_OH = 5;
                    uobj.MANA_COUNT = 30;
                    uobj.MAX_MANA = 100; 
                    uobj.ARMOR = 60; 
                    uobj.MR = 60;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1200;  
                            uobj.AD = 60;
                            
                            
                            break;
                        case "2":
                            uobj.HP = 2160; 
                            uobj.AD = 90;
                            break;
                        case "3":
                            uobj.HP = 3888;
                            uobj.AD = 135;
                            break;

                        default: break;
                    }
                    break;
                case "Poppy":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "Heavyweight";
                    uobj.TRAIT2 = "Star Guardian";
                    uobj.ATKS = .6;
                    uobj.MANA_OH = 5;
                    uobj.MANA_COUNT = 45;
                    uobj.MAX_MANA = 105;
                    uobj.ARMOR = 60;
                    uobj.MR = 60;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1100;
                            uobj.AD = 65;
                            break;
                        case "2":
                            uobj.HP = 1980;
                            uobj.AD = 98;
                            break;
                        case "3":
                            uobj.HP = 3564;
                            uobj.AD = 146;
                            break;

                        default: break;
                    }
                    break;
                case "Sett":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "Juggernaut";
                    uobj.TRAIT2 = "Soul Fighter";
                    uobj.ATKS = .7;
                    uobj.MANA_OH = 5;
                    uobj.MANA_COUNT = 40;
                    uobj.MAX_MANA = 100;
                    uobj.ARMOR = 50;
                    uobj.MR = 50;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1100;
                            uobj.AD = 60;
                            break;
                        case "2":
                            uobj.HP = 1980;
                            uobj.AD = 90;
                            break;
                        case "3":
                            uobj.HP = 3564;
                            uobj.AD = 135;
                            break;

                        default: break;
                    }
                    break;
                case "Volibear":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "EdgeLord";
                    uobj.TRAIT2 = "Luchador";
                    uobj.ATKS = .9;
                    uobj.MANA_OH = 10;
                    uobj.OMNIVAMP = .1;
                    uobj.MAX_MANA = 40;
                    uobj.ARMOR = 65;
                    uobj.MR = 65;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1050;
                            uobj.AD = 65;


                            break;
                        case "2":
                            uobj.HP = 1890;
                            uobj.AD = 98;
                            break;
                        case "3":
                            uobj.HP = 3402;
                            uobj.AD = 146;
                            break;

                        default: break;
                    }
                    break;
                case "Akali":
                    uobj.COST = 4;
                    uobj.TRAIT1 = "Executioner";
                    uobj.TRAIT2 = "Supreme Cells";
                    uobj.MAX_MANA = 30;
                    uobj.ARMOR = 65;
                    uobj.MR = 65;
                    uobj.ATKS = .85;
                    uobj.MANA_OH = 10;
                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 1050;
                            uobj.AD = 30;
                            break;
                        case "2":
                            uobj.HP = 1890;
                            uobj.AD = 45;
                            break;
                        case "3":
                            uobj.HP = 3402;
                            uobj.AD = 68;
                            break;

                        default: break;
                    }
                    break;

                // 2 costs 

                case "Katarina":
                    uobj.COST = 2;
                    uobj.TRAIT1 = "Executioner";
                    uobj.TRAIT2 = "Battle Academia";
                    uobj.ARMOR = 55;
                    uobj.MR = 55;
                    uobj.MANA_OH = 10;
                    uobj.MAX_MANA = 30;
                    uobj.ATKS = .8;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 800;
                            uobj.AD = 35;

                            break;
                        case "2":
                            uobj.HP = 1440;
                            uobj.AD = 53;
                            break;
                        case "3":
                            uobj.HP = 2592;
                            uobj.AD = 79;
                            break;

                        default: break;
                    }
                    break;

                // 3 cost

                case "Malzahar":
                    uobj.COST = 3;
                    uobj.TRAIT1 = "Prodigy";
                    uobj.TRAIT2 = "Wraith";
                    uobj.ARMOR = 30;
                    uobj.MR = 30;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.MAX_MANA = 35;
                    uobj.ATKS = .7;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 900;
                            uobj.AD = 40;

                            break;
                        case "2":
                            uobj.HP = 1620;
                            uobj.AD = 60;
                            break;
                        case "3":
                            uobj.HP = 2916;
                            uobj.AD = 90;
                            break;

                        default: break;
                    }
                    break;

                case "Caitlyn":
                    uobj.COST = 3;
                    uobj.TRAIT1 = "Sniper";
                    uobj.TRAIT2 = "Battle Academia";
                    uobj.ARMOR = 30;
                    uobj.MR = 30;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.MAX_MANA = 60;
                    uobj.ATKS = .7;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 650;
                            uobj.AD = 55;

                            break;
                        case "2":
                            uobj.HP = 1170;
                            uobj.AD = 83;
                            break;
                        case "3":
                            uobj.HP = 2106;
                            uobj.AD = 124;
                            break;

                        default: break;
                    }
                    break;

                case "Senna":
                    uobj.COST = 3;
                    uobj.TRAIT1 = "Executioner";
                    uobj.TRAIT2 = "Mighty Mech";
                    uobj.ARMOR = 30;
                    uobj.MR = 30;
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.MAX_MANA = 75;
                    uobj.ATKS = .75;
                    uobj.MANA_COUNT = 15;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 650;
                            uobj.AD = 55;

                            break;
                        case "2":
                            uobj.HP = 1170;
                            uobj.AD = 83;
                            break;
                        case "3":
                            uobj.HP = 2106;
                            uobj.AD = 124;
                            break;

                        default: break;
                    }
                    break;

                case "Smolder": // unfinished
                    uobj.COST = 3;
                    uobj.TRAIT1 = "Monster Trainer";
                    uobj.ARMOR = 55; 
                    uobj.MR = 55; 
                    uobj.MANA_OH = 10;
                    uobj.MAX_MANA = 30;
                    uobj.ATKS = .8;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 800;
                            uobj.AD = 35;

                            break;
                        case "2":
                            uobj.HP = 1440;
                            uobj.AD = 53;
                            break;
                        case "3":
                            uobj.HP = 2592;
                            uobj.AD = 79;
                            break;

                        default: break;
                    }
                    break;

                // 1 cost
                case "Lucian": 
                    uobj.COST = 1;
                    uobj.TRAIT1 = "Mighty Mech";
                    uobj.ARMOR = 20; 
                    uobj.MR = 20; 
                    uobj.MANA_OH = 7;
                    uobj.MANA_REGEN = 2;
                    uobj.MAX_MANA = 40;
                    uobj.ATKS = .7;

                    switch (uobj.STAR)
                    {
                        case "1":
                            uobj.HP = 500;
                            uobj.AD = 30;

                            break;
                        case "2":
                            uobj.HP = 900;
                            uobj.AD = 35;
                            break;
                        case "3":
                            uobj.HP = 1620;
                            uobj.AD = 68;
                            break;

                        default: break;
                    }
                    break;


                default: break;


            }
        }

        private static void Trait_Stat_Setter(Trait_Holder tobj, string trait)
        {

            switch (trait)// fix this later
            {
                case "None":

                    break;

                case "Sniper":

                    if (tobj.TRAIT_VALUE == 2)
                    {
                        tobj.D_AMP = .25;
                    }
                    else if (tobj.TRAIT_VALUE == 3)
                    {
                        tobj.D_AMP = .36;
                    }
                    else if (tobj.TRAIT_VALUE == 4)
                    {
                        tobj.D_AMP = .57;
                    }
                    else if (tobj.TRAIT_VALUE >= 5)
                    {
                        tobj.D_AMP = .65;
                    }
                    break;

                case "Prodigy":
                    if (tobj.TRAIT_VALUE == 2)
                    {
                        tobj.MANA_REGEN = 3;
                    }
                    else if (tobj.TRAIT_VALUE == 3)
                    {
                        tobj.MANA_REGEN = 5;
                    }
                    else if (tobj.TRAIT_VALUE == 4)
                    {
                        tobj.MANA_REGEN = 7;
                    }
                    else if (tobj.TRAIT_VALUE >= 5)
                    {
                        tobj.MANA_REGEN = 8;
                    }
                    break;

                case "Edgelord":
                    // atks not yet implemented
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        //hp = 300;
                        tobj.OMNIVAMP = .1;
                        tobj.AD = .15;
                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        tobj.OMNIVAMP = .12;
                        tobj.AD = .35;
                    }
                    else if (tobj.TRAIT_VALUE >= 6)
                    {
                        tobj.OMNIVAMP = .15;
                        tobj.AD = .5;
                    }
                    break;

                case "Executioner":
                    if (tobj.TRAIT_VALUE == 2)
                    {
                        tobj.CRIT_FLAG = 1;
                        tobj.CRIT = .25;
                        tobj.CRIT_MULT = .1;
                    }
                    else if (tobj.TRAIT_VALUE == 3)
                    {
                        tobj.CRIT_FLAG = 1;
                        tobj.CRIT = .35;
                        tobj.CRIT_MULT = .12;
                    }
                    else if (tobj.TRAIT_VALUE == 4)
                    {
                        tobj.CRIT_FLAG = 1;
                        tobj.CRIT = .5;
                        tobj.CRIT_MULT = .18;
                    }
                    else if (tobj.TRAIT_VALUE >= 5)
                    {
                        tobj.CRIT_FLAG = 1;
                        tobj.CRIT = .55;
                        tobj.CRIT_MULT = .28;
                    }
                    break;

                case "Bastion":
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        if (tobj.FIRST10)
                        {
                            tobj.ARMOR = 36;
                            tobj.MR = 36;
                        }
                        else
                        {
                            tobj.ARMOR = 18;
                            tobj.MR = 18;
                        }


                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        if (tobj.FIRST10)
                        {
                            tobj.ARMOR = 80;
                            tobj.MR = 80;
                        }
                        else
                        {
                            tobj.ARMOR = 40;
                            tobj.MR = 40;
                        }

                    }
                    else if (tobj.TRAIT_VALUE >= 6)
                    {
                        if (tobj.FIRST10)
                        {
                            tobj.ARMOR = 150;
                            tobj.MR = 150;
                        }
                        else
                        {
                            tobj.ARMOR = 75;
                            tobj.MR = 75;
                        }

                    }
                    break;

                case "Protector":

                    if (tobj.SHIELDED)
                    {
                        tobj.DR = .05;
                    }

                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        tobj.SHIELD = .2;
                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        tobj.SHIELD = .4;
                    }
                    else if (tobj.TRAIT_VALUE >= 6)
                    {
                        tobj.SHIELD = .6;
                    }
                    break;

                case "Juggernaut":
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        if (tobj.ABOVE50)
                        {
                            tobj.DR = .25;
                        }
                        else tobj.DR = .15;
                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        if (tobj.ABOVE50)
                        {
                            tobj.DR = .30;
                        }
                        else tobj.DR = .20;
                    }
                    else if (tobj.TRAIT_VALUE >= 6)
                    {
                        if (tobj.ABOVE50)
                        {
                            tobj.DR = .35;
                        }
                        else tobj.DR = .25;
                    }
                    break;

                case "Sorcerer":
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        tobj.AP = .2;
                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        tobj.AP = .5;
                    }
                    else if (tobj.TRAIT_VALUE >= 6)
                    {
                        tobj.AP = .9;
                    }
                    break;

                case "Strategist_B":
                    if (tobj.TRAIT_VALUE == 2)
                    {
                        tobj.D_AMP = .12;
                    }
                    else if (tobj.TRAIT_VALUE == 3)
                    {
                        tobj.D_AMP = .18;
                    }
                    else if (tobj.TRAIT_VALUE == 4)
                    {
                        tobj.D_AMP = .3;
                    }
                    else if (tobj.TRAIT_VALUE >= 5)
                    {
                        tobj.D_AMP = .42;
                    }
                    break;

                case "Battle Academia":
                    if (tobj.TRAIT_VALUE >= 3 && tobj.TRAIT_VALUE < 5)
                    {
                        tobj.POTENTIAL = 3;
                    }
                    else if (tobj.TRAIT_VALUE >= 5 && tobj.TRAIT_VALUE < 7)
                    {
                        tobj.POTENTIAL = 5;
                    }
                    else if (tobj.TRAIT_VALUE >= 7)
                    {
                        tobj.POTENTIAL = 7;
                    }
                    break;

                case "Luchador":
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        tobj.AD = .15;
                    }
                    else if (tobj.TRAIT_VALUE >= 4)
                    {
                        tobj.AD = .4;
                    }
                    break;

                case "Supreme Cells":
                    if (tobj.TRAIT_VALUE == 2)
                    {
                        tobj.EXECUTE = .1;
                        tobj.D_AMP = .12;
                    }
                    else if (tobj.TRAIT_VALUE == 3)
                    {
                        tobj.EXECUTE = .1;
                        tobj.D_AMP = .3;
                    }
                    else if (tobj.TRAIT_VALUE >= 4)
                    {
                        tobj.EXECUTE = .1;
                        tobj.D_AMP = .5;
                    }
                    break;

                case "Duelist":
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        tobj.DUELIST_FLAG = true;
                        tobj.D_ATKS = .04;
                        tobj.D_CAP = .48;
                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        tobj.D_ATKS = .07;
                        tobj.DUELIST_FLAG = true;
                        tobj.D_CAP = .84;
                    }
                    else if (tobj.TRAIT_VALUE >= 6)
                    {
                        tobj.D_ATKS = .1;
                        tobj.DUELIST_FLAG = true;
                        tobj.D_CAP = 1.2;
                        tobj.DR = .12;
                        // dr increases by 12
                    }
                    break;

                case "Soul Fighter":
                    if (tobj.TRAIT_VALUE >= 2 && tobj.TRAIT_VALUE < 4)
                    {
                        tobj.HP = 120;
                        tobj.SF_FLAG = true;
                        tobj.SF_AD = .01;
                        tobj.SF_T_V = .1;
                    }
                    else if (tobj.TRAIT_VALUE >= 4 && tobj.TRAIT_VALUE < 6)
                    {
                        tobj.HP = 240;
                        tobj.SF_FLAG = true;
                        tobj.SF_AD = .02;
                        tobj.SF_T_V = .16;
                    }
                    else if (tobj.TRAIT_VALUE >= 6 && tobj.TRAIT_VALUE < 8)
                    {
                        tobj.HP = 450;
                        tobj.SF_FLAG = true;
                        tobj.SF_AD = .03;
                        tobj.SF_T_V = .22;
                    }
                    else if (tobj.TRAIT_VALUE >= 8)
                    {
                        tobj.HP = 700;
                        tobj.SF_FLAG = true;
                        tobj.SF_AD = .04;
                        tobj.SF_T_V = .3;
                    }
                    break;

                case "Starguardian":
                    // only jinx implemented
                    if (tobj.TRAIT_VALUE >= 2)
                    {
                        tobj.ATKS = .05 * (1 + (tobj.TRAIT_VALUE * .1));
                    }

                    break;

                case "Mentor":
                    if (tobj.TRAIT_VALUE == 1)
                    {
                        tobj.MANA_OH = 2;
                    }
                    else if (tobj.TRAIT_VALUE == 4)
                    {
                        tobj.MANA_OH = 2;
                        tobj.DR = .06;
                        tobj.AD = .08;
                        tobj.AP = .08;
                        tobj.ATKS = .1;
                        tobj.M_FLAG = true;
                    }
                    break;

                default: break;

            }

        }

        private static void Fruit_Stat_Setter(Fruit_Holder fobj)
        {
            switch (fobj.FRUIT_NAME)
            {
                case "Star Student":
                    fobj.HP = 200;
                    fobj.POT_MULTI = .4;
                    break;
                case "Not Done Yet":
                    fobj.HP_MULT = .25;
                    fobj.OMNIVAMP = .1;
                    fobj.D_AMP = .25;
                    break;
                case "Colossal": break;
                case "Dark Amulet": break;
                case "Over 9000": break;
                case "Unflinching": break;
                case "Blink Attack": break;
                case "On The Edge":
                    fobj.D_AMP = .35;
                    break;
                case "Fusion Dance": break;
                case "Scoialite":
                    // currently only solo stats
                    fobj.HP = 400;
                    fobj.D_AMP = .24;
                    break;
                case "Hemorrhage": 
                    // flag
                    break;
                case "Keen Eye": 
                    // flag
                    break;
                case "Fairy Tail": 
                    // flag
                    break;
                case "Heros Arc": 
                    // player level input
                    break;
                case "Final Boss": 
                    // ally death input
                    break;
                case "Magic Expert": 
                    // somehow separate the flat ap from fruit from others

                    break;
                case "Hungry Hero": 
                    // # of feed input
                    break;
                case "Weights":
                    // assume 0 weights
                    fobj.ATKS = .6;
                    fobj.DR = .18;
                    break;
                case "Finalist": 
                    // elim player # input
                    break;
                case "Tiny Terror":
                    // auto dodge not implemented
                    fobj.ATKS = .12;
                    break;
                case "100 Push Ups": 
                    // # of reroll inputs
                    break;
                case "Crimson Veil": 
                    
                    break;
                case "Max Arcana":
                    //takendown # input
                    break;
                case "Trickster": break;
                case "Midas Touch":
                    fobj.EXECUTE = 1;
                    break;
                case "Ordinary": 
                    // no active traits? and stage # input
                    break;
                case "Corrupted": 
                    // # of dead units input
                    break;
                case "Sky Piercer": break;
                case "Shadow Clone": break;
                case "Mage": break;
                case "Power Font":
                    fobj.MANA_REGEN = 1;
                    fobj.TIMED_EVENT = "Power Font";
                    break;
                case "Critical Threat":
                    fobj.CRIT_FLAG = 1;
                    fobj.TIMED_EVENT = "Critical Threat";
                    break;
                case "Efficient": break;
                case "Bludgeoner": break;
                case "Gather Force": break;
                case "Solar Breath": break;
                case "Max Attack": break;
                case "Hat Trick": break;
                case "Attack Expert": break;
                case "Cyclone Rush": break;
                case "Precision": break;
                case "Classy": break;
                case "Max Speed": break;
                case "Pursuit": break;
                case "Storm Bender": break;
                case "Mech Pilot": break;
                case "Demolitionist": break;
                case "Bullet Hell": break;
                case "Killer Instinct":
                    fobj.MANA_REGEN = 3;
                    break;
                case "Caretaker": break;
                case "Essence Share": break;
                case "Robo Range": break;
                case "Super Genius": break;
                case "Thrillseeker": break;
                case "Supremacy": break;
                case "Frost Touch": break;
                case "Desperado": break;
                case "Doublestrike": break;
                case "Kahunahuna": break;
                case "Spirit Sword": break;
                case "Resistant": break;
                case "Adaptive Skin": break;
                case "Round Two": break;
                case "Stand Alone":
                    fobj.HP_MULT = .35;
                    break;
                case "Corrosive": break;
                case "Body Change": break;
                case "Inner Fire": break;
                case "Regenerative": break;
                case "Strong Spark": break;
                case "Selfish": break;
                case "Tank-zilla":
                    fobj.HP_MULT = .2;
                    break;
                case "Robo Ranger": break;
                case "Spiky Shell":
                    fobj.ARMOR = 40;
                    break;
                case "Mana Rush": break;
                case "Star Sailor": break;
                case "Hyperactive": break;
                case "Golden Edge": break;
                case "Ramping Rage": break;
                case "All Out": break;
                case "Atomic": break;
                case "Warming Up": break;
                case "Pure Heart": break;
                case "Unstoppable": break;
                case "Soul Chipper": break;
                case "Esence Share": break;
                case "Living Wall": break;
                case "Singularity": break;
                case "Best Defense": break;
                case "Ice Bender": break;
                case "Annihilation": break;
                case "Resistance": break;
                case "Serious Slam": break;
                case "Bladenado": break;
                case "Stretchy Arms":
                    fobj.ATKS = .1;
                    break;

                default: break;
            }
        }

        private static void Combat_Setter(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3, Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3,
                       Trait_Holder trait1, Trait_Holder trait2, Trait_Holder trait3, Fruit_Holder fobj, Post_Combat_Stats pobj)
        {
            pobj.UNIT_NAME = uobj.UNIT_NAME;
            pobj.STAR = uobj.STAR;
            pobj.BASE_ATKS = uobj.ATKS;
            pobj.MAX_MANA = uobj.MAX_MANA;
            pobj.BASE_AD = uobj.AD;
            pobj.MANA_COUNTER = uobj.MANA_COUNT;

            pobj.CAST_TIME = uobj.CAST_TIME;
            pobj.CAST_TIME2 = uobj.CAST_TIME2;

            pobj.TITANS_FLAG = item1.TITANS_FLAG + item2.TITANS_FLAG + item3.TITANS_FLAG;
            pobj.ASCEND_FLAG = aug1.ASCEND_FLAG || aug2.ASCEND_FLAG || aug3.ASCEND_FLAG;
            
            pobj.POTENTIAL = trait1.POTENTIAL + trait2.POTENTIAL + trait3.POTENTIAL;
            pobj.M_FLAG = trait1.M_FLAG | trait2.M_FLAG | trait3.M_FLAG;

            pobj.ASI = item1.ATKS + item2.ATKS + item3.ATKS + aug1.ATKS + aug2.ATKS + aug3.ATKS + trait1.ATKS + trait2.ATKS + trait3.ATKS;
            
            pobj.MANA_REGEN = uobj.MANA_REGEN + item1.MANA_REGEN + item2.MANA_REGEN + item3.MANA_REGEN +
                   aug1.MANA_REGEN + aug2.MANA_REGEN + aug3.MANA_REGEN + trait1.MANA_REGEN + trait2.MANA_REGEN + trait3.MANA_REGEN;

            pobj.MANA_OH = uobj.MANA_OH + item1.MANA_OH + item2.MANA_OH + item3.MANA_OH + trait1.MANA_OH + trait2.MANA_OH + trait3.MANA_OH;

            pobj.MANA_MULT = item1.MANA_MULT + item2.MANA_MULT + item3.MANA_MULT;

            if (pobj.MANA_MULT > 0)
            {
                pobj.MANA_OH = pobj.MANA_OH * (1 + (.15 * pobj.MANA_MULT));
                pobj.MANA_REGEN = pobj.MANA_REGEN * (1 + (.15 * pobj.MANA_MULT));
            }


            pobj.CRIT = uobj.CRIT + item1.CRIT + item2.CRIT + item3.CRIT + aug1.CRIT + aug2.CRIT + aug3.CRIT + trait1.CRIT + trait2.CRIT + trait3.CRIT;
            double over_crit = 0;
            if (pobj.CRIT > 1)
            {
                over_crit = pobj.CRIT - 1;
                pobj.CRIT = 1;
            }


            // uobj.CRIT + + aug1.CRIT + aug2.CRIT + aug3.CRIT; item1.CRIT + item2.CRIT + 
            pobj.IE_FLAG = item1.IE_FLAG + item2.IE_FLAG + item3.IE_FLAG;

            double over_cm = over_crit / 2;
            double ie_cm = 0;
            pobj.CRIT_FLAG2 = aug1.CRIT_FLAG + aug2.CRIT_FLAG + aug3.CRIT_FLAG + trait1.CRIT_FLAG + trait2.CRIT_FLAG + trait3.CRIT_FLAG;

            if (pobj.CRIT_FLAG2 > 1)
            {
                ie_cm = pobj.IE_FLAG * .1;
            }
            else if (pobj.IE_FLAG > 0)
            {
                ie_cm = (pobj.IE_FLAG - 1) * .1;
            }


            pobj.CRIT_MULTI = ie_cm + over_cm + uobj.CRIT_MULTI + trait1.CRIT_MULT + trait2.CRIT_MULT + trait3.CRIT_MULT;

            if (pobj.IE_FLAG + pobj.CRIT_FLAG2 > 0)
            {
                pobj.CRIT_FLAG = true;
            }
            else pobj.CRIT_FLAG = false;

            //pobj.CRIT_FLAG = ie_flag + crit_flag2; // change this to a bool eventually

            pobj.AMP = item1.D_AMP + item2.D_AMP + item3.D_AMP + aug1.D_AMP + aug2.D_AMP + aug3.D_AMP + trait1.D_AMP + trait2.D_AMP + trait3.D_AMP;
            pobj.AD = item1.AD + item2.AD + item3.AD + aug1.AD + aug2.AD + aug3.AD + trait1.AD + trait2.AD + trait3.AD;
            pobj.AP = item1.AP + item2.AP + item3.AP + aug1.AP + aug2.AP + aug3.AP + trait1.AP + trait2.AP + trait3.AP;

            pobj.RB_FLAG = item1.RB_FLAG + item2.RB_FLAG + item3.RB_FLAG;
            //double rb_flag = 0;
            pobj.KRAKEN_FLAG = item1.KRAKEN_FLAG + item2.KRAKEN_FLAG + item3.KRAKEN_FLAG;
            pobj.AA_FLAG = item1.AA_FLAG + item2.AA_FLAG + item3.AA_FLAG;

            if (uobj.UNIT_NAME == "Jinx")
            {
                pobj.JINX_FLAG = true;
            }
            else pobj.JINX_FLAG = false;

            pobj.NASHORS_FLAG = item1.NASHORS_FLAG + item2.NASHORS_FLAG + item3.NASHORS_FLAG;
            pobj.NASHORS_TRACKER = 0;
            pobj.NASHORS_E = false;

            pobj.QSS_FLAG = item1.QSS_FLAG + item2.QSS_FLAG + item3.QSS_FLAG;
            pobj.GS_FLAG = item1.GS_FLAG + item2.GS_FLAG + item3.GS_FLAG;

            pobj.SF_T = false;
            pobj.SF_FLAG = trait1.SF_FLAG || trait2.SF_FLAG || trait3.SF_FLAG;
            pobj.SF_T_V = trait1.SF_T_V + trait2.SF_T_V + trait3.SF_T_V;
            pobj.SF_AD = trait1.SF_AD + trait2.SF_AD + trait3.SF_AD;

            pobj.DUELIST_FLAG = trait1.DUELIST_FLAG | trait2.DUELIST_FLAG | trait3.DUELIST_FLAG;
            pobj.DUELIST_ASI = trait1.D_ATKS + trait2.D_ATKS + trait3.D_ATKS;

            pobj.EXECUTE = trait1.EXECUTE + trait2.EXECUTE + trait3.EXECUTE;

            pobj.SUNDER = item1.SUNDER + item2.SUNDER + item3.SUNDER;
            pobj.SHRED = item1.SHRED + item2.SHRED + item3.SHRED;
            pobj.OMNIVAMP = uobj.OMNIVAMP + item1.OMNIVAMP + item2.OMNIVAMP + item3.OMNIVAMP + aug1.OMNIVAMP + aug2.OMNIVAMP + aug3.OMNIVAMP
                              + trait1.OMNIVAMP + trait2.OMNIVAMP + trait3.OMNIVAMP;

            pobj.TRUE_DAMAGE = 0;
            pobj.TRUE_DAMAGE_DPS = 0;
            pobj.TRUE_DAMAGE_TRACKER = 0;
            pobj.TRUE_DAMAGE_DPS15 = 0;

            //double mana_counter15 = 0;


            pobj.ASHE_COUNTER = 0;
            pobj.VOLI_PASSIVE = 0;
            pobj.VOLI_ATKS = 0;

            pobj.SPELL_START = 0;

            //double j_track = 0; // track jinx's ability attack speed increase

            //double d_dtrack = 0; // track duelist attack speed increase

            pobj.ATK_TIME = Attack_Time_calc(pobj.BASE_ATKS, pobj.ASI); // in1 is base attack speed


            pobj.TIME_S = 0;

            pobj.TIME_E = pobj.ATK_TIME;


            pobj.CAST_FLAG = false;



            pobj.ATTACK_FLAG = false;

            pobj.ARMOR_DR = 0;

            pobj.MR_DR = 0;



            pobj.HALF_FLAG = false;

            pobj.AA_CHECK = false;

            pobj.VOLI_TRACKER = 0;

            pobj.STYLE = 0;

        }



        // List methods

        public static List<Item_Holder> Create_Item_List()
        {
            Item_Holder None = new();
            Item_Holder Deathblade = new();
            Item_Holder Giantslayer = new();
            Item_Holder Gunblade = new();
            Item_Holder Shojin = new();
            Item_Holder EdgeOfNight = new();
            Item_Holder BloodThirster = new();
            Item_Holder Steraks = new();
            Item_Holder InfinityEdge = new();
            Item_Holder Redbuff = new();
            Item_Holder Rageblade = new();
            Item_Holder VoidStaff = new();
            Item_Holder Titans = new();
            Item_Holder Kraken = new();
            Item_Holder Nashor = new();
            Item_Holder LastWhisper = new();
            Item_Holder Deathcap = new();
            Item_Holder Archangels = new();
            Item_Holder Morello = new();
            Item_Holder JeweledGauntlet = new();
            Item_Holder HandOfJustice = new();
            Item_Holder BlueBuff = new();
            Item_Holder QuickSilver = new();
            Item_Holder StrikersFlail = new();
            Item_Holder Warmogs = new();
            Item_Holder Sunfire = new();
            Item_Holder SpiritVisage = new();
            Item_Holder EvenShroud = new();
            Item_Holder Spark = new();
            Item_Holder AdaptiveFront = new();
            Item_Holder Stoneplate = new();
            Item_Holder DragonClaw = new();
            Item_Holder Bramble = new();
            Item_Holder ProtectorsVow = new();
            Item_Holder Crownguard = new();
            Item_Holder SteadfastHeart = new();
            Item_Holder AdaptiveBack = new();

            None.ITEM_NAME = "None";
            Deathblade.ITEM_NAME = "Deathblade";
            Giantslayer.ITEM_NAME = "Giantslayer";
            Gunblade.ITEM_NAME = "Gunblade";
            Shojin.ITEM_NAME = "Shojin";
            EdgeOfNight.ITEM_NAME = "EdgeOfNight";
            BloodThirster.ITEM_NAME = "BloodThirster";
            Steraks.ITEM_NAME = "Steraks";
            InfinityEdge.ITEM_NAME = "InfinityEdge";
            Redbuff.ITEM_NAME = "Redbuff";
            Rageblade.ITEM_NAME = "Rageblade";
            VoidStaff.ITEM_NAME = "VoidStaff";
            Titans.ITEM_NAME = "Titans";
            Kraken.ITEM_NAME = "Kraken";
            Nashor.ITEM_NAME = "Nashor";
            LastWhisper.ITEM_NAME = "LastWhisper";
            Deathcap.ITEM_NAME = "Deathcap";
            Archangels.ITEM_NAME = "Archangels";
            Morello.ITEM_NAME = "Morello";
            JeweledGauntlet.ITEM_NAME = "JeweledGauntlet";
            HandOfJustice.ITEM_NAME = "HandOfJustice";
            BlueBuff.ITEM_NAME = "BlueBuff";
            QuickSilver.ITEM_NAME = "QuickSilver";
            StrikersFlail.ITEM_NAME = "StrikersFlail";
            Warmogs.ITEM_NAME = "Warmogs";
            Sunfire.ITEM_NAME = "Sunfire";
            SpiritVisage.ITEM_NAME = "SpiritVisage";
            EvenShroud.ITEM_NAME = "EvenShroud";
            Spark.ITEM_NAME = "Spark";
            AdaptiveFront.ITEM_NAME = "AdaptiveFront";
            Stoneplate.ITEM_NAME = "Stoneplate";
            DragonClaw.ITEM_NAME = "DragonClaw";
            Bramble.ITEM_NAME = "Bramble";
            ProtectorsVow.ITEM_NAME = "ProtectorsVow";
            Crownguard.ITEM_NAME = "Crownguard";
            SteadfastHeart.ITEM_NAME = "SteadfastHeart";
            AdaptiveBack.ITEM_NAME = "AdaptiveBack";

            List<Item_Holder> list1 = new()
            {
                None,
                Deathblade,
                Giantslayer,
                Gunblade,
                Shojin,
                EdgeOfNight,
                BloodThirster,
                Steraks,
                InfinityEdge,
                Redbuff,
                Rageblade,
                VoidStaff,
                Titans,
                Kraken,
                Nashor,
                LastWhisper,
                Deathcap,
                Archangels,
                Morello,
                JeweledGauntlet,
                HandOfJustice,
                BlueBuff,
                QuickSilver,
                StrikersFlail,
                Warmogs,
                Sunfire,
                SpiritVisage,
                EvenShroud,
                Spark,
                AdaptiveFront,
                Stoneplate,
                DragonClaw,
                Bramble,
                ProtectorsVow,
                Crownguard,
                SteadfastHeart,
                AdaptiveBack
            };

            //List<string> list2 = new()
            //{
            //    "None",
            //    "Deathblade",
            //    "Giantslayer",
            //    "Gunblade",
            //    "Shojin",
            //    "EdgeOfNight",
            //    "BloodThirster",
            //    "Steraks",
            //    "InfinityEdge",
            //    "Redbuff",
            //    "Rageblade",
            //    "VoidStaff",
            //    "Titans",
            //    "Kraken",
            //    "Nashor",
            //    "LastWhisper",
            //    "Deathcap",
            //    "Archangels",
            //    "Morello",
            //    "JeweledGauntlet",
            //    "HandOfJustice",
            //    "BlueBuff",
            //    "QuickSilver",
            //    "StrikersFlail",
            //    "Warmogs",
            //    "Sunfire",
            //    "SpiritVisage",
            //    "EvenShroud",
            //    "Spark",
            //    "AdaptiveFront",
            //    "Stoneplate",
            //    "DragonClaw",
            //    "Bramble",
            //    "ProtectorsVow",
            //    "Crownguard",
            //    "SteadfastHeart",
            //    "AdaptiveBack"
            //};



            return list1;
        }

        public List<Unit_Holder> Create_Unit_List1()
        {
            Unit_Holder No_Unit = new();
            Unit_Holder Jinx1 = new();
            Unit_Holder Karma1 = new();
            Unit_Holder Ryze1 = new();
            Unit_Holder Yuumi1 = new();
            Unit_Holder Ashe1 = new();
            Unit_Holder Samira1 = new();
            Unit_Holder Jarvan1 = new();
            Unit_Holder Ksante1 = new();
            Unit_Holder Leona1 = new();
            Unit_Holder Poppy1 = new();
            Unit_Holder Sett1 = new();
            Unit_Holder Volibear1 = new();
            Unit_Holder Akali1 = new();

            Jinx1.HP = 850; Jinx1.MAX_MANA = 80; Jinx1.ARMOR = 35; Jinx1.MR = 35; Jinx1.AD = 70;
            Jinx1.ATKS = .75; Jinx1.MANA_OH = 7; Jinx1.MANA_REGEN = 2;
            Jinx1.TRAIT1 = "Sniper"; Jinx1.TRAIT2 = "Starguardian";

            Karma1.HP = 850; Karma1.MAX_MANA = 70; Karma1.ARMOR = 35; Karma1.MR = 35; Karma1.AD = 40;
            Karma1.ATKS = .75; Karma1.MANA_OH = 7; Karma1.MANA_REGEN = 2;
            Karma1.TRAIT1 = "Mighty Mech"; Karma1.TRAIT2 = "Sorcerer";

            Ryze1.HP = 1000; Ryze1.MAX_MANA = 60; Ryze1.ARMOR = 35; Ryze1.MR = 35; Ryze1.AD = 50;
            Ryze1.ATKS = .8; Ryze1.MANA_OH = 7; Ryze1.MANA_REGEN = 2;
            Ryze1.TRAIT1 = "Mentor"; Ryze1.TRAIT2 = "Strategist"; Ryze1.TRAIT3 = "Executioner";

            Yuumi1.HP = 850; Yuumi1.MAX_MANA = 40; Yuumi1.ARMOR = 35; Yuumi1.MR = 35; Yuumi1.AD = 40;
            Yuumi1.ATKS = .75; Yuumi1.MANA_OH = 7; Yuumi1.MANA_REGEN = 2;
            Yuumi1.TRAIT1 = "Prodigy"; Yuumi1.TRAIT2 = "Battle Academia";

            Ashe1.HP = 1000; Ashe1.MAX_MANA = 80; Ashe1.ARMOR = 35; Ashe1.MR = 35; Ashe1.AD = 60;
            Ashe1.ATKS = .8; Ashe1.MANA_OH = 10;
            Ashe1.TRAIT1 = "Crystal Gambit"; Ashe1.TRAIT2 = "Duelist";

            Samira1.HP = 850; Samira1.MAX_MANA = 15; Samira1.ARMOR = 45; Samira1.MR = 45; Samira1.AD = 50;
            Samira1.ATKS = .75; Samira1.MANA_OH = 7; Samira1.MANA_REGEN = 2;
            Samira1.TRAIT1 = "Edgelord"; Samira1.TRAIT2 = "Soul Fighter";

            Jarvan1.HP = 1100; Jarvan1.MAX_MANA = 150; Jarvan1.ARMOR = 60; Jarvan1.MR = 60; Jarvan1.AD = 60;
            Jarvan1.ATKS = .65; Jarvan1.MANA_OH = 5;
            Jarvan1.TRAIT1 = "Mighty Mech"; Jarvan1.TRAIT2 = "Strategist";

            Ksante1.HP = 1000; Ksante1.MAX_MANA = 90; Ksante1.ARMOR = 60; Ksante1.MR = 60; Ksante1.AD = 60;
            Ksante1.ATKS = .7; Ksante1.MANA_OH = 5;
            Ksante1.TRAIT1 = "Protector"; Ksante1.TRAIT2 = "Wraith";

            Leona1.HP = 1200; Leona1.MAX_MANA = 100; Leona1.ARMOR = 60; Leona1.MR = 60; Leona1.AD = 60;
            Leona1.ATKS = .6; Leona1.MANA_OH = 5;
            Leona1.TRAIT1 = "Bastion"; Leona1.TRAIT2 = "Battle Academia";

            Poppy1.HP = 1100; Poppy1.MAX_MANA = 105; Poppy1.ARMOR = 60; Poppy1.MR = 60; Poppy1.AD = 65;
            Poppy1.ATKS = .6; Poppy1.MANA_OH = 5;
            Poppy1.TRAIT1 = "Heavyweight"; Poppy1.TRAIT2 = "Star Guardian";

            Sett1.HP = 1100; Sett1.MAX_MANA = 100; Sett1.ARMOR = 50; Sett1.MR = 50; Sett1.AD = 60;
            Sett1.ATKS = .7; Sett1.MANA_OH = 5;
            Sett1.TRAIT1 = "Juggernaut"; Sett1.TRAIT2 = "Soul Fighter";

            Volibear1.HP = 1050; Volibear1.MAX_MANA = 40; Volibear1.ARMOR = 65; Volibear1.MR = 65; Volibear1.AD = 65;
            Volibear1.ATKS = .9; Volibear1.MANA_OH = 10; Volibear1.OMNIVAMP = .1;
            Volibear1.TRAIT1 = "EdgeLord"; Volibear1.TRAIT2 = "Luchador";

            Akali1.HP = 1050; Akali1.MAX_MANA = 30; Akali1.ARMOR = 65; Akali1.MR = 65; Akali1.AD = 30;
            Akali1.ATKS = .85; Akali1.MANA_OH = 10;
            Akali1.TRAIT1 = "Executioner"; Akali1.TRAIT2 = "Supreme Cells";


            List<Unit_Holder> list1 = new()
            {
                No_Unit,
                Jinx1,
                Karma1,
                Ryze1,
                Yuumi1,
                Ashe1,
                Samira1,
                Jarvan1,
                Ksante1,
                Leona1,
                Poppy1,
                Sett1,
                Volibear1,
                Akali1
            };



            return list1;
        }

        public List<Unit_Holder> Create_Unit_List2()
        {
            Unit_Holder No_Unit = new();
            Unit_Holder Jinx2 = new();
            Unit_Holder Karma2 = new();
            Unit_Holder Ryze2 = new();
            Unit_Holder Yuumi2 = new();
            Unit_Holder Ashe2 = new();
            Unit_Holder Samira2 = new();
            Unit_Holder Jarvan2 = new();
            Unit_Holder Ksante2 = new();
            Unit_Holder Leona2 = new();
            Unit_Holder Poppy2 = new();
            Unit_Holder Sett2 = new();
            Unit_Holder Volibear2 = new();
            Unit_Holder Akali2 = new();

            Jinx2.HP = 1530; Jinx2.MAX_MANA = 80; Jinx2.ARMOR = 35; Jinx2.MR = 35; Jinx2.AD = 105;
            Jinx2.ATKS = .75; Jinx2.MANA_OH = 7; Jinx2.MANA_REGEN = 2;
            Jinx2.TRAIT1 = "Sniper"; Jinx2.TRAIT2 = "Starguardian";

            Karma2.HP = 1530; Karma2.MAX_MANA = 70; Karma2.ARMOR = 35; Karma2.MR = 35; Karma2.AD = 70;
            Karma2.ATKS = .75; Karma2.MANA_OH = 7; Karma2.MANA_REGEN = 2;
            Karma2.TRAIT1 = "Mighty Mech"; Karma2.TRAIT2 = "Sorcerer";

            Ryze2.HP = 1530; Ryze2.MAX_MANA = 60; Ryze2.ARMOR = 35; Ryze2.MR = 35; Ryze2.AD = 75;
            Ryze2.ATKS = .8; Ryze2.MANA_OH = 7; Ryze2.MANA_REGEN = 2;
            Ryze2.TRAIT1 = "Mentor"; Ryze2.TRAIT2 = "Strategist"; Ryze2.TRAIT3 = "Executioner";

            Yuumi2.HP = 1530; Yuumi2.MAX_MANA = 40; Yuumi2.ARMOR = 35; Yuumi2.MR = 35; Yuumi2.AD = 60;
            Yuumi2.ATKS = .75; Yuumi2.MANA_OH = 7; Yuumi2.MANA_REGEN = 2;
            Yuumi2.TRAIT1 = "Prodigy"; Yuumi2.TRAIT2 = "Battle Academia";

            Ashe2.HP = 1530; Ashe2.MAX_MANA = 80; Ashe2.ARMOR = 35; Ashe2.MR = 35; Ashe2.AD = 90;
            Ashe2.ATKS = .8; Ashe2.MANA_OH = 10;
            Ashe2.TRAIT1 = "Crystal Gambit"; Ashe2.TRAIT2 = "Duelist";

            Samira2.HP = 1530; Samira2.MAX_MANA = 15; Samira2.ARMOR = 45; Samira2.MR = 45; Samira2.AD = 75;
            Samira2.ATKS = .75; Samira2.MANA_OH = 7; Samira2.MANA_REGEN = 2;
            Samira2.TRAIT1 = "Edgelord"; Samira2.TRAIT2 = "Soul Fighter";

            Jarvan2.HP = 1980; Jarvan2.MAX_MANA = 150; Jarvan2.ARMOR = 60; Jarvan2.MR = 60; Jarvan2.AD = 90;
            Jarvan2.ATKS = .65; Jarvan2.MANA_OH = 5;
            Jarvan2.TRAIT1 = "Mighty Mech"; Jarvan2.TRAIT2 = "Strategist";

            Ksante2.HP = 1800; Ksante2.MAX_MANA = 90; Ksante2.ARMOR = 60; Ksante2.MR = 60; Ksante2.AD = 90;
            Ksante2.ATKS = .7; Ksante2.MANA_OH = 5;
            Ksante2.TRAIT1 = "Protector"; Ksante2.TRAIT2 = "Wraith";

            Leona2.HP = 2160; Leona2.MAX_MANA = 100; Leona2.ARMOR = 60; Leona2.MR = 60; Leona2.AD = 90;
            Leona2.ATKS = .6; Leona2.MANA_OH = 5;
            Leona2.TRAIT1 = "Bastion"; Leona2.TRAIT2 = "Battle Academia";

            Poppy2.HP = 1980; Poppy2.MAX_MANA = 105; Poppy2.ARMOR = 60; Poppy2.MR = 60; Poppy2.AD = 97;
            Poppy2.ATKS = .6; Poppy2.MANA_OH = 5;
            Poppy2.TRAIT1 = "Heavyweight"; Poppy2.TRAIT2 = "Star Guardian";

            Sett2.HP = 1980; Sett2.MAX_MANA = 100; Sett2.ARMOR = 50; Sett2.MR = 50; Sett2.AD = 90;
            Sett2.ATKS = .7; Sett2.MANA_OH = 5;
            Sett2.TRAIT1 = "Juggernaut"; Sett2.TRAIT2 = "Soul Fighter";

            Volibear2.HP = 1890; Volibear2.MAX_MANA = 40; Volibear2.ARMOR = 65; Volibear2.MR = 65; Volibear2.AD = 97;
            Volibear2.ATKS = .9; Volibear2.MANA_OH = 10; Volibear2.OMNIVAMP = .1;
            Volibear2.TRAIT1 = "EdgeLord"; Volibear2.TRAIT2 = "Luchador";

            Akali2.HP = 1990; Akali2.MAX_MANA = 30; Akali2.ARMOR = 65; Akali2.MR = 65; Akali2.AD = 45;
            Akali2.ATKS = .85; Akali2.MANA_OH = 10;
            Akali2.TRAIT1 = "Executioner"; Akali2.TRAIT2 = "Supreme Cells";


            List<Unit_Holder> list1 = new()
            {
                No_Unit,
                Jinx2,
                Karma2,
                Ryze2,
                Yuumi2,
                Ashe2,
                Samira2,
                Jarvan2,
                Ksante2,
                Leona2,
                Poppy2,
                Sett2,
                Volibear2,
                Akali2
            };



            return list1;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    #region classes
    public class Item_DPS_Obj
    {
        string item_name = "none";

        double item_dps = 0;

        public string ITEM_NAME { get { return item_name; } set { item_name = value; } }

        public double ITEM_DPS { get { return item_dps; } set { item_dps = value; } }
    }

    public class Input_Obj
    {
        

    }

    public class Unit_Holder
    {
        string unit_name = "No_Unit";
        string star = "1";
        double hp = 0;
        double max_mana = 0;
        double armor = 0;
        double mr = 0;
        double ap = 0;
        double ad = 0;
        double crit = .25;
        double crit_multi = .4;
        double atks = 0;
        double mana_oh = 0;
        double omnivamp = 0;
        double mana_regen = 0;
        double mana_count = 0;
        double cast_time = 0;
        double cast_time2 = 0;
        int cost = 0;

        string trait1 = "none";
        string trait2 = "none";
        string trait3 = "none";

        public string STAR { get { return star; } set { star = value; } }
        public string UNIT_NAME { get { return unit_name; } set { unit_name = value; } }
        public int COST { get { return cost; } set { cost = value; } }
        public double CAST_TIME { get { return cast_time; } set { cast_time = value; } }
        public double CAST_TIME2 { get { return cast_time2; } set { cast_time2 = value; } }
        public double MANA_COUNT { get { return mana_count; } set { mana_count = value; } }
        public double HP { get { return hp; } set { hp = value; } }
        public double MAX_MANA { get { return max_mana; } set { max_mana = value; } }
        public double ARMOR { get { return armor; } set { armor = value; } }
        public double MR { get { return mr; } set { mr = value; } }
        public double AP { get { return ap; } set { ap = value; } }
        public double AD { get { return ad; } set { ad = value; } }
        public double CRIT { get { return crit; } set { crit = value; } }
        public double CRIT_MULTI { get { return crit_multi; } set { crit_multi = value; } }
        public double ATKS { get { return atks; } set { atks = value; } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; } }
        public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; } }
        public string TRAIT1 { get { return trait1; } set { trait1 = value; } }
        public string TRAIT2 { get { return trait2; } set { trait2 = value; } }
        public string TRAIT3 { get { return trait3; } set { trait3 = value; } }



    }

    public class Item_Holder
    {

        string item_name = "None";
        double hp = 0;
        double hp_mult = 0;
        double armor = 0;
        double mr = 0;
        double dr = 0;
        double shield = 0;
        double mana_regen = 0;
        double ap = 0;
        double ad = 0;
        double crit = 0;
        double atks = 0;
        double d_amp = 0;
        double omnivamp = 0;
        double mana_oh = 0;
        double sunder = 0;
        double shred = 0;
        double antiheal = 0;
        double gs_flag = 0;
        double rb_flag = 0;
        double aa_flag = 0;
        double kraken_flag = 0;
        double crit_flag = 0;
        double titans_flag = 0;
        double nashors_flag = 0;
        double auto_dr = 0;
        double mana_mult = 0;
        double qss_flag = 0;
        double ie_flag = 0;
        bool above50 = false;
        bool hit_tank = false;

        public string ITEM_NAME { get { return item_name; } set { item_name = value; } }
        public bool HIT_TANK { get { return hit_tank; } set { hit_tank = value; } }
        public bool ABOVE50 { get { return above50; } set { above50 = value; } }
        public double HP { get { return hp; } set { hp = value; } }
        public double HP_MULT { get { return hp_mult; } set { hp_mult = value; } }
        public double ARMOR { get { return armor; } set { armor = value; } }
        public double MR { get { return mr; } set { mr = value; } }
        public double DR { get { return dr; } set { dr = value; } }
        public double SHIELD { get { return shield; } set { shield = value; } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; } }
        public double AP { get { return ap; } set { ap = value; } }
        public double AD { get { return ad; } set { ad = value; } }
        public double CRIT { get { return crit; } set { crit = value; } }
        public double ATKS { get { return atks; } set { atks = value; } }
        public double D_AMP { get { return d_amp; } set { d_amp = value; } }
        public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; } }
        public double SUNDER { get { return sunder; } set { sunder = value; } }
        public double SHRED { get { return shred; } set { shred = value; } }
        public double ANTIHEAL { get { return antiheal; } set { antiheal = value; } }
        public double GS_FLAG { get { return gs_flag; } set { gs_flag = value; } }
        public double RB_FLAG { get { return rb_flag; } set { rb_flag = value; } }
        public double AA_FLAG { get { return aa_flag; } set { aa_flag = value; } }
        public double KRAKEN_FLAG { get { return kraken_flag; } set { kraken_flag = value; } }
        public double CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; } }
        public double TITANS_FLAG { get { return titans_flag; } set { titans_flag = value; } }
        public double NASHORS_FLAG { get { return nashors_flag; } set { nashors_flag = value; } }
        
        public double MANA_MULT { get { return mana_mult; } set { mana_mult = value; } }
        public double QSS_FLAG { get { return qss_flag; } set { qss_flag = value; } }

        public double IE_FLAG { get { return ie_flag; } set { ie_flag = value; } }

        public double AUTO_DR { get { return auto_dr; } set { auto_dr = value; } }
    }


    public class Aug_Holder
    {
        string aug_name = "None";
        double hp = 0;
        double hp_mult = 0;
        double armor = 0;
        double mr = 0;
        double dr = 0;
        double shield = 0;
        double mana_regen = 0;
        double ap = 0;
        double ad = 0;
        double crit = 0;
        double atks = 0;
        double d_amp = 0;
        double omnivamp = 0;
        double crit_flag = 0;
        double more_mult = 0;
        bool ascend_flag = false;
        bool water_lotus = false;
        int lilb = 0;
        int item_n = 0;

        public int LILB { get { return lilb; } set { lilb = value; } }
        public int ITEM_N { get { return item_n; } set { item_n = value; } }
        public string AUG_NAME { get { return aug_name; } set { aug_name = value; } }
        public bool WATER_LOTUS { get { return water_lotus; } set { water_lotus = value; } }
        public bool ASCEND_FLAG { get { return ascend_flag; } set { ascend_flag = value; } }
        public double MORE_MULT { get { return more_mult; } set { more_mult = value; } }
        public double HP { get { return hp; } set { hp = value; } }
        public double HP_MULT { get { return hp_mult; } set { hp_mult = value; } }
        public double ARMOR { get { return armor; } set { armor = value; } }
        public double MR { get { return mr; } set { mr = value; } }
        public double DR { get { return dr; } set { dr = value; } }
        public double SHIELD { get { return shield; } set { shield = value; } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; } }
        public double AP { get { return ap; } set { ap = value; } }
        public double AD { get { return ad; } set { ad = value; } }
        public double CRIT { get { return crit; } set { crit = value; } }
        public double ATKS { get { return atks; } set { atks = value; } }
        public double D_AMP { get { return d_amp; } set { d_amp = value; } }
        public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; } }
        public double CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; } }
    }

    public class Trait_Holder
    {

        double trait_value = 0;
        double potential = 0;
        double hp = 0;
        double hp_mult = 0;
        double armor = 0;
        double mr = 0;
        double dr = 0;
        double shield = 0;
        double mana_regen = 0;
        double ap = 0;
        double ad = 0;
        double crit = 0;
        double crit_mult = 0;
        double atks = 0;
        double d_amp = 0;
        double omnivamp = 0;
        double mana_oh = 0;
        double sunder = 0;
        double shred = 0;
        double antiheal = 0;
        double gs_flag = 0;
        double rb_flag = 0;
        double aa_flag = 0;
        double kraken_flag = 0;
        double mana_regen_mult = 0;
        double crit_flag = 0;
        double titans_flag = 0;
        double nashors_flag = 0;
        double auto_dr = 0;
        double mana_mult = 0;
        double qss_flag = 0;
        double ie_flag = 0;
        double execute = 0;
        bool duelist_flag = false;
        double d_atks = 0;
        double d_cap = 0;
        bool sf_flag = false;
        double sf_ad = 0;
        double sf_t_v = 0;
        bool m_flag = false;
        int targets = 0;
        bool above50 = false;
        bool first10 = false;
        bool shielded = false;

        public bool SHIELDED { get { return shielded; } set { shielded = value; } }
        public bool FIRST10 { get { return first10; } set { first10 = value; } }
        public bool ABOVE50 { get { return above50; } set { above50 = value; } }
        public int TARGETS { get { return targets; } set { targets = value; } }
        public bool M_FLAG { get { return m_flag; } set { m_flag = value; } }
        public double SF_AD { get { return sf_ad; } set { sf_ad = value; } }
        public double SF_T_V { get { return sf_t_v; } set { sf_t_v = value; } }
        public bool SF_FLAG { get { return sf_flag; } set { sf_flag = value; } }
        public double D_CAP { get { return d_cap; } set { d_cap = value; } }
        public double D_ATKS { get { return d_atks; } set { d_atks = value; } }
        public bool DUELIST_FLAG { get { return duelist_flag; } set { duelist_flag = value; } }
        public double POTENTIAL { get { return potential; } set { potential = value; } }
        public double HP { get { return hp; } set { hp = value; } }
        public double HP_MULT { get { return hp_mult; } set { hp_mult = value; } }
        public double ARMOR { get { return armor; } set { armor = value; } }
        public double MR { get { return mr; } set { mr = value; } }
        public double DR { get { return dr; } set { dr = value; } }
        public double SHIELD { get { return shield; } set { shield = value; } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; } }
        public double AP { get { return ap; } set { ap = value; } }
        public double AD { get { return ad; } set { ad = value; } }
        public double CRIT { get { return crit; } set { crit = value; } }
        public double CRIT_MULT { get { return crit_mult; } set { crit_mult = value; } }
        public double ATKS { get { return atks; } set { atks = value; } }
        public double D_AMP { get { return d_amp; } set { d_amp = value; } }
        public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; } }
        public double SUNDER { get { return sunder; } set { sunder = value; } }
        public double SHRED { get { return shred; } set { shred = value; } }
        public double ANTIHEAL { get { return antiheal; } set { antiheal = value; } }
        public double GS_FLAG { get { return gs_flag; } set { gs_flag = value; } }
        public double RB_FLAG { get { return rb_flag; } set { rb_flag = value; } }
        public double AA_FLAG { get { return aa_flag; } set { aa_flag = value; } }
        public double KRAKEN_FLAG { get { return kraken_flag; } set { kraken_flag = value; } }
        public double MANA_REGEN_MULT { get { return mana_regen_mult; } set { mana_regen_mult = value; } }
        public double CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; } }
        public double TITANS_FLAG { get { return titans_flag; } set { titans_flag = value; } }
        public double NASHORS_FLAG { get { return nashors_flag; } set { nashors_flag = value; } }
        public double AUTO_DR { get { return auto_dr; } set { auto_dr = value; } }
        public double MANA_MULT { get { return mana_mult; } set { mana_mult = value; } }
        public double QSS_FLAG { get { return qss_flag; } set { qss_flag = value; } }

        public double IE_FLAG { get { return ie_flag; } set { ie_flag = value; } }
        public double EXECUTE { get { return execute; } set { execute = value; } }
        public double TRAIT_VALUE { get { return trait_value; } set { trait_value = value; } }

    }

    public class Fruit_Holder
    {
        string fruit_name = "None";
        double hp = 0;
        double hp_mult = 0;
        double armor = 0;
        double mr = 0;
        double dr = 0;
        double shield = 0;
        double mana_regen = 0;
        double ap = 0;
        double ad = 0;
        double crit = 0;
        double atks = 0;
        double d_amp = 0;
        double omnivamp = 0;
        double mana_oh = 0;
        double sunder = 0;
        double shred = 0;
        double antiheal = 0;
        double gs_flag = 0;
        double rb_flag = 0;
        double aa_flag = 0;
        double kraken_flag = 0;
        double mana_regen_mult = 0;
        double crit_flag = 0;
        double titans_flag = 0;
        double execute = 0;
        double pot_multi = 0;
        string timed_event = "None";

        public string FRUIT_NAME { get { return fruit_name; } set { fruit_name = value; } }
        public string TIMED_EVENT { get { return timed_event; } set { timed_event = value; } }
        public double POT_MULTI { get { return pot_multi; } set { pot_multi = value; } }
        public double HP { get { return hp; } set { hp = value; } }
        public double HP_MULT { get { return hp_mult; } set { hp_mult = value; } }
        public double ARMOR { get { return armor; } set { armor = value; } }
        public double MR { get { return mr; } set { mr = value; } }
        public double DR { get { return dr; } set { dr = value; } }
        public double SHIELD { get { return shield; } set { shield = value; } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; } }
        public double AP { get { return ap; } set { ap = value; } }
        public double AD { get { return ad; } set { ad = value; } }
        public double CRIT { get { return crit; } set { crit = value; } }
        public double ATKS { get { return atks; } set { atks = value; } }
        public double D_AMP { get { return d_amp; } set { d_amp = value; } }
        public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; } }
        public double SUNDER { get { return sunder; } set { sunder = value; } }
        public double SHRED { get { return shred; } set { shred = value; } }
        public double ANTIHEAL { get { return antiheal; } set { antiheal = value; } }
        public double GS_FLAG { get { return gs_flag; } set { gs_flag = value; } }
        public double RB_FLAG { get { return rb_flag; } set { rb_flag = value; } }
        public double AA_FLAG { get { return aa_flag; } set { aa_flag = value; } }
        public double KRAKEN_FLAG { get { return kraken_flag; } set { kraken_flag = value; } }
        public double MANA_REGEN_MULT { get { return mana_regen_mult; } set { mana_regen_mult = value; } }
        public double CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; } }
        public double TITANS_FLAG { get { return titans_flag; } set { titans_flag = value; } }
        public double EXECUTE { get { return execute; } set { execute = value; } }
    }

    public class MVM_Connector
    {
        
    }

    public class Post_Combat_Stats
    {
        

        #region properties
        int attack_counter = 0;
        int cast_counter = 0;
        int attack_counter15 = 0;
        int cast_counter15 = 0;

        string unit_name = "No_Unit";
        string star = "1";
        
        double auto_dps = 0;
        double cast_dps = 0;
        double p_cast_dps = 0;
        double full_dps = 0;
        double true_damage_dps = 0;

        double auto_dps15 = 0;
        double cast_dps15 = 0;
        double p_cast_dps15 = 0;
        double full_dps15 = 0;
        double true_damage_dps15 = 0;

        double auto_ad = 0;
        double final_atks = 0;
        double shield = 0;

        double hp = 0;
        double hp_mult = 0;
        double armor = 0;
        double mr = 0;

        double healing = 0;

        //
        int targets = 0;
        int style = 0;
        int ashe_counter = 0;

        bool crit_flag = false;
        bool m_flag = false;
        bool ascend_flag = false;
        bool jinx_flag = false;
        bool nashors_e = false;
        bool sf_t = false;
        bool sf_flag = false;
        bool duelist_flag = false;
        bool cast_flag = false;
        bool half_flag = false;
        bool aa_check = false;
        bool attack_flag = false;

        double base_atks = 0;
        double max_mana = 0;
        double base_ad = 0;
        double mana_counter = 0;

        double titans_flag = 0;
        double potential = 0;
        double asi = 0;
        double mana_regen = 0;

        double mana_oh = 0;
        double mana_mult = 0;

        double crit = 0;
        double over_crit = 0;

        double ie_flag = 0;
        double over_cm = 0;
        double ie_cm = 0;
        double crit_flag2 = 0;
        double crit_multi = 0;

        double amp = 0;
        double ad = 0;
        double ap = 0;

        double rb_flag = 0;
        double kraken_flag = 0;
        double aa_flag = 0;

        double nashors_flag = 0;
        double nashors_tracker = 0;
        
        double qss_flag = 0;
        double gs_flag = 0;

        double sf_t_v = 0;
        double sf_ad = 0;

        double duelist_asi = 0;
        double duelist_cap = 0;
        double duelist_track = 0;
        double execute = 0;

        double sunder = 0;
        double shred = 0;
        double omnivamp = 0;

        double true_damage = 0;
        double true_damage_tracker = 0;

        
        double voli_passive = 0;
        double voli_atks = 0;

        double spell_start = 0;

        double atk_time = 0; 

        double time_s = 0;

        double time_e = 0;

        double cast_time = 0;
        double cast_time2 = 0;
        

        double cast_damage_tracker = 0;

        double phys_cast_damage_tracker = 0;

        double auto_damage_tracker = 0;

        double cast_damage = 0;

        double p_cast_damage = 0;

        double auto_damage = 0;


        double armor_dr = 0;

        double mr_dr = 0;

        double tsf = 0;
        double tef = 0;

        double voli_tracker = 0;
        #endregion

        public string UNIT_NAME { get { return unit_name; } set { unit_name = value; } }
        public string STAR { get { return star; } set { star = value; } }
        public double HEALING { get { return healing; } set { healing = value; } }
        public double ARMOR { get { return armor; } set { armor = value; } }
        public double MR { get { return mr; } set { mr = value; } }
        public double HP { get { return hp; } set { hp = value; } }
        public double HP_MULT { get { return hp_mult; } set { hp_mult = value; } }
        public double ARMOR_DR { get { return armor_dr; } set { armor_dr = value; } }
        public double MR_DR { get { return mr_dr; } set { mr_dr = value; } }
        public double CAST_TIME { get { return cast_time; } set { cast_time = value; } }
        public double CAST_TIME2 { get { return cast_time2; } set { cast_time2 = value; } }
        public double TIME_S { get { return time_s; } set { time_s = value; } }
        public double TIME_E { get { return time_e; } set { time_e = value; } }
        public int ASHE_COUNTER { get { return ashe_counter; } set { ashe_counter = value; } }
        public double VOLI_PASSIVE{ get { return voli_passive; } set { voli_passive = value; } }
        public double FINAL_ATKS { get { return final_atks; } set { final_atks = value; } }
        public double AUTO_AD { get { return auto_ad; } set { auto_ad = value; } }
        public double VOLI_ATKS { get { return voli_atks; } set { voli_atks = value; } }
        public double SPELL_START { get { return spell_start; } set { spell_start = value; } }
        public double ATK_TIME { get { return atk_time; } set { atk_time = value; } }
        public double TRUE_DAMAGE { get { return true_damage; } set { true_damage = value; } }
        public double TRUE_DAMAGE_TRACKER { get { return true_damage_tracker; } set { true_damage_tracker = value; } }
        public double EXECUTE { get { return execute; } set { execute = value; } }
        public double DUELIST_ASI { get { return duelist_asi; } set { duelist_asi = value; } }
        public double NASHORS_TRACKER { get { return nashors_tracker; } set { nashors_tracker = value; } }
        public double AP { get { return ap; } set { ap = value; } }
        public double AMP { get { return amp; } set { amp = value; } }
        public double AD { get { return ad; } set { ad = value; } }
        public double CRIT { get { return crit; } set { crit = value; } }
        public double CRIT_MULTI { get { return crit_multi; } set { crit_multi = value; } }
        public double MANA_OH { get { return mana_oh; } set { mana_oh = value; } }
        public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; } }
        public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; } }
        public double ASI { get { return asi; } set { asi = value; } }
        public bool M_FLAG { get { return m_flag; } set { m_flag = value; } }
        public double SF_AD { get { return sf_ad; } set { sf_ad = value; } }
        public double SF_T_V { get { return sf_t_v; } set { sf_t_v = value; } }
        public bool CAST_FLAG { get { return cast_flag; } set { cast_flag = value; } }
        public bool ATTACK_FLAG { get { return attack_flag; } set { attack_flag = value; } }
        public bool NASHORS_E { get { return nashors_e; } set { nashors_e = value; } }
        public bool SF_FLAG { get { return sf_flag; } set { sf_flag = value; } }
        public bool SF_T { get { return sf_t; } set { sf_t = value; } }
        public bool JINX_FLAG { get { return jinx_flag; } set { jinx_flag = value; } }
        public bool DUELIST_FLAG { get { return duelist_flag; } set { duelist_flag = value; } }
        public double POTENTIAL { get { return potential; } set { potential = value; } }
        public double BASE_ATKS { get { return base_atks; } set { base_atks = value; } }
        public double BASE_AD { get { return base_ad; } set { base_ad = value; } }
        public double MAX_MANA { get { return max_mana; } set { max_mana = value; } }
        public double MANA_COUNTER { get { return mana_counter; } set { mana_counter = value; } }
        public bool ASCEND_FLAG { get { return ascend_flag; } set { ascend_flag = value; } }
        public double SUNDER { get { return sunder; } set { sunder = value; } }
        public double SHRED { get { return shred; } set { shred = value; } }
        //public double ANTIHEAL { get { return antiheal; } set { antiheal = value; } }
        public double GS_FLAG { get { return gs_flag; } set { gs_flag = value; } }
        public double RB_FLAG { get { return rb_flag; } set { rb_flag = value; } }
        public double AA_FLAG { get { return aa_flag; } set { aa_flag = value; } }
        public double KRAKEN_FLAG { get { return kraken_flag; } set { kraken_flag = value; } }
        public bool CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; } }
        public double CRIT_FLAG2 { get { return crit_flag2; } set { crit_flag2 = value; } }
        public double TITANS_FLAG { get { return titans_flag; } set { titans_flag = value; } }
        public double NASHORS_FLAG { get { return nashors_flag; } set { nashors_flag = value; } }

        public double MANA_MULT { get { return mana_mult; } set { mana_mult = value; } }
        public double QSS_FLAG { get { return qss_flag; } set { qss_flag = value; } }

        public double IE_FLAG { get { return ie_flag; } set { ie_flag = value; } }

        public double AUTO_DPS { get { return auto_dps; } set { auto_dps = value; } }
        public double CAST_DPS { get { return cast_dps; } set { cast_dps = value; } }
        public double P_CAST_DPS { get { return p_cast_dps; } set { p_cast_dps = value; } }
        public double FULL_DPS { get { return full_dps; } set { full_dps = value; } }
        public double TRUE_DAMAGE_DPS { get { return true_damage_dps; } set { true_damage_dps = value; } }
        public double AUTO_DPS15 { get { return auto_dps15; } set { auto_dps15 = value; } }
        public double CAST_DPS15 { get { return cast_dps15; } set { cast_dps15 = value; } }
        public double P_CAST_DPS15 { get { return p_cast_dps15; } set { p_cast_dps15 = value; } }
        public double FULL_DPS15{ get { return full_dps15; } set { full_dps15 = value; } }
        public double TRUE_DAMAGE_DPS15 { get { return true_damage_dps15; } set { true_damage_dps15 = value; } }
        public int ATTACK_COUNTER { get { return attack_counter; } set { attack_counter = value; } }
        public int ATTACK_COUNTER15 { get { return attack_counter15; } set { attack_counter15 = value; } }
        public int CAST_COUNTER { get { return cast_counter; } set { cast_counter = value; } }
        public int CAST_COUNTER15 { get { return cast_counter15; } set { cast_counter15 = value; } }
        public double CAST_DAMAGE_TRACKER { get { return cast_damage_tracker; } set { cast_damage_tracker = value; } }
        public double PHYS_CAST_DAMAGE_TRACKER { get { return phys_cast_damage_tracker; } set { phys_cast_damage_tracker = value; } }
        public double AUTO_DAMAGE_TRACKER { get { return auto_damage_tracker; } set { auto_damage_tracker = value; } }
        public double CAST_DAMAGE { get { return cast_damage; } set { cast_damage = value; } }
        public double P_CAST_DAMAGE { get { return p_cast_damage; } set { p_cast_damage = value; } }
        public double AUTO_DAMAGE { get { return auto_damage; } set { auto_damage = value; } }
        public bool HALF_FLAG { get { return half_flag; } set { half_flag = value; } }
        public bool AA_CHECK { get { return aa_check; } set { aa_check = value; } }
        public double VOLI_TRACKER{ get { return voli_tracker; } set { voli_tracker = value; } }
        public int STYLE { get { return style; } set { style = value; } }


        

    }


    public class List_Obj
    {

        public static List<string> kat_flist = new()
        {
            "None",
            "Star Student",
            "Not Done Yet",
            "Colossal",
            "Dark Amulet",
            "Over 9000",
            "Unflinching",
            "Blink Attack",
            "On The Edge",
            "Fusion Dance",
            "Scoialite",
            "Hemorrhage",
            "Keen Eye",
            "Fairy Tail",
            "Heros Arc",
            "Final Boss",
            "Magic Expert",
            "Hungry Hero",
            "Weights",
            "Finalist",
            "Tiny Terror",
            "100 Push Ups",
            "Crimson Veil",
            "Max Arcana",
            "Trickster",
            "Midas Touch",
            "Ordinary",
            "Corrupted"

        };

        public List<string> KAT_FLIST { get { return kat_flist; } }

        public static List<string> cait_flist = new()
        {
            "None",
            "Star Student",
            "Sky Piercer",
            "Shadow Clone",
            "Mage",
            "Over 9000",
            "Power Font",
            "Critical Threat",
            "Efficient",
            "Bludgeoner",
            "Gather Force",
            "Solar Breath",
            "Max Attack",
            "Hat Trick",
            "Attack Expert",
            "Cyclone Rush",
            "Precision",
            "Classy",
            "Midas Touch",
            "Ordinary",
            "Max Speed"


        };

        public List<string> CAIT_FLIST { get { return cait_flist; } }

        public static List<string> lucian_flist = new()
        {
            "None",
            "Pursuit",
            "Storm Bender",
            "Mech Pilot",
            "Sky Piercer",
            "Shadow Clone",
            "Mage",
            "Over 9000",
            "Power Font",
            "Demolitionist",
            "Bullet Hell",
            "Critical Threat",
            "Killer Instinct",
            "Keen Eye",
            "Caretaker",
            "Fairy Tail",
            "Essence Share",
            "Solar Breath",
            "Heros Arc",
            "Magic Expert",
            "Hungry Hero",
            "Max Arcana",
            "Robo Range",
            "Classy",
            "Midas Touch"

        };

        public List<string> LUCIAN_FLIST { get { return lucian_flist; } }

        public static List<string> malz_flist = new()
        {
            "None",
            "Storm Bender",
            "Sky Piercer",
            "Shadow Clone",
            "Mage",
            "Power Font",
            "Critical Threat",
            "Killer Instinct",
            "Keen Eye",
            "Caretaker",
            "Fairy Tail",
            "Essence Share",
            "Super Genius",
            "Solar Breath",
            "Magic Expert",
            "Max Arcana",
            "Hat Trick",
            "Classy",
            "Midas Touch"

        };

        public List<string> MALZ_FLIST { get { return malz_flist; } }

        public static List<string> senna_flist = new()
        {
            "None",
            "Storm Bender",
            "Mech Pilot",
            "Sky Piercer",
            "Shadow Clone",
            "Over 9000",
            "Efficient",
            "Bludgeoner",
            "Gather Force",
            "Solar Breath",
            "Max Attack",
            "Hat Trick",
            "Attack Expert",
            "Cyclone Rush",
            "Precision",
            "Midas Touch",
            "Ordinary"

        };

        public List<string> SENNA_FLIST { get { return senna_flist; } }

        public static List<string> akali_flist = new()
        {
            "None",
            "Thrillseeker",
            "Mage",
            "Dark Amulet",
            "Unflinching",
            "Blink Attack",
            "Supremacy",
            "On The Edge",
            "Fusion Dance",
            "Hemorrhage",
            "Keen Eye",
            "Magic Expert",
            "Finalist",
            "Tiny Terror",
            "Crimson Veil",
            "Trickster",
            "Corrupted"

        };

        public List<string> AKALI_FLIST { get { return akali_flist; } }

        public static List<string> ashe_flist = new()
        {
            "None",
            "Frost Touch",
            "Sky Piercer",
            "Shadow Clone",
            "Over 9000",
            "Desperado",
            "Bullet Hell",
            "Critical Threat",
            "Bludgeoner",
            "Doublestrike",
            "Solar Breath",
            "Kahunahuna",
            "Spirit Sword",
            "Attack Expert",
            "Cyclone Rush",
            "Precision",
            "Midas Touch",
            "Ordinary"

        };

        public List<string> ASHE_FLIST { get { return ashe_flist; } }

        public static List<string> jarvan_flist = new()
        {
            "None",
            "Mech Pilot",
            "Resistant",
            "Colossal",
            "Adaptive Skin",
            "Round Two",
            "Stand Alone",
            "Corrosive",
            "Body Change",
            "Inner Fire",
            "Regenerative",
            "Strong Spark",
            "Selfish",
            "Tank-zilla",
            "Robo Ranger",
            "Spiky Shell",
            "Classy",
            "Mana Rush"

        };

        public List<string> JARVAN_FLIST { get { return jarvan_flist; } }

        public static List<string> jinx_flist = new()
        {
            "None",
            "Star Sailor",
            "Storm Bender",
            "Sky Piercer",
            "Hyperactive",
            "Mage",
            "Desperado",
            "Power Font",
            "Critical Threat",
            "Hemorrhage",
            "Golden Edge",
            "Gather Force",
            "Doublestrike",
            "Solar Breath",
            "Ramping RAge",
            "Attack Expert",
            "Cyclone Rush",
            "Precision",
            "Classy",
            "Midas Touch",
            "Ordinary"

        };

        public List<string> JINX_FLIST { get { return jinx_flist; } }

        public static List<string> ksante_flist = new()
        {
            "None",
            "All Out",
            "Resistant",
            "Colossal",
            "Stand Alone",
            "Corrosive",
            "Atomic",
            "Warming Up",
            "Body Change",
            "Fusion Dance",
            "Inner Fire",
            "Regenerative",
            "Pure Heart",
            "Selfish",
            "Weights",
            "Tank-zilla",
            "Unstoppable",
            "Spiky Shell",
            "Ordinary"
        };

        public List<string> KSANTE_FLIST { get { return ksante_flist; } }

        public static List<string> karma_flist = new()
        {
            "None",
            "Storm Bender",
            "Mech Pilot",
            "Sky Piercer",
            "Shadow Clone",
            "Mage",
            "Soul Chipper",
            "Power Font",
            "Critical Threat",
            "Efficient",
            "Keen Eye",
            "Caretaker",
            "Esence Share",
            "Super Genius",
            "Solar Breath",
            "Magic Expert",
            "Robo Ranger",
            "Classy",
            "Midas Touch"

        };

        public List<string> KARMA_FLIST { get { return karma_flist; } }

        public static List<string> leona_flist = new()
        {
            "None",
            "Star Student",
            "Resistant",
            "Colossal",
            "Round Two",
            "Stand Alone",
            "Corrosive",
            "Atomic",
            "Body Change",
            "Inner Fire",
            "Regenerative",
            "Pure Heart",
            "Selfish",
            "Tank-zilla",
            "Living Wall",
            "Unstoppable",
            "Spiky Shell",
            "Classy"

        };

        public List<string> LEONA_FLIST { get { return leona_flist; } }

        public static List<string> poppy_flist = new()
        {
            "None",
            "Star Sailor",
            "Colossal",
            "Singularity",
            "Adaptive Skin",
            "Stand Alone",
            "Corrosive",
            "Best Defense",
            "Atomic",
            "Body Change",
            "Inner Fire",
            "Regenerative",
            "Strong Spark",
            "Pure Heart",
            "Tank-zilla",
            "Unstoppable",
            "Spiky Shell",
            "Classy"

        };

        public List<string> POPPY_FLIST { get { return poppy_flist; } }

        public static List<string> ryze_flist = new()
        {
            "None",
            "Ice Bender",
            "Storm Bender",
            "Sky Piercer",
            "Shadow Clone",
            "Soul Chipper",
            "Critical Threat",
            "Efficient",
            "Killer Instinct",
            "Keen Eye",
            "Super Genius",
            "Solar Breath",
            "Magic Expert",
            "Annihilation",
            "Classy",
            "Midas Touch"

        };

        public List<string> RYZE_FLIST { get { return ryze_flist; } }

        public static List<string> samira_flist = new()
        {
            "None",
            "Storm Bender",
            "Sky Piercer",
            "Shadow Clone",
            "On The Edge",
            "Critical Threat",
            "Killer Instinct",
            "Bludgeoner",
            "Fairy Tail",
            "Essence Share",
            "Gather Force",
            "Solar Breath",
            "Finalist",
            "Crimson Veil",
            "Attack Expert",
            "Cyclone Rush",
            "Precision",
            "Midas Touch",
            "Ordinary"

        };

        public List<string> SAMIRA_FLIST { get { return samira_flist; } }

        public static List<string> sett_flist = new()
        {
            "None",
            "Resistance",
            "Colossal",
            "Adaptive Skin",
            "Round Two",
            "Stand Alone",
            "Corrosive",
            "Best Defense",
            "Atomic",
            "Body Change",
            "Inner Fire",
            "Regenerative",
            "Strong Spark",
            "Pure Heart",
            "Selfish",
            "Tank-zilla",
            "Spiky Shell"
        };

        public List<string> SETT_FLIST { get { return sett_flist; } }

        public static List<string> voli_flist = new()
        {
            "None",
            "Thrillseeker",
            "Colossal",
            "Unflinching",
            "Serious Slam",
            "On The Edge",
            "Warming Up",
            "Fusion Dance",
            "Bludgeoner",
            "Bladenado",
            "Doublestrike",
            "Final Boss",
            "Stretchy Arms",
            "Weights",
            "Finalist",
            "Tiny Terror",
            "Attack Expert",
            "Classy",
            "Trickster",
            "Midas Touch",
            "Ordinary",
            "Corrupted"

        };

        public List<string> VOLI_FLIST { get { return voli_flist; } }

        public static List<string> yuumi_flist = new()
        {
            "None",
            "Star Student",
            "Storm Bender",
            "Sky Piercer",
            "Power Font",
            "Bullet Hell",
            "Critical Threat",
            "Keen Eye",
            "Caretaker",
            "Fairy Tail",
            "Essence Share",
            "Super Genius",
            "Solar Breath",
            "Magic Expert",
            "Classy",
            "Midas Touch"

        };

        public List<string> YUUMI_FLIST { get { return yuumi_flist; } }
        public static List<string> g_auglist = new()
        {
            "None",
            "PairOfFours",
            "BestFriends2",
            "LittleBuddies",
            "MacesWill",
            "Preparation2",
            "ScoreboardScrapper",
            "BackUpDancers",
            "BlazingSoul2",
            "GlassCannon2",
            "CyberImplants2",
            "CyberUplink2",
            "ItemCollector2",
            "KnowYourEnemy",
            "PumpingUp2",
            "SpearsWill",
            "WaterLotus",
            "Ascension"
        };

        public List<string> G_AUGLIST { get { return g_auglist; } }

        public static List<string> s_auglist = new()
        {
            "None",
            "silver"
        };

        public List<string> S_AUGLIST { get { return s_auglist; } }

        public static List<string> p_auglist = new()
        {
            "None",
            "prismatic"
        };

        public List<string> P_AUGLIST { get { return p_auglist; } }

        // ad items
        public static List<string> itemlist2 = new()
         {
            "None",
            "Deathblade",
            "Giantslayer",
            "InfinityEdge",
            "Shojin",
            "LastWhisper",
            "Kraken",
            "HandOfJustice",
            "Titans",
            "BloodThirster",
            "Gunblade",
            "EdgeOfNight"
        };

        //tank items
        public List<string> ITEMLIST2 { get { return itemlist2; } }

        public static List<string> itemlist3 = new()
        {
            "None",
            "Warmogs",
            "SpiritVisage",
            "Bramble",
            "DragonClaw",
            "ProtectorsVow",
            "SteadfastHeart",
            "Crownguard",
            "Stoneplate",
            "AdaptiveFront",
            "Spark",
            "EvenShroud",
            "Sunfire"
        };

        public List<string> ITEMLIST3 { get { return itemlist3; } }

        // ap/as
        public static List<string> itemlist = new()
        {
            "None",
            "Archangels",
            "Deathcap",
            "JeweledGauntlet",
            "VoidStaff",
            "Rageblade",
            "BlueBuff",
            "Nashor",
            "StrikersFlail",
            "AdaptiveBack",
            "Morello",
            "Gunblade",
            "Redbuff",
            "QuickSilver",
        };
        public List<string> ITEMLIST { get { return itemlist; } }

        public static List<string> unitlist3 = new()
        {
            "No_Unit",
            "Malzahar",
            "Caitlyn",
            "Senna",
            "Smolder"
        };
        public List<string> UNITLIST3 { get { return unitlist3; } }

        public static List<string> unitlist2 = new()
        {
            "No_Unit",
            "Katarina"
        };
        public List<string> UNITLIST2 { get { return unitlist2; } }

        public static List<string> unitlist1 = new()
        {
            "No_Unit",
            "Lucian"
        };
        public List<string> UNITLIST1 { get { return unitlist1; } }

        
        public static List<string> unitlist4 = new()
        {
            "No_Unit",
            "Jinx",
            "Karma",
            "Ryze",
            "Yuumi",
            "Ashe",
            "Samira",
            "Jarvan",
            "Ksante",
            "Leona",
            "Poppy",
            "Sett",
            "Volibear",
            "Akali"
        };

        public List<string> UNITLIST4 { get { return unitlist4; } }

        public static List<string> unitlist5 = new()
        {
        "No_Unit",
        "5 cost"
        };
        public List<string> UNITLIST5 { get { return unitlist5; } }

        public List<string> starlist = new()
            {
                "1",
                "2",
                "3"
            };
        public List<string> STARLIST { get { return starlist; } }

        


    }
    



        #endregion
    }
