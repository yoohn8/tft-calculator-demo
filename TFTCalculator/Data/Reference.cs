using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static TFTCalculator.Data.Reference;

namespace TFTCalculator.Data
{
    internal class Reference
    {
        public class Calc_Methods
        {

            public (int, int)
                FightSim(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                    Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3, string star, string unit, Trait_Holder traits)
            {
                double base_ad = uobj.AD;

                double base_atks = uobj.ATKS;

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




                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                    auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                    inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen)
                    = Combat_Method(uobj, item1, item2, item3, aug1, aug2, aug3, star, unit, traits);

                (phys_EHP, magic_EHP, final_hp, final_phys_dr, final_magic_dr, armor, mr) =
                    EHP_calc(uobj, item1, item2, item3, aug1, aug2, aug3);




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



                return (attack_counter, cast_counter);

            }

            private static (double, double, double, double, double, int, int, double, double, double,
                        double, double, int, int, double, double, double, double, double, double,
                        double, double, double, double)
                Combat_Method(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                          Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3,
                          string star, string unit, Trait_Holder traits)
            {
                double base_atks = uobj.ATKS;
                double max_mana = uobj.MAX_MANA;
                double base_ad = uobj.AD;

                double asi = item1.ATKS + item2.ATKS + item3.ATKS + aug1.ATKS + aug2.ATKS + aug3.ATKS;
                double mana_regen = uobj.MANA_REGEN + item1.MANA_REGEN + item2.MANA_REGEN + item3.MANA_REGEN + aug1.MANA_REGEN + aug2.MANA_REGEN + aug3.MANA_REGEN;

                double mana_hit = uobj.MANA_OH + item1.MANA_OH + item2.MANA_OH + item3.MANA_OH;
                double crit = uobj.CRIT + item1.CRIT + item2.CRIT + item3.CRIT + aug1.CRIT + aug2.CRIT + aug3.CRIT;
                // uobj.CRIT + + aug1.CRIT + aug2.CRIT + aug3.CRIT; item1.CRIT + item2.CRIT + 
                double crit_multi = .4;

                double amp = item1.D_AMP + item2.D_AMP + item3.D_AMP + aug1.D_AMP + aug2.D_AMP + aug3.D_AMP;
                double inc_ad = item1.AD + item2.AD + item3.AD + aug1.AD + aug2.AD + aug3.AD;
                double ap = item1.AP + item2.AP + item3.AP + aug1.AP + aug2.AP + aug3.AP;
                double crit_flag = item1.CRIT_FLAG + item2.CRIT_FLAG + item3.CRIT_FLAG + aug1.CRIT_FLAG + aug2.CRIT_FLAG + aug3.CRIT_FLAG;
                double rb_flag = item1.RB_FLAG + item2.RB_FLAG + item3.RB_FLAG;
                //double rb_flag = 0;
                double kraken_flag = item1.KRAKEN_FLAG + item2.KRAKEN_FLAG + item3.KRAKEN_FLAG;
                double aa_flag = item1.AA_FLAG + item2.AA_FLAG + item3.AA_FLAG;
                bool duelist_flag = false;
                bool jinx_flag = false;
                double trait1 = traits.TRAIT1_VALUE;
                double trait2 = traits.TRAIT2_VALUE;
                double trait3 = traits.TRAIT3_VALUE;

                double nashors_flag = item1.NASHORS_FLAG + item2.NASHORS_FLAG + item3.NASHORS_FLAG;

                /*
                double trait1 = disp.TRAIT1_VALUE;
                double trait2 = disp.TRAIT2_VALUE;
                double trait3 = disp.TRAIT3_VALUE;
                */

                double sunder = item1.SUNDER + item2.SUNDER + item3.SUNDER;
                double shred = item1.SHRED + item2.SHRED + item3.SHRED;
                double omnivamp = uobj.OMNIVAMP + item1.OMNIVAMP + item2.OMNIVAMP + item3.OMNIVAMP + aug1.OMNIVAMP + aug2.OMNIVAMP + aug3.OMNIVAMP;

                double true_damage = 0;
                double true_damage_dps = 0;
                double true_damage_tracker = 0;
                double true_damage_dps15 = 0;

                double mana_counter15 = 0;
                double duelist_asi = 0;
                double duelist_cap = 0;
                double duelist_track = 0;
                int ashe_counter = 0;
                double voli_passive = 0;
                double voli_atks = 0;

                double spell_start = 0;

                double j_track = 0; // track jinx's ability attack speed increase

                double d_dtrack = 0; // track duelist attack speed increase

                double atk_time = Attack_Time_calc(base_atks, asi); // in1 is base attack speed

                double mana_counter = 0;

                double attack_checker = atk_time;

                double time_s = 0;

                double time_e = atk_time;

                int attack_counter = 0;

                int cast_counter = 0;

                bool cast_flag = false;

                int i = 0;

                int rb_counter = 0;

                double cast_damage_tracker = 0;

                double phys_cast_damage_tracker = 0;

                double auto_damage_tracker = 0;

                double cast_damage = 0;

                double p_cast_damage = 0;

                double auto_damage = 0;

                bool attack_flag = false;

                double auto_dps = 0;

                double cast_dps = 0;

                double phys_cast_dps = 0;

                double full_dps = 0;

                double auto_dps15 = 0;

                double cast_dps15 = 0;

                double phys_cast_dps15 = 0;

                int attack_counter15 = 0;

                int cast_counter15 = 0;

                double full_dps15 = 0;

                double final_inc_ad = 0;

                double final_atks = 0;

                double final_ad = 0;

                int break_counter = 0;

                double armor_dr = 0;

                double mr_dr = 0;

                double tsf = 0;
                double tef = 0;

                double potential = 0;

                bool half_flag = false;

                bool aa_check = false;


                bool nashors_e = false;

                double nashors_atks = .3;

                double nashors_tracker = 0;

                switch (unit) // resolve unit specific
                {
                    case "No_Unit":
                        break;

                    case "Jinx":
                        // trait value 1 = sniper
                        // trait value 2 = star guardian
                        // no 3rd trait
                        // ADD STAR GUARDIAN
                        if (trait1 == 2)
                        {
                            amp += .25;
                        }
                        else if (trait1 == 3)
                        {
                            amp += .36;
                        }
                        else if (trait1 == 4)
                        {
                            amp += .57;
                        }
                        else if (trait1 >= 5)
                        {
                            amp += .65;
                        }
                        //base_atks
                        while (time_s < 30)
                        {
                            // attack event
                            //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                            //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase
                            (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap,
                                half_flag)
                                = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, duelist_flag, true, break_counter, ap, half_flag);
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);

                            if (attack_flag == true)
                            {
                                // calc auto damage here
                                auto_damage = Auto_Damage_Calc(crit, crit_multi, base_ad, inc_ad, amp);
                                //attack_counter += 1;
                                auto_damage_tracker += auto_damage;

                                if (nashors_e && (time_e - nashors_tracker < 5))
                                {
                                    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                                }

                            }
                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                            }


                            if (cast_flag == true)
                            {
                                (time_s, time_e, cast_counter, ap, asi, half_flag) =
                                    Base_Cast_event(time_s, time_e, cast_counter, atk_time, aa_flag, ap, rb_flag, asi, base_atks, 1,
                                                    half_flag);
                                //cast_flag = false; // reset cast flag (double crit, double crit_multi, , double ad, double amp, double crit_flag, string star)
                                p_cast_damage = Jinx_Spell_Damage_Calc(crit, crit_multi, inc_ad, amp, crit_flag, star);
                                phys_cast_damage_tracker += p_cast_damage;

                                if (nashors_flag > 0)
                                {
                                    nashors_e = true;
                                    nashors_tracker = time_s;
                                    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                                }

                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                            }

                        }

                        break;

                    case "Karma":
                        // trait 1 mighty mech
                        // trait 2 = sorc

                        if (trait2 == 2)
                        {
                            ap += .2;
                        }
                        else if (trait2 == 4)
                        {
                            ap += .5;
                        }
                        else if (trait2 == 6)
                        {
                            ap += .9;
                        }

                        //base_atks
                        while (time_s < 30)
                        {
                            // attack event
                            //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                            //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase
                            (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap,
                                half_flag)
                                = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, duelist_flag, false, break_counter, ap, half_flag);
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);

                            if (attack_flag == true)
                            {
                                // calc auto damage here
                                auto_damage = Auto_Damage_Calc(crit, crit_multi, base_ad, inc_ad, amp);
                                //attack_counter += 1;
                                auto_damage_tracker += auto_damage;
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                            }

                            if (cast_flag == true)
                            {
                                (time_s, time_e, cast_counter, ap, asi, half_flag) =
                                    Base_Cast_event(time_s, time_e, cast_counter, atk_time, aa_flag, ap, rb_flag, asi, base_atks, 1,
                                                    half_flag);
                                //cast_flag = false; // reset cast flag (double crit, double crit_multi, , double ad, double amp, double crit_flag, string star)
                                cast_damage = Karma_Spell_Damage_Calc(crit, crit_multi, amp, crit_flag, star, ap);
                                cast_damage_tracker += cast_damage;
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                            }



                        }
                        break;
                    case "Ryze":
                        // trait 1 mentor
                        // trait 2 = Executioner
                        // trait 3 = strategist
                        if (trait1 == 1)
                        {
                            mana_hit += 2;
                        }
                        else if (trait1 == 4)
                        {
                            inc_ad += .08;
                            ap += .08;
                            mana_hit += 2;
                            asi += .1;
                        }

                        if (trait2 == 2)
                        {
                            crit_flag += 1;
                            crit += .25;
                            crit_multi += .1;
                        }
                        else if (trait2 == 3)
                        {
                            crit_flag += 1;
                            crit += .35;
                            crit_multi += .12;
                        }
                        else if (trait2 == 4)
                        {
                            crit_flag += 1;
                            crit += 5;
                            crit_multi += .18;
                        }
                        else if (trait2 == 5)
                        {
                            crit_flag += 1;
                            crit += 55;
                            crit_multi += .28;
                        }

                        if (trait3 == 2)
                        {
                            amp += .12;
                        }
                        else if (trait3 == 3)
                        {
                            amp += .18;
                        }
                        else if (trait3 == 4)
                        {
                            amp += .3;
                        }
                        else if (trait3 == 5)
                        {
                            amp += .42;
                        }

                        //base_atks
                        while (time_s < 30)
                        {
                            // attack event
                            //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                            //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase
                            //         (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap)
                            //              = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                            //                             rb_flag, kraken_flag, aa_flag, duelist_flag, false, break_counter, ap);
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);
                            (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap,
                                half_flag)
                                = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, duelist_flag, false, break_counter, ap, half_flag);
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);

                            if (attack_flag == true)
                            {
                                // calc auto damage here
                                auto_damage = Auto_Damage_Calc(crit, crit_multi, base_ad, inc_ad, amp);
                                //attack_counter += 1;
                                auto_damage_tracker += auto_damage;
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                                mana_counter15 = mana_counter;
                            }

                            if (cast_flag == true)
                            {
                                (time_s, time_e, cast_counter, ap, asi, half_flag) =
                                    Base_Cast_event(time_s, time_e, cast_counter, atk_time, aa_flag, ap, rb_flag, asi, base_atks, 3,
                                                    half_flag);
                                //cast_flag = false; // reset cast flag (double crit, double crit_multi, , double ad, double amp, double crit_flag, string star)
                                cast_damage = Ryze_Spell_Damage_Calc(crit, crit_multi, amp, crit_flag, star, ap, 1);
                                cast_damage_tracker += cast_damage;
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                            }



                        }
                        break;
                    case "Yuumi":
                        // trait 1 Prodigy
                        // trait 2 = Battle Academia

                        if (trait1 == 2)
                        {
                            mana_regen += 3;
                        }
                        else if (trait1 == 3)
                        {
                            mana_regen += 5;
                        }
                        else if (trait1 == 4)
                        {
                            mana_regen += 7;
                        }
                        else if (trait1 == 5)
                        {
                            mana_regen += 9;
                        }

                        if (trait2 == 3)
                        {
                            potential += 3;
                        }
                        else if (trait2 == 5)
                        {
                            potential += 5;
                        }
                        else if (trait2 == 7)
                        {
                            potential += 7;
                        }

                        //base_atks
                        while (time_s < 30)
                        {
                            // attack event
                            //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                            //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase
                            (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap,
                                half_flag)
                                = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, duelist_flag, false, break_counter, ap, half_flag);
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);

                            if (attack_flag == true)
                            {
                                // calc auto damage here
                                auto_damage = Auto_Damage_Calc(crit, crit_multi, base_ad, inc_ad, amp);
                                //attack_counter += 1;
                                auto_damage_tracker += auto_damage;

                                if (nashors_e && (time_e - nashors_tracker < 5))
                                {
                                    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                                }
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                                mana_counter15 = mana_counter;
                                true_damage_dps15 = true_damage_tracker / 15;
                            }

                            if (cast_flag == true)
                            {
                                (time_s, time_e, cast_counter, ap, asi, half_flag) =
                                    Base_Cast_event(time_s, time_e, cast_counter, atk_time, aa_flag, ap, rb_flag, asi, base_atks, 1,
                                                    half_flag);
                                //cast_flag = false; // reset cast flag (double crit, double crit_multi, , double ad, double amp, double crit_flag, string star)
                                (cast_damage, true_damage) = Yuumi_Spell_Damage_Calc(crit, crit_multi, ap, amp, crit_flag, star, potential, cast_counter);
                                cast_damage_tracker += cast_damage;
                                true_damage_tracker += true_damage;

                                if (nashors_flag > 0)
                                {
                                    nashors_e = true;
                                    nashors_tracker = time_s;
                                    atk_time = Attack_Time_calc(base_atks, asi + (nashors_atks * nashors_flag));
                                }
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                                true_damage_dps15 = true_damage_tracker / 15;
                            }



                        }
                        break;
                    case "Ashe":
                        // trait 1 crystal gambit
                        // trait 2 = duelist

                        if (trait1 == 7)
                        {
                            //hp += 300;
                            amp += .25;
                        }

                        if (trait2 == 2)
                        {
                            duelist_flag = true;
                            duelist_asi = .04;
                            duelist_cap = .48;
                        }
                        else if (trait2 == 4)
                        {
                            duelist_asi = .07;
                            duelist_flag = true;
                            duelist_cap = .84;
                        }
                        else if (trait2 == 6)
                        {
                            duelist_asi = .1;
                            duelist_flag = true;
                            duelist_cap = 1.2;
                            // dr increases by 12
                        }

                        //base_atks
                        while (time_s < 30) // implement ashes spell lasting 8 auto attacks
                        {
                            // attack event
                            //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                            //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase
                            /*(time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, break_counter, attack_flag, ap,
                                half_flag)
                                = Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, j_track, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, duelist_flag, false, break_counter, ap, half_flag, duelist_asi, duelist_cap);
                            */
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);
                            (time_s, time_e, cast_flag, mana_counter, asi, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, attack_flag, ap,
                                half_flag, cast_counter, cast_flag, ashe_counter)
                               = Ashe_Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, ap, half_flag, cast_counter, cast_flag, ashe_counter, duelist_flag, duelist_asi
                                    );

                            if (attack_flag == true)
                            {
                                // calc auto damage here
                                auto_damage = Auto_Damage_Calc(crit, crit_multi, base_ad, inc_ad, amp);
                                //attack_counter += 1;
                                auto_damage_tracker += auto_damage;

                                if (cast_flag)
                                {

                                    phys_cast_damage_tracker += Ashe_Spell_Damage_Calc(crit, crit_multi, amp, crit_flag, star, inc_ad, asi, ap);
                                }
                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                            }


                        }
                        break;
                    case "Samira":
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
                        // trait 1 edgelord
                        // trait 2 = luchador

                        // implement is the enemy under 50% hp?

                        if (trait1 == 2)
                        {
                            //hp += 300;
                            asi += .1;
                            inc_ad += .15;
                        }
                        else if (trait1 == 4)
                        {
                            asi += .12;
                            inc_ad += .35;
                        }
                        else if (trait1 == 6)
                        {
                            asi += .15;
                            inc_ad += .5;
                        }

                        if (trait2 == 2)
                        {
                            inc_ad += .15;
                        }
                        else if (trait2 == 4)
                        {
                            inc_ad += .4;
                        }

                        //Voli_Spell_Damage_Calc();

                        //base_atks
                        while (time_s < 30) // implement ashes spell lasting 8 auto attacks
                        {
                            // attack event
                            //Attack_event(double in1, double in2, double in3, double in4, double in5, double in6, double in7, double in8, double in9, double in10, double in11)

                            //in1 time start, in2 time end, in3 atk time, in4 base s, in5 mana r, in6 max mana, in7 mana counter, in9 mana on hit, in10 j_track, in11 attack speed increase

                            (time_s, time_e, cast_flag, mana_counter, asi, atk_time, attack_counter, rb_counter, mana_counter, inc_ad, attack_flag, ap,
                                half_flag, cast_counter, cast_flag, spell_start, voli_atks)
                            // Voli_Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, asi, attack_counter, rb_counter, inc_ad,
                            //  rb_flag, kraken_flag, aa_flag, ap, half_flag, cast_counter, cast_flag, spell_start, voli_atks);
                            = Voli_Attack_event(time_s, time_e, atk_time, base_atks, mana_regen, max_mana, mana_counter, mana_hit, asi, attack_counter, rb_counter, inc_ad,
                                               rb_flag, kraken_flag, aa_flag, ap, half_flag, cast_counter, cast_flag, spell_start, voli_atks);
                            //rb_flag, kraken_flag, aa_flag, duelist_flag, jinx_flag);




                            if (attack_flag == true)
                            {
                                // calc auto damage here
                                auto_damage = Auto_Damage_Calc(crit, crit_multi, base_ad, inc_ad, amp);
                                //attack_counter += 1;

                                if ((attack_counter % 4) == 0)
                                {
                                    voli_passive = Voli_Spell_Damage_Calc(star, amp, crit, crit_multi, inc_ad);
                                }

                                auto_damage_tracker += auto_damage + voli_passive;


                            }

                            if (half_flag)
                            {
                                auto_dps15 = auto_damage_tracker / 15;
                                phys_cast_dps15 = phys_cast_damage_tracker / 15;
                                cast_dps15 = cast_damage_tracker / 15;
                                attack_counter15 = attack_counter;
                                cast_counter15 = cast_counter;
                                mana_counter15 = mana_counter;
                            }



                        }
                        break;
                    case "Akali":
                        break;

                    default:
                        break;
                }


                double dummy_armor = 100;
                double dummy_mr = 100;

                if (sunder > 0)
                {
                    dummy_armor = 70;
                }
                if (shred > 0)
                {
                    dummy_mr = 70;
                }


                armor_dr = Armor_DR_calc(dummy_armor);

                mr_dr = Magic_DR_calc(dummy_mr);

                // disp outputs


                auto_dps = auto_damage_tracker / 30;
                phys_cast_dps = phys_cast_damage_tracker / 30;
                cast_dps = cast_damage_tracker / 30;
                true_damage_dps = true_damage_tracker / 30;

                auto_dps = auto_dps - (auto_dps * armor_dr);
                phys_cast_dps = phys_cast_dps - (phys_cast_dps * armor_dr);
                cast_dps = cast_dps - (cast_dps * mr_dr);

                auto_dps15 = auto_dps15 - (auto_dps15 * armor_dr);
                phys_cast_dps15 = phys_cast_dps15 - (phys_cast_dps15 * armor_dr);
                cast_dps15 = cast_dps15 - (cast_dps15 * mr_dr);

                full_dps = auto_dps + phys_cast_dps + cast_dps + true_damage_dps;
                full_dps15 = auto_dps15 + phys_cast_dps15 + cast_dps15 + true_damage_dps15;

                //final_ad = ase_ad * (1 + inc_ad);



                return (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                        auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                        inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen
                        );
            }

            // TANK STATS

            private static (double, double, double, double, double, double, double)
            EHP_calc(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                          Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3
                          )
            //string star, string unit, Trait_Holder traits
            {
                double base_hp = uobj.HP;
                double item_hp = item1.HP + item2.HP + item3.HP + aug1.HP + aug2.HP + aug3.HP;
                double hp_mult = item1.HP_MULT + item2.HP_MULT + item3.HP_MULT + aug1.HP_MULT + aug2.HP_MULT + aug3.HP_MULT;
                double armor = uobj.ARMOR + item1.ARMOR + item2.ARMOR + item3.ARMOR + aug1.ARMOR + aug2.ARMOR + aug3.ARMOR;
                double mr = uobj.MR + item1.MR + item2.MR + item3.MR + aug1.MR + aug2.MR + aug3.MR;
                double item1_dr = item1.DR;
                double item2_dr = item2.DR;
                double item3_dr = item3.DR;

                double h = 1;
                double phys_EHP;
                double magic_EHP;

                double final_hp = HP_calc(base_hp, item_hp, hp_mult);

                double armor_dr = Armor_DR_calc(armor);

                double mr_dr = Magic_DR_calc(mr);

                double final_phys_dr = DR_calc(armor_dr, item1_dr, item2_dr, item3_dr, 0);

                double final_magic_dr = DR_calc(mr_dr, item1_dr, item2_dr, item3_dr, 0);

                phys_EHP = final_hp / (h - final_phys_dr);

                magic_EHP = final_hp / (h - final_magic_dr);


                return (phys_EHP, magic_EHP, final_hp, final_phys_dr, final_magic_dr, armor, mr);
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
            private static double DR_calc(double in1, double in2, double in3, double in4, double in5)
            {
                double h = 1;
                double h1;
                double h2;
                double h3;
                double h4, h5;
                //return in1 + (in1 * in2) + (in1 * in2 * in3) + (in1 * in2 * in3 * in4);
                //return in1 + (in1 * in2) + (in1 * in3) + (in1 * in4);
                h1 = h - (h * in1);
                h2 = h1 - (h1 * in2);
                h3 = h2 - (h2 * in3);
                h4 = h3 - (h3 * in4);
                h5 = h4 - (h4 * in5);
                //return h1 - h2 - h3 - h4;
                return h - h5;
            }


            // ATTACK EVENTS

            private static (double, double, bool, double, double, double, double, int, int, double, double, int, bool, double, bool)
            Attack_event(double time_s, double time_e, double atk_time, double base_a, double mana_r, double max_mana, double mana_counter,
                            double mana_oh, double j_track, double asi, int attack_counter, int rb_counter, double ad,
                            double rb_flag, double kraken_flag, double aa_flag, bool duelist_flag, bool jinx_flag, int break_counter, double ap,
                            bool half_flag
            )
            {

                double tsf = Math.Floor(time_s);
                double tef = Math.Floor(time_e);


                double loop_amount = tef - tsf;


                double j_cap = .6 * (1 + ap);

                bool cast_flag = false;

                bool attack_flag = false;

                //mana_counter += mana_oh;

                double mana_r2 = mana_r / 2;

                double r_counter = 0;

                bool aa_check = false;

                r_counter = Mana_Regen_Counter(time_s, time_e);

                if (aa_flag > 0)
                {
                    aa_check = AA_Counter(time_s, time_e);
                    if (aa_check)
                    {
                        ap += .3 * aa_flag;
                    }
                }

                if ((tsf < 15) && (tef >= 15))
                {

                    half_flag = true;
                }
                else half_flag = false;


                // rage blade
                if (rb_flag > 0)
                {
                    for (int i = 0; i < loop_amount; i++)
                    {
                        asi += .07 * rb_flag;
                        rb_counter += 1;
                        atk_time = Attack_Time_calc(base_a, asi);
                    }
                }






                if (jinx_flag && (j_track < j_cap)) // jinx atk speed per auto
                {
                    j_track += .06 * (1 + ap);
                    asi += .06 * (1 + ap);
                    atk_time = Attack_Time_calc(base_a, asi);
                }

                if (kraken_flag > 0)
                {
                    ad += .03 * kraken_flag;
                }


                time_s = time_e;
                time_e = time_e + atk_time;
                mana_counter += (mana_r2 * r_counter) + mana_oh;
                attack_flag = true;
                if (mana_counter >= max_mana)
                {
                    cast_flag = true;
                    mana_counter -= max_mana; // overflow mana
                }
                attack_counter += 1;





                return (time_s, time_e, cast_flag, mana_counter, asi, j_track, atk_time, attack_counter, rb_counter, mana_counter, ad, break_counter, attack_flag, ap,
                        half_flag);
            }

            private static (double, double, bool, double, double, double, int, int, double, double, bool, double, bool, int, bool, int)
                Ashe_Attack_event(double time_s, double time_e, double atk_time, double base_a, double mana_r, double max_mana, double mana_counter,
                                double mana_oh, double asi, int attack_counter, int rb_counter, double ad,
                                double rb_flag, double kraken_flag, double aa_flag, double ap,
                                bool half_flag, int cast_counter, bool cast_flag, int ashe_counter, bool duelist_flag, double duelist_asi
                )
            {

                double tsf = Math.Floor(time_s);
                double tef = Math.Floor(time_e);


                double loop_amount = tef - tsf;




                bool attack_flag = false;

                //mana_counter += mana_oh;

                double mana_r2 = mana_r / 2;

                double r_counter = 0;

                bool aa_check = false;



                r_counter = Mana_Regen_Counter(time_s, time_e);

                if (cast_flag && ((ashe_counter) == 8))
                {
                    cast_flag = false;
                    ashe_counter = 0;

                }

                if (aa_flag > 0)
                {
                    aa_check = AA_Counter(time_s, time_e);
                    if (aa_check)
                    {
                        ap += .3 * aa_flag;
                    }
                }

                if ((tsf < 15) && (tef >= 15))
                {

                    half_flag = true;
                }
                else half_flag = false;


                // rage blade
                if (rb_flag > 0)
                {
                    for (int i = 0; i < loop_amount; i++)
                    {
                        asi += .07 * rb_flag;
                        rb_counter += 1;
                        atk_time = Attack_Time_calc(base_a, asi);
                    }
                }

                if (duelist_flag && (attack_counter < 12))
                {
                    asi += duelist_asi;
                    atk_time = Attack_Time_calc(base_a, asi);
                }

                // mana regen during auto event



                if (kraken_flag > 0)
                {
                    ad += .03 * kraken_flag;
                }



                if (cast_flag) // mana lock
                {

                    ashe_counter += 1;

                }
                else
                {
                    mana_counter += (mana_r2 * r_counter) + mana_oh;
                }

                if (mana_counter >= max_mana)
                {
                    cast_flag = true;
                    mana_counter -= max_mana; // overflow mana
                    cast_counter += 1;
                }






                time_s = time_e;
                time_e = time_e + atk_time;
                attack_counter += 1;
                attack_flag = true;





                return (time_s, time_e, cast_flag, mana_counter, asi, atk_time, attack_counter, rb_counter, mana_counter, ad, attack_flag, ap,
                        half_flag, cast_counter, cast_flag, ashe_counter);
            }

            private static (double, double, bool, double, double, double, int, int, double, double, bool, double, bool, int, bool, double, double)
                Voli_Attack_event(double time_s, double time_e, double atk_time, double base_a, double mana_r, double max_mana, double mana_counter,
                                double mana_oh, double asi, int attack_counter, int rb_counter, double ad,
                                double rb_flag, double kraken_flag, double aa_flag, double ap,
                                bool half_flag, int cast_counter, bool cast_flag, double spell_start, double voli_atks
                )
            {

                double tsf = Math.Floor(time_s);
                double tef = Math.Floor(time_e);


                double loop_amount = tef - tsf;




                bool attack_flag = false;

                //mana_counter += mana_oh;

                double mana_r2 = mana_r / 2;

                double r_counter = 0;

                bool aa_check = false;



                r_counter = Mana_Regen_Counter(time_s, time_e);

                if (cast_flag && ((time_s - spell_start) >= 5))
                {
                    cast_flag = false;


                }

                if (aa_flag > 0)
                {
                    aa_check = AA_Counter(time_s, time_e);
                    if (aa_check)
                    {
                        ap += .3 * aa_flag;
                    }
                }

                if ((tsf < 15) && (tef >= 15))
                {

                    half_flag = true;
                }
                else half_flag = false;


                // rage blade
                if (rb_flag > 0)
                {
                    for (int i = 0; i < loop_amount; i++)
                    {
                        asi += .07 * rb_flag;
                        rb_counter += 1;
                        atk_time = Attack_Time_calc(base_a, asi + voli_atks);
                    }
                }

                // mana regen during auto event



                if (kraken_flag > 0)
                {
                    ad += .03 * kraken_flag;
                }



                if (cast_flag) // mana lock
                {


                    voli_atks = .99;
                    atk_time = Attack_Time_calc(base_a, asi + voli_atks);

                }
                else
                {
                    mana_counter += (mana_r2 * r_counter) + mana_oh;
                    voli_atks = 0;
                    atk_time = Attack_Time_calc(base_a, asi + voli_atks);
                }

                if (mana_counter >= max_mana)
                {
                    cast_flag = true;
                    mana_counter -= max_mana; // overflow mana
                    voli_atks = .99;
                    atk_time = Attack_Time_calc(base_a, asi + voli_atks);
                    spell_start = time_e;
                    cast_counter += 1;
                }






                time_s = time_e;
                time_e = time_e + atk_time;
                attack_counter += 1;
                attack_flag = true;





                return (time_s, time_e, cast_flag, mana_counter, asi, atk_time, attack_counter, rb_counter, mana_counter, ad, attack_flag, ap,
                        half_flag, cast_counter, cast_flag, spell_start, voli_atks);
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

            private static (double, double, int, double, double, bool) Base_Cast_event(double time_s, double time_e, int cast_counter,
                            double atk_time, double aa_flag, double ap, double rb_flag, double asi, double base_a, double cast_time,
                            bool half_flag)
            {

                //double cast_time = 1;

                double time_s_floor = 0;
                double time_e_floor = 0;

                double loop_amount = 0;
                bool aa_check = false;

                //time_s = time_s;
                time_e = time_s + cast_time;


                time_s_floor = Math.Floor(time_s);

                time_e_floor = Math.Floor(time_e);

                loop_amount = time_e_floor - time_s_floor;

                if ((time_s_floor < 15) && (time_e_floor >= 15))
                {

                    half_flag = true;
                }
                else half_flag = false;

                if (aa_flag > 0)
                {
                    aa_check = AA_Counter(time_s, time_e);
                    if (aa_check)
                    {
                        ap += .3 * aa_flag;
                    }
                }

                // rage blade
                if (rb_flag > 0)
                {
                    for (int i = 0; i < loop_amount; i++)
                    {
                        asi += .07 * rb_flag;
                        //rb_counter += 1;
                        atk_time = Attack_Time_calc(base_a, asi);
                    }
                }

                time_s = time_e;
                time_e = time_s + atk_time;

                cast_counter += 1;

                return (time_s, time_e, cast_counter, ap, asi, half_flag);
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

            private static double Auto_Damage_Calc(double crit, double crit_multi, double base_ad, double inc_ad, double amp)
            {
                double final_crit = 1 + (crit * crit_multi);

                return base_ad * (1 + inc_ad) * final_crit * (1 + amp);

            }

            // SPELL DAMAGE CALCS

            private static double Jinx_Spell_Damage_Calc(double crit, double crit_multi, double ad, double amp, double crit_flag, string star)
            { // passive attack speed and cap handled in attack event
                double final_crit = 1;
                double base_damage = 0;
                double base_damage2 = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                return (base_damage + base_damage2) * (1 + ad) * final_crit * (1 + amp);

            }
            private static double Samira_Spell_Damage_Calc(double crit, double crit_multi, double inc_ad, double ap, double amp,
                                                            double crit_flag, string star, int style)
            {
                double final_crit = 1;
                double base_damage = 0;
                double ap_base_damage = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                if (style < 4)
                {
                    ap_base_damage = 0;
                    switch (star)
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
                    switch (star)
                    {
                        case "1":
                            base_damage = 310;
                            ap_base_damage = 50;
                            break;
                        case "2":
                            base_damage = 465;
                            ap_base_damage = 75;
                            break;
                        case "3":
                            base_damage = 2200;
                            ap_base_damage = 225;
                            break;
                        default: break;
                    }
                }


                return ((base_damage * (1 + inc_ad)) + (ap_base_damage * (1 + ap))) * final_crit * (1 + amp);

            }

            private static (double, double) Yuumi_Spell_Damage_Calc(double crit, double crit_multi, double ap, double amp,
                                                            double crit_flag, string star, double potential, int cast_tracker)
            {
                double final_crit = 1;
                double base_damage = 0;

                double page_counter = 15 + (5 * cast_tracker);

                double pot_page_counter = page_counter / 5;

                double final_damage = 0;

                int true_damage_i = 0;

                double true_damage_f = 0;


                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
                {
                    case "1":
                        base_damage = 26;
                        break;
                    case "2":
                        base_damage = 39;
                        break;
                    case "3":
                        base_damage = 150;
                        break;
                    default: break;
                }

                final_damage = base_damage * (1 + ap);

                //true_damage_i = 

                //return (final_damage * page_counter * final_crit * (1 + amp), final_damage * pot_page_counter * potential * .32 * final_crit * (1 + amp));
                return (final_damage * page_counter * final_crit * (1 + amp), final_damage * pot_page_counter * potential * .32 * final_crit * (1 + amp));

            }

            private static double Ksante_Spell_Damage_Calc(double crit, double crit_multi, double amp,
                                                            double crit_flag, string star, double armor, double mr)
            {
                double final_crit = 1;
                double base_damage = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                return (armor + mr) * base_damage * final_crit * (1 + amp);

            }

            private static double Allout_Spell_Damage_Calc(double crit, double crit_multi, double inc_ad, double ap, double amp,
                                                            double crit_flag, string star)
            {
                double final_crit = 1;
                double base_damage = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                return base_damage * (1 + inc_ad) * final_crit * (1 + amp);

            }

            private static double Ashe_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double inc_ad, double asi, double ap)
            { // the spell lasts for 8 auto attacks, 0 cast time
                double final_crit = 1;
                double base_damage = 0;
                double ap_base_damage = 0;
                double base_final = 0;
                double ap_base_final = 0;
                double arrows = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                base_final = base_damage * (1 + inc_ad);
                ap_base_final = ap_base_damage * (1 + ap);
                arrows = 8 + Math.Floor(asi * 100 / 34.5);

                return (base_final + ap_base_final) * arrows * final_crit * (1 + amp);

            }

            private static double Voli_Spell_Damage_Calc(string star, double amp, double crit, double crit_multi, double ad)

            { // omni and asi is built into voli attack event
                double final_crit = 1;

                double base_damage = 0;

                final_crit = 1 + (crit * crit_multi);

                switch (star)
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



                return base_damage * final_crit * (1 + amp) * (1 + ad);

            }

            private static double Ryze_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double ap, double targets)
            { // targets are # of units hit around the target, single target scenario targets = 0
              // maybe make a single target dps output later
                double final_crit = 1;
                double base_damage = 0;
                double base_damage2 = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
                {
                    case "1":
                        base_damage = 720;
                        base_damage2 = 110;
                        break;
                    case "2":
                        base_damage = 1080;
                        base_damage2 = 165;
                        break;
                    case "3":
                        base_damage = 6000;
                        base_damage2 = 550;
                        break;
                    default: break;
                }

                return (base_damage2 * targets * (1 + ap) * final_crit * (1 + amp)) + (base_damage * (1 + ap) * final_crit * (1 + amp));

            }

            private static double Karma_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double ap)
            {
                double final_crit = 1;
                double base_damage = 0;


                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
                {
                    case "1":
                        base_damage = 1050;
                        break;
                    case "2":
                        base_damage = 1575;
                        break;
                    case "3":
                        base_damage = 6500;
                        break;
                    default: break;
                }

                return base_damage * (1 + ap) * final_crit * (1 + amp);

            }

            private static double Jarvan_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double ap)
            {
                double final_crit = 1;
                double base_damage = 0;


                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                return base_damage * (1 + ap) * final_crit * (1 + amp);

            }

            private static double Akali_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double ap, double targets, int cast_counter)
            {
                double final_crit = 1;
                double base_damage = 0;
                double base_damage2 = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
                {
                    case "1":
                        base_damage = 80;
                        base_damage2 = 60;
                        break;
                    case "2":
                        base_damage = 120;
                        base_damage2 = 90;
                        break;
                    case "3":
                        base_damage = 1000;
                        base_damage2 = 1000;
                        break;
                    default: break;
                }

                return (base_damage2 * targets * (1 + ap) * final_crit * (1 + amp)) + (base_damage * (1 + ap) * final_crit * (1 + amp)) * cast_counter;

            }

            private static double Poppy_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double ad, double targets, double hp)
            { // targets are # of units hit around the target, single target scenario targets = 0
              // maybe make a single target dps output later
                double final_crit = 1;
                double base_damage = 0;
                double base_damage2 = 0;

                double primary = 0;
                double secondary = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                primary = ((base_damage * (1 + ad)) + (hp * .1));
                secondary = (((base_damage2 * (1 + ad)) + (hp * .05)) * targets);



                return (primary + secondary) * final_crit * (1 + amp);

            }

            private static double Sett_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                        double ad, double targets, double hp, double healing)
            { // targets are # of units hit around the target, single target scenario targets = 0
              // maybe make a single target dps output later
                double final_crit = 1;
                double base_damage = 0;
                double base_damage2 = 0;
                double base_damage3 = 0;

                double primary = 0;
                double secondary = 0;
                double tertiary = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
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

                primary = base_damage * (1 + ad);
                secondary = (((base_damage2 * (1 + ad)) + (hp * .04) + (base_damage3)) + (base_damage3 + (15 * healing / 100)));
                tertiary = (((base_damage2 * (1 + ad)) + (hp * .04)) * targets);

                return (primary + secondary + tertiary) * final_crit * (1 + amp);

            }

            private static double Leona_Spell_Damage_Calc(double crit, double crit_multi, double amp, double crit_flag, string star,
                                                       double targets, double armor, double mr)
            { // targets are # of units hit around the target, single target scenario targets = 0
              // maybe make a single target dps output later
                double final_crit = 1;
                double base_damage = 0;
                double base_damage2 = 0;

                double primary = 0;
                double secondary = 0;

                if (crit_flag > 0)
                {
                    final_crit = 1 + (crit * crit_multi);
                }

                switch (star)
                {
                    case "1":
                        base_damage = (armor + mr) * .50;
                        base_damage2 = (armor + mr) * .25;
                        break;
                    case "2":
                        base_damage = (armor + mr) * .75;
                        base_damage2 = (armor + mr) * 40;
                        break;
                    case "3":
                        base_damage = (armor + mr) * 500;
                        base_damage2 = (armor + mr) * 200;
                        break;
                    default: break;
                }

                return (base_damage + base_damage2) * final_crit * (1 + amp);

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

            public List<string>
            Sort_Item_List(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                            Aug_Holder Aug1_Slot, Aug_Holder Aug2_Slot, Aug_Holder Aug3_Slot,
                            string unit, string star, int slot, bool full, double outside_full_dps, double outside_full_dps15,
                            Trait_Holder traits, bool enable
            )
            {

                List<Item_DPS_Obj> DPS_list = new();
                List<string> out_list = new()
            {
                "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
                "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
                "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
                "0",  "0",  "0",  "0",  "0",  "0"
            };
                if (enable)
                {

                    DPS_list = Item_DPS_Compare_Calc(uobj, item1, item2, item3, Aug1_Slot, Aug2_Slot, Aug3_Slot, unit, star, slot, full, outside_full_dps, outside_full_dps15, traits);


                    //list1[0] = list1[0] + number.ToString();

                    out_list = Combine_List(DPS_list);

                }

                //return item_list;
                return out_list;
            }

            private List<Item_DPS_Obj>
            Item_DPS_Compare_Calc(Unit_Holder uobj, Item_Holder item1, Item_Holder item2, Item_Holder item3,
                            Aug_Holder aug1, Aug_Holder aug2, Aug_Holder aug3,
                            string unit, string star, int slot, bool full, double outside_full_dps, double outside_full_dps15,
                            Trait_Holder traits
            )
            {
                //List<Item_Holder> list_int = Create_Item_List();

                List<Item_Holder> list_int = Create_Item_List();

                //DPS_Display disp_int = new();

                //CopyProperties(disp,disp_int);

                //Unit_Stats_Display stats_int = new();


                //double final_dps = disp.FINAL_DPS;
                //double final_dps15 = disp.FINAL_DPS15;

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
                //Item_DPS_Obj None_o = new(); SteadfastHeart_o.ITEM_NAME = "None           ";

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
                SteadfastHeart_o
            };


                //(DPS_Display1.AUTO_DPS, DPS_Display1.CAST_DPS, DPS_Display1.FINAL_DPS, DPS_Display1.ATTACK_COUNTER, DPS_Display1.CAST_COUNTER, DPS_Display1.BREAK_COUNTER,
                //  DPS_Display1.AD, DPS_Display1.ATKS, DPS_Display1.FINAL_ATKS, DPS_Display1.D_AMP, DPS_Display1.CRIT, DPS_Display1.FINAL_AD, DPS_Display1.CRIT_FLAG
                // , DPS_Display1.AP, DPS_Display1.P_CAST_DPS
                //  ) =

                //CopyProperties(item_list2[34],Item_Blank);


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

                        for (int i = 0; i < 36; i++)
                        {
                            if (full)
                            {
                                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                                auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                                inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen) =
                                Combat_Method(uobj, list_int[i], item2, item3, aug1, aug2, aug3, star, unit, traits);
                                //item_list[i].ITEM_DPS = full_dps;

                                //item_list[i].ITEM_DPS = outside_full_dps;

                                item_list[i].ITEM_DPS = Resolve_DPS_Change(outside_full_dps, full_dps);

                                //(disp_int, stats_int) = FightSim(Unit_Name, list_int[i], list_int[item2_i], list_int[item3_i], Aug1_Slot, Aug2_Slot, Aug3_Slot, disp_int, stats, star, unit);
                                //item_list[i].ITEM_DPS = Resolve_DPS_Change(final_dps, disp_int.FINAL_DPS);
                            }
                            else
                            {
                                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                                auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                                inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen) =
                                Combat_Method(uobj, list_int[i], item2, item3, aug1, aug2, aug3, star, unit, traits);
                                item_list[i].ITEM_DPS = Resolve_DPS_Change(outside_full_dps15, full_dps15);

                            }


                        }
                        //CopyProperties(item_list2[i], Item_Blank);



                        break;


                    case 2:
                        for (int i = 0; i < 36; i++)
                        {
                            if (full)
                            {
                                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                                auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                                inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen) =
                                Combat_Method(uobj, item1, list_int[i], item3, aug1, aug2, aug3, star, unit, traits);
                                item_list[i].ITEM_DPS = Resolve_DPS_Change(outside_full_dps, full_dps);

                                //(disp_int, stats_int) = FightSim(Unit_Name, list_int[i], list_int[item2_i], list_int[item3_i], Aug1_Slot, Aug2_Slot, Aug3_Slot, disp_int, stats, star, unit);
                                //item_list[i].ITEM_DPS = Resolve_DPS_Change(final_dps, disp_int.FINAL_DPS);
                            }
                            else
                            {
                                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                                auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                                inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen) =
                                Combat_Method(uobj, item1, list_int[i], item3, aug1, aug2, aug3, star, unit, traits);
                                item_list[i].ITEM_DPS = Resolve_DPS_Change(outside_full_dps15, full_dps15);
                            }


                        }

                        break;
                    case 3:
                        for (int i = 0; i < 36; i++)
                        {
                            if (full)
                            {
                                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                                auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                                inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen) =
                                Combat_Method(uobj, item1, item2, list_int[i], aug1, aug2, aug3, star, unit, traits);
                                item_list[i].ITEM_DPS = Resolve_DPS_Change(outside_full_dps, full_dps);

                                //(disp_int, stats_int) = FightSim(Unit_Name, list_int[i], list_int[item2_i], list_int[item3_i], Aug1_Slot, Aug2_Slot, Aug3_Slot, disp_int, stats, star, unit);
                                //item_list[i].ITEM_DPS = Resolve_DPS_Change(final_dps, disp_int.FINAL_DPS);
                            }
                            else
                            {
                                (auto_dps, cast_dps, phys_cast_dps, true_damage_dps, full_dps, attack_counter, cast_counter,
                                auto_dps15, cast_dps15, phys_cast_dps15, true_damage_dps15, full_dps15, attack_counter15, cast_counter15,
                                inc_ad, crit, crit_multi, asi, amp, omnivamp, mana_hit, ap, crit_flag, mana_regen) =
                                Combat_Method(uobj, item1, item2, list_int[i], aug1, aug2, aug3, star, unit, traits);
                                item_list[i].ITEM_DPS = Resolve_DPS_Change(outside_full_dps15, full_dps15);
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
                    diff = 100;
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

            private static List<string> Combine_List(List<Item_DPS_Obj> list1)
            {
                //list1[0] = list1[0] + "test";
                List<string> out_list = new()
            {
                "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
                "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
                "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",
                "0",  "0",  "0",  "0",  "0",  "0"
            };
                for (int i = 0; i < 36; i++)
                {
                    if (list1[i].ITEM_DPS > 0)
                    {
                        out_list[i] = list1[i].ITEM_NAME + " +" + list1[i].ITEM_DPS.ToString() + "%";
                    }
                    else
                    {
                        out_list[i] = list1[i].ITEM_NAME + " " + list1[i].ITEM_DPS.ToString() + "%";
                    }

                }

                //list1[0] = list1[0] + "test";

                return out_list;
            }

           public (int, int) 
                Combat_Wrapper(string unit, string star, string item1, string item2, string item3)
            {
                int attack_counter = 0;
                int cast_counter = 0;

                Unit_Holder uobj = new();
                Item_Holder iobj1 = new();
                Item_Holder iobj2 = new();
                Item_Holder iobj3 = new();
                Aug_Holder aobj1 = new();
                Aug_Holder aobj2 = new();
                Aug_Holder aobj3 = new();
                Trait_Holder tobj = new();

                Unit_Stat_Setter(uobj, unit, star);

                Item_Stat_Setter(iobj1, item1);
                Item_Stat_Setter(iobj2, item2);
                Item_Stat_Setter(iobj3, item3);

                (attack_counter, cast_counter) = FightSim(uobj, iobj1, iobj2, iobj3, aobj1, aobj2, aobj3, star, unit, tobj);
                return (attack_counter, cast_counter);
            }

            private static void Item_Stat_Setter(Item_Holder iobj, string item)
            {
                switch (item)
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
                        iobj.D_AMP = .1;
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
                        iobj.CRIT_FLAG = 1;
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
                        iobj.ARMOR = 20;
                        iobj.MR = 0;
                        iobj.AP = 0;
                        iobj.AD = 0;
                        iobj.ATKS = .1;
                        iobj.TITANS_FLAG = 1;
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
                    case "DeathCap":
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
                        iobj.CRIT_FLAG = 1;
                        break;
                    case "HandOfJustice":
                        iobj.MANA_REGEN = 1;
                        iobj.AP = .15;
                        iobj.AD = .15;
                        iobj.CRIT = .2;
                        iobj.OMNIVAMP = .12;
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

            private static void Unit_Stat_Setter(Unit_Holder uobj, string unit, string star)
            {
                int i = 0;
                switch (unit)
                {
                    case "No_Unit":

                        break;

                    case "Jinx":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 850; uobj.MAX_MANA = 80; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 70;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Sniper"; uobj.TRAIT2 = "Starguardian";
                                break;
                            case "2":
                                uobj.HP = 1530; uobj.MAX_MANA = 80; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 105;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Sniper"; uobj.TRAIT2 = "Starguardian";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;

                    case "Karma":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 850; uobj.MAX_MANA = 70; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 40;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Mighty Mech"; uobj.TRAIT2 = "Sorcerer";
                                break;
                            case "2":
                                uobj.HP = 1530; uobj.MAX_MANA = 70; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 70;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Mighty Mech"; uobj.TRAIT2 = "Sorcerer";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Ryze":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1000; uobj.MAX_MANA = 60; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 50;
                                uobj.ATKS = .8; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Mentor"; uobj.TRAIT2 = "Strategist"; uobj.TRAIT3 = "Executioner";
                                break;
                            case "2":
                                uobj.HP = 1530; uobj.MAX_MANA = 60; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 75;
                                uobj.ATKS = .8; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Mentor"; uobj.TRAIT2 = "Strategist"; uobj.TRAIT3 = "Executioner";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Yuumi":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 850; uobj.MAX_MANA = 40; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 40;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Prodigy"; uobj.TRAIT2 = "Battle Academia";
                                break;
                            case "2":
                                uobj.HP = 1530; uobj.MAX_MANA = 40; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 60;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Prodigy"; uobj.TRAIT2 = "Battle Academia";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Ashe":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1000; uobj.MAX_MANA = 80; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 60;
                                uobj.ATKS = .8; uobj.MANA_OH = 10;
                                uobj.TRAIT1 = "Crystal Gambit"; uobj.TRAIT2 = "Duelist";
                                break;
                            case "2":
                                uobj.HP = 1530; uobj.MAX_MANA = 80; uobj.ARMOR = 35; uobj.MR = 35; uobj.AD = 90;
                                uobj.ATKS = .8; uobj.MANA_OH = 10;
                                uobj.TRAIT1 = "Crystal Gambit"; uobj.TRAIT2 = "Duelist";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Samira":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 850; uobj.MAX_MANA = 15; uobj.ARMOR = 45; uobj.MR = 45; uobj.AD = 50;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Edgelord"; uobj.TRAIT2 = "Soul Fighter";
                                break;
                            case "2":
                                uobj.HP = 1530; uobj.MAX_MANA = 15; uobj.ARMOR = 45; uobj.MR = 45; uobj.AD = 75;
                                uobj.ATKS = .75; uobj.MANA_OH = 7; uobj.MANA_REGEN = 2;
                                uobj.TRAIT1 = "Edgelord"; uobj.TRAIT2 = "Soul Fighter";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Jarvan":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1100; uobj.MAX_MANA = 150; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 60;
                                uobj.ATKS = .65; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Mighty Mech"; uobj.TRAIT2 = "Strategist";
                                break;
                            case "2":
                                uobj.HP = 1980; uobj.MAX_MANA = 150; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 90;
                                uobj.ATKS = .65; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Mighty Mech"; uobj.TRAIT2 = "Strategist";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Ksante":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1000; uobj.MAX_MANA = 90; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 60;
                                uobj.ATKS = .7; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Protector"; uobj.TRAIT2 = "Wraith";
                                break;
                            case "2":
                                uobj.HP = 1800; uobj.MAX_MANA = 90; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 90;
                                uobj.ATKS = .7; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Protector"; uobj.TRAIT2 = "Wraith";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Leona":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1200; uobj.MAX_MANA = 100; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 60;
                                uobj.ATKS = .6; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Bastion"; uobj.TRAIT2 = "Battle Academia";
                                break;
                            case "2":
                                uobj.HP = 2160; uobj.MAX_MANA = 100; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 90;
                                uobj.ATKS = .6; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Bastion"; uobj.TRAIT2 = "Battle Academia";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Poppy":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1100; uobj.MAX_MANA = 105; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 65;
                                uobj.ATKS = .6; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Heavyweight"; uobj.TRAIT2 = "Star Guardian";
                                break;
                            case "2":
                                uobj.HP = 1980; uobj.MAX_MANA = 105; uobj.ARMOR = 60; uobj.MR = 60; uobj.AD = 97;
                                uobj.ATKS = .6; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Heavyweight"; uobj.TRAIT2 = "Star Guardian";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Sett":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1100; uobj.MAX_MANA = 100; uobj.ARMOR = 50; uobj.MR = 50; uobj.AD = 60;
                                uobj.ATKS = .7; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Juggernaut"; uobj.TRAIT2 = "Soul Fighter";
                                break;
                            case "2":
                                uobj.HP = 1980; uobj.MAX_MANA = 100; uobj.ARMOR = 50; uobj.MR = 50; uobj.AD = 90;
                                uobj.ATKS = .7; uobj.MANA_OH = 5;
                                uobj.TRAIT1 = "Juggernaut"; uobj.TRAIT2 = "Soul Fighter";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Volibear":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1050; uobj.MAX_MANA = 40; uobj.ARMOR = 65; uobj.MR = 65; uobj.AD = 65;
                                uobj.ATKS = .9; uobj.MANA_OH = 10; uobj.OMNIVAMP = .1;
                                uobj.TRAIT1 = "EdgeLord"; uobj.TRAIT2 = "Luchador";
                                break;
                            case "2":
                                uobj.HP = 1890; uobj.MAX_MANA = 40; uobj.ARMOR = 65; uobj.MR = 65; uobj.AD = 97;
                                uobj.ATKS = .9; uobj.MANA_OH = 10; uobj.OMNIVAMP = .1;
                                uobj.TRAIT1 = "EdgeLord"; uobj.TRAIT2 = "Luchador";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;
                    case "Akali":
                        switch (star)
                        {
                            case "1":
                                uobj.HP = 1050; uobj.MAX_MANA = 30; uobj.ARMOR = 65; uobj.MR = 65; uobj.AD = 30;
                                uobj.ATKS = .85; uobj.MANA_OH = 10;
                                uobj.TRAIT1 = "Executioner"; uobj.TRAIT2 = "Supreme Cells";
                                break;
                            case "2":
                                uobj.HP = 1990; uobj.MAX_MANA = 30; uobj.ARMOR = 65; uobj.MR = 65; uobj.AD = 45;
                                uobj.ATKS = .85; uobj.MANA_OH = 10;
                                uobj.TRAIT1 = "Executioner"; uobj.TRAIT2 = "Supreme Cells";
                                break;
                            case "3":
                                break;

                            default: break;
                        }
                        break;

                    default: break;
                }
            }

            private static int Unit_Selector(string unit)
            { 
                int i = 0;
                switch (unit)
                {
                    case "No_Unit":

                        break;

                    case "Jinx":
                        i = 1;
                        break;

                    case "Karma":
                        i = 2;
                        break;
                    case "Ryze":
                        i = 3;
                        break;
                    case "Yuumi":
                        i = 4;
                        break;
                    case "Ashe":
                        i = 5;
                        break;
                    case "Samira":
                        i = 6;
                        break;
                    case "Jarvan":
                        i = 7;
                        break;
                    case "Ksante":
                        i = 8;
                        break;
                    case "Leona":
                        i = 9;
                        break;
                    case "Poppy":
                        i = 10;
                        break;
                    case "Sett":
                        i = 11;
                        break;
                    case "Volibear":
                        i = 12;
                        break;
                    case "Akali":
                        i = 13;
                        break;

                    default: break;
                }

                return i;
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
                Item_Holder DeathCap = new();
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


                Deathblade.AD = .55;
                Deathblade.D_AMP = .1;

                Giantslayer.AP = .2;
                Giantslayer.AD = .2;
                Giantslayer.ATKS = .2;
                Giantslayer.D_AMP = .1;
                Giantslayer.GS_FLAG = 1;

                Gunblade.MANA_REGEN = 1;
                Gunblade.AP = .2;
                Gunblade.AD = .2;
                Gunblade.OMNIVAMP = .18;

                Shojin.MANA_REGEN = 1;
                Shojin.AP = .15;
                Shojin.AD = .15;
                Shojin.MANA_OH = 5;

                EdgeOfNight.AP = .1;
                EdgeOfNight.AD = .1;
                EdgeOfNight.ATKS = .15;

                BloodThirster.ARMOR = 20;
                BloodThirster.MR = 20;
                BloodThirster.DR = 0;
                BloodThirster.SHIELD = .25;

                BloodThirster.AP = .15;
                BloodThirster.AD = .15;
                BloodThirster.OMNIVAMP = .2;


                Steraks.HP = 300;
                Steraks.SHIELD = .5;
                Steraks.AD = .4;

                InfinityEdge.AD = .35;
                InfinityEdge.CRIT = .35;
                InfinityEdge.CRIT_FLAG = 1;

                Redbuff.ATKS = .4;
                Redbuff.D_AMP = .06;
                Redbuff.ANTIHEAL = 1;

                Rageblade.AP = .1;
                Rageblade.ATKS = .1;
                Rageblade.RB_FLAG = 1;

                VoidStaff.AP = .35;
                VoidStaff.MANA_REGEN = 1;
                VoidStaff.ATKS = .15;
                VoidStaff.SHRED = 1;

                Titans.ARMOR = 20;
                Titans.MR = 0;
                Titans.AP = 0;
                Titans.AD = 0;
                Titans.ATKS = .1;
                Titans.TITANS_FLAG = 1;

                Kraken.MR = 20;
                Kraken.AD = .15;
                Kraken.ATKS = .1;
                Kraken.KRAKEN_FLAG = 1;

                Nashor.HP = 150;
                Nashor.MANA_REGEN = 2;
                Nashor.AP = .2;
                Nashor.ATKS = .1;
                Nashor.NASHORS_FLAG = 1;

                LastWhisper.AD = .15;
                LastWhisper.CRIT = .2;
                LastWhisper.ATKS = .2;
                LastWhisper.SUNDER = 1;

                DeathCap.AP = .5;
                DeathCap.D_AMP = .15;

                Archangels.MANA_REGEN = 1;
                Archangels.AP = .2;
                Archangels.AA_FLAG = 1;

                Morello.HP = 150;
                Morello.MANA_REGEN = 1;
                Morello.AP = .2;
                Morello.ANTIHEAL = 1;

                JeweledGauntlet.AP = .35;
                JeweledGauntlet.CRIT = .35;
                JeweledGauntlet.CRIT_FLAG = 1;

                HandOfJustice.MANA_REGEN = 1;
                HandOfJustice.AP = .15;
                HandOfJustice.AD = .15;
                HandOfJustice.CRIT = .2;
                HandOfJustice.OMNIVAMP = .12;

                BlueBuff.MANA_REGEN = 5;
                BlueBuff.AP = .15;
                BlueBuff.AD = .15;

                QuickSilver.MR = 20;
                QuickSilver.CRIT = .2;
                QuickSilver.ATKS = .3;

                StrikersFlail.HP = 150;
                StrikersFlail.CRIT = .2;
                StrikersFlail.ATKS = .2;
                StrikersFlail.D_AMP = .3;

                Warmogs.HP = 600;
                Warmogs.HP_MULT = .12;

                Sunfire.HP = 150;
                Sunfire.ARMOR = 20;
                Sunfire.ANTIHEAL = 1;

                SpiritVisage.HP = 300;
                SpiritVisage.DR = .1;
                SpiritVisage.MANA_REGEN = 1;

                EvenShroud.HP = 150;
                EvenShroud.ARMOR = 20;
                EvenShroud.MR = 40;
                EvenShroud.SUNDER = 1;

                Spark.HP = 150;
                Spark.MR = 25;
                Spark.AP = .15;
                Spark.SHRED = 1;

                AdaptiveFront.ARMOR = 35;
                AdaptiveFront.MR = 55;
                AdaptiveFront.MANA_REGEN = 2;

                AdaptiveBack.MR = 20;
                AdaptiveBack.MANA_REGEN = 2;
                AdaptiveBack.AP = .15;
                AdaptiveBack.AD = .15;
                AdaptiveBack.MANA_MULT = .15;

                Stoneplate.HP = 100;
                Stoneplate.ARMOR = 25;
                Stoneplate.MR = 25;

                DragonClaw.HP_MULT = .09;
                DragonClaw.MR = 75;

                Bramble.HP_MULT = .07;
                Bramble.ARMOR = 65;
                Bramble.AUTO_DR = .08;

                ProtectorsVow.ARMOR = 25;
                ProtectorsVow.MR = 25;
                ProtectorsVow.SHIELD = .4;
                ProtectorsVow.MANA_REGEN = 1;

                Crownguard.HP = 100;
                Crownguard.ARMOR = 20;
                Crownguard.SHIELD = .25;
                Crownguard.AP = .45;

                SteadfastHeart.HP = 250;
                SteadfastHeart.ARMOR = 20;
                SteadfastHeart.DR = .14;
                SteadfastHeart.CRIT = .2;


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
                DeathCap,
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

        }

        public class View_Model_Methods
        {

        }

        public class Item_Holder_List
        {

        }





        public class DPS_Display : INotifyPropertyChanged
        {

            double auto_dps = 0;
            double cast_dps = 0;
            double p_cast_dps = 0;
            double final_dps = 0;
            double auto_damage_tracker;
            double cast_damage_tracker;
            double true_damage_tracker;
            double true_damage_dps = 0;

            double auto_dps15 = 0;
            double cast_dps15 = 0;
            double p_cast_dps15 = 0;
            double final_dps15 = 0;
            double true_damage_dps15 = 0;

            double trait1_value = 0;
            double trait2_value = 0;
            double trait3_value = 0;

            int attack_counter = 0;
            int cast_counter = 0;

            int attack_counter15 = 0;
            int cast_counter15 = 0;

            int break_counter = 0;

            string trait1 = "none";
            string trait2 = "none";
            string trait3 = "none";

            double mana_counter = 0;

            double final_atks = 0;

            double final_ad = 0;

            double phys_EHP = 0;
            double magic_EHP = 0;
            double final_hp = 0;
            double final_phys_dr = 0;
            double final_magic_dr = 0;

            double crit_flag = 0;

            List<string> item_list = new()
            {
                "None",
                "Deathblade",
                "Giantslayer",
                "Gunblade",
                "Shojin",
                "EdgeOfNight",
                "BloodThirster",
                "Steraks",
                "InfinityEdge",
                "Redbuff",
                "Rageblade",
                "VoidStaff",
                "Titans",
                "Kraken",
                "Nashor",
                "LastWhisper",
                "DeathCap",
                "Archangels",
                "Morello",
                "JeweledGauntlet",
                "HandOfJustice",
                "BlueBuff",
                "QuickSilver",
                "StrikersFlail",
                "Warmogs",
                "Sunfire",
                "SpiritVisage",
                "EvenShroud",
                "Spark",
                "AdaptiveFront",
                "Stoneplate",
                "DragonClaw",
                "Bramble",
                "ProtectorsVow",
                "Crownguard",
                "SteadfastHeart"
            };

            List<string> item_list2 = new()
            {
                "None",
                "Deathblade",
                "Giantslayer",
                "Gunblade",
                "Shojin",
                "EdgeOfNight",
                "BloodThirster",
                "Steraks",
                "InfinityEdge",
                "Redbuff",
                "Rageblade",
                "VoidStaff",
                "Titans",
                "Kraken",
                "Nashor",
                "LastWhisper",
                "DeathCap",
                "Archangels",
                "Morello",
                "JeweledGauntlet",
                "HandOfJustice",
                "BlueBuff",
                "QuickSilver",
                "StrikersFlail",
                "Warmogs",
                "Sunfire",
                "SpiritVisage",
                "EvenShroud",
                "Spark",
                "AdaptiveFront",
                "Stoneplate",
                "DragonClaw",
                "Bramble",
                "ProtectorsVow",
                "Crownguard",
                "SteadfastHeart"
            };

            List<string> item_list3 = new()
            {
                "None",
                "Deathblade",
                "Giantslayer",
                "Gunblade",
                "Shojin",
                "EdgeOfNight",
                "BloodThirster",
                "Steraks",
                "InfinityEdge",
                "Redbuff",
                "Rageblade",
                "VoidStaff",
                "Titans",
                "Kraken",
                "Nashor",
                "LastWhisper",
                "DeathCap",
                "Archangels",
                "Morello",
                "JeweledGauntlet",
                "HandOfJustice",
                "BlueBuff",
                "QuickSilver",
                "StrikersFlail",
                "Warmogs",
                "Sunfire",
                "SpiritVisage",
                "EvenShroud",
                "Spark",
                "AdaptiveFront",
                "Stoneplate",
                "DragonClaw",
                "Bramble",
                "ProtectorsVow",
                "Crownguard",
                "SteadfastHeart"
            };

            //test_list[] = {"one","two"};


            double ts1 = 0, ts2 = 0, ts3 = 0, ts4 = 0, ts5 = 0, ts6 = 0, ts7 = 0, ts8 = 0, ts9 = 0, ts10 = 0, ts11 = 0, ts12 = 0, ts13 = 0, ts14 = 0, ts15 = 0, ts16 = 0;
            double te1 = 0, te2 = 0, te3 = 0, te4 = 0, te5 = 0, te6 = 0, te7 = 0, te8 = 0, te9 = 0, te10 = 0, te11 = 0, te12 = 0, te13 = 0, te14 = 0, te15 = 0, te16 = 0;

            public event PropertyChangedEventHandler PropertyChanged;

            public List<string> ITEM_LIST { get { return item_list; } set { item_list = value; OnPropertyChanged(); } }
            public List<string> ITEM_LIST2 { get { return item_list2; } set { item_list2 = value; OnPropertyChanged(); } }
            public List<string> ITEM_LIST3 { get { return item_list3; } set { item_list3 = value; OnPropertyChanged(); } }


            public double MANA_COUNTER { get { return mana_counter; } set { mana_counter = value; OnPropertyChanged(); } }
            public double FINAL_ATKS { get { return final_atks; } set { final_atks = value; OnPropertyChanged(); } }

            public double FINAL_AD { get { return final_ad; } set { final_ad = value; OnPropertyChanged(); } }

            public double PHYS_EHP { get { return phys_EHP; } set { phys_EHP = value; OnPropertyChanged(); } }
            public double MAGIC_EHP { get { return magic_EHP; } set { magic_EHP = value; OnPropertyChanged(); } }
            public double FINAL_HP { get { return final_hp; } set { final_hp = value; OnPropertyChanged(); } }
            public double FINAL_PHYS_DR { get { return final_phys_dr; } set { final_phys_dr = value; OnPropertyChanged(); } }
            public double FINAL_MAGIC_DR { get { return final_magic_dr; } set { final_magic_dr = value; OnPropertyChanged(); } }

            public double CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; OnPropertyChanged(); } }

            public double TRUE_DAMAGE_DPS { get { return true_damage_dps; } set { true_damage_dps = value; OnPropertyChanged(); } }

            public double TRUE_DAMAGE_DPS15 { get { return true_damage_dps15; } set { true_damage_dps15 = value; OnPropertyChanged(); } }

            public double P_CAST_DPS { get { return p_cast_dps; } set { p_cast_dps = value; OnPropertyChanged(); } }

            public double P_CAST_DPS15 { get { return p_cast_dps15; } set { p_cast_dps15 = value; OnPropertyChanged(); } }

            public int BREAK_COUNTER
            {
                get { return break_counter; }
                set
                {
                    break_counter = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }
            public int ATTACK_COUNTER
            {
                get { return attack_counter; }
                set
                {
                    attack_counter = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public int CAST_COUNTER
            {
                get { return cast_counter; }
                set
                {
                    cast_counter = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public int ATTACK_COUNTER15
            {
                get { return attack_counter15; }
                set
                {
                    attack_counter15 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public int CAST_COUNTER15
            {
                get { return cast_counter15; }
                set
                {
                    cast_counter15 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            /*
            public double AUTO_DAMAGE_TRACKER
            {
                get { return auto_damage_tracker; }
                set
                {
                    auto_damage_tracker = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double CAST_DAMAGE_TRACKER
            {
                get { return cast_damage_tracker; }
                set
                {
                    cast_damage_tracker = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }
            */

            public double AUTO_DPS
            {
                get { return auto_dps; }
                set
                {
                    auto_dps = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double CAST_DPS
            {
                get { return cast_dps; }
                set
                {
                    cast_dps = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double FINAL_DPS
            {
                get { return final_dps; }
                set
                {
                    final_dps = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double AUTO_DPS15
            {
                get { return auto_dps15; }
                set
                {
                    auto_dps15 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double CAST_DPS15
            {
                get { return cast_dps15; }
                set
                {
                    cast_dps15 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double FINAL_DPS15
            {
                get { return final_dps15; }
                set
                {
                    final_dps15 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double TRAIT1_VALUE
            {
                get { return trait1_value; }
                set
                {
                    trait1_value = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double TRAIT2_VALUE
            {
                get { return trait2_value; }
                set
                {
                    trait2_value = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public double TRAIT3_VALUE
            {
                get { return trait3_value; }
                set
                {
                    trait3_value = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public string TRAIT1
            {
                get { return trait1; }
                set
                {
                    trait1 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public string TRAIT2
            {
                get { return trait2; }
                set
                {
                    trait2 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            public string TRAIT3
            {
                get { return trait3; }
                set
                {
                    trait3 = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged();
                }
            }

            protected void OnPropertyChanged([CallerMemberName] string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }



        }

        public class Unit_Stats_Display : INotifyPropertyChanged
        {

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
            double crit_multi = 0;
            double atks = 0;
            double d_amp = 0;
            double omnivamp = 0;
            double mana_oh = 0;

            double final_atks = 0;

            double final_ad = 0;

            double phys_EHP = 0;
            double magic_EHP = 0;
            double final_hp = 0;
            double final_phys_dr = 0;
            double final_magic_dr = 0;

            double crit_flag = 0;


            string test = "hello";


            public event PropertyChangedEventHandler PropertyChanged;

            public string TEST { get { return test; } set { test = value; OnPropertyChanged(); } }

            public double HP { get { return hp; } set { hp = value; OnPropertyChanged(); } }
            public double HP_MULT { get { return hp_mult; } set { hp_mult = value; OnPropertyChanged(); } }
            public double ARMOR { get { return armor; } set { armor = value; OnPropertyChanged(); } }
            public double MR { get { return mr; } set { mr = value; OnPropertyChanged(); } }
            public double DR { get { return dr; } set { dr = value; OnPropertyChanged(); } }
            public double SHIELD { get { return shield; } set { shield = value; OnPropertyChanged(); } }
            public double MANA_REGEN { get { return mana_regen; } set { mana_regen = value; OnPropertyChanged(); } }
            public double AP { get { return ap; } set { ap = value; OnPropertyChanged(); } }
            public double AD { get { return ad; } set { ad = value; OnPropertyChanged(); } }
            public double CRIT { get { return crit; } set { crit = value; OnPropertyChanged(); } }
            public double CRIT_MULTI { get { return crit_multi; } set { crit_multi = value; OnPropertyChanged(); } }
            public double ATKS { get { return atks; } set { atks = value; OnPropertyChanged(); } }
            public double D_AMP { get { return d_amp; } set { d_amp = value; OnPropertyChanged(); } }
            public double OMNIVAMP { get { return omnivamp; } set { omnivamp = value; OnPropertyChanged(); } }
            public double MANA_OH { get { return mana_oh; } set { mana_oh = value; OnPropertyChanged(); } }

            public double FINAL_ATKS { get { return final_atks; } set { final_atks = value; OnPropertyChanged(); } }

            public double FINAL_AD { get { return final_ad; } set { final_ad = value; OnPropertyChanged(); } }

            public double PHYS_EHP { get { return phys_EHP; } set { phys_EHP = value; OnPropertyChanged(); } }
            public double MAGIC_EHP { get { return magic_EHP; } set { magic_EHP = value; OnPropertyChanged(); } }
            public double FINAL_HP { get { return final_hp; } set { final_hp = value; OnPropertyChanged(); } }
            public double FINAL_PHYS_DR { get { return final_phys_dr; } set { final_phys_dr = value; OnPropertyChanged(); } }
            public double FINAL_MAGIC_DR { get { return final_magic_dr; } set { final_magic_dr = value; OnPropertyChanged(); } }

            public double CRIT_FLAG { get { return crit_flag; } set { crit_flag = value; OnPropertyChanged(); } }




            protected void OnPropertyChanged([CallerMemberName] string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }



        }

        public class Item_DPS_Obj
        {
            string item_name = "none";

            double item_dps = 0;

            public string ITEM_NAME { get { return item_name; } set { item_name = value; } }

            public double ITEM_DPS { get { return item_dps; } set { item_dps = value; } }
        }

        public class Unit_Holder
        {
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
            string trait1 = "none";
            string trait2 = "none";
            string trait3 = "none";

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
            double nashors_flag = 0;
            double auto_dr = 0;
            double mana_mult = 0;

            public void Deathblade()
            {
                ad = 10;
            }

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
            public double NASHORS_FLAG { get { return nashors_flag; } set { nashors_flag = value; } }
            public double AUTO_DR { get { return auto_dr; } set { auto_dr = value; } }
            public double MANA_MULT { get { return mana_mult; } set { mana_mult = value; } }
        }


        public class Aug_Holder
        {
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
            string trait1 = "None";

            string trait2 = "None";

            string trait3 = "None";

            double trait1_value = 0;

            double trait2_value = 0;

            double trait3_value = 0;

            public string TRAIT1 { get { return trait1; } set { trait1 = value; } }
            public string TRAIT2 { get { return trait2; } set { trait2 = value; } }

            public string TRAIT3 { get { return trait3; } set { trait3 = value; } }
            public double TRAIT1_VALUE { get { return trait1_value; } set { trait1_value = value; } }

            public double TRAIT2_VALUE { get { return trait2_value; } set { trait2_value = value; } }

            public double TRAIT3_VALUE { get { return trait3_value; } set { trait3_value = value; } }

        }

        public class Fruit_Holder
        {
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
        }
    }
}
